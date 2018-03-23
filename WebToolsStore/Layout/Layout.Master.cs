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