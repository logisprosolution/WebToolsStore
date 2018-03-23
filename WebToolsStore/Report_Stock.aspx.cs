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
    public partial class Report_Stock : BasePage
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
            loadEx.LoadCategories(ref ddlCategoryID, Enumerator.ConditionLoadEx.All);
            loadEx.LoadWarehouse(ref ddlWarehouseID, Enumerator.ConditionLoadEx.None);//คลัง
            loadEx = null;
        }

        protected override void DoLoadData()
        {
            
        }
        private void BindGridProduct()//โหลดตาราง
        {
            ProductSelectBiz biz = new ProductSelectBiz();
            string searchText = txtSearch.Text;
            int categoryID = ConvertHelper.ToInt(ddlCategoryID.SelectedValue);
            int subCategoryID = ConvertHelper.ToInt(ddlSubCategoryID.SelectedValue);
            int warehouseID = ConvertHelper.ToInt(ddlWarehouseID.SelectedValue);
            dgv1.DataSource = biz.SelectProductStock(searchText, categoryID, subCategoryID,warehouseID);
            dgv1.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindGridProduct();
                //table.Style.Add("display", "none");
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
                //if (ddlCategoryID.SelectedIndex != 0)
                //{
                //    Header = "รายงาน" + ddlDocTypeID.SelectedItem.Text;
                //}
                //else
                //{
                //    Header = "รายงาน";
                //}
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
            biz.dataModel.SearchText = txtSearch.Text;
            biz.dataModel.CategoryID = ConvertHelper.ToInt(ddlCategoryID.SelectedValue);
            biz.dataModel.SubcategoryID = ConvertHelper.ToInt(ddlSubCategoryID.SelectedValue);
            biz.dataModel.WareHouseID = ConvertHelper.ToInt(ddlWarehouseID.SelectedValue);
            return biz.SelectStock(0);
        }
        private void LoadReport(bool isPrint, string header)
        {
            ReportDocument crystalReport = new ReportDocument();
            //LogFile.WriteLogFile("", "Report_TransAll", "LoadReport", "before load");
            crystalReport.Load(Server.MapPath("Reports/ReportStock.rpt"));
            //LogFile.WriteLogFile("", "Report_TransAll", "LoadReport", "load success");
            DataSet ds = SearchTransAll();
            if (ds == null)
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
        protected void ddlCategoryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubCategoryID.SelectedIndex = -1;
            int id = ConvertHelper.ToInt(ddlCategoryID.SelectedValue);
            loadEx.LoadSubcategoriesById(ref ddlSubCategoryID, id, Enumerator.ConditionLoadEx.All);
            loadEx = null;
        }
        protected void dgv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportBiz biz = new ReportBiz();
            int index = dgv1.SelectedRow.RowIndex;
            GridViewRow row = dgv1.Rows[index];
            int id = ConvertHelper.ToInt(((HiddenField)row.FindControl("hdfID")).Value);
            //DataSet SearchTransAll = biz.SelectStock(id);
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("Reports/ReportStock.rpt"));
            biz.dataModel.SearchText = txtSearch.Text;
            biz.dataModel.CategoryID = ConvertHelper.ToInt(ddlCategoryID.SelectedValue);
            biz.dataModel.SubcategoryID = ConvertHelper.ToInt(ddlSubCategoryID.SelectedValue);
            biz.dataModel.WareHouseID = ConvertHelper.ToInt(ddlWarehouseID.SelectedValue);
            DataSet ds = biz.SelectStock(id);
            if (ds.Tables[0].Rows.Count == 0)
            {
                base.ShowMessage("ไม่พบเอกสาร");
            }
            else
            {
                crystalReport.SetDataSource(ds);
                if (true)
                {
                    crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, System.Guid.NewGuid().ToString());
                }
            }
        }
        //protected void ddlShop_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int shopID = ConvertHelper.ToInt(ddlShop.SelectedValue);
        //    LoadExHelper loadEx = new LoadExHelper();
        //    loadEx.LoadWarehouse(shopID, ref ddlWarehouseID, Enumerator.ConditionLoadEx.None);//คลัง
        //    loadEx = null;
        //}
    }
}