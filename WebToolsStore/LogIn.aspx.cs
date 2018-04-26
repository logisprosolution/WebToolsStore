using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebToolsStore.Biz;
using AT.Framework;
using System.Data;
using WebToolsStore.Data;

namespace WebToolsStore
{
    public partial class LogIn : BasePage
    {
        LoginBiz biz = new LoginBiz();

        protected override void DoPrepareData()
        {
            Session["UserID"] = null;
            txtPassword.Attributes["type"] = "password";
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                Login();
            }
            catch (Exception ex)
            {

                base.HandleException(ex);
            }
        }

        private void Login()
        {
            biz.dataModel.user_name = txtUsername.Text.Trim();
            biz.dataModel.user_password = txtPassword.Text.Trim();
            DataTable dt = biz.SelectLogin();
            if (dt.Rows.Count == 0)
            {
                base.ShowMessage("ชื่อเข้าใช้หรือรหัสผ่านไม่ถูกต้อง");
            }
            else
            {
                Session["UserID"] = ConvertHelper.ToInt(dt.Rows[0]["user_id"]);
                Session["UserDisplayName"] = dt.Rows[0]["user_namedis"].ToString();
                Session["UserProfileID"] = dt.Rows[0]["user_profile_id"].ToString();
                base.RedirectToPage(typeof(Main));


                GetPermission(ConvertHelper.ToInt(dt.Rows[0]["user_id"]));
            }
        }

        private void GetPermission(int id)
        {
            DataTable dt = biz.GetPermission(id);
            if (dt.Rows.Count == 0)
            {
                base.ShowMessage("ไม่พบสิทธิ์การใช้งาน กรุณาติดต่อ admin");
            }
            else
            {
                List<USR_Role_Submenu> roleMenu = new List<USR_Role_Submenu>();
                foreach (DataRow row in dt.Rows)
                {
                    USR_Role_Submenu item = new USR_Role_Submenu();
                    item.role_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "role_id"));
                    item.submenu_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "submenu_id"));
                    item.is_view = ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row, "is_view"));
                    item.is_add = ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row, "is_add"));
                    item.is_edit = ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row, "is_edit"));
                    item.is_delete = ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row, "is_delete"));
                    item.is_search = ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row, "is_search"));
                    roleMenu.Add(item);
                }
                ApplicationWebInfo.RoleMenuList = roleMenu;
            }
        }
    }
}