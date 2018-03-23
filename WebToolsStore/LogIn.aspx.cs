using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebToolsStore.Biz;
using AT.Framework;
using System.Data;

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
            biz.dataModel.user_name = txtUsername.Text.Trim();
            biz.dataModel.user_password = txtPassword.Text.Trim();
            DataTable dt = biz.SelectLogin();
            if (dt.Rows.Count == 0)
            {
                base.ShowMessage("ชื่อเข้าใช้หรือรหัสผ่านไม่ถูกต้อง");
            }
            else
            {
                Session["UserID"] =  ConvertHelper.ToInt(dt.Rows[0]["user_id"]);
                Session["UserDisplayName"] = dt.Rows[0]["user_namedis"].ToString();
                Session["UserProfileID"] = dt.Rows[0]["user_profile_id"].ToString();
                base.RedirectToPage(typeof(Main));
            }
        }
    }
}