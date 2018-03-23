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
            //loadEx.LoadPaymentType(ref ddl_PaymentID, Enumerator.ConditionLoadEx.All);
            loadEx.LoadSupplyer(ref ddl_supplier, Enumerator.ConditionLoadEx.All);
            txt_header_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected override void DoLoadData()
        {
            if (!IsNewMode)
            {
                BindControl(dataId);
                txt_header_code.ReadOnly = true;
            }
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
                CartList_Save.Add(item);
            }
            CartList_Show = CartList_Save;
            dgv1.DataSource = CartList_Show;
            dgv1.DataBind();
        }
        private void BindControl(int id)//โหลดข้อมูล
        {
            if (base.dataId != -1)
            {
                DataTable dt = biz.SelectInfo(id);
                if (ConvertHelper.IsDataExists(dt))
                {
                    DataRow row = dt.Rows[0];
                    txt_header_code.Text = ConvertHelper.InitialValueDB(row, "header_code");
                    txt_header_date.Text = ConvertHelper.InitialValueDB(row, "header_date");
                    ddl_supplier.SelectedValue = ConvertHelper.InitialValueDB(row, "header_supplier_id");
                    txt_header_address.Text = ConvertHelper.InitialValueDB(row, "header_address");
                    //ddl_type_vat.SelectedValue = ConvertHelper.InitialValueDB(row, "vat_id");
                    //ddl_PaymentID.SelectedValue = ConvertHelper.InitialValueDB(row, "payment_id");
                    //txt_PaymentDate.Text = ConvertHelper.InitialValueDB(row, "payment_date");
                    txt_remark.Text = ConvertHelper.InitialValueDB(row, "header_remark");
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
                Tuple<int, int, decimal, int> value = FunctionSplitValue(txt);
                int quantity = value.Item1;
                int product_price_id = value.Item2;
                decimal price = value.Item3;
                int unit_value = value.Item4;

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
        private Tuple<int, int, decimal, int> FunctionSplitValue(string txt)
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
                    product_price_id = ConvertHelper.ToInt(arr[1]);
                    price = ConvertHelper.ToDecimal(arr[2]);
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
            return Tuple.Create(quantity, product_price_id, price, unit_value);
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
                model.Doc_Header.header_supplier_id = ConvertHelper.ToInt(ddl_supplier.SelectedValue);
                model.Doc_Header.header_supplier_name = ddl_supplier.SelectedItem.Text;
                model.Doc_Header.header_address = txt_header_address.Text;
                model.Doc_Header.header_remark = txt_remark.Text;
                //model.Doc_Header.payment_date = ConvertHelper.ToDateTime(txt_PaymentDate.Text, ConfigurationInfo.FORMATE_DATE_DISPLAY, ConfigurationInfo.CULTUREINFO_DISPLAY);
                model.Doc_Header.is_del = false;
                model.Doc_Header.is_enabled = true;
                model.Doc_Header.update_by = ApplicationWebInfo.UserID;
                model.Doc_Header.subDocTypeID = ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_InFromBuy"].ToString());

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
            base.RedirectToBackPage(typeof(ReceiveproductList));
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

        protected void btnAddHidden_Click(object sender, EventArgs e)
        {
            string txt = hdfValue.Value;
            AddProductToCart(txt);
        }
        protected void btnAddDocHidden_Click(object sender, EventArgs e)
        {
            int id = ConvertHelper.ToInt(hdfDocValue.Value);
            BindControl(id);
            BindGrid(id);
        }
        protected void ddl_supplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_supplier.SelectedIndex != 0)
            {
                RequiredSupplier.Validate();
                txt_header_address.Text = "";
                int id = ConvertHelper.ToInt(ddl_supplier.SelectedValue);
                txt_header_address.Text = biz.SelectAddress_Supplier(id);
            }
            else
            {
                RequiredSupplier.Validate();
                txt_header_address.Text = "";
            }
        }

        #endregion Events

    }
}