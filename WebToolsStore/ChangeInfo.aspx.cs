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
using static WebToolsStore.Enumerator;

namespace WebToolsStore
{
    public partial class ChangeInfo : BasePage
    {
        #region Parameter
        DocBiz biz = new DocBiz();

        const string CartList_SaveState = "CartList_SaveState";
        const string CartList_ShowState = "CartList_ShowState";
        const string CartList2_SaveState = "CartList2_SaveState";
        const string CartList2_ShowState = "CartList2_ShowState";
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
        public List<DOC_Detail> CartList2_Save //ไว้สำหรับsave จะมี row ที่โดนลบด้วย
        {
            get
            {
                if (!(ViewState[CartList2_SaveState] is List<DOC_Detail>))
                {
                    ViewState[CartList2_SaveState] = new List<DOC_Detail>();
                }

                return (List<DOC_Detail>)ViewState[CartList2_SaveState];
            }
            set { ViewState[CartList2_SaveState] = value; }
        }
        public List<DOC_Detail> CartList2_Show  //ไว้สำหรับ bind ลงกริด จะไม่เห็น row ที่ลบ
        {
            get
            {
                if (!(ViewState[CartList2_ShowState] is List<DOC_Detail>))
                {
                    ViewState[CartList2_ShowState] = new List<DOC_Detail>();
                }

                return (List<DOC_Detail>)ViewState[CartList2_ShowState];
            }
            set { ViewState[CartList2_ShowState] = value; }
        }
        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {
            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
            LoadExHelper loadEx = new LoadExHelper();
            //loadEx.LoadVatType(ref ddl_type_vat, Enumerator.ConditionLoadEx.All);
            //loadEx.LoadPaymentType(ref ddl_PaymentID, Enumerator.ConditionLoadEx.All);
            loadEx.LoadCustomer(ref ddl_customer, Enumerator.ConditionLoadEx.All);
            loadEx.LoadHeaderStatus(ref ddl_header_status, ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_RE"].ToString()), Enumerator.ConditionLoadEx.All);
            txt_header_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txt_header_date_to.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected override void DoLoadData()
        {
            if (!IsNewMode)
            {
                BindControl(dataId);
                txt_header_code.ReadOnly = true;
            }
            BindGrid(dataId, ConvertHelper.ToInt(ConfigurationManager.AppSettings["DetailStatusID_IN"].ToString()));
            BindGridRE();
        }
        #endregion Override Methods

        #region Private Methods
        private void BindGrid(int id, int? detail_status)//โหลดตาราง
        {
            biz.dataModel.Detail_status = detail_status;
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
                item.detail_status = ConvertHelper.ToInt(ConfigurationManager.AppSettings["DetailStatusID_IN"].ToString());//สินค้าที่รับมาเปลี่ยน
                item.used_qty = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "used_qty"));
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

        private void BindGridRE()//โหลดตาราง 
        {
            biz.dataModel.Detail_status = ConvertHelper.ToInt(ConfigurationManager.AppSettings["DetailStatusID_OT"].ToString());
            DataTable dt = biz.SelectDetail(base.dataId);
            CartList2_Save = new List<DOC_Detail>();
            foreach (DataRow row in dt.Rows)
            {
                DOC_Detail item = new DOC_Detail()
                {
                    product_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_id")),
                    product_price_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_price_id")),
                    product_price_code = ConvertHelper.InitialValueDB(row, "product_price_code"),
                    product_price_name = ConvertHelper.InitialValueDB(row, "product_price_name"),
                    unit_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "unit_id")),
                    unit_name = ConvertHelper.InitialValueDB(row, "unit_name"),
                    detail_qty = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "detail_qty")),
                    detail_price = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "detail_price")),
                    detail_discount = ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(row, "detail_discount")),
                    detail_total = ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(row, "detail_total")),
                    detail_remark = ConvertHelper.InitialValueDB(row, "detail_remark"),
                    detail_status = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "detail_status")),
                    detail_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "detail_id")),
                    header_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "header_id"))
                };
                CartList2_Save.Add(item);
            }
            CartList2_Show = CartList2_Save;
            dgv2.DataSource = CartList2_Show;
            dgv2.DataBind();
        }
        private void BindControl(int id)//โหลดข้อมูล
        {
            if (id > 0)
            {
                DataTable dt = biz.SelectInfo(id);
                if (ConvertHelper.IsDataExists(dt))
                {
                    DataRow row = dt.Rows[0];

                    //txt_header_ref.Text = ConvertHelper.InitialValueDB(row, "header_id");
                    if (!IsNewMode)
                    {
                        txt_header_code.Text = ConvertHelper.InitialValueDB(row, "header_code");
                        txt_header_ref.Text = ConvertHelper.InitialValueDB(row, "header_ref_code");
                        txt_header_date.Text = ConvertHelper.InitialValueDB(row, "header_date");
                        txt_header_date_to.Text = ConvertHelper.InitialValueDB(row, "header_date_to");
                        ddl_customer.SelectedValue = ConvertHelper.InitialValueDB(row, "header_customer_id");
                        //ddl_is_enabled.SelectedValue = ConvertHelper.InitialValueDB(row, "is_enabled");
                        txt_remark.Text = ConvertHelper.InitialValueDB(row, "header_remark");
                        ddl_header_status.SelectedValue = ConvertHelper.InitialValueDB(row, "header_status");
                        hdfDocValue.Value = ConvertHelper.InitialValueDB(row, "header_ref");
                        txt_header_address.Text = ConvertHelper.InitialValueDB(row, "header_address");
                    }
                    else
                    {
                        txt_header_ref.Text = ConvertHelper.InitialValueDB(row, "header_code");
                        ddl_customer.SelectedValue = ConvertHelper.InitialValueDB(row, "header_customer_id");
                        txt_header_address.Text = ConvertHelper.InitialValueDB(row, "header_address");
                    }


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
                        detail_status = ConvertHelper.ToInt(ConfigurationManager.AppSettings["DetailStatusID_OT"].ToString()), //สินค้าเปลี่ยนคืน
                        subDocTypeID = ConvertHelper.ToInt(ConfigurationManager.AppSettings["DocTypeID_RE"].ToString()),
                    };
                    if (!IsNewMode)// กรณี แก้ไข แล้วเพิ่ม เข้าไปใหม่
                    {
                        item.header_id = dataId;
                    }
                    //string logStr = GetStringFromObj(item);
                    //LogFile.WriteLogFile("", "Transfer", "AddProductToCart", logStr);

                    CartList2_Save.Add(item);
                    CartList2_Show.Add(item);
                    dgv2.DataSource = CartList2_Show;
                    dgv2.DataBind();


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
                    if (arr.Length == 4)
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
                    model.Doc_Header.header_ref = ConvertHelper.ToInt(hdfDocValue.Value);
                }
                else
                {
                    model.Doc_Header.header_id = base.dataId;
                }
                model.Doc_Header.header_code = txt_header_code.Text;
                model.Doc_Header.header_date = ConvertHelper.ToDateTime(txt_header_date.Text, ConfigurationInfo.FORMATE_DATE_DISPLAY, ConfigurationInfo.CULTUREINFO_DISPLAY);
                model.Doc_Header.header_customer_id = ConvertHelper.ToInt(ddl_customer.SelectedValue);
                model.Doc_Header.header_customer_name = ddl_customer.SelectedItem.Text;
                model.Doc_Header.header_date_to = ConvertHelper.ToDateTime(txt_header_date_to.Text, ConfigurationInfo.FORMATE_DATE_DISPLAY, ConfigurationInfo.CULTUREINFO_DISPLAY);
                model.Doc_Header.header_remark = txt_remark.Text;
                model.Doc_Header.header_status = ConvertHelper.ToInt(ddl_header_status.SelectedValue);
                model.Doc_Header.is_del = false;
                //model.Doc_Header.is_enabled = ConvertHelper.ToBoolean(ddl_is_enabled.SelectedValue);
                model.Doc_Header.update_by = ApplicationWebInfo.UserID;
                model.Doc_Header.subDocTypeID = ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_RE"].ToString());
                if (ConvertHelper.ToDecimal(txt_receive.Text) < ConvertHelper.ToDecimal(txt_net.Text))
                {
                    base.DisplayMessageDialogAndFocus("ใส่จำนวนเงินให้ถูกต้อง", "txt_receive");
                    return;
                }
                model.Doc_Header.header_total = ConvertHelper.ToDecimal(txt_total.Text);
                model.Doc_Header.header_receive = ConvertHelper.ToDecimal(txt_receive.Text);
                model.Doc_Header.header_discout = ConvertHelper.ToDecimal(txt_discout.Text);
                model.Doc_Header.header_vat = ConvertHelper.ToDecimal(txt_vat.Text);
                if (ConvertHelper.ToDecimal(txt_net.Text) < 0)
                {
                    base.DisplayMessageDialogAndFocus("ไม่สามารถบันทึกรายการได้เนื่องจากจำนวนเงินสุทธิติดลบ", "txt_discout");
                    return;
                }
                model.Doc_Header.header_net = ConvertHelper.ToDecimal(txt_net.Text);
                model.Doc_Header.header_refund = ConvertHelper.ToDecimal(txt_refund);

                //doc
                model.DocDetailList = CartList_Save;

                //product refund
                model.DocDetailList2 = CartList2_Save;

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
                        base.ShowMessageAndRedirect(SuccessMessage, typeof(ChangeList));
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
            int vat = ConvertHelper.ToInt(ddl_vat.SelectedValue);
            decimal total = ConvertHelper.ToDecimal(txt_total.Text);
            decimal discount = ConvertHelper.ToDecimal(txt_discout.Text);
            txt_vat.Text = String.Format("{0:n}", ((total - discount) * vat / 100)).ToString();
            txt_net.Text = String.Format("{0:n}", ((total - discount) + (total - discount) * vat / 100)).ToString();
        }
        private void clear()
        {
            txt_total.Text = "0.00";
            txt_receive.Text = "0.00";
            txt_refund.Text = "0.00";
            txt_discout.Text = "0.00";
            txt_net.Text = "0.00";
            txt_vat.Text = "0.00";
            ddl_vat.SelectedIndex = 0;
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
            SaveInfo();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.RedirectToBackPage(typeof(ChangeList));
        }
        protected void dgv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt16(e.CommandArgument);
                if (e.CommandName == "DeleteCart") // ลบออกเฉพาะหน้าจอ ต้องทำการบันทึกก่อนถึงจะอัพเดท
                {
                    if (base.IsNewMode) // ถ้า new mome ให้ ลบตามลำดับตารางได้เลย
                    {
                        CartList_Save.RemoveAt(index);
                    }
                    else // ลบโดยหาจากไอดี
                    {
                        int id = ConvertHelper.ToInt(dgv1.DataKeys[index].Value.ToString());
                        CartList_Save.Find(x => x.detail_id == id).is_del = true;
                    }
                    CartList_Show.RemoveAt(index);
                    dgv1.DataSource = CartList_Show;
                    dgv1.DataBind();
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

        protected void dgv2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt16(e.CommandArgument);
                if (e.CommandName == "DeleteCart") // ลบออกเฉพาะหน้าจอ ต้องทำการบันทึกก่อนถึงจะอัพเดท
                {
                    if (base.IsNewMode) // ถ้า new mome ให้ ลบตามลำดับตารางได้เลย
                    {
                        CartList2_Save.RemoveAt(index);
                    }
                    else // ลบโดยหาจากไอดี
                    {
                        int id = ConvertHelper.ToInt(dgv2.DataKeys[index].Value.ToString());
                        CartList2_Save.Find(x => x.detail_id == id).is_del = true;
                    }
                    CartList2_Show.RemoveAt(index);
                    dgv2.DataSource = CartList2_Show;
                    dgv2.DataBind();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void dgv2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnAddHidden_Click(object sender, EventArgs e)
        {
            string txt = hdfValue.Value;
            AddProductToCart(txt);
        }
        protected void btnAddDocHidden_Click(object sender, EventArgs e)
        {
            int id = ConvertHelper.ToInt(hdfDocValue.Value);
            BindControl(id);
            BindGrid(id, null);
        }

        protected void txt_used_qty_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            int index = row.RowIndex;
            TextBox used = (TextBox)dgv1.Rows[index].FindControl("txt_used_qty_current");
            int used_qty = ConvertHelper.ToInt(used.Text);
            CartList_Save[index].used_qty += used_qty;
        }
        protected void ddl_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_customer.SelectedIndex != 0)
            {
                RequiredCustomer.Validate();
                txt_header_address.Text = "";
                int id = ConvertHelper.ToInt(ddl_customer.SelectedValue);
                txt_header_address.Text = biz.SelectAddress_Customer(id);
            }
            else
            {
                RequiredCustomer.Validate();
                txt_header_address.Text = "";
            }
        }
        protected void ddl_header_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_header_status.SelectedIndex == 0)
            {
                RequiredStatus.Validate();
            }
        }
        protected void txt_receive_TextChanged(object sender, EventArgs e)
        {

            txt_receive.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_receive.Text))).ToString();
            if (ConvertHelper.ToDecimal(txt_receive.Text) < ConvertHelper.ToDecimal(txt_net.Text))
            {
                base.DisplayMessageDialogAndFocus("ใส่จำนวนเงินไม่ถูกต้อง", "txt_receive");
                return;
            }
        }
        protected void txt_refund_TextChanged(object sender, EventArgs e)
        {
            if (txt_refund.Text == "0")
            {
                ddl_vat.Attributes.Remove("disabled");
                txt_receive.ReadOnly = false;
                txt_discout.ReadOnly = false;
                txt_total.ReadOnly = false;
                txt_refund.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_refund.Text))).ToString();
            }
            else
            {
                txt_refund.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_refund.Text))).ToString();
                ddl_vat.Attributes.Add("disabled", "disabled");
                txt_receive.ReadOnly = true;
                txt_discout.ReadOnly = true;
                txt_total.ReadOnly = true;
            }
        }
        protected void ddl_vat_SelectedIndexChanged(object sender, EventArgs e)
        {

            Sum();
        }
        protected void txt_discout_TextChanged(object sender, EventArgs e)
        {

            txt_discout.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_discout.Text))).ToString();
            Sum();
        }
        protected void txt_total_TextChanged(object sender, EventArgs e)
        {
            if (txt_total.Text == "0")
            {
                txt_refund.ReadOnly = false;
                clear();
            }
            else
            {
                txt_refund.ReadOnly = true;
                txt_total.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_total.Text))).ToString();
                Sum();
            }

        }
        #endregion Events


    }
}