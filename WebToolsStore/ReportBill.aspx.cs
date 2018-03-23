using AT.Framework;
using CrystalDecisions.CrystalReports.Engine;
using WebToolsStore.Biz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebToolsStore.Data;

namespace WebToolsStore
{
    public partial class ReportBill : BasePage
    {
        protected override void DoLoadData()
        {
            bindCrystal();
        }

        public void bindCrystal()
        {
            try
            {
                //ReportDS ds = new ReportDS();
                //ReportDocument rptDoc = new ReportDocument();
                //LoadExHelperBiz biz = new LoadExHelperBiz();
                //DataTable dt = biz.SelectReportBill();
                //ds.Tables["v_bill"].Merge(dt);
                //rptDoc.Load(Server.MapPath("/Reports/ReportReceipt.rpt"));
                //string IP = ConfigurationManager.AppSettings["IP"];
                //string DB_Name = ConfigurationManager.AppSettings["DB_Name"];
                //string User = ConfigurationManager.AppSettings["User"];
                //string Password = ConfigurationManager.AppSettings["Password"];
                //rptDoc.SetDatabaseLogon(User, Password, IP, DB_Name);
                //rptDoc.SetDataSource(ds);
                //CrystalReportViewer1.ReportSource = rptDoc;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}