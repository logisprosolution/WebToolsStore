using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;

namespace WebToolsStore
{
    public partial class UnitInfo : BasePage
    {
        #region Parameter
        UnitBiz biz = new UnitBiz();
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
                txt_unit_code.ReadOnly = true;
            }
            else
            {
                txt_unit_code.Text = biz.SelectMaxID();
            }
        }

        #endregion Override Methods

        #region Private Methods
        private void BindControl()//โหลดข้อมูล
        {
            if (base.dataId != -1)
            {
                DataTable dt = biz.SelectInfo(base.dataId);
                if (ConvertHelper.IsDataExists(dt))
                {
                    DataRow row = dt.Rows[0];
                    txt_unit_code.Text = ConvertHelper.InitialValueDB(row, "unit_code");
                    txt_unit_name.Text = ConvertHelper.InitialValueDB(row, "unit_name");
                    txt_unit_value.Text = ConvertHelper.InitialValueDB(row, "unit_value");
                    ddl_is_enabled.SelectedValue = ConvertHelper.InitialValueDB(row, "is_enabled");
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
                MAS_Unit model = new MAS_Unit();
                if (base.IsNewMode)
                {
                    if (biz.CheckContainID(txt_unit_code.Text))
                    {
                        base.DisplayMessageDialogAndFocus("ไม่สามารถบันทึกรายการได้เนื่องจากรหัสซ้ำ", "txt_unit_code");
                        return;
                    }
                    model.create_by = ApplicationWebInfo.UserID;
                }
                else
                {
                    model.unit_id = base.dataId;
                }
                model.unit_code = txt_unit_code.Text;
                model.unit_name = txt_unit_name.Text;
                model.unit_value = ConvertHelper.ToInt(txt_unit_value.Text.Trim());
                model.is_del = false;
                model.is_enabled = ConvertHelper.ToBoolean(ddl_is_enabled.SelectedValue);
                //model.Description = txtDescription.Text;
                model.update_by = ApplicationWebInfo.UserID;
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
                        base.ShowMessageAndRedirect(SuccessMessage, typeof(UnitList));
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
            base.RedirectToBackPage(typeof(UnitList));
        }
        #endregion Events
    }
}