using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;

namespace WebToolsStore
{
    public partial class RoleList : BasePage
    {
        #region Parameter
        RoleBiz biz = new RoleBiz();
        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {
        }

        protected override void DoLoadData()
        {
            txt_role_code.Text = "role" + biz.SelectMaxID();
            BindGrid("");
        }

        #endregion Override Methods

        #region Private Methods
        private void BindGrid(string searchText)//โหลดตาราง
        {
            dgv1.DataSource = biz.SelectList(searchText);
            dgv1.DataBind();
        }
        private void SaveInfo()//บันทึก
        {
            try
            {
                RoleModel model = new RoleModel();
                if (base.IsNewMode)
                {
                    model.USR_Role.create_by = ApplicationWebInfo.UserID;
                }
                else
                {
                    model.USR_Role.role_id = base.dataId;
                }
                model.USR_Role.role_code = txt_role_code.Text;
                model.USR_Role.role_name = txt_role_name.Text;
                model.USR_Role.role_value = 0;
                model.USR_Role.is_del = false;
                model.USR_Role.is_enabled = true;
                //model.Description = txtDescription.Text;
                model.USR_Role.update_by = ApplicationWebInfo.UserID;
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
                        base.ShowMessageAndRedirect(SuccessMessage, typeof(RoleList));
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
        protected void brnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid(txtSearch.Text);
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
        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        base.SetBackURL();
        //        base.RedirectToPage(typeof(RoleInfo), null);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.HandleException(ex);
        //    }
        //}

        protected void dgv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt16(e.CommandArgument);
                GridViewRow row = dgv1.Rows[index];
                string id = ((HiddenField)row.FindControl("hdfID")).Value;
                row = null;
                if (e.CommandName == "User")
                {
                    base.SetBackURL();
                    base.RedirectToPage(typeof(RoleUser),id);
                }
                else if (e.CommandName == "Edit")
                {
                    base.SetBackURL();
                    base.RedirectToPage(typeof(RoleInfo), id);
                }
                else if (e.CommandName == "Delete")
                {
                    int result = biz.DeleteData(ConvertHelper.ToInt(id), ApplicationWebInfo.UserID.ToString(), base.DELETE_LIST);
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