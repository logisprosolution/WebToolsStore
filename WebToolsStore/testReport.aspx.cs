using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebToolsStore
{
    public partial class testReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("ReportReceipt.rpt"));
            rpt.SetParameterValue("header_id", 1);
            this.CrystalReportViewer1.ReportSource = rpt;
        }
    }
}