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
    public partial class PopupProductIngredient : BasePage
    {
        ProductIngredientBiz biz = new ProductIngredientBiz();

        protected override void DoPrepareData()
        {
            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
        }

        protected override void DoLoadData()
        {
            //BindGrid("");
            BindGrid(dataId);
        }

        private void BindGrid(int id)//โหลดตาราง
        {
            dgv1.DataSource = biz.SelectInfo(id);
            dgv1.DataBind();
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            //int index = dgv1.SelectedRow.RowIndex;
            //GridViewRow row = dgv1.Rows[index];
            //int id = ConvertHelper.ToInt(((HiddenField)row.FindControl("hdfID")).Value);
            //row = null;
            ////load goods price
            //BindGrid(id);
        }
    }
}