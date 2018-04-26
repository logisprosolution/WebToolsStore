using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;

namespace WebToolsStore
{
    public partial class ProductInfo : BasePage
    {
        #region Parameter
        ProductBiz biz = new ProductBiz();
        public USR_Role_Submenu roleMenu;
        LoadExHelper loadEx = new LoadExHelper();
        const string IngredientList_SaveState = "IngredientList_SaveState";
        const string IngredientList_ShowState = "IngredientList_ShowState";

        public List<MAS_Ingredient> IngredientList_Save //ไว้สำหรับsave จะมี row ที่โดนลบด้วย
        {
            get
            {
                if (!(ViewState[IngredientList_SaveState] is List<MAS_Ingredient>))
                {
                    ViewState[IngredientList_SaveState] = new List<MAS_Ingredient>();
                }

                return (List<MAS_Ingredient>)ViewState[IngredientList_SaveState];
            }
            set { ViewState[IngredientList_SaveState] = value; }
        }
        public List<MAS_Ingredient> IngredientList_Show  //ไว้สำหรับ bind ลงกริด จะไม่เห็น row ที่ลบ
        {
            get
            {
                if (!(ViewState[IngredientList_ShowState] is List<MAS_Ingredient>))
                {
                    ViewState[IngredientList_ShowState] = new List<MAS_Ingredient>();
                }

                return (List<MAS_Ingredient>)ViewState[IngredientList_ShowState];
            }
            set { ViewState[IngredientList_ShowState] = value; }
        }
        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {
            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
            loadEx.LoadSubcategoriesById(ref ddl_subcategories, 0, Enumerator.ConditionLoadEx.All);
            loadEx.LoadCategories(ref ddl_categories, Enumerator.ConditionLoadEx.All);
            loadEx.LoadUnit(ref ddl_unit, Enumerator.ConditionLoadEx.All);

            roleMenu = ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Product);
        }

        protected override void DoLoadData()
        {
            if (!IsNewMode)
            {
                BindControl();
                txt_product_code.ReadOnly = true;
            }
            BindGrid1();
            BindGrid2();
            //LoadExHelper loadEx = new LoadExHelper();
            //loadEx.LoadSubcategories(ref ddl_categories, Enumerator.ConditionLoadEx.All);
        }

        #endregion Override Methods

        #region Private Methods
        private void BindGrid1()//โหลดตาราง
        {
            DataTable dt = biz.SelectDetail(base.dataId);
            dgv1.DataSource = dt;
            dgv1.DataBind();
        }

