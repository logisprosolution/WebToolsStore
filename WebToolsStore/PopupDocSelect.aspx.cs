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
    public partial class PopupDocSelect : BasePage
    {
        DocSelectBiz biz = new DocSelectBiz();
        LoadExHelper loadEx = new LoadExHelper();

        protected override void DoPrepareData()
        {
            //1 = supplier , 2= customer
            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
            if (dataId == 1) //รับเข้าจากใยสั่งซื้อ
            {
                ddl_customer.Visible = false;
                lblTypeName.Text = "ชื่อบริษัทคู่ค้า";
                lblTypeDate.Text = "วันที่สั่งซื้อ";
                loadEx.LoadSupplyer(ref ddl_supplier, Enumerator.ConditionLoadEx.All);
            }
            else if (dataId == 2) //เปลี่ยนจากใบขาย
            {
                lblTypeName.Text = "ชื่อลูกค้า";
                lblTypeDate.Text = "วันที่ขาย";
                ddl_supplier.Visible = false;
                loadEx.LoadCustomer(ref ddl_customer, Enumerator.ConditionLoadEx.All);
            }
            else
            {   //ขายจากใบสั่งทำ
                lblTypeName.Text = "ชื่อลูกค้า";
                lblTypeDate.Text = "วันที่สั่งทำ";
                ddl_supplier.Visible = false;
                loadEx.LoadCustomer(ref ddl_customer, Enumerator.ConditionLoadEx.All);
            }

        }

        protected override void DoLoadData()
        {
            BindGridProduct();
        }

        private void BindGridProduct()//โหลดตาราง
        {
            string searchText = txtSearch.Text;
            DateTime? searchDate = null;
            if (txt_header_date.Text != "")
            {
                searchDate =ConvertHelper.ToDateTime(txt_header_date.Text);
            } 
            DataTable dt;
            int id;
            if (dataId == 1)
            {
                id = ConvertHelper.ToInt(ddl_supplier.SelectedValue);
                dt = biz.SelectDocSup(searchText, id, searchDate);
            }
            else if (dataId == 2)
            {
                id = ConvertHelper.ToInt(ddl_customer.SelectedValue);
                dt = biz.SelectDocCus(searchText, id, searchDate);
                
            }
            else
            {
                id = ConvertHelper.ToInt(ddl_customer.SelectedValue);
                dt = biz.SelectDocBookung(searchText, id, searchDate);
            }
            dgv1.DataSource = dt;
            dgv1.DataBind();
        }

        private void BindGridDetail(int id)//โหลดตาราง
        {
            dgv2.DataSource = biz.SelectDetail(id);
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
            string header_id = ((HiddenField)row.FindControl("hdfID")).Value;
            row = null;
            hdfValue.Value = header_id;
            BindGridDetail(ConvertHelper.ToInt(header_id));
        }
    }
}