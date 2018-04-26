using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using AT.Framework;
using WebToolsStore.Biz;
//using Microsoft.Reporting.WebForms;

namespace WebToolsStore
{
    public partial class Report_TransAll : BasePage
    {
        LoadExHelper loadEx = new LoadExHelper();
        private string Header
        {
            get
            {
                if (ViewState["Header"] == null)
                    return "";
                else
                {
                    return ViewState["Header"].ToString();
                }
            }
            set {
                ViewState["Header"] = value;
            }
        }

        protected override void DoPrepareData()
        {
            //int companyID = ConvertHelper.ToInt(ConfigurationManager.AppSettings["CompanyID"]);
            //loadEx.LoadDocType(ref ddlDocTypeID, Enumerator.ConditionLoadEx.None);//ประเภทเอกสาร
            loadEx.LoadWarehouse(ref ddlWarehouseID, Enumerator.ConditionLoadEx.None);//คลัง
            loadEx.LoadProduct(ref ddlProductID, Enumerator.ConditionLoadEx.None);//สินค้า
            loadEx.LoadSubDocType(0, ref ddlSubDocTypeID, Enumerator.ConditionLoadEx.None);//คลัง
            Header = "รายงาน";
            txtDateFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            loadEx = null;
        }

        protected override void DoLoadData()
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //ReportDocument crystalReport = new ReportDocument();
                //crystalReport.Load(Server.MapPath("~/Reports/TransAll.rpt"));

                //DataSet ds = SearchTransAll();
                //crystalReport.SetDataSource(ds.Tables[0]);
                //crystalReport.SetDatabaseLogon(ApplicationWebInfo.UserID.ToString(), ApplicationWebInfo.UserPassword);
                //CrystalReportViewer1.ReportSource = crystalReport;
                //CrystalReportViewer1.DisplayToolbar = true;

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlDocTypeID.SelectedIndex != 0)
                {
                    Header = "รายงาน" + ddlDocTypeID.SelectedItem.Text;
                }
                else
                {
                    Header = "รายงาน";
                }
                LogFile.WriteLogFile("", "Report_TransAll", "LoadReport", Server.MapPath("Reports/TransAll.rpt"));
                LoadReport(true, Header);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private DataSet SearchTransAll()
        {
            ReportBiz biz = new ReportBiz();
            //int shopID = ConvertHelper.ToInt(ConfigurationManager.AppSettings["ShopID"]);
            biz.dataModel.DocTypeID = ConvertHelper.ToInt(ddlDocTypeID.SelectedValue);
            biz.dataModel.WareHouseID = ConvertHelper.ToInt(ddlWarehouseID.SelectedValue);
            biz.dataModel.ProductID = ConvertHelper.ToInt(ddlProductID.SelectedValue);
            biz.dataModel.SubDocTypeID = ConvertHelper.ToInt(ddlSubDocTypeID.SelectedValue);
            biz.dataModel.Header_date_from = txtDateFrom.Text;
            biz.dataModel.Header_date_to = txtDateTo.Text;
            return biz.SelectTransAll();
        }

        private void LoadReport(bool isPrint, string header)
        {
            ReportDocument crystalReport = new ReportDocument();
            //LogFile.WriteLogFile("", "Report_TransAll", "LoadReport", "before load");
            crystalReport.Load(Server.MapPath("Reports/ReportDailySell.rpt"));
            //LogFile.WriteLogFile("", "Report_TransAll", "LoadReport", "load success");
            DataSet ds = SearchTransAll();
            if (ds.Tables[0].Rows.Count == 0)
            {
                base.ShowMessage("ไม่พบเอกสาร");
            }
            else
            {
                crystalReport.SetDataSource(ds);
                //set parameter after load source
                //crystalReport.SetParameterValue("header", header);
                //CrystalReportViewer1.ReportSource = crystalReport;
                if (isPrint)
                {
                    crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, System.Guid.NewGuid().ToString());
                }
            }
        }

        protected void ddlDocTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DocTypeID = ConvertHelper.ToInt(ddlDocTypeID.SelectedValue);
            loadEx.LoadSubDocType(DocTypeID, ref ddlSubDocTypeID, Enumerator.ConditionLoadEx.None);//คลัง
            //loadEx = null;
        }
    }
}