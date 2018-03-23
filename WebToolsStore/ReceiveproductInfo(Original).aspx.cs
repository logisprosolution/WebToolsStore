using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections.Generic;

namespace WebToolsStore
{
    public partial class ReceiveproductInfo : BasePage
    {
        #region Parameter
        DocBiz biz = new DocBiz();
        const string CartList_SaveState = "CartList_SaveState";
        const string CartList_ShowState = "CartList_ShowState";
        public List<DOC_Detail> CartList_Save //ไว้สำหรับsave จะมี row ที่โดนลบด้วย
        {
            get
            {
                if (!(ViewState[CartList_SaveState] is List<DOC_Detail>))
                {
                    ViewState[CartList_SaveState] = new List<DOC_Detail>();
                }

                return (List<DOC_Detail>)ViewState[CartList_SaveState];
            }
            set { ViewState[CartList_SaveState] = value; }
        }
        public List<DOC_Detail> CartList_Show  //ไว้สำหรับ bind ลงกริด จะไม่เห็น row ที่ลบ
        {
            get
            {
                if (!(ViewState[CartList_ShowState] is List<DOC_Detail>))
                {
                    ViewState[CartList_ShowState] = new List<DOC_Detail>();
                }

                return (List<DOC_Detail>)ViewState[CartList_ShowState];
            }
            set { ViewState[CartList_ShowState] = value; }
        }
        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {
            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
            LoadExHelper loadEx = new LoadExHelper();
            //loadEx.LoadVatType(ref ddl_type_vat, Enumerator.ConditionLoadEx.All);
            //loadEx.LoadPaymentType(ref ddl_tpe_buy, Enumerator.ConditionLoadEx.All);

        }

        protected override void DoLoadData()
        {
            if (!IsNewMode)
            {
                BindControl();
            }
            BindGrid();
        }
        #endregion Override Methods

