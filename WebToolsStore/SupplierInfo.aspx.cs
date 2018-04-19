using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;

namespace WebToolsStore
{
    public partial class SupplierInfo : BasePage
    {
        #region Parameter
        SupplierBiz biz = new SupplierBiz();
        LoadExHelper loadEx = new LoadExHelper();
        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {
            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
            loadEx.LoadProvince(ref ddl_province, Enumerator.ConditionLoadEx.All);
        }

        protected override void DoLoadData()
        {
            if (!IsNewMode)
            {
                BindControl();
                txt_supplier_code.ReadOnly = true;
            }
            else
            {
                txt_supplier_code.Text = biz.SelectMaxID();
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
                    int provinceID = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "supplier_province"));
                    int distictID = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "supplier_distict"));
                    loadEx.LoadDistrictById(ref ddl_distict, provinceID, Enumerator.ConditionLoadEx.Else);
                    loadEx.LoadSubDistrictById(ref ddl_subdistict, distictID, Enumerator.ConditionLoadEx.Else);
                    txt_supplier_code.Text = ConvertHelper.InitialValueDB(row, "supplier_code");
                    txt_supplier_name.Text = ConvertHelper.InitialValueDB(row, "supplier_name");
                    txt_supplier_tel1.Text = ConvertHelper.InitialValueDB(row, "supplier_tel1");
                    txt_supplier_tel2.Text = ConvertHelper.InitialValueDB(row, "supplier_tel2");
                    txt_supplier_fax.Text = ConvertHelper.InitialValueDB(row, "supplier_fax");
                    txt_supplier_email.Text = ConvertHelper.InitialValueDB(row, "supplier_email");
                    txt_supplier_address.Text = ConvertHelper.InitialValueDB(row, "supplier_address");
                    ddl_province.SelectedValue = provinceID.ToString();
                    ddl_distict.SelectedValue = distictID.ToString();
                    ddl_subdistict.SelectedValue = ConvertHelper.InitialValueDB(row, "supplier_subdistict");
                    txt_zipcode.Text = ConvertHelper.InitialValueDB(row, "supplier_zipcode");
                    txtdescription.Text = ConvertHelper.InitialValueDB(row, "description");
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
                MAS_Supplier model = new MAS_Supplier();
                if (base.IsNewMode)
                {
                    if (biz.CheckContainID(txt_supplier_code.Text))
                    {
                        base.DisplayMessageDialogAndFocus("ไม่สามารถบันทึกรายการได้เนื่องจากรหัสซ้ำ", "txt_supplier_code");
                        return;
                    }
                    model.create_by = ApplicationWebInfo.UserID;
                }
                else
                {
                    model.supplier_id = base.dataId;
                }
                model.supplier_code = txt_supplier_code.Text;
                model.supplier_name = txt_supplier_name.Text;
                model.supplier_tel1 = txt_supplier_tel1.Text;
                model.supplier_tel2 = txt_supplier_tel2.Text;
                model.supplier_fax = txt_supplier_fax.Text;
                model.supplier_email = txt_supplier_email.Text;
                model.supplier_address = txt_supplier_address.Text;
                model.supplier_subdistict = ConvertHelper.ToInt(ddl_subdistict.SelectedValue);
                model.supplier_distict = ConvertHelper.ToInt(ddl_distict.SelectedValue);
                model.supplier_province = ConvertHelper.ToInt(ddl_province.SelectedValue);
                model.supplier_zipcode = txt_zipcode.Text;
                model.description = txtdescription.Text;
                model.is_del = false;
                model.is_enabled = true;
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
                        base.ShowMessageAndRedirect(SuccessMessage, typeof(SupplierList));
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
            base.RedirectToBackPage(typeof(SupplierList));
        }
        protected void ddl_province_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_distict.SelectedIndex = -1;
            ddl_subdistict.SelectedIndex = -1;
            RequiredProvince.Validate();
            txt_zipcode.Text = "";
            int id = ConvertHelper.ToInt(ddl_province.SelectedValue);
            loadEx.LoadDistrictById(ref ddl_distict, id, Enumerator.ConditionLoadEx.All);
        }

        protected void ddl_distict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_subdistict.SelectedIndex = -1;
            RequiredDistict.Validate();
            txt_zipcode.Text = "";
            int id = ConvertHelper.ToInt(ddl_distict.SelectedValue);
            loadEx.LoadSubDistrictById(ref ddl_subdistict, id, Enumerator.ConditionLoadEx.All);

        }

        protected void ddl_subdistict_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequiredSubDistict.Validate();
            txt_zipcode.Text = "";
            int id = ConvertHelper.ToInt(ddl_subdistict.SelectedValue);
            loadEx.LoadZipCode(id, Enumerator.ConditionLoadEx.All, ref txt_zipcode);
        }
        #endregion Events
    }
}