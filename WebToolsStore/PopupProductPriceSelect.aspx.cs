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

namespace WebToolsStore
{
    public partial class PopupProductPriceSelect : BasePage
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
            BindGridProduct();
        }

        private void BindGridProduct()//โหลดตาราง
        {
            string searchText = txtSearch.Text;
            int categoryID = ConvertHelper.ToInt(ddlCategoryID.SelectedValue);
            int subCategoryID = ConvertHelper.ToInt(ddlSubCategoryID.SelectedValue);
            dgv1.DataSource = biz.SelectProduct(searchText, categoryID, subCategoryID, 0);
            dgv1.DataBind();
        }

        private void BindGridPrice(int id)//โหลดตาราง
        {
            dgv2.DataSource = biz.SelectPrice(id);
            dgv2.DataBind();
        }

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
            row = null;
            //load goods price
            BindGridPrice(id);
            subtitle.Style.Add("display", "block");
            ddlprice.Items.Clear();
        }

        protected void dgv2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlprice.Items.Clear();
            int index = dgv2.SelectedRow.RowIndex;
            GridViewRow row = dgv2.Rows[index];
            int product_price_id = ConvertHelper.ToInt(((HiddenField)row.FindControl("hdfproduct_price_id")).Value);
            //int price = ConvertHelper.ToInt(((HiddenField)row.FindControl("hdfprice")).Value);
            int unit_valuue = ConvertHelper.ToInt(((HiddenField)row.FindControl("hdfunit")).Value);
            int stock = ConvertHelper.ToInt(((Label)row.FindControl("lblstock")).Text);

            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem(dgv2.HeaderRow.Cells[5].Text + " " + row.Cells[5].Text, row.Cells[5].Text));
            items.Add(new ListItem(dgv2.HeaderRow.Cells[6].Text + " " + row.Cells[6].Text, row.Cells[6].Text));
            items.Add(new ListItem(dgv2.HeaderRow.Cells[7].Text + " " + row.Cells[7].Text, row.Cells[7].Text));
            ddlprice.Items.AddRange(items.ToArray());
            if (base.dataId == ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_SaleCredit"].ToString()))
            {
                ddlprice.SelectedIndex = 1;
            }
            is_stock.Value = "0";
            row = null;

            if (stock <= 0 && base.dataId != ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_BO"].ToString()) && base.dataId != ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_InFromBuy"].ToString()))
            {
                is_stock.Value = "1";
                base.ShowMessage("จำนวนสินค้าไม่พอ");
            }
            else
            {
                is_stock.Value = "0";
                hdfValue.Value = product_price_id + "*" + unit_valuue;
            }
        }

        protected void ddlCategoryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubCategoryID.SelectedIndex = -1;
            int id = ConvertHelper.ToInt(ddlCategoryID.SelectedValue);
            loadEx.LoadSubcategoriesById(ref ddlSubCategoryID, id, Enumerator.ConditionLoadEx.All);
        }
    }
}