using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace WebToolsStore
{
    public partial class RoleInfo : BasePage
    {
        #region Parameter
        RoleBiz biz = new RoleBiz();
        const string List_SaveState = "List_SaveState";
        const string List_ShowState = "List_ShowState";
        public List<USR_Role_Submenu> List_Save //ไว้สำหรับsave จะมี row ที่โดนลบด้วย
        {
            get
            {
                if (!(ViewState[List_SaveState] is List<USR_Role_Submenu>))
                {
                    ViewState[List_SaveState] = new List<USR_Role_Submenu>();
                }

                return (List<USR_Role_Submenu>)ViewState[List_SaveState];
            }
            set { ViewState[List_SaveState] = value; }
        }
        public List<USR_Role_Submenu> List_Show  //ไว้สำหรับ bind ลงกริด จะไม่เห็น row ที่ลบ
        {
            get
            {
                if (!(ViewState[List_ShowState] is List<USR_Role_Submenu>))
                {
                    ViewState[List_ShowState] = new List<USR_Role_Submenu>();
                }

                return (List<USR_Role_Submenu>)ViewState[List_ShowState];
            }
            set { ViewState[List_ShowState] = value; }
        }
        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {
            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
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
            dgv1.DataSource = biz.SelectInfo(base.dataId);
            dgv1.DataBind();
        }
        private void BindControl()//โหลดข้อมูล
        {
            //    if (base.dataId != -1)
            //    {
            //        DataTable dt = biz.SelectInfo(base.dataId);
            //        if (ConvertHelper.IsDataExists(dt))
            //        {
            //            DataRow row = dt.Rows[0];
            //            txt_unit_code.Text = ConvertHelper.InitialValueDB(row, "unit_code");
            //            txt_unit_name.Text = ConvertHelper.InitialValueDB(row, "unit_name");
            //            txt_unit_value.Text = ConvertHelper.InitialValueDB(row, "unit_value");
            //            ddl_is_enabled.SelectedValue = ConvertHelper.InitialValueDB(row, "is_enabled");
            //            //txtDescription.Text = ConvertHelper.InitialValueDB(row, "Description");
            //        }
            //        else
            //        {
            //            ShowMessage("ไม่พบข้อมูล");
            //        }
            //    }
        }
        private void SaveInfo()//บันทึก
        {
            try
            {
                RoleModel model = new RoleModel();
                if (base.IsNewMode)
                {
                    model.USR_Role.create_by = ApplicationWebInfo.UserID;
                }
                else
                {
                    model.USR_Role_Submenu.role_id = base.dataId;
                }
                List_Save = new List<USR_Role_Submenu>();
                foreach (GridViewRow row in dgv1.Rows)
                {
                    USR_Role_Submenu item = new USR_Role_Submenu();
                    item.role_id = base.dataId;
                    HiddenField hdf = (HiddenField)row.FindControl("hdfID");
                    int hdfID = ConvertHelper.ToInt(hdf.Value);
                    item.submenu_id = hdfID;
                    CheckBox cb1 = (CheckBox)row.FindControl("is_view");
                    bool is_view = cb1.Checked;
                    item.is_view = is_view;
                    CheckBox cb2 = (CheckBox)row.FindControl("is_add");
                    bool is_add = cb2.Checked;
                    item.is_add = is_add;
                    CheckBox cb3 = (CheckBox)row.FindControl("is_edit");
                    bool is_edit = cb3.Checked;
                    item.is_edit = is_edit;
                    CheckBox cb4 = (CheckBox)row.FindControl("is_delete");
                    bool is_delete = cb4.Checked;
                    item.is_delete = is_delete;
                    CheckBox cb5 = (CheckBox)row.FindControl("is_search");
                    bool is_search = cb5.Checked;
                    item.is_search = is_search;
                    List_Save.Add(item);
                }
                model.RoleSubmenuList = List_Save;
                int newDataId = biz.SaveData(model, base.SAVE_DETAIL, base.IsNewMode);
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
                        base.ShowMessageAndRedirect(SuccessMessage, typeof(RoleList));
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveInfo();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.RedirectToBackPage(typeof(RoleList));
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
                    base.RedirectToPage(typeof(RoleInfo), id);
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
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void all_view_CheckedChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in dgv1.Rows)
            {
                CheckBox chk = (CheckBox)dgv1.HeaderRow.FindControl("all_view");
                CheckBox chk1 = (CheckBox)row.Cells[0].FindControl("is_view");
                if (chk.Checked == true)
                {
                    chk1.Checked = true;
                }
                else
                {
                    chk1.Checked = false;
                }
            }
        }
        protected void all_add_CheckedChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in dgv1.Rows)
            {
                CheckBox chk = (CheckBox)dgv1.HeaderRow.FindControl("all_add");
                CheckBox chk1 = (CheckBox)row.Cells[0].FindControl("is_add");
                if (chk.Checked == true)
                {
                    chk1.Checked = true;
                }
                else
                {
                    chk1.Checked = false;
                }
            }
        }
        protected void all_edit_CheckedChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in dgv1.Rows)
            {
                CheckBox chk = (CheckBox)dgv1.HeaderRow.FindControl("all_edit");
                CheckBox chk1 = (CheckBox)row.Cells[0].FindControl("is_edit");
                if (chk.Checked == true)
                {
                    chk1.Checked = true;
                }
                else
                {
                    chk1.Checked = false;
                }
            }
        }
        protected void all_delete_CheckedChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in dgv1.Rows)
            {
                CheckBox chk = (CheckBox)dgv1.HeaderRow.FindControl("all_delete");
                CheckBox chk1 = (CheckBox)row.Cells[0].FindControl("is_delete");
                if (chk.Checked == true)
                {
                    chk1.Checked = true;
                }
                else
                {
                    chk1.Checked = false;
                }
            }
        }
        protected void all_search_CheckedChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in dgv1.Rows)
            {
                CheckBox chk = (CheckBox)dgv1.HeaderRow.FindControl("all_search");
                CheckBox chk1 = (CheckBox)row.Cells[0].FindControl("is_search");
                if (chk.Checked == true)
                {
                    chk1.Checked = true;
                }
                else
                {
                    chk1.Checked = false;
                }
            }
        }
        #endregion Events
    }
}