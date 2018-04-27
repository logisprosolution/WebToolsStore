using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;

namespace WebToolsStore
{
    public partial class CustomerInfo : BasePage
    {
        #region Parameter
        CustomerBiz biz = new CustomerBiz();
        LoadExHelper loadEx = new LoadExHelper();
        public USR_Role_Submenu roleMenu;
        #endregion Parameter

        #region Override Methods
        protected override void OnPreLoad(EventArgs e)
        {
            roleMenu = ApplicationWebInfo.RoleMenuList.Find(x => x.submenu_id == (int)Enumerator.SubMenu.Customer);
        }
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
                txt_customer_code.ReadOnly = true;
            }
            else
            {
                txt_customer_code.Text = "CUS" + biz.SelectMaxID();
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
                    int provinceID = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "customer_province"));
                    int distictID = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "customer_distict"));
                    loadEx.LoadDistrictById(ref ddl_distict, provinceID, Enumerator.ConditionLoadEx.Else);
                    loadEx.LoadSubDistrictById(ref ddl_subdistict, distictID, Enumerator.ConditionLoadEx.Else);
                    txt_customer_code.Text = ConvertHelper.InitialValueDB(row, "customer_code");
                    txt_customer_name.Text = ConvertHelper.InitialValueDB(row, "customer_name");
                    txt_customer_tel1.Text = ConvertHelper.InitialValueDB(row, "customer_tel1");
                    txt_customer_tel2.Text = ConvertHelper.InitialValueDB(row, "customer_tel2");
                    txt_customer_fax.Text = ConvertHelper.InitialValueDB(row, "customer_fax");
                    txt_customer_email.Text = ConvertHelper.InitialValueDB(row, "customer_email");
                    txt_customer_address.Text = ConvertHelper.InitialValueDB(row, "customer_address");
                    ddl_province.SelectedValue = provinceID.ToString();
                    ddl_distict.SelectedValue = distictID.ToString();
                    ddl_subdistict.SelectedValue = ConvertHelper.InitialValueDB(row, "customer_subdistict");
                    txt_zipcode.Text = ConvertHelper.InitialValueDB(row, "customer_zipcode");
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
                MAS_Customer model = new MAS_Customer();
                if (base.IsNewMode)
                {
                    if (biz.CheckContainID(txt_customer_code.Text))
                    {
                        base.DisplayMessageDialogAndFocus("ไม่สามารถบันทึกรายการได้เนื่องจากรหัสซ้ำ", "txt_customer_code");
                        return;
                    }
                    model.create_by = ApplicationWebInfo.UserID;
                }
                else
                {
                    model.customer_id = base.dataId;
                }
                model.customer_code = txt_customer_code.Text;
                model.customer_name = txt_customer_name.Text;
                model.customer_tel1 = txt_customer_tel1.Text;
                model.customer_tel2 = txt_customer_tel2.Text;
                model.customer_fax = txt_customer_fax.Text;
                model.customer_email = txt_customer_email.Text;
                model.customer_address = txt_customer_address.Text;
                model.customer_subdistict = ConvertHelper.ToInt(ddl_subdistict.SelectedValue);
                model.customer_distict = ConvertHelper.ToInt(ddl_distict.SelectedValue);
                model.customer_province = ConvertHelper.ToInt(ddl_province.SelectedValue);
                model.customer_zipcode = txt_zipcode.Text;
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
                        base.ShowMessageAndRedirect(SuccessMessage, typeof(CustomerList));
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
            base.RedirectToBackPage(typeof(CustomerList));
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
            if (ddl_subdistict.SelectedIndex != 0)
            {
                RequiredSubDistict.Validate();
                txt_zipcode.Text = "";
                int id = ConvertHelper.ToInt(ddl_subdistict.SelectedValue);
                loadEx.LoadZipCode(id, Enumerator.ConditionLoadEx.All, ref txt_zipcode);
            }else
            {
                RequiredSubDistict.Validate();
                txt_zipcode.Text = "";
            }
        }
        #endregion Events
    }
}