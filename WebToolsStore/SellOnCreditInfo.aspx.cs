﻿using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections.Generic;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;

namespace WebToolsStore
{
    public partial class SellOnCreditInfo : BasePage
    {
        #region Parameter
        DocBiz biz = new DocBiz();

        const string CartList_SaveState = "CartList_SaveState";
        const string CartList_ShowState = "CartList_ShowState";
        const string IngredientList_SaveState = "IngredientList_SaveState";
        const string IngredientList_ShowState = "IngredientList_ShowState";

        public List<DOC_Detail_Ingredient> IngredientList_Save //ไว้สำหรับsave จะมี row ที่โดนลบด้วย
        {
            get
            {
                if (!(ViewState[IngredientList_SaveState] is List<DOC_Detail_Ingredient>))
                {
                    ViewState[IngredientList_SaveState] = new List<DOC_Detail_Ingredient>();
                }

                return (List<DOC_Detail_Ingredient>)ViewState[IngredientList_SaveState];
            }
            set { ViewState[IngredientList_SaveState] = value; }
        }
        public List<DOC_Detail_Ingredient> IngredientList_Show  //ไว้สำหรับ bind ลงกริด จะไม่เห็น row ที่ลบ
        {
            get
            {
                if (!(ViewState[IngredientList_ShowState] is List<DOC_Detail_Ingredient>))
                {
                    ViewState[IngredientList_ShowState] = new List<DOC_Detail_Ingredient>();
                }

                return (List<DOC_Detail_Ingredient>)ViewState[IngredientList_ShowState];
            }
            set { ViewState[IngredientList_ShowState] = value; }
        }

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
            txt_header_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //loadEx.LoadPaymentType(ref ddl_payment, 1, Enumerator.ConditionLoadEx.Else);
            //loadEx.LoadVatType(ref ddl_type_vat, Enumerator.ConditionLoadEx.Else);
            loadEx.LoadCustomer(ref ddl_customer, Enumerator.ConditionLoadEx.All);
            //loadEx.LoadHeaderStatus(ref ddl_header_status, ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_SaleCredit"].ToString()), Enumerator.ConditionLoadEx.All);
            txt_header_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txt_payment_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected override void DoLoadData()
        {
            if (!IsNewMode)
            {
                BindControl(dataId);
                txt_header_code.ReadOnly = true;
            }
            else
            {
                txt_header_code.Text = "SC" + DateTime.Now.ToString("yyyyMMdd") + "-" + biz.SelectMaxID(ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_SaleCredit"].ToString()));
            }
            BindGridIngredient(dataId);
            BindGrid(dataId);
        }
        #endregion Override Methods

        #region Private Methods
        private void BindGrid(int id)//โหลดตาราง
        {
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
                item.unit_value = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "unit_value"));
                item.PaytypeID = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "PaytypeID"));

                if (!IsNewMode)
                {
                    item.detail_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "detail_id"));
                    item.header_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "header_id"));
                }
                else
                {
                    txt_total.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_total.Text) + item.detail_total)).ToString();
                    txt_net.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_net.Text) + item.detail_total)).ToString();
                }
                CartList_Save.Add(item);
            }

            CartList_Show = CartList_Save;
            dgv1.DataSource = CartList_Show;
            dgv1.DataBind();
        }
        private void BindGridIngredient(int id)//โหลดตาราง
        {
            DataTable dt = biz.SelectDetailIngredient(id);
            IngredientList_Save = new List<DOC_Detail_Ingredient>();
            foreach (DataRow row in dt.Rows)
            {
                DOC_Detail_Ingredient item = new DOC_Detail_Ingredient();

                item.ingredient_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "ingredient_id"));
                item.product_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_id"));
                item.product_unit = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_unit"));
                item.product_qty = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_qty"));
                item.product_code = ConvertHelper.InitialValueDB(row, "product_code");
                item.product_name = ConvertHelper.InitialValueDB(row, "product_name");
                item.unit_name = ConvertHelper.InitialValueDB(row, "unit_name");
                item.product_price_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_price_id"));
                item.is_enabled = ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row, "is_enabled"));
                item.is_del = ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row, "is_del"));
                item.detail_price = ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(row, "detail_price"));
                item.PaytypeID = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "PaytypeID"));
                if (!IsNewMode)
                {
                    item.running = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "running"));
                    item.detail_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "detail_id"));
                }
                IngredientList_Save.Add(item);
            }
            IngredientList_Show = IngredientList_Save;
        }
        private void SetEditIngredient()//แก้ไขสินค้าส่วนประกอบ ตอน Editmode
        {
            foreach (GridViewRow row in dgv1.Rows)
            {
                GridView dgv2 = row.FindControl("dgv2") as GridView;
                foreach (GridViewRow row2 in dgv2.Rows)
                {
                    TextBox textbox = row2.FindControl("txt_product_qty") as TextBox;
                    string txt = textbox.Text;
                    txt = txt.Substring(txt.IndexOf(',') + 1);
                    int id = ConvertHelper.ToInt(dgv2.DataKeys[row2.RowIndex].Value.ToString());
                    IngredientList_Save.Find(x => x.ingredient_id == id).product_qty = ConvertHelper.ToInt(txt);
                    textbox.Text = txt;
                }
            }
        }
        private void BindControl(int id)//โหลดข้อมูล
        {
            if (id > 0)
            {
                DataTable dt = biz.SelectInfo(id);
                if (ConvertHelper.IsDataExists(dt))
                {
                    DataRow row = dt.Rows[0];
                    if (!IsNewMode)
                    {
                        txt_header_code.Text = ConvertHelper.InitialValueDB(row, "header_code");
                        txt_header_date.Text = ConvertHelper.InitialValueDB(row, "header_date");
                        ddl_customer.SelectedValue = ConvertHelper.InitialValueDB(row, "header_customer_id");
                        txt_header_ref.Text = ConvertHelper.InitialValueDB(row, "header_ref_code");
                        //ddl_type_vat.SelectedValue = ConvertHelper.InitialValueDB(row, "vat_id");
                        ddl_payment.SelectedValue = ConvertHelper.InitialValueDB(row, "payment_id");
                        //ddl_header_status.SelectedValue = ConvertHelper.InitialValueDB(row, "header_status");
                        txt_payment_date.Text = ConvertHelper.InitialValueDB(row, "payment_date");
                        txt_remark.Text = ConvertHelper.InitialValueDB(row, "header_remark");
                        txt_header_address.Text = ConvertHelper.InitialValueDB(row, "header_address");
                        txt_total.Text = ConvertHelper.InitialValueDB(row, "header_total");
                        txt_receive.Text = ConvertHelper.InitialValueDB(row, "header_receive");
                        txt_discout.Text = ConvertHelper.InitialValueDB(row, "header_discout");
                        txt_vat.Text = ConvertHelper.InitialValueDB(row, "header_vat");
                        txt_net.Text = ConvertHelper.InitialValueDB(row, "header_net");
                        txt_added.Text = ConvertHelper.InitialValueDB(row, "header_added");
                        if (ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "header_deposit")) != 0)
                        {
                            lbl_deposit.Text = "***หักส่วนลดค่ามัดจำ " + ConvertHelper.InitialValueDB(row, "header_deposit") + " บาท";
                            lbl_deposit.Visible = true;
                        }
                    }
                    else
                    {
                        txt_header_ref.Text = ConvertHelper.InitialValueDB(row, "header_code");
                        ddl_customer.SelectedValue = ConvertHelper.InitialValueDB(row, "header_customer_id");
                        txt_header_address.Text = ConvertHelper.InitialValueDB(row, "header_address");
                        lbl_deposit.Text = "***หักส่วนลดค่ามัดจำ " + ConvertHelper.InitialValueDB(row, "header_deposit") + " บาท";
                        lbl_deposit.Visible = true;
                        txt_discout.Text = ConvertHelper.InitialValueDB(row, "header_discout");
                        txt_total.Text = ConvertHelper.InitialValueDB(row, "header_total");
                        txt_receive.Text = ConvertHelper.InitialValueDB(row, "header_deposit");
                        txt_vat.Text = ConvertHelper.InitialValueDB(row, "header_vat");
                        txt_net.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(row, "header_net")) - ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(row, "header_deposit")))).ToString();
                        txt_added.Text = ConvertHelper.InitialValueDB(row, "header_added");
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
                Tuple<int, int, decimal, int, int> value = FunctionSplitValue(txt);
                int quantity = value.Item1;
                int paytype = value.Item2;
                decimal price = value.Item3;
                int product_price_id = value.Item4;
                int unit_value = value.Item5;
                decimal total = price * quantity;

                if (quantity < 0)
                {
                    base.DisplayMessageDialogAndFocus("จำนวนมีค่า 1 ขึ้นไป และระบุให้ถูกต้อง เช่น 2*รหัสสินค้า", "txtProductBarCode");
                    return;
                }

                DataTable dt = biz.SelectProductPrice(product_price_id);
                if (ConvertHelper.IsDataExists(dt))
                {
                    int product_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(dt.Rows[0], "product_id"));
                    if (!ConvertHelper.ToBoolean(dt.Rows[0], "is_enabled"))
                    {
                        //ClearTxtProductBarCode("ไม่สามารถใช้สินค้านี้ได้เนื่องจากถูกปิดการใช้งาน กรุณาติดต่อผู้ดูแลระบบ");
                        return;
                    }

                    //เช็คว่ามี product_price_id และ paytype หรือยัง ถ้ายัง สร้างแถวใหม่ ถ้ามีแล้วบวกเพิ่มจำนวน
                    bool isNewDetail = true;
                    DOC_Detail docdetail = CartList_Show.FindAll(x => x.product_price_id == product_price_id).Find(y => y.PaytypeID == paytype);
                    if (docdetail != null)
                    {
                        isNewDetail = false;
                    }

                    //decimal price = ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(dt.Rows[0], "productPrice"));
                    if (isNewDetail)
                    {

                        DOC_Detail item = new DOC_Detail()
                        {
                            product_id = product_id,
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
                            unit_value = unit_value,
                            PaytypeID = paytype,
                            //seq = CartList_Save.Count + 1,
                        };
                        if (!IsNewMode)// กรณี แก้ไข แล้วเพิ่ม เข้าไปใหม่
                        {
                            item.header_id = dataId;
                        }

                        //string logStr = GetStringFromObj(item);
                        //LogFile.WriteLogFile("", "Transfer", "AddProductToCart", logStr);

                        CartList_Save.Add(item);
                        CartList_Show.Add(item);

                        ProductIngredientBiz biz = new ProductIngredientBiz();
                        DataTable dt2 = biz.SelectInfo(product_id);

                        foreach (DataRow row2 in dt2.Rows)
                        {
                            DOC_Detail_Ingredient item2 = new DOC_Detail_Ingredient();
                            item2.ingredient_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row2, "ingredient_id"));
                            item2.product_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row2, "product_id"));
                            item2.product_unit = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row2, "product_unit"));
                            item2.product_code = ConvertHelper.InitialValueDB(row2, "product_code");
                            item2.product_name = ConvertHelper.InitialValueDB(row2, "product_name");
                            item2.unit_name = ConvertHelper.InitialValueDB(row2, "unit_name");
                            item2.product_price_id = product_price_id;
                            item2.is_enabled = ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row2, "is_default"));
                            item2.is_del = false;
                            item2.detail_price = price;
                            item2.PaytypeID = paytype;
                            if (ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row2, "is_default")))//ถ้าตั้งเป็นสินค้าส่วนประกอบตั้งต้นถึงจะบวกจำนวนเพิ่ม
                            {
                                item2.product_qty = quantity * unit_value * ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row2, "product_qty"));
                            }
                            else
                            {
                                item2.product_qty = 0;
                            }
                            //seq = seq1
                            IngredientList_Save.Add(item2);
                            //IngredientList_Show.Add(item2);
                        }
                    }
                    else
                    {
                        CartList_Save.Find(x => x.product_price_id == product_price_id).detail_total += total;
                        CartList_Save.Find(x => x.product_price_id == product_price_id).detail_qty += quantity;
                        CartList_Show = CartList_Save;


                        ProductIngredientBiz biz = new ProductIngredientBiz();
                        dt = biz.SelectProductIngredient(product_price_id);

                        //List<DOC_Detail_Ingredient> list = new List<DOC_Detail_Ingredient>();
                        //list = IngredientList_Save.FindAll(x => x.product_price_id == product_price_id); //บวกจำนวนgrid2

                        //เปลี่ยนจำนวนสินค้าส่วนประกอบตามจำนวนจาก popup
                        if (dt != null)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (ConvertHelper.ToBoolean(row["is_default"])) //ถ้าตั้งเป็นสินค้าส่วนประกอบตั้งต้นถึงจะบวกจำนวนเพิ่ม
                                {
                                    IngredientList_Save.FindAll(x => x.product_price_id == product_price_id && x.PaytypeID == paytype).Find(a => a.ingredient_id == (int)row["ingredient_id"]).product_qty += quantity * (int)row["product_qty"];
                                }
                            }
                        }
                    }
                    dgv1.DataSource = CartList_Show;
                    dgv1.DataBind();
                    txt_total.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_total.Text) + total)).ToString();
                    txt_net.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_net.Text) + total)).ToString();
                    //item = null;
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
        private Tuple<int, int, decimal, int, int> FunctionSplitValue(string txt)
        {
            int quantity = 1;
            int paytype = 0;
            decimal price = 0;
            int product_price_id = 0;
            int unit_value = 0;
            if (!ConvertHelper.IsStringEmpty(txt))
            {
                if (txt.Contains("*"))
                {
                    string[] arr = txt.Split('*');
                    if (!int.TryParse(arr[0].ToString(), out quantity) || quantity < 1)
                    {
                        quantity = -1;
                    }
                    paytype = ConvertHelper.ToInt(arr[1]);
                    price = ConvertHelper.ToDecimal(arr[2]);
                    product_price_id = ConvertHelper.ToInt(arr[3]);
                    if (arr.Length == 5)
                    {
                        unit_value = ConvertHelper.ToInt(arr[4]);
                    }
                }
                else
                {
                    quantity = 1;
                }
            }
            return Tuple.Create(quantity, paytype, price, product_price_id, unit_value);
        }

        private void SaveInfo(int id)//บันทึก
        {
            try
            {
                DocModel model = new DocModel();
                if (base.IsNewMode)
                {
                    if (biz.CheckContainID(ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_SaleCredit"].ToString()), txt_header_code.Text))
                    {
                        base.DisplayMessageDialogAndFocus("ไม่สามารถบันทึกรายการได้เนื่องจากรหัสซ้ำ", "txt_header_code");
                        return;
                    }
                    model.Doc_Header.create_by = ApplicationWebInfo.UserID;
                }
                else
                {
                    model.Doc_Header.header_id = base.dataId;
                    SetEditIngredient();
                }
                model.Doc_Header.header_code = txt_header_code.Text;
                model.Doc_Header.header_date = ConvertHelper.ToDateTime(txt_header_date.Text, ConfigurationInfo.FORMATE_DATE_DISPLAY, ConfigurationInfo.CULTUREINFO_DISPLAY);
                model.Doc_Header.header_customer_id = ConvertHelper.ToInt(ddl_customer.SelectedValue);
                model.Doc_Header.header_customer_name = ddl_customer.SelectedItem.Text;
                //model.Doc_Header.vat_id = ConvertHelper.ToInt(ddl_type_vat.SelectedValue);
                model.Doc_Header.payment_id = ConvertHelper.ToInt(ddl_payment.SelectedValue);
                model.Doc_Header.payment_date = ConvertHelper.ToDateTime(txt_payment_date.Text, ConfigurationInfo.FORMATE_DATE_DISPLAY, ConfigurationInfo.CULTUREINFO_DISPLAY);
                model.Doc_Header.is_del = false;
                model.Doc_Header.is_enabled = true;
                model.Doc_Header.header_remark = txt_remark.Text;
                model.Doc_Header.header_address = txt_header_address.Text;
                model.Doc_Header.header_status = 5;
                model.Doc_Header.update_by = ApplicationWebInfo.UserID;
                model.Doc_Header.subDocTypeID = ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_SaleCredit"].ToString());
                model.Doc_Header.header_ref = id;
                if (lbl_deposit.Text != "")
                {
                    string[] deposit = lbl_deposit.Text.Split(new char[0]);
                    model.Doc_Header.header_deposit = ConvertHelper.ToDecimal(deposit[1]);
                }
                else
                {
                    model.Doc_Header.header_deposit = ConvertHelper.ToDecimal(lbl_deposit.Text);
                }
                model.Doc_Header.header_total = ConvertHelper.ToDecimal(txt_total.Text);
                model.Doc_Header.header_receive = ConvertHelper.ToDecimal(txt_receive.Text);
                model.Doc_Header.header_discout = ConvertHelper.ToDecimal(txt_discout.Text);
                model.Doc_Header.header_added = ConvertHelper.ToDecimal(txt_added.Text);
                model.Doc_Header.header_vat = ConvertHelper.ToDecimal(txt_vat.Text);
                if (ConvertHelper.ToDecimal(txt_net.Text) < 0)
                {
                    base.DisplayMessageDialogAndFocus("ไม่สามารถบันทึกรายการได้เนื่องจากจำนวนเงินสุทธิติดลบ", "txt_discout");
                    return;
                }
                model.Doc_Header.header_net = ConvertHelper.ToDecimal(txt_net.Text);
                //detail
                model.DocDetailList = CartList_Save;
                //detailIngredient
                model.DocIngredientList = IngredientList_Save;

                int newDataId = biz.SaveData(model, base.SAVE_INFO, base.IsNewMode);
                model = null;
                GC.Collect();
                if (newDataId < 0)
                {
                    base.ShowMessage(FailMessage);
                }
                else
                {
                    if (base.IsNewMode)
                    {
                        base.ShowMessageAndRedirect(SuccessMessage, typeof(SellOnCreditList));
                    }
                    else
                    {
                        base.ShowMessage(SuccessMessage);
                    }
                    ReportBiz biz = new ReportBiz();
                    ReportDocument crystalReport = new ReportDocument();
                    crystalReport.Load(Server.MapPath("Reports/ReportInvoice.rpt"));
                    DataSet ds = biz.SelectBill(ConvertHelper.ToInt(newDataId));
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        base.ShowMessage("ไม่พบเอกสาร");
                    }
                    else
                    {
                        crystalReport.SetDataSource(ds);
                        crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, System.Guid.NewGuid().ToString());
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
            decimal total = ConvertHelper.ToDecimal(txt_total.Text);
            decimal discount = ConvertHelper.ToDecimal(txt_discout.Text);
            decimal added = ConvertHelper.ToDecimal(txt_added.Text);
            if (discount != 0)
            {
                txt_net.Text = String.Format("{0:n}", ((total - discount) + (total - discount))).ToString();
            }
            else
            {
                txt_net.Text = String.Format("{0:n}", ((total + added))).ToString();
            }
        }
        private void clear()
        {
            txt_added.Text = "0.00";
            txt_total.Text = "0.00";
            txt_receive.Text = "0.00";
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
            int id = ConvertHelper.ToInt(hdfDocValue.Value);
            SaveInfo(id);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.RedirectToBackPage(typeof(SellOnCreditList));
        }

        protected void dgv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt16(e.CommandArgument);
                if (e.CommandName == "DeleteCart") // ลบออกเฉพาะหน้าจอ ต้องทำการบันทึกก่อนถึงจะอัพเดท
                {
                    int id = ConvertHelper.ToInt(dgv1.DataKeys[index].Value.ToString());
                    int product_price_id = ConvertHelper.ToInt(dgv1.DataKeys[index].Values[1]);
                    int PaytypeID = ConvertHelper.ToInt(((HiddenField)dgv1.Rows[index].FindControl("hdfPaytype")).Value);
                    if (base.IsNewMode) // ถ้า new mome ให้ ลบตามลำดับตารางได้เลย
                    {
                        txt_total.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_total.Text) - CartList_Save[index].detail_total)).ToString();
                        txt_net.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_net.Text) - CartList_Save[index].detail_total)).ToString();
                        CartList_Save.RemoveAt(index);
                        IngredientList_Save.RemoveAll(x => x.product_price_id == product_price_id);
                    }
                    else // ลบโดยหาจากไอดี
                    {
                        txt_total.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_total.Text) - CartList_Save.Find(x => x.detail_id == id).detail_total)).ToString();
                        txt_net.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_net.Text) - CartList_Save.Find(x => x.detail_id == id).detail_total)).ToString();
                        CartList_Save.Find(x => x.detail_id == id).is_del = true;
                        var detail_Ingredient = IngredientList_Save.FindAll(x => x.product_price_id == product_price_id && x.PaytypeID == PaytypeID && x.detail_id == id);
                        foreach (var item in detail_Ingredient)
                        {
                            item.is_del = true;
                        }
                        //IngredientList_Save = detail_Ingredient;
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
        protected void dgv1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void btnAddHidden_Click(object sender, EventArgs e)
        {
            string txt = hdfValue.Value;
            AddProductToCart(txt);
        }
        protected void btnAddDocHidden_Click(object sender, EventArgs e)
        {
            clear();
            int id = ConvertHelper.ToInt(hdfDocValue.Value);
            BindGridIngredient(id);
            BindControl(id);
            BindGrid(id);
        }
        protected void txt_discout_TextChanged(object sender, EventArgs e)
        {
            txt_discout.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_discout.Text))).ToString();
            txt_added.Text = "0.00";
            Sum();
        }
        protected void txt_added_TextChanged(object sender, EventArgs e)
        {
            txt_added.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_added.Text))).ToString();
            txt_discout.Text = "0.00";
            Sum();
        }

        protected void ddl_vat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sum();
        }
        protected void txt_receive_TextChanged(object sender, EventArgs e)
        {
            txt_receive.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_receive.Text))).ToString();
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
        protected void ddl_type_vat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddl_type_vat.SelectedIndex == 1 || ddl_type_vat.SelectedIndex == 2)
            //{
            //    ddl_vat.SelectedIndex = 0;
            //    //ddl_vat.Enabled = false;
            //    ddl_vat.Attributes.Add("disabled", "disabled");
            //    txt_vat.Text = "0.00";
            //}
            //else
            //{
            //    ddl_vat.Attributes.Remove("disabled");
            //}
        }
        protected void dgv1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView dgv2 = e.Row.FindControl("dgv2") as GridView;

                    int product_price_id = ConvertHelper.ToInt(dgv1.DataKeys[e.Row.RowIndex].Values[1]);
                    int PaytypeID = ConvertHelper.ToInt(((HiddenField)e.Row.FindControl("hdfPaytype")).Value);
                    IngredientList_Show = IngredientList_Save;
                    dgv2.DataSource = IngredientList_Show.FindAll(x => x.product_price_id == product_price_id && x.PaytypeID == PaytypeID && x.is_del == false);
                    dgv2.DataBind();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion Events

    }
}