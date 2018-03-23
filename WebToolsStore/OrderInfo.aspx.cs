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
    public partial class OrderInfo : BasePage
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
            //loadEx.LoadPaymentType(ref ddl_PaymentID, Enumerator.ConditionLoadEx.All);
            loadEx.LoadCustomer(ref ddl_customer, Enumerator.ConditionLoadEx.All);
            loadEx.LoadHeaderStatus(ref ddl_header_status, ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_BO"].ToString()), Enumerator.ConditionLoadEx.All);
            txt_header_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txt_PaymentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected override void DoLoadData()
        {
            if (!IsNewMode)
            {
                BindControl();
                txt_header_code.ReadOnly = true;
            }
            BindGrid();
            BindGridIngredient();
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
                    header_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "header_id")),
                    unit_value = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "unit_value")),
                };
                CartList_Save.Add(item);
                //DataTable dt1 = biz.SelectDetailIngredient(CartList_Save.GetRange();
                //IngredientList_Save = new List<DOC_Detail_Ingredient>();
                //foreach (DataRow row in dt.Rows)
                //{
                //    DOC_Detail_Ingredient item = new DOC_Detail_Ingredient()
                //    {
                //        ingredient_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "ingredient_id")),
                //        product_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_id")),
                //        product_unit = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_unit")),
                //        product_qty = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_qty")),
                //        product_code = ConvertHelper.InitialValueDB(row, "product_code"),
                //        product_name = ConvertHelper.InitialValueDB(row, "product_name"),
                //        unit_name = ConvertHelper.InitialValueDB(row, "unit_name"),
                //        //seq = seq1,
                //    };
                //    IngredientList_Save.Add(item);
                //}
            }
            CartList_Show = CartList_Save;
            dgv1.DataSource = CartList_Show;
            dgv1.DataBind();
        }
        private void BindGridIngredient()//โหลดตาราง
        {
            
            DataTable dt = biz.SelectDetailIngredient(base.dataId);
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
                    //seq = seq1,
                };
                IngredientList_Save.Add(item);
            }
            IngredientList_Show = IngredientList_Save;
            dgv1.DataSource = IngredientList_Show;
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
                    ddl_customer.SelectedValue = ConvertHelper.InitialValueDB(row, "header_customer_id");
                    //ddl_PaymentID.SelectedValue = ConvertHelper.InitialValueDB(row, "payment_id");
                    txt_PaymentDate.Text = ConvertHelper.InitialValueDB(row, "header_date_to");
                    txt_Deposit.Text = ConvertHelper.InitialValueDB(row, "header_deposit");
                    txt_remark.Text = ConvertHelper.InitialValueDB(row, "header_remark");
                    txt_header_address.Text = ConvertHelper.InitialValueDB(row, "header_address");
                    ddl_header_status.SelectedValue = ConvertHelper.InitialValueDB(row, "header_status");
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
                        unit_value = unit_value,
                        seq = CartList_Save.Count + 1,
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
                model.Doc_Header.header_customer_id = ConvertHelper.ToInt(ddl_customer.SelectedValue);
                model.Doc_Header.header_customer_name = ddl_customer.SelectedItem.Text;
                //model.Doc_Header.payment_id = ConvertHelper.ToInt(ddl_PaymentID.SelectedValue);
                model.Doc_Header.header_date_to = ConvertHelper.ToDateTime(txt_PaymentDate.Text, ConfigurationInfo.FORMATE_DATE_DISPLAY, ConfigurationInfo.CULTUREINFO_DISPLAY);
                model.Doc_Header.header_deposit = ConvertHelper.ToDecimal(txt_Deposit.Text);
                model.Doc_Header.is_del = false;
                model.Doc_Header.is_enabled = true;
                model.Doc_Header.header_remark = txt_remark.Text;
                model.Doc_Header.header_address = txt_header_address.Text;
                model.Doc_Header.update_by = ApplicationWebInfo.UserID;
                model.Doc_Header.subDocTypeID = ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_BO"].ToString());
                model.Doc_Header.header_status = ConvertHelper.ToInt(ddl_header_status.SelectedValue);
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
                        base.ShowMessageAndRedirect(SuccessMessage, typeof(OrderList));
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
            base.RedirectToBackPage(typeof(OrderList));
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
                    //var removeIndex = IngredientList_Show.FindAll(x => x.seq == index + 1);
                    //IngredientList_Show.Remove(removeIndex);
                    IngredientList_Show.RemoveAll(x => x.seq == index + 1);
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
        protected void ChkIsDefault_CheckedChanged(object sender, EventArgs e)
        {
            //GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
            //int index = row.RowIndex;
            //CheckBox cb1 = (CheckBox)row.Cells[index].FindControl("chkDefault");
            //bool isDefault = cb1.Checked;

            //IngredientList_Save[index].is_default = isDefault;
        }
        protected void dgv1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView dgv2 = e.Row.FindControl("dgv2") as GridView;
                    HiddenField hdfSeq  = (HiddenField)e.Row.FindControl("hdfSeq");
                    int seq1 = ConvertHelper.ToInt(hdfSeq.Value);
                    if (IngredientList_Save.Find(x => x.seq == seq1) == null)
                    {
                        HiddenField id = (HiddenField)e.Row.FindControl("hdfProID");
                        int product_id = ConvertHelper.ToInt(id.Value);
                        ProductIngredientBiz biz = new ProductIngredientBiz();
                        DataTable dt = biz.SelectInfo(product_id);
                        //IngredientList_Show = new List<MAS_Ingredient>();
                        foreach (DataRow row in dt.Rows)
                        {
                            string txt = hdfValue.Value;
                            Tuple<int, int, decimal, int> value = FunctionSplitValue(txt);
                            int quantity = value.Item1;
                            int product_price_id = value.Item2;
                            decimal price = value.Item3;
                            int unit_value = value.Item4;//ไม่ได้ใช้

                            //quantity = (product_unit_value * product_quantity) * quantity;
                            DOC_Detail_Ingredient item = new DOC_Detail_Ingredient()
                            {
                                ingredient_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "ingredient_id")),
                                product_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_id")),
                                product_unit = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_unit")),
                                product_qty = quantity * ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "unit_value")) * ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_qty")),
                                product_code = ConvertHelper.InitialValueDB(row, "product_code"),
                                product_name = ConvertHelper.InitialValueDB(row, "product_name"),
                                unit_name = ConvertHelper.InitialValueDB(row, "unit_name"),
                                seq = seq1
                            };
                            IngredientList_Save.Add(item);
                        }
                    }
                    IngredientList_Show = IngredientList_Save;
                    dgv2.DataSource = IngredientList_Show.FindAll(x => x.seq == seq1);
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