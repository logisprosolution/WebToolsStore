using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;

namespace WebToolsStore
{
    public partial class SubcategoriesInfo : BasePage
    {
        #region Parameter
        SubcategoriesBiz biz = new SubcategoriesBiz();
        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {
            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
            base.dataId2 = ConvertHelper.ToInt(Request.QueryString["dataId2"]);
        }

        protected override void DoLoadData()
        {
            if (!IsNewMode)
            {
                BindControl();
                txt_subcategories_code.ReadOnly = true;
            }
            //else
            //{
            //    txt_subcategories_code.Text = biz.SelectMaxID();
            //}
        }

        #endregion Override Methods

        #region Private Methods
        private void BindControl()//โหลดข้อมูล
        {
            if (base.dataId != -1)
            {
                DataTable dt = biz.SelectInfo(base.dataId);
                if (ConvertHelper.IsDataExists(dt))
                {
                    DataRow row = dt.Rows[0];
                    txt_subcategories_code.Text = ConvertHelper.InitialValueDB(row, "subcategories_code");
                    txt_subcategories_name.Text = ConvertHelper.InitialValueDB(row, "subcategories_name");
                    txt_subcategories_index.Text = ConvertHelper.InitialValueDB(row, "subcategories_index");
                    ddl_is_enabled.SelectedValue = ConvertHelper.InitialValueDB(row, "is_enabled");
                    txtDescription.Text = ConvertHelper.InitialValueDB(row, "Description");
                }
                else
                {
                    ShowMessage("ไม่พบข้อมูล");
                }
            }
        }
        private void SaveInfo()//บันทึก
        {
            try
            {
                MAS_Subcategories model = new MAS_Subcategories();
                if (base.IsNewMode)
                {
                    if (biz.CheckContainID(txt_subcategories_code.Text))
                    {
                        base.DisplayMessageDialogAndFocus("ไม่สามารถบันทึกรายการได้เนื่องจากรหัสซ้ำ", "txt_subcategories_code");
                        return;
                    }
                    model.create_by = ApplicationWebInfo.UserID;
                }
                else
                {
                    model.subcategories_id = base.dataId;
                }
                model.categories_id = base.dataId2;
                model.subcategories_code = txt_subcategories_code.Text;
                model.subcategories_name = txt_subcategories_name.Text;
                model.subcategories_index = ConvertHelper.ToFloat(txt_subcategories_index.Text);
                model.is_del = false;
                model.is_enabled = ConvertHelper.ToBoolean(ddl_is_enabled.SelectedValue);
                model.description = txtDescription.Text;
                model.update_by = ApplicationWebInfo.UserID;
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
                        base.ShowMessageAndRedirectBack(SuccessMessage, typeof(CategoriesInfo));
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
            base.RedirectToBackPage(typeof(CategoriesInfo));
        }
        #endregion Events
    }
}