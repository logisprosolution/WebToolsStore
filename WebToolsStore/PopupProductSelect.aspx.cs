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
    public partial class PopupProductSelect : BasePage
    {
        ProductSelectBiz biz = new ProductSelectBiz();
        LoadExHelper loadEx = new LoadExHelper();

        protected override void DoPrepareData()
        {
            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
            loadEx.LoadCategories(ref ddlCategoryID, Enumerator.ConditionLoadEx.All);
        }

        protected override void DoLoadData()
        {
            //BindGrid("");
            BindGridProduct();
        }

        private void BindGridProduct()//โหลดตาราง
        {
            int productId = base.dataId;
            string searchText = txtSearch.Text;
            int categoryID = ConvertHelper.ToInt(ddlCategoryID.SelectedValue);
            int subCategoryID = ConvertHelper.ToInt(ddlSubCategoryID.SelectedValue);
            dgv1.DataSource = biz.SelectProduct(productId, searchText, categoryID, subCategoryID,0);
            dgv1.DataBind();
        }

        //private void BindGridPrice(int id)//โหลดตาราง
        //{
        //    dgv2.DataSource = biz.SelectPrice(id);
        //    dgv2.DataBind();
        //}

        protected void brnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindGridProduct();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void dgv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = dgv1.SelectedRow.RowIndex;
            GridViewRow row = dgv1.Rows[index];
            int id = ConvertHelper.ToInt(((HiddenField)row.FindControl("hdfID")).Value);
            int unit = ConvertHelper.ToInt(((HiddenField)row.FindControl("hdfUnit")).Value);
            row = null;
            hdfValue.Value = id + "*" + unit;
            //load goods price
            //BindGridPrice(id);
        }

        //protected void dgv2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int index = dgv2.SelectedRow.RowIndex;
        //    GridViewRow row = dgv2.Rows[index];
        //    int product_price_id = ConvertHelper.ToInt(((HiddenField)row.FindControl("hdfProduct_price_id")).Value);
        //    int price = ConvertHelper.ToInt(((HiddenField)row.FindControl("hdfPrice")).Value);

        //    row = null;

        //    hdfValue.Value = product_price_id + "*" + price;
        //}

        protected void ddlCategoryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubCategoryID.SelectedIndex = -1;
            int id = ConvertHelper.ToInt(ddlCategoryID.SelectedValue);
            loadEx.LoadSubcategoriesById(ref ddlSubCategoryID, id, Enumerator.ConditionLoadEx.All);
        }
    }
}