        #region Private Methods
        private void BindGrid()//โหลดตาราง
        {
            DataTable dt = biz.SelectDetail(base.dataId);
            CartList_Save = new List<DOC_Detail>();
            foreach (DataRow row in dt.Rows)
            {
                DOC_Detail item = new DOC_Detail()
                {
                    product_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_id")),
                    product_price_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_price_id")),
                    product_price_name = ConvertHelper.InitialValueDB(row, "product_price_name"),
                    unit_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "unit_id")),
                    unit_name = ConvertHelper.InitialValueDB(row, "unit_name"),
                    detail_qty = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "detail_qty")),
                    detail_price = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "detail_price")),
                    detail_discount = ConvertHelper.InitialValueDB(row, "detail_discount"),
                    detail_total = ConvertHelper.InitialValueDB(row, "detail_total"),
                    detail_remark = ConvertHelper.InitialValueDB(row, "detail_remark"),
                    detail_status = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "detail_status")),
                    detail_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "detail_id")),
                    header_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "header_id"))
                };
                CartList_Save.Add(item);
            }
            CartList_Show = CartList_Save;
            dgv1.DataSource = CartList_Show;
            dgv1.DataBind();
        }
        private void BindControl()//โหลดข้อมูล
        {
            if (base.dataId != -1)
            {
                DataTable dt = biz.SelectInfo(base.dataId);
                if (ConvertHelper.IsDataExists(dt))
                {
                    DataRow row = dt.Rows[0];
                    txt_header_code.Text = ConvertHelper.InitialValueDB(row, "header_code");
                    txt_header_date.Text = ConvertHelper.InitialValueDB(row, "header_date");
                    txt_header_name.Text = ConvertHelper.InitialValueDB(row, "header_customer_name");
                    txt_header_code.ReadOnly = true;
                    //ddl_type_vat.SelectedValue = ConvertHelper.InitialValueDB(row, "vat_id");
                    //ddl_tpe_buy.SelectedValue = ConvertHelper.InitialValueDB(row, "payment_id");
                    //txtDescription.Text = ConvertHelper.InitialValueDB(row, "Description");
                }
                else
                {
                    ShowMessage("ไม่พบข้อมูล");
                }
            }
        }

        private void AddProductToCart(string txt)
        {
            try
            {
                Tuple<int, int, decimal> value = FunctionSplitValue(txt);
                int quantity = value.Item1;
                int product_price_id = value.Item2;
                decimal price = value.Item3;

                if (quantity < 0)
                {
                    base.DisplayMessageDialogAndFocus("จำนวนมีค่า 1 ขึ้นไป และระบุให้ถูกต้อง เช่น 2*รหัสสินค้า", "txtProductBarCode");
                    return;
                }

                DataTable dt = biz.SelectProductPrice(product_price_id);
                if (ConvertHelper.IsDataExists(dt))
                {
                    if (!ConvertHelper.ToBoolean(dt.Rows[0], "is_enabled"))
                    {
                        //ClearTxtProductBarCode("ไม่สามารถใช้สินค้านี้ได้เนื่องจากถูกปิดการใช้งาน กรุณาติดต่อผู้ดูแลระบบ");
                        return;
                    }

                    //decimal price = ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(dt.Rows[0], "productPrice"));
                    decimal total = price * quantity;

                    DOC_Detail item = new DOC_Detail()
                    {
                        product_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(dt.Rows[0], "product_id")),
                        product_price_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(dt.Rows[0], "product_price_id")),
                        product_price_name = ConvertHelper.InitialValueDB(dt.Rows[0], "product_price_name"),
                        unit_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(dt.Rows[0], "unit_id")),
                        unit_name = ConvertHelper.InitialValueDB(dt.Rows[0], "unit_name"),
                        detail_qty = quantity,
                        detail_price = price,
                        detail_discount = "0",
                        detail_total = total.ToString(),
                        detail_remark = null,
                        detail_status = null,
                    };
                    if (!IsNewMode)// กรณี แก้ไข แล้วเพิ่ม เข้าไปใหม่
                    {
                        item.header_id = dataId;
                    }

                    //string logStr = GetStringFromObj(item);
                    //LogFile.WriteLogFile("", "Transfer", "AddProductToCart", logStr);

                    CartList_Save.Add(item);
                    CartList_Show.Add(item);
                    dgv1.DataSource = CartList_Show;
                    dgv1.DataBind();


                    item = null;
                    GC.Collect();
                }
                else
                {
                    base.DisplayMessageDialogAndFocus("ไม่พบสินค้า", "txtProductBarCode");
                    LogFile.WriteLogFile("", "Transfer", "SelectProduct", "ไม่พบสินค้า");
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        private Tuple<int, int, decimal> FunctionSplitValue(string txt)
        {
            int quantity = 1;
            int product_price_id = 0;
            decimal price = 0;
            if (!ConvertHelper.IsStringEmpty(txt))
            {
                if (txt.Contains("*"))
                {
                    string[] arr = txt.Split('*');
                    if (!int.TryParse(arr[0].ToString(), out quantity) || quantity < 1)
                    {
                        quantity = -1;
                    }
                    product_price_id = ConvertHelper.ToInt(arr[1]);
                    if (arr.Length == 3)
                    {
                        price = ConvertHelper.ToDecimal(arr[2]);
                    }
                }
                else
                {
                    quantity = 1;
                }
            }
            return Tuple.Create(quantity, product_price_id, price);
        }

        private void SaveInfo()//บันทึก
        {
            try
            {
                DocModel model = new DocModel();
                if (base.IsNewMode)
                {
                    model.Doc_Header.create_by = ApplicationWebInfo.UserID;
                }
                else
                {
                    model.Doc_Header.header_id = base.dataId;
                }
                model.Doc_Header.header_code = txt_header_code.Text;
                model.Doc_Header.header_date = ConvertHelper.ToDateTime(txt_header_date.Text, ConfigurationInfo.FORMATE_DATE_DISPLAY, ConfigurationInfo.CULTUREINFO_DISPLAY);
                model.Doc_Header.header_customer_name = txt_header_name.Text;
                //model.Doc_Header.vat_id = ConvertHelper.ToInt(ddl_type_vat.SelectedValue);
                //model.Doc_Header.payment_id = ConvertHelper.ToInt(ddl_tpe_buy.SelectedValue);
                model.Doc_Header.is_del = false;
                model.Doc_Header.is_enabled = true;
                //model.Description = txtDescription.Text;
                model.Doc_Header.update_by = ApplicationWebInfo.UserID;
                model.Doc_Header.doctype_id = 5;

                //detail
                model.DocDetailList = CartList_Save;
                int newDataId = biz.SaveData(model, base.SAVE_INFO, base.IsNewMode);
                model = null;
                GC.Collect();
                if (newDataId < 0)
                {
                    base.ShowMessage(FailMessage);
                }
                else
                {
                    //base.ShowMessage(SuccessMessage);
                    //if (base.IsNewMode)//บันทึกเสร็จแล้ว new mode จะทำการรีเฟรชข้อมูลใหม่
                    //{
                    //    LoadAfterNewMode(newDataId);
                    //}
                    if (base.IsNewMode)
                    {
                        base.ShowMessageAndRedirect(SuccessMessage, typeof(ReceiveproductList));
                    }
                    else
                    {
                        base.ShowMessage(SuccessMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion Private Methods

        #region Events
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveInfo();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.RedirectToBackPage(typeof(ReceiveproductList));
        }

        protected void dgv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt16(e.CommandArgument);
                GridViewRow row = dgv1.Rows[index];
                string id = ((HiddenField)row.FindControl("hdfID")).Value;
                row = null;
                if (e.CommandName == "Delete")
                {
                    int result = biz.DeleteDetail(ConvertHelper.ToInt(id), ApplicationWebInfo.UserID.ToString(), base.DELETE_DETAIL);
                    if (result < 0)
                    {
                        base.ShowMessage(FailMessage);
                    }
                    else
                    {
                        base.ShowMessage(SuccessMessage);
                        DoLoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void dgv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void btnAddHidden_Click(object sender, EventArgs e)
        {
            string txt = hdfValue.Value;
            AddProductToCart(txt);
        }
        #endregion Events
    }
}