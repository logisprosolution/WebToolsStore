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

namespace WebToolsStore
{
    public partial class SellInfo : BasePage
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
            //loadEx.LoadVatType(ref ddl_type_vat, Enumerator.ConditionLoadEx.All);
            loadEx.LoadVatType(ref ddl_type_vat, Enumerator.ConditionLoadEx.All);
            loadEx.LoadCustomer(ref ddl_customer, Enumerator.ConditionLoadEx.All);
            txt_header_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected override void DoLoadData()
        {
            if (!IsNewMode)
            {
                BindControl(dataId);
                txt_header_code.ReadOnly = true;
            }
            BindGridIngredient(dataId);
            BindGrid(dataId);
        }
        #endregion Override Methods

        #region Private Methods
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
                    //txt_total.Text = ConvertHelper.ToDecimal(item.detail_total).ToString();
                    //txt_net.Text = ConvertHelper.ToDecimal(item.detail_total).ToString();
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
                DOC_Detail_Ingredient item = new DOC_Detail_Ingredient()
                {
                    ingredient_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "ingredient_id")),
                    product_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_id")),
                    product_unit = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_unit")),
                    product_qty = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_qty")),
                    product_code = ConvertHelper.InitialValueDB(row, "product_code"),
                    product_name = ConvertHelper.InitialValueDB(row, "product_name"),
                    unit_name = ConvertHelper.InitialValueDB(row, "unit_name"),
                    product_price_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_price_id")),
                    is_enabled = ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row, "is_enabled")),
                    //seq = seq1,
                };

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
                        ddl_type_vat.SelectedValue = ConvertHelper.InitialValueDB(row, "vat_id");
                        //ddl_is_enabled.Text = ConvertHelper.InitialValueDB(row, "is_enabled");
                        txt_remark.Text = ConvertHelper.InitialValueDB(row, "header_remark");
                        txt_header_address.Text = ConvertHelper.InitialValueDB(row, "header_address");
                        txt_total.Text = ConvertHelper.InitialValueDB(row, "header_total");
                        txt_receive.Text = ConvertHelper.InitialValueDB(row, "header_receive");
                        txt_discout.Text = ConvertHelper.InitialValueDB(row, "header_discout");
                        txt_vat.Text = ConvertHelper.InitialValueDB(row, "header_vat");
                        txt_net.Text = ConvertHelper.InitialValueDB(row, "header_net");
                        txt_added.Text = ConvertHelper.InitialValueDB(row, "header_added");
                        lbl_deposit.Text = "***หักส่วนลดค่ามัดจำ " + ConvertHelper.InitialValueDB(row, "header_deposit") + " บาท";
                        lbl_deposit.Visible = true;
                    }
                    else
                    {
                        ddl_customer.SelectedValue = ConvertHelper.InitialValueDB(row, "header_customer_id");
                        txt_header_address.Text = ConvertHelper.InitialValueDB(row, "header_address");
                        lbl_deposit.Text = "***หักส่วนลดค่ามัดจำ " + ConvertHelper.InitialValueDB(row, "header_deposit") + " บาท";
                        lbl_deposit.Visible = true;
                        txt_discout.Text = ConvertHelper.InitialValueDB(row, "header_discout");
                        txt_total.Text = ConvertHelper.InitialValueDB(row, "header_total");
                        txt_receive.Text = ConvertHelper.InitialValueDB(row, "header_receive");
                        txt_vat.Text = ConvertHelper.InitialValueDB(row, "header_vat");
                        txt_net.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(row, "header_net")) - ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(row, "header_deposit")))).ToString();
                        txt_added.Text = ConvertHelper.InitialValueDB(row, "header_added");

                        //txt_total.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_total.Text) - ConvertHelper.ToDecimal(txt_discout.Text))).ToString();
                        //txt_net.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_net.Text) - ConvertHelper.ToDecimal(txt_discout.Text))).ToString();
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
                Tuple<int, decimal, int, int> value = FunctionSplitValue(txt);
                int quantity = value.Item1;
                decimal price = value.Item2;
                int product_price_id = value.Item3;
                int unit_value = value.Item4;
                decimal total = price * quantity;
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
                    if (CartList_Show.Find(x => x.product_price_id == product_price_id) == null)
                    {
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
                            unit_value = unit_value,
                        };
                        if (!IsNewMode)// กรณี แก้ไข แล้วเพิ่ม เข้าไปใหม่
                        {
                            item.header_id = dataId;
                        }
                        CartList_Save.Add(item);
                        CartList_Show.Add(item);
                    }
                    else
                    {
                        CartList_Save.Find(x => x.product_price_id == product_price_id).detail_total += total;
                        CartList_Save.Find(x => x.product_price_id == product_price_id).detail_qty += quantity;
                        CartList_Show = CartList_Save;
                        ProductIngredientBiz biz = new ProductIngredientBiz();
                        dt = biz.SelectProductIngredient(product_price_id);
                        if (dt != null) //ถ้ามี row product_price_id อยู่แล้ว
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (ConvertHelper.ToBoolean(row["is_default"])) //ถ้าตั้งเป็นสินค้าส่วนประกอบตั้งต้นถึงจะบวกจำนวนเพิ่ม
                                {
                                    IngredientList_Save.FindAll(x => x.product_price_id == product_price_id).Find(a => a.ingredient_id == (int)row["ingredient_id"]).product_qty += quantity * (int)row["product_qty"];
                                }
                            }
                        }
                    }
                    txt_total.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_total.Text) + total)).ToString();
                    txt_net.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_net.Text) + total)).ToString();
                    dgv1.DataSource = CartList_Show;
                    dgv1.DataBind();


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
        private Tuple<int, decimal, int, int> FunctionSplitValue(string txt)
        {
            int quantity = 1;
            int product_price_id = 0;
            decimal price = 0;
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
                    price = ConvertHelper.ToDecimal(arr[1]);
                    product_price_id = ConvertHelper.ToInt(arr[2]);
                    if (arr.Length == 4)
                    {
                        unit_value = ConvertHelper.ToInt(arr[3]);
                    }
                }
                else
                {
                    quantity = 1;
                }
            }
            return Tuple.Create(quantity, price, product_price_id, unit_value);
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
                model.Doc_Header.header_code = txt_header_code.Text;
                model.Doc_Header.header_date = ConvertHelper.ToDateTime(txt_header_date.Text, ConfigurationInfo.FORMATE_DATE_DISPLAY, ConfigurationInfo.CULTUREINFO_DISPLAY);
                model.Doc_Header.header_customer_id = ConvertHelper.ToInt(ddl_customer.SelectedValue);
                model.Doc_Header.header_customer_name = ddl_customer.SelectedItem.Text;
                model.Doc_Header.vat_id = ConvertHelper.ToInt(ddl_type_vat.SelectedValue);
                //model.Doc_Header.payment_date = converthelper.todatetime(txt_paymentdate.text, configurationinfo.formate_date_display, configurationinfo.cultureinfo_display);
                model.Doc_Header.is_del = false;
                model.Doc_Header.is_enabled = true;
                model.Doc_Header.header_remark = txt_remark.Text;
                model.Doc_Header.header_address = txt_header_address.Text;
                model.Doc_Header.update_by = ApplicationWebInfo.UserID;
                model.Doc_Header.subDocTypeID = ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_Sale"].ToString());
                model.Doc_Header.header_ref = id;
                string[] deposit = lbl_deposit.Text.Split(new char[0]);
                model.Doc_Header.header_deposit = ConvertHelper.ToDecimal(deposit[1]);
                if (ConvertHelper.ToDecimal(txt_receive.Text) < ConvertHelper.ToDecimal(txt_net.Text))
                {
                    base.DisplayMessageDialogAndFocus("ใส่จำนวนเงินให้ถูกต้อง", "txt_receive");
                    return;
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
            int vat = ConvertHelper.ToInt(ddl_vat.SelectedValue);
            decimal total = ConvertHelper.ToDecimal(txt_total.Text);
            decimal discount = ConvertHelper.ToDecimal(txt_discout.Text);
            decimal added = ConvertHelper.ToDecimal(txt_added.Text);
            if (discount != 0)
            {
                txt_vat.Text = String.Format("{0:n}", ((total - discount) * vat / 100)).ToString();
                txt_net.Text = String.Format("{0:n}", ((total - discount) + (total - discount) * vat / 100)).ToString();
            }
            else
            {
                txt_vat.Text = String.Format("{0:n}", ((total + added) * vat / 100)).ToString();
                txt_net.Text = String.Format("{0:n}", ((total + added) + (total - added) * vat / 100)).ToString();
            }
        }
        private void clear()
        {
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
            base.RedirectToBackPage(typeof(SellList));
        }
        protected void dgv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt16(e.CommandArgument);
                if (e.CommandName == "DeleteCart") // ลบออกเฉพาะหน้าจอ ต้องทำการบันทึกก่อนถึงจะอัพเดท
                {
                    int id = ConvertHelper.ToInt(dgv1.DataKeys[index].Value.ToString());
                    if (base.IsNewMode) // ถ้า new mome ให้ ลบตามลำดับตารางได้เลย
                    {
                        txt_total.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_total.Text) - CartList_Save[index].detail_total)).ToString();
                        txt_net.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_net.Text) - CartList_Save[index].detail_total)).ToString();
                        CartList_Save.RemoveAt(index);
                    }
                    else // ลบโดยหาจากไอดี
                    {
                        txt_total.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_total.Text) - CartList_Save.Find(x => x.detail_id == id).detail_total)).ToString();
                        txt_net.Text = String.Format("{0:n}", (ConvertHelper.ToDecimal(txt_net.Text) - CartList_Save.Find(x => x.detail_id == id).detail_total)).ToString();
                        CartList_Save.Find(x => x.detail_id == id).is_del = true;
                    }


                    CartList_Show.RemoveAt(index);
                    int product_price_id = ConvertHelper.ToInt(dgv1.DataKeys[index].Values[1]);
                    IngredientList_Show.RemoveAll(x => x.product_price_id == product_price_id);
                    IngredientList_Save.RemoveAll(x => x.product_price_id == product_price_id);
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
        //protected void btnAddIgdHidden_Click(object sender, EventArgs e)
        //{
        //    string txt = hdfIgdValue.Value;
        //    AddProductToCart(txt);
        //    if (txt.Contains("|"))
        //    {
        //        string[] strArr = txt.Split('|');
        //        foreach (var item in strArr)
        //        {
        //            string[] itemArr = item.Split('*');
        //            int id = ConvertHelper.ToInt(itemArr[0]);
        //            itemArr[1].ToString();
        //        }
        //    }
        //}
        protected void btnAddDocHidden_Click(object sender, EventArgs e)
        {
            clear();
            int id = ConvertHelper.ToInt(hdfDocValue.Value);
            BindGridIngredient(id);
            BindGrid(id);
            BindControl(id);
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

        //protected void txt_net_TextChanged(object sender, EventArgs e)
        //{
        //    Sum();
        //}
        protected void ddl_vat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sum();
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
            if (ddl_type_vat.SelectedIndex == 0)
            {
                RequiredTypeVat.Validate();
            }
            else if (ddl_type_vat.SelectedIndex == 1 || ddl_type_vat.SelectedIndex == 2)
            {
                ddl_vat.SelectedIndex = 0;
                //ddl_vat.Enabled = false;
                ddl_vat.Attributes.Add("disabled", "disabled");
                txt_vat.Text = "0.00";
            }
            else
            {
                ddl_vat.Attributes.Remove("disabled");
            }
        }
        protected void dgv1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView dgv2 = e.Row.FindControl("dgv2") as GridView;
                    //HiddenField hdfSeq = (HiddenField)e.Row.FindControl("hdfSeq");
                    //int seq1 = ConvertHelper.ToInt(hdfSeq.Value);
                    HiddenField id = (HiddenField)e.Row.FindControl("hdfProID");
                    int detail_qty = ConvertHelper.ToInt(((HiddenField)e.Row.FindControl("hdfQty")).Value);
                    int product_id = ConvertHelper.ToInt(id.Value);
                    ProductIngredientBiz biz = new ProductIngredientBiz();
                    DataTable dt = biz.SelectInfo(product_id);
                    int product_price_id = ConvertHelper.ToInt(dgv1.DataKeys[e.Row.RowIndex].Values[1]);
                    string txt = hdfValue.Value;
                    Tuple<int, decimal, int, int> value = FunctionSplitValue(txt);
                    int quantity = value.Item1;
                    int unit_value = value.Item4;

                    if (IngredientList_Show.Find(x => x.product_price_id == product_price_id) == null) //ถ้า grid1 new row เข้าเงื่อนไขนี้
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            DOC_Detail_Ingredient item = new DOC_Detail_Ingredient();
                            item.ingredient_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "ingredient_id"));
                            item.product_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_id"));
                            item.product_unit = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_unit"));
                            item.product_code = ConvertHelper.InitialValueDB(row, "product_code");
                            item.product_name = ConvertHelper.InitialValueDB(row, "product_name");
                            item.unit_name = ConvertHelper.InitialValueDB(row, "unit_name");
                            item.product_price_id = product_price_id;
                            item.is_enabled = ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row, "is_default"));
                            if (ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row, "is_default")))//ถ้าตั้งเป็นสินค้าส่วนประกอบตั้งต้นถึงจะบวกจำนวนเพิ่ม
                            {
                                item.product_qty = quantity * unit_value * ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_qty"));
                            }
                            else
                            {
                                item.product_qty = 0;
                            }
                            //seq = seq1
                            IngredientList_Save.Add(item);
                            //IngredientList_Show.Add(item);
                        }
                    }
                    IngredientList_Show = IngredientList_Save;
                    dgv2.DataSource = IngredientList_Show.FindAll(x => x.product_price_id == product_price_id);
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