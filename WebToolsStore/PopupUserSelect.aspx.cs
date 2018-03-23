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
    public partial class PopupUserSelect : BasePage
    {
        UserBiz biz = new UserBiz();
        LoadExHelper loadEx = new LoadExHelper();

        protected override void DoPrepareData()
        {
            //1 = supplier , 2= customer
            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
            //if (dataId == 1)
            //{
            //    ddl_customer.Visible = false;
            //    lblTypeName.Text = "ชื่อบริษัทคู่ค้า";
            //    lblTypeDate.Text = "วันที่สั่งซื้อ";
            //    loadEx.LoadSupplyer(ref ddl_supplier, Enumerator.ConditionLoadEx.All);
            //}
            //else if (dataId == 2)
            //{
            //    lblTypeName.Text = "ชื่อลูกค้า";
            //    lblTypeDate.Text = "วันที่ขาย";
            //    ddl_supplier.Visible = false;
            //    loadEx.LoadCustomer(ref ddl_customer, Enumerator.ConditionLoadEx.All);
            //}
            //else
            //{
            //    lblTypeName.Text = "ชื่อลูกค้า";
            //    lblTypeDate.Text = "วันที่สั่งทำ";
            //    ddl_supplier.Visible = false;
            //    loadEx.LoadCustomer(ref ddl_customer, Enumerator.ConditionLoadEx.All);
            //}

        }

        protected override void DoLoadData()
        {
            BindGrid("");
        }

        private void BindGrid(string searchText)//โหลดตาราง
        {
            dgv1.DataSource = biz.SelectList(searchText);
            dgv1.DataBind();
        }

        protected void brnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid(txtSearch.Text);
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
            int user_id = ConvertHelper.ToInt(((HiddenField)row.FindControl("hdfID")).Value);
            string user_name = ((HiddenField)row.FindControl("hdfName")).Value;
            row = null;
            hdfValue.Value = user_id + "*" + user_name;
        }
    }
}