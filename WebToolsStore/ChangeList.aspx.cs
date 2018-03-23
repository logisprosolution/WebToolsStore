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
using System.Configuration;

namespace WebToolsStore
{
    public partial class ChangeList : BasePage
    {
        #region Parameter
        DocBiz biz = new DocBiz();
        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {
        }

        protected override void DoLoadData()
        {
            BindGrid("");
        }

        #endregion Override Methods

        #region Private Methods
        private void BindGrid(string searchText)//โหลดตาราง
        {
            biz.dataModel.SubDoctype_id = ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_RE"].ToString());
            dgv1.DataSource = biz.SelectList(searchText);
            dgv1.DataBind();
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                base.SetBackURL();
                base.RedirectToPage(typeof(ChangeInfo), null);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
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
                    base.RedirectToPage(typeof(ChangeInfo), id);
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