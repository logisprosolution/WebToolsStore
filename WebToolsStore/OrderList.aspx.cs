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
    public partial class OrderList : BasePage
    {
        #region Parameter
        DocBiz biz = new DocBiz();
        const string CartList_SaveState = "CartList_SaveState";
        const string CartList_ShowState = "CartList_ShowState";
        public List<DOC_Detail> CartList_Save //ไว้สำหรับsave จะมี row ที่โดนลบด้วย
        {
            get
            {
                if (!(ViewState[CartList_SaveState] is List<DOC_Detail>))
                {
                    ViewState[CartList_SaveState] = new List<DOC_Detail>();
                }

                return (List<DOC_Detail>)ViewState[CartList_SaveState];
            }
            set { ViewState[CartList_SaveState] = value; }
        }
        public List<DOC_Detail> CartList_Show  //ไว้สำหรับ bind ลงกริด จะไม่เห็น row ที่ลบ
        {
            get
            {
                if (!(ViewState[CartList_ShowState] is List<DOC_Detail>))
                {
                    ViewState[CartList_ShowState] = new List<DOC_Detail>();
                }

                return (List<DOC_Detail>)ViewState[CartList_ShowState];
            }
            set { ViewState[CartList_ShowState] = value; }
        }

        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {
        }

        protected override void DoLoadData()
        {
            BindGrid("");
        }

        #endregion Override Methods

        #region Private Methods
        private void BindGrid(string searchText)//โหลดตาราง
        {
            biz.dataModel.SubDoctype_id = ConvertHelper.ToInt(ConfigurationManager.AppSettings["SubDocTypeID_OR"].ToString());
            dgv1.DataSource = biz.SelectList(searchText);
            dgv1.DataBind();
        }
        private void UpdateStatus()//โหลดข้อมูล
        {
            int result = biz.SaveData(biz.dataModel, "done", false);
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
        private void DrawOrder()//โหลดข้อมูล
        {
            int result = biz.SaveData(biz.dataModel, "draw", false);
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
        #endregion Private Methods

        #region Events
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                base.SetBackURL();
                base.RedirectToPage(typeof(OrderInfo), null);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void dgv1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label staus = e.Row.FindControl("lbl_status") as Label;
                    if (staus.Text == "อยู่ระหว่างดำเนินการ")
                    {
                        LinkButton btn = e.Row.FindControl("btnGridSuccess") as LinkButton;
                        btn.Attributes.Add("disabled", "true");
                    }
                    else
                    {
                        if (staus.Text == "เสร็จสมบูรณ์")
                        {
                            LinkButton btn = e.Row.FindControl("btnGridSuccess") as LinkButton;
                            btn.Attributes.Add("disabled", "true");
                        }
                        LinkButton btnWait = e.Row.FindControl("btnGridWait") as LinkButton;
                        btnWait.Attributes.Add("disabled", "true");
                        LinkButton btnEdit = e.Row.FindControl("btnGridEdit") as LinkButton;
                        btnEdit.Attributes.Add("disabled", "true");
                        LinkButton btnDelete = e.Row.FindControl("btnGridDelete") as LinkButton;
                        btnDelete.Attributes.Add("disabled", "true");
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void dgv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt16(e.CommandArgument);
                GridViewRow row = dgv1.Rows[index];
                string id = ((HiddenField)row.FindControl("hdfID")).Value;
                biz.dataModel.Doc_Header.header_id = ConvertHelper.ToInt(id);
                row = null;
                if (e.CommandName == "Edit")
                {
                    base.SetBackURL();
                    base.RedirectToPage(typeof(OrderInfo), id);
                }
                else if (e.CommandName == "Delete")
                {
                    int result = biz.DeleteData(ConvertHelper.ToInt(id), ApplicationWebInfo.UserID.ToString(), base.DELETE_LIST);
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
                else if (e.CommandName == "Print")
                {
                    ReportBiz biz = new ReportBiz();
                    ReportDocument crystalReport = new ReportDocument();
                    crystalReport.Load(Server.MapPath("Reports/ReportReceive.rpt"));
                    DataSet ds = biz.SelectBill(ConvertHelper.ToInt(id));
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
                else if (e.CommandName == "Wait")
                {
                    biz.dataModel.Doc_Header.header_status = 11;
                    DrawOrder();
                }
                else if (e.CommandName == "Success")
                {
                    biz.dataModel.Doc_Header.header_status = 2;
                    UpdateStatus();
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

        #endregion Events
    }
}