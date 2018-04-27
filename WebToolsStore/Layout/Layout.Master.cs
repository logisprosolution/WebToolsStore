using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebToolsStore.Layout
{
    public partial class layout : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            lblUserName.Text = ApplicationWebInfo.UserDisplayName;
            lblUserName2.Text = ApplicationWebInfo.UserDisplayName;

            LinkOrderList.Visible = (bool)ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Order).is_view;
            LinkReceiveproductList.Visible = (bool)ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Receiveproduct).is_view;
            LinkSellList.Visible = (bool)ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Sell).is_view;
            LinkSellOnCreditList.Visible = (bool)ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.SellOnCredit).is_view;
            LinkChangeList.Visible = (bool)ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Change).is_view;
            LinkRoleList.Visible = (bool)ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Role).is_view;
            LinkTitleList.Visible = (bool)ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Title).is_view;
            LinkEmployeeList.Visible = (bool)ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Employee).is_view;
            LinkSupplierList.Visible = (bool)ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Supplier).is_view;
            LinkCustomerList.Visible = (bool)ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Customer).is_view;
            LinkUnitList.Visible = (bool)ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Unit).is_view;
            LinkCategoriesList.Visible = (bool)ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Categories).is_view;
            LinkProductList.Visible = (bool)ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Product).is_view;  
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            string id = ApplicationWebInfo.UserProfileID;
            Response.Redirect("EmployeeInfo.aspx?dataId=" + id);
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}