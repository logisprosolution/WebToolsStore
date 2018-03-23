using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace WebToolsStore
{
    public partial class ChangeInfo : BasePage
    {
        #region Parameter
        DocBiz biz = new DocBiz();
        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {
            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
            LoadExHelper loadEx = new LoadExHelper();
            //loadEx.LoadVatType(ref ddl_type_vat, Enumerator.ConditionLoadEx.All);
            //loadEx.LoadPaymentType(ref ddl_tpe_buy, Enumerator.ConditionLoadEx.All);

        }

        protected override void DoLoadData()
        {
            if (!IsNewMode)
            {
                BindControl();
            }
            BindGrid();
        }
        #endregion Override Methods

        #region Private Methods
        private void BindGrid()//โหลดตาราง
        {
            dgv1.DataSource = biz.SelectDetail(base.dataId);
            dgv1.DataBind();
        }
        private void BindControl()//โหลดข้อมูล
        {
            if (base.dataId != -1)
            {
                DataTable dt = biz.SelectInfo(base.dataId);
                if (ConvertHelper.IsDataExists(dt))
                {
                    DataRow row = dt.Rows[0];
                    txt_header_code.Text = ConvertHelper.InitialValueDB(row, "header_code");
                    txt_header_date.Text = ConvertHelper.InitialValueDB(row, "header_date");
                    txt_header_name.Text = ConvertHelper.InitialValueDB(row, "header_customer_name");
                    txt_header_code.ReadOnly = true;
                    //ddl_type_vat.SelectedValue = ConvertHelper.InitialValueDB(row, "vat_id");
                    //ddl_tpe_buy.SelectedValue = ConvertHelper.InitialValueDB(row, "payment_id");
                    //txtDescription.Text = ConvertHelper.InitialValueDB(row, "Description");
                }
                else
                {
                    ShowMessage("ไม่พบข้อมูล");
                }
            }
        }
        private void SaveInfo()//บันทึก
        {
            try
            {
                DocModel model = new DocModel();
                if (base.IsNewMode)
                {
                    model.Doc_Header.create_by = ApplicationWebInfo.UserID;
                }
                else
                {
                    model.Doc_Header.header_id = base.dataId;
                }
                model.Doc_Header.header_code = txt_header_code.Text;
                model.Doc_Header.header_date = ConvertHelper.ToDateTime(txt_header_date.Text, ConfigurationInfo.FORMATE_DATE_DISPLAY, ConfigurationInfo.CULTUREINFO_DISPLAY);
                model.Doc_Header.header_customer_name = txt_header_name.Text;
                //model.Doc_Header.vat_id = ConvertHelper.ToInt(ddl_type_vat.SelectedValue);
                //model.Doc_Header.payment_id = ConvertHelper.ToInt(ddl_tpe_buy.SelectedValue);
                model.Doc_Header.is_del = false;
                model.Doc_Header.is_enabled = true;
                //model.Description = txtDescription.Text;
                model.Doc_Header.update_by = ApplicationWebInfo.UserID;
                int newDataId = biz.SaveData(model, base.SAVE_INFO, base.IsNewMode);
                model = null;
                GC.Collect();
                if (newDataId < 0)
                {
                    base.ShowMessage(FailMessage);
                }
                else
                {
                    //base.ShowMessage(SuccessMessage);
                    //if (base.IsNewMode)//บันทึกเสร็จแล้ว new mode จะทำการรีเฟรชข้อมูลใหม่
                    //{
                    //    LoadAfterNewMode(newDataId);
                    //}
                    if (base.IsNewMode)
                    {
                        base.ShowMessageAndRedirect(SuccessMessage, typeof(ChangeList));
                    }
                    else
                    {
                        base.ShowMessage(SuccessMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion Private Methods

        #region Events
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveInfo();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.RedirectToBackPage(typeof(ChangeList));
        }

        protected void dgv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt16(e.CommandArgument);
                GridViewRow row = dgv1.Rows[index];
                string id = ((HiddenField)row.FindControl("hdfID")).Value;
                row = null;
                if (e.CommandName == "Delete")
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
        #endregion Events
    }
}