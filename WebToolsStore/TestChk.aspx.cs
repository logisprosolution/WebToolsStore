using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;

namespace WebToolsStore
{
    public partial class TestChk : BasePage
    {
        ProductBiz biz = new ProductBiz();
        const string IngredientList_SaveState = "IngredientList_SaveState";
        const string IngredientList_ShowState = "IngredientList_ShowState";
        public List<MAS_Ingredient> IngredientList_Save //ไว้สำหรับsave จะมี row ที่โดนลบด้วย
        {
            get
            {
                if (!(ViewState[IngredientList_SaveState] is List<MAS_Ingredient>))
                {
                    ViewState[IngredientList_SaveState] = new List<MAS_Ingredient>();
                }

                return (List<MAS_Ingredient>)ViewState[IngredientList_SaveState];
            }
            set { ViewState[IngredientList_SaveState] = value; }
        }
        public List<MAS_Ingredient> IngredientList_Show  //ไว้สำหรับ bind ลงกริด จะไม่เห็น row ที่ลบ
        {
            get
            {
                if (!(ViewState[IngredientList_ShowState] is List<MAS_Ingredient>))
                {
                    ViewState[IngredientList_ShowState] = new List<MAS_Ingredient>();
                }

                return (List<MAS_Ingredient>)ViewState[IngredientList_ShowState];
            }
            set { ViewState[IngredientList_ShowState] = value; }
        }
        protected override void DoPrepareData()
        {
            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
            //LoadExHelper loadEx = new LoadExHelper();
        }
        protected override void DoLoadData()
        {
            BindGrid1();
        }
        private void BindGrid1()//โหลดตาราง
        {
            DataTable dt = biz.SelectDetail(base.dataId);
            dgv1.DataSource = dt;
            dgv1.DataBind();
        }
        protected void dgv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt16(e.CommandArgument);
                GridViewRow row = dgv1.Rows[index];
                string id = ((HiddenField)row.FindControl("hdfID")).Value;
                row = null;
                if (e.CommandName == "Edit")
                {
                    base.SetBackURL();
                    string queryString = "dataId2=" + base.dataId;
                    base.RedirectToPage(typeof(ProductPriceInfo), id, queryString);
                }
                else if (e.CommandName == "Delete")
                {
                    int result = biz.DeleteDetail(ConvertHelper.ToInt(id), ApplicationWebInfo.UserID.ToString(), base.DELETE_DETAIL);
                    if (result < 0)
                    {
                        base.ShowMessage(FailMessage);
                    }
                    else
                    {
                        base.ShowMessage(SuccessMessage);
                        DoLoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void dgv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgv1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        public void chkStatus_OnCheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chkview_CheckedChanged(object sender, EventArgs e)
        {
            //Define your code here.
        }
    }
}