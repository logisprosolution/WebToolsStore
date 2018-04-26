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
    public partial class LogFileList : BasePage
    {
        #region Parameter
        DocBiz biz = new DocBiz();
        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {
        }

        protected override void DoLoadData()
        {
            BindGrid();
        }

        #endregion Override Methods

        #region Private Methods
        private void BindGrid()//โหลดตาราง
        {
            string searchText = txtSearch.Text;
            DateTime? searchDate = null;
            if (txt_header_date.Text != "")
            {
                searchDate = ConvertHelper.ToDateTime(txt_header_date.Text);
            }
            dgv1.DataSource = biz.SelectLogFile(searchText,searchDate);
            dgv1.DataBind();
        }

        #endregion Private Methods

        #region Events
        protected void brnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion Events
    }
}