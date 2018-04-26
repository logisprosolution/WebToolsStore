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
    public partial class ProductList : BasePage
    {
        #region Parameter
        ProductBiz biz = new ProductBiz();
        public USR_Role_Submenu roleMenu;
        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {
            roleMenu = ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Product);
        }

        protected override void DoLoadData()
        {
            BindGrid("");
        }

        #endregion Override Methods

        #region Private Methods
        private void BindGrid(string searchText)//โหลดตาราง
        {
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
                base.RedirectToPage(typeof(ProductInfo), null);
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
                    base.RedirectToPage(typeof(ProductInfo), id);
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