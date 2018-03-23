using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Configuration;

namespace WebToolsStore
{
    public partial class RoleUser : BasePage
    {
        #region Parameter
        RoleBiz biz = new RoleBiz();
        const string List_SaveState = "List_SaveState";
        const string List_ShowState = "List_ShowState";
        public List<USR_User_Role> List_Save //ไว้สำหรับsave จะมี row ที่โดนลบด้วย
        {
            get
            {
                if (!(ViewState[List_SaveState] is List<USR_User_Role>))
                {
                    ViewState[List_SaveState] = new List<USR_User_Role>();
                }

                return (List<USR_User_Role>)ViewState[List_SaveState];
            }
            set { ViewState[List_SaveState] = value; }
        }
        public List<USR_User_Role> List_Show  //ไว้สำหรับ bind ลงกริด จะไม่เห็น row ที่ลบ
        {
            get
            {
                if (!(ViewState[List_ShowState] is List<USR_User_Role>))
                {
                    ViewState[List_ShowState] = new List<USR_User_Role>();
                }

                return (List<USR_User_Role>)ViewState[List_ShowState];
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
            DataTable dt = biz.SelectDetail(base.dataId);
            List_Save = new List<USR_User_Role>();
            foreach (DataRow row in dt.Rows)
            {
                USR_User_Role item = new USR_User_Role()
                {
                    running_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "running_id")),
                    role_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "role_id")),
                    user_id = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "user_id")),
                    user_name = ConvertHelper.InitialValueDB(row, "user_name"),
                    is_del = ConvertHelper.ToBoolean(ConvertHelper.InitialValueDB(row, "is_del")),
                };
                List_Save.Add(item);
            }
            List_Show = List_Save;
            dgv1.DataSource = List_Show;
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
                model.UserRoleList = List_Save;
                int newDataId = biz.SaveData(model, base.SAVE_OTHERS, base.IsNewMode);
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
                    //if (List_Save.Find(x => x.user_id == id).running_id == 0)
                    //{
                    //    base.ShowMessageAndRedirect(SuccessMessage, typeof(RoleList));
                    //}
                    //else
                    //{
                        base.ShowMessage(SuccessMessage);
                    //}
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        private void AddProductToCart(string txt)
        {
            try
            {
                Tuple<int, string> value = FunctionSplitValue(txt);
                int user_id = value.Item1;
                string user_name = value.Item2;
                //if (ConvertHelper.IsDataExists(dt))
                //{
                //    if (!ConvertHelper.ToBoolean(dt.Rows[0], "is_enabled"))
                //    {
                //        //ClearTxtProductBarCode("ไม่สามารถใช้สินค้านี้ได้เนื่องจากถูกปิดการใช้งาน กรุณาติดต่อผู้ดูแลระบบ");
                //        return;
                //    }
                USR_User_Role item = new USR_User_Role()
                {
                    role_id = base.dataId,
                    user_id = user_id,
                    user_name = user_name,
                    is_del = false,
                    is_enabled = true,
                    create_by = ApplicationWebInfo.UserID,
                    update_by = ApplicationWebInfo.UserID,
                };
                //string logStr = GetStringFromObj(item);
                //LogFile.WriteLogFile("", "Transfer", "AddProductToCart", logStr);

                List_Save.Add(item);
                List_Show.Add(item);
                dgv1.DataSource = List_Show;
                dgv1.DataBind();


                item = null;
                GC.Collect();
                //}
                //else
                //{
                //base.DisplayMessageDialogAndFocus("ไม่พบสินค้า", "txtProductBarCode");
                //LogFile.WriteLogFile("", "Transfer", "SelectProduct", "ไม่พบสินค้า");
                //}
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        private Tuple<int, string> FunctionSplitValue(string txt)
        {
            int user_id = 0;
            string user_name = "";
            if (!ConvertHelper.IsStringEmpty(txt))
            {
                if (txt.Contains("*"))
                {
                    string[] arr = txt.Split('*');
                    user_id = ConvertHelper.ToInt(arr[0]);
                    if (arr.Length == 2)
                    {
                        user_name = arr[1];
                    }
                }
                else
                {
                    user_id = 1;
                }
            }
            return Tuple.Create(user_id, user_name);
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
                if (e.CommandName == "Delete")
                {
                    int id = ConvertHelper.ToInt(dgv1.DataKeys[index].Value.ToString());
                    RoleModel model = new RoleModel();
                    if (List_Save.Find(x => x.user_id == id).running_id == 0) // ถ้า new mome ให้ ลบตามลำดับตารางได้เลย
                    {
                        List_Save.RemoveAt(index);
                    }
                    else // ลบโดยหาจากไอดี
                    {
                        List_Save.Find(x => x.user_id == id).is_del = true;
                    }
                    List_Show.RemoveAt(index);
                    dgv1.DataSource = List_Show;
                    dgv1.DataBind();
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
        protected void btnAddHidden_Click(object sender, EventArgs e)
        {
            string txt = hdfValue.Value;
            AddProductToCart(txt);
        }
        #endregion Events
    }
}