        private void BindGrid2()//โหลดตาราง
        {
            DataTable dt = biz.SelectProductIngredient(base.dataId);
            IngredientList_Save = new List<MAS_Ingredient>();
            foreach (DataRow row in dt.Rows)
            {
                MAS_Ingredient item = new MAS_Ingredient()
                {
                    ingredient_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "ingredient_id")),
                    product_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_id")),
                    ingredient_product = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "ingredient_product")),
                    product_unit = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_unit")),
                    product_qty = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "product_qty")),
                    is_default = ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row, "is_default")),
                    is_enabled = ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row, "is_enabled")),
                    is_del = ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row, "is_del")),
                    create_date = ConvertHelper.InitialValueDB(row, "create_date") != "" ? ConvertHelper.ToDateTime(ConvertHelper.InitialValueDB(row, "create_date")) : (DateTime?)null,
                    create_by = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "create_by")),
                    update_date = ConvertHelper.InitialValueDB(row, "update_date") != "" ? ConvertHelper.ToDateTime(ConvertHelper.InitialValueDB(row, "update_date")) : (DateTime?)null,
                    update_by = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "update_by")),
                    product_code = ConvertHelper.InitialValueDB(row, "product_code"),
                    product_name = ConvertHelper.InitialValueDB(row, "product_name"),
                    unit_name = ConvertHelper.InitialValueDB(row, "unit_name"),
                };
                IngredientList_Save.Add(item);
            }
            IngredientList_Show = IngredientList_Save;
            dgv2.DataSource = IngredientList_Show;
            dgv2.DataBind();
        } //bindgrid2

        private byte[] UploadImage()
        {
            FileUpload img = (FileUpload)imgUpload;
            Byte[] imgByte = null;
            if (img.HasFile && img.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = imgUpload.PostedFile;
                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];
                //force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);
                txt_FileName.Text = File.FileName.ToString();
            }
            return imgByte;
        }
        private void BindControl()//โหลดข้อมูล
        {
            if (base.dataId != -1)
            {
                DataTable dt = biz.SelectInfo(base.dataId);
                if (ConvertHelper.IsDataExists(dt))
                {
                    DataRow row = dt.Rows[0];
                    int CategoriesID = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "categories_id"));
                    loadEx.LoadSubcategoriesById(ref ddl_subcategories, CategoriesID, Enumerator.ConditionLoadEx.All);
                    txt_product_code.Text = ConvertHelper.InitialValueDB(row, "product_code");
                    txt_product_name.Text = ConvertHelper.InitialValueDB(row, "product_name");
                    ddl_unit.SelectedValue = ConvertHelper.InitialValueDB(row, "product_unit");
                    ddl_categories.SelectedValue = ConvertHelper.InitialValueDB(row, "categories_id");
                    ddl_subcategories.SelectedValue = ConvertHelper.InitialValueDB(row, "subcategories_id");
                    ddl_is_enabled.SelectedValue = ConvertHelper.InitialValueDB(row, "is_enabled");
                    txtDescription.Text = ConvertHelper.InitialValueDB(row, "description");
                    if (!ConvertHelper.IsStringEmpty(row, "pic_filename"))
                    {
                        txt_FileName.Text = ConvertHelper.InitialValueDB(row, "pic_filename");
                    }
                    if (!ConvertHelper.IsStringEmpty(row, "product_pic"))
                    {
                        ViewState["image"] = (byte[])(row["product_pic"]);
                        Image1.ImageUrl = "~/ShowImage.ashx?dataId=" + base.dataId + "&dataId2=Product";
                        Image1.Attributes.Add("FileName", "aaaasssss");
                    }
                }
                else
                {
                    ShowMessage("ไม่พบข้อมูล");
                }
            }
        }
        private void AddProductToIngredient(string txt)
        {
            try
            {
                Tuple<int, int, int> value = FunctionSplitValue(txt);
                int quantity = value.Item1;
                int product_id = value.Item2;
                int unit = value.Item3;

                if (quantity < 0)
                {
                    base.DisplayMessageDialogAndFocus("จำนวนมีค่า 1 ขึ้นไป และระบุให้ถูกต้อง เช่น 2*รหัสสินค้า", "txtProductBarCode");
                    return;
                }
                DataTable dt = biz.SelectIngredient(product_id);
                if (ConvertHelper.IsDataExists(dt))
                {
                    if (!ConvertHelper.ToBoolean(dt.Rows[0], "is_enabled"))
                    {
                        //ClearTxtProductBarCode("ไม่สามารถใช้สินค้านี้ได้เนื่องจากถูกปิดการใช้งาน กรุณาติดต่อผู้ดูแลระบบ");
                        return;
                    }
                    MAS_Ingredient item = new MAS_Ingredient()
                    {
                        ingredient_product = product_id,//สินค้าส่วนประกอบที่เลือก
                        product_id = dataId,//FK
                        product_unit = unit,
                        product_qty = quantity,
                        is_default = true,
                        is_enabled = true,
                        is_del = false,
                        product_code = ConvertHelper.InitialValueDB(dt.Rows[0], "product_code"),
                        product_name = ConvertHelper.InitialValueDB(dt.Rows[0], "product_name"),
                        unit_name = ConvertHelper.InitialValueDB(dt.Rows[0], "unit_name"),
                    };

                    IngredientList_Save.Add(item);
                    IngredientList_Show.Add(item);
                    dgv2.DataSource = IngredientList_Show;
                    dgv2.DataBind();


                    item = null;
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        private Tuple<int, int, int> FunctionSplitValue(string txt)
        {
            int quantity = 1;
            int product_id = 0;
            int unit = 0;
            if (!ConvertHelper.IsStringEmpty(txt))
            {
                if (txt.Contains("*"))
                {
                    string[] arr = txt.Split('*');
                    if (!int.TryParse(arr[0].ToString(), out quantity) || quantity < 1)
                    {
                        quantity = -1;
                    }
                    product_id = ConvertHelper.ToInt(arr[1]);
                    if (arr.Length == 3)
                    {
                        unit = ConvertHelper.ToInt(arr[2]);
                    }
                }
                else
                {
                    quantity = 1;
                }
            }
            return Tuple.Create(quantity, product_id, unit);
        }
        private void SaveInfo()//บันทึก
        {
            try
            {
                ProductModel model = new ProductModel();
                if (base.IsNewMode)
                {
                    if (biz.CheckContainID(txt_product_code.Text))
                    {
                        base.DisplayMessageDialogAndFocus("ไม่สามารถบันทึกรายการได้เนื่องจากรหัสซ้ำ", "txt_product_code");
                        return;
                    }
                    model.MAS_Product.create_by = ApplicationWebInfo.UserID;
                }
                else
                {
                    model.MAS_Product.product_id = base.dataId;
                }
                model.MAS_Product.product_code = txt_product_code.Text;
                model.MAS_Product.product_name = txt_product_name.Text;
                model.MAS_Product.product_pic = UploadImage();
                if (model.MAS_Product.product_pic == null)
                {
                    model.MAS_Product.product_pic = ViewState["image"] != null ? (byte[])ViewState["image"] : null;
                }
                model.MAS_Product.pic_filename = txt_FileName.Text;
                model.MAS_Product.product_unit = ConvertHelper.ToInt(ddl_unit.SelectedValue);
                model.MAS_Product.subcategories_id = ConvertHelper.ToInt(ddl_subcategories.SelectedValue);
                model.MAS_Product.is_del = false;
                model.MAS_Product.is_enabled = ConvertHelper.ToBoolean(ddl_is_enabled.SelectedValue);
                model.MAS_Product.description = txtDescription.Text;
                model.MAS_Product.update_by = ApplicationWebInfo.UserID;
                model.MAS_Product.warehouse_default = null;
                //model.MAS_Product.product_unit = null;

                //Ingredient
                model.MasIngredientList = IngredientList_Save;
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
                        base.ShowMessageAndRedirect(SuccessMessage, typeof(ProductList));
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!base.IsNewMode)
                {
                    base.SetBackURL();
                    string queryString = "dataId2=" + base.dataId;
                    base.RedirectToPage(typeof(ProductPriceInfo), null, queryString);
                }
                else
                {
                    base.ShowMessage("กรุณาบันทึกข้อมุลก่อน");
                }
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
            base.RedirectToBackPage(typeof(ProductList));
        }
        protected void dgv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt16(e.CommandArgument);
                GridViewRow row = dgv1.Rows[index];
                string id = ((HiddenField)row.FindControl("hdfID")).Value;
                row = null;
                if (e.CommandName == "Edit")
                {
                    base.SetBackURL();
                    string queryString = "dataId2=" + base.dataId;
                    base.RedirectToPage(typeof(ProductPriceInfo), id, queryString);
                }
                else if (e.CommandName == "Delete")
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

        protected void dgv2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt16(e.CommandArgument);
                if (e.CommandName == "DeleteCart") // ลบออกเฉพาะหน้าจอ ต้องทำการบันทึกก่อนถึงจะอัพเดท
                {
                    if (base.IsNewMode) // ถ้า new mome ให้ ลบตามลำดับตารางได้เลย
                    {
                        IngredientList_Save.RemoveAt(index);
                    }
                    else // ลบโดยหาจากไอดี
                    {
                        int id = ConvertHelper.ToInt(dgv2.DataKeys[index].Value.ToString());
                        IngredientList_Save.Find(x => x.ingredient_id == id).is_del = true;
                    }
                    IngredientList_Show.RemoveAt(index);
                    dgv2.DataSource = IngredientList_Show;
                    dgv2.DataBind();
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
        protected void Upload(object sender, EventArgs e)
        {


        }
        protected void dgv1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void dgv2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void ddl_categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_subcategories.SelectedIndex = -1;
            RequiredCategories.Validate();
            int id = ConvertHelper.ToInt(ddl_categories.SelectedValue);
            loadEx.LoadSubcategoriesById(ref ddl_subcategories, id, Enumerator.ConditionLoadEx.All);
            txt_product_code.Text = "";
        }

        protected void ddl_subcategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_product_code.Text = "";
            if (ddl_subcategories.SelectedIndex == 0)
            {
                RequiredSubcategories.Validate();
            }
            else
            {
                int id = ConvertHelper.ToInt(ddl_subcategories.SelectedValue);
                DataTable dt = biz.SelectCode(id);
                txt_product_code.Text = ConvertHelper.InitialValueDB(dt.Rows[0], "subcategories_code").ToString() +"-"+ biz.SelectMaxID();
            }
        }

        protected void btnAddHidden_Click(object sender, EventArgs e)
        {
            string txt = hdfValue.Value;
            AddProductToIngredient(txt);
        }
        protected void ChkIsDefault_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
            int index = row.RowIndex;
            CheckBox cb1 = (CheckBox)dgv2.Rows[index].FindControl("chkDefault");
            bool isDefault = cb1.Checked;

            IngredientList_Save[index].is_default = isDefault;
        }

        #endregion Events


    }


}