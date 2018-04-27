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
using CrystalDecisions.CrystalReports.Engine;
namespace WebToolsStore
{
    public partial class Main : BasePage
    {
        #region Parameter
        DocBiz biz = new DocBiz();
        #endregion Parameter
        protected override void DoPrepareData()
        {

        }

        protected override void DoLoadData()
        {
            BindGrid("");
        }
        private void BindGrid(string searchText)//โหลดตาราง
        {
            biz.dataModel.SubDoctype_id = ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_OR"].ToString());
            biz.dataModel.Doc_Header.header_status = 1;
            dgv1.DataSource = biz.SelectList(searchText);
            dgv1.DataBind();
        }
        protected void dgv1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
        protected void dgv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
        protected void dgv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgv1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}