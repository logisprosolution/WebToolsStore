using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace WebToolsStore
{
    public partial class CategoriesInfo : BasePage
    {
        #region Parameter
        CategoriesBiz biz = new CategoriesBiz();
        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {
            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
        }

        protected override void DoLoadData()
        {
            if (!IsNewMode)
            {
                BindControl();
                txt_categories_code.ReadOnly = true;
            }
            else
            {
                txt_categories_code.Text = biz.SelectMaxID();
            }
            BindGrid();
        }

        #endregion Override Methods

        #region Private Methods
        private void BindGrid()//โหลดตาราง
        {
            dgv1.DataSource = biz.SelectDetail(base.dataId);
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
                    txt_categories_code.Text = ConvertHelper.InitialValueDB(row, "categories_code");
                    txt_categories_name.Text = ConvertHelper.InitialValueDB(row, "categories_name");
                    txt_categories_index.Text = ConvertHelper.InitialValueDB(row, "categories_index");
                    ddl_is_enabled.SelectedValue = ConvertHelper.InitialValueDB(row, "is_enabled");
                    txtDescription.Text = ConvertHelper.InitialValueDB(row, "description");
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
                MAS_Categories model = new MAS_Categories();
                if (base.IsNewMode)
                {
                    if (biz.CheckContainID(txt_categories_code.Text))
                    {
                        base.DisplayMessageDialogAndFocus("ไม่สามารถบันทึกรายการได้เนื่องจากรหัสซ้ำ", "txt_categories_code");
                        return;
                    }
                    model.create_by = ApplicationWebInfo.UserID;
                }
                else
                {
                    model.categories_id = base.dataId;
                }
                model.categories_code = txt_categories_code.Text;
                model.categories_name = txt_categories_name.Text;
                model.categories_index = ConvertHelper.ToInt(txt_categories_index.Text.Trim());
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
                        base.ShowMessageAndRedirect(SuccessMessage, typeof(CategoriesList));
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
                    base.RedirectToPage(typeof(SubcategoriesInfo), null, queryString);
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
            base.RedirectToBackPage(typeof(CategoriesList));
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
                    base.RedirectToPage(typeof(SubcategoriesInfo), id, queryString);
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
        protected void dgv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgv1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        #endregion Events
    }
}