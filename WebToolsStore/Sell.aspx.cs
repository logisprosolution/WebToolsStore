using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections.Generic;
using System.Configuration;

namespace WebToolsStore
{
    public partial class Sell : BasePage
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

        }

        protected override void DoLoadData()
        {
            if (!IsNewMode)
            {
                BindRepeater();
            } 
            BindGrid(dataId);
        }
        #endregion Override Methods

        #region Private Methods
        private void BindRepeater()
        {
            //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand("SELECT TOP 10 * FROM Customers", con))
            //    {
            //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            //        {
                        DataTable dt = new DataTable();
                        //sda.Fill(dt);
                        dgv1.DataSource = dt;
                        dgv1.DataBind();
            //        }
            //    }
            //}
        }
        private void BindGrid(int id)//โหลดตาราง
        {
            //biz.dataModel.Detail_status = detail_status;
            DataTable dt = biz.SelectDetail(id);
            CartList_Save = new List<DOC_Detail>();
            foreach (DataRow row in dt.Rows)
            {
                DOC_Detail item = new DOC_Detail();
                item.product_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_id"));
                item.product_price_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_price_id"));
                item.product_price_code = ConvertHelper.InitialValueDB(row, "product_price_code");
                item.product_price_name = ConvertHelper.InitialValueDB(row, "product_price_name");
                item.unit_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "unit_id"));
                item.unit_name = ConvertHelper.InitialValueDB(row, "unit_name");
                item.detail_qty = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "detail_qty"));
                item.detail_price = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "detail_price"));
                item.detail_discount = ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(row, "detail_discount"));
                item.detail_total = ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(row, "detail_total"));
                item.detail_remark = ConvertHelper.InitialValueDB(row, "detail_remark");
                item.detail_status = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "detail_status"));
                if (!IsNewMode)
                {
                    item.detail_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "detail_id"));
                    item.header_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "header_id"));
                }
                CartList_Save.Add(item);
            }
            CartList_Show = CartList_Save;
            dgv1.DataSource = CartList_Show;
            dgv1.DataBind();
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
                        product_price_code = ConvertHelper.InitialValueDB(dt.Rows[0], "product_price_code"),
                        product_price_name = ConvertHelper.InitialValueDB(dt.Rows[0], "product_price_name"),
                        unit_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(dt.Rows[0], "unit_id")),
                        unit_name = ConvertHelper.InitialValueDB(dt.Rows[0], "unit_name"),
                        detail_qty = quantity,
                        detail_price = price,
                        detail_discount = 0,
                        detail_total = total,
                        detail_remark = null,
                        detail_status = null,
                    };
                    if (!IsNewMode)// กรณี แก้ไข แล้วเพิ่ม เข้าไปใหม่
                    {
                        item.header_id = dataId;
                    }

                    //string logStr = GetStringFromObj(item);
                    //LogFile.WriteLogFile("", "Transfer", "AddProductToCart", logStr);
                    //txt_total.Text = (ConvertHelper.ToDecimal(txt_total.Text) + total).ToString();
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
        private void SaveInfo(int id)//บันทึก
        {
            try
            {
                LogFile.WriteLogFile("", "SellInfo", "SaveInfo", "User :" + ApplicationWebInfo.UserID + " header_id: " + base.dataId);
                DocModel model = new DocModel();
                if (base.IsNewMode)
                {
                    model.Doc_Header.create_by = ApplicationWebInfo.UserID;
                }
                else
                {
                    model.Doc_Header.header_id = base.dataId;
                }
                //model.Doc_Header.header_code = txt_header_code.Text;
                //model.Doc_Header.header_date = ConvertHelper.ToDateTime(txt_header_date.Text, ConfigurationInfo.FORMATE_DATE_DISPLAY, ConfigurationInfo.CULTUREINFO_DISPLAY);
                //model.Doc_Header.header_customer_id = ConvertHelper.ToInt(ddl_customer.SelectedValue);
                //model.Doc_Header.header_customer_name = ddl_customer.SelectedItem.Text;
                //model.Doc_Header.vat_id = ConvertHelper.ToInt(ddl_type_vat.SelectedValue);
                ////model.Doc_Header.payment_date = converthelper.todatetime(txt_paymentdate.text, configurationinfo.formate_date_display, configurationinfo.cultureinfo_display);
                //model.Doc_Header.is_del = false;
                //model.Doc_Header.is_enabled = ConvertHelper.ToBoolean(ddl_is_enabled.SelectedValue);
                //model.Doc_Header.header_remark = txt_remark.Text;
                //model.Doc_Header.header_address = txt_header_address.Text;
                //model.Doc_Header.update_by = ApplicationWebInfo.UserID;
                //model.Doc_Header.doctype_id = ConvertHelper.ToInt(ConfigurationManager.AppSettings["doctypeid_so"].ToString());
                //model.Doc_Header.header_ref = id;
                //if (ConvertHelper.ToDecimal(txt_receive.Text) < ConvertHelper.ToDecimal(txt_net.Text))
                //{
                //    base.DisplayMessageDialogAndFocus("ใส่จำนวนเงินให้ถูกต้อง", "txt_receive");
                //    return;
                //}
                //model.Doc_Header.header_total = ConvertHelper.ToDecimal(txt_total.Text);
                //model.Doc_Header.header_receive = ConvertHelper.ToDecimal(txt_receive.Text);
                //model.Doc_Header.header_discout = ConvertHelper.ToDecimal(txt_discout.Text);
                //model.Doc_Header.header_vat = ConvertHelper.ToDecimal(txt_vat.Text);
                //model.Doc_Header.header_net = ConvertHelper.ToDecimal(txt_net.Text);
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
                        base.ShowMessageAndRedirect(SuccessMessage, typeof(SellList));
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
        private void Sum()
        {
            //int vat = ConvertHelper.ToInt(ddl_vat.SelectedValue);
            //decimal total = ConvertHelper.ToDecimal(txt_total.Text);
            //decimal discount = ConvertHelper.ToDecimal(txt_discout.Text);
            //txt_vat.Text = ((total - discount) * vat / 100).ToString();
            //txt_net.Text = ((total - discount) + (total - discount) * vat / 100).ToString();
        }
        #endregion Private Methods

        #region Events
        protected void btnOpen_Popup(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //int id = ConvertHelper.ToInt(hdfDocValue.Value);
            //SaveInfo(id);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.RedirectToBackPage(typeof(SellList));
        }
        protected void txt_discout_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        protected void ddl_vat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int vat = ConvertHelper.ToInt(ddl_vat.SelectedValue);
            //decimal total = ConvertHelper.ToDecimal(txt_total.Text);
            //txt_vat.Text = (total * vat/100).ToString();
            Sum();
        }
        protected void txt_receive_TextChanged(object sender, EventArgs e)
        {
            //if (ConvertHelper.ToDecimal(txt_receive.Text) < ConvertHelper.ToDecimal(txt_net.Text))
            //{
            //    base.DisplayMessageDialogAndFocus("ใส่จำนวนเงินให้ถูกต้อง", "txt_receive");
            //    return;
            //}
        }
        #endregion Events
    }
}