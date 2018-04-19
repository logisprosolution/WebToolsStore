using System;
using AT.Framework;
using WebToolsStore.Data;
using WebToolsStore.Biz;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;

namespace WebToolsStore
{
    public partial class EmployeeInfo : BasePage
    {
        #region Parameter
        UserBiz biz = new UserBiz();
        LoadExHelper loadEx = new LoadExHelper();
        #endregion Parameter

        #region Override Methods
        protected override void DoPrepareData()
        {

            base.dataId = ConvertHelper.ToInt(Request.QueryString["dataId"]);
            loadEx.LoadTitle(ref ddl_title, Enumerator.ConditionLoadEx.All);
            loadEx.LoadProvince(ref ddl_province, Enumerator.ConditionLoadEx.All);
            txt_user_password.Attributes["type"] = "password";
            //Image1.Attributes["onchange"] = "UploadFile(this)";
        }

        protected override void DoLoadData()
        {
            if (!IsNewMode)
            {
                BindControl();
                txt_emp_code.ReadOnly = true;
            }
            else
            {
                txt_emp_code.Text = biz.SelectMaxID();
            }
        }

        #endregion Override Methods

        #region Private Methods
        private byte[] UploadImage()
        {
            FileUpload img = (FileUpload)imgUpload;
            Byte[] imgByte = null;
            if (img.HasFile && img.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = imgUpload.PostedFile;
                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];
                //force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);
                txt_FileName.Text = File.FileName.ToString();
            }
            return imgByte;
        }
        private void BindControl()//โหลดข้อมูล
        {
            if (base.dataId != -1)
            {
                DataTable dt = biz.SelectInfo(base.dataId);
                if (ConvertHelper.IsDataExists(dt))
                {
                    DataRow row = dt.Rows[0];

                    int provinceID = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "province"));
                    int distictID = ConvertHelper.ToInt(ConvertHelper.InitialValueDB(row, "distict"));
                    loadEx.LoadDistrictById(ref ddl_distict, provinceID, Enumerator.ConditionLoadEx.Else);
                    loadEx.LoadSubDistrictById(ref ddl_subdistict, distictID, Enumerator.ConditionLoadEx.Else);

                    txt_emp_code.Text = ConvertHelper.InitialValueDB(row, "emp_code");
                    ddl_title.SelectedValue = ConvertHelper.InitialValueDB(row, "title_id");
                    txt_emp_name.Text = ConvertHelper.InitialValueDB(row, "name");
                    txt_emp_last.Text = ConvertHelper.InitialValueDB(row, "lastname");
                    txt_emp_age.Text = ConvertHelper.InitialValueDB(row, "age");
                    txt_emp_birth.Text = ConvertHelper.InitialValueDB(row, "bithdate");
                    txt_emp_card.Text = ConvertHelper.InitialValueDB(row, "card");
                    txt_emp_tel.Text = ConvertHelper.InitialValueDB(row, "tel");
                    txt_emp_email.Text = ConvertHelper.InitialValueDB(row, "email");
                    txt_emp_address.Text = ConvertHelper.InitialValueDB(row, "address");
                    ddl_province.SelectedValue = provinceID.ToString();
                    ddl_distict.SelectedValue = distictID.ToString();
                    ddl_subdistict.SelectedValue = ConvertHelper.InitialValueDB(row, "subdistict");
                    txt_zipcode.Text = ConvertHelper.InitialValueDB(row, "zipcode");
                    txt_FileName.Text = ConvertHelper.InitialValueDB(row, "pic_filename");
                    txtdescription.Text = ConvertHelper.InitialValueDB(row, "description");
                    txt_user_name.Text = ConvertHelper.InitialValueDB(row, "user_name");
                    txt_user_password.Text = ConvertHelper.InitialValueDB(row, "user_password");
                    txt_user_disname.Text = ConvertHelper.InitialValueDB(row, "user_namedis");
                    //ddl_type.SelectedValue = ConvertHelper.InitialValueDB(row, "user_type");
                    is_enabled.Checked = ConvertHelper.ToBoolean(row, "is_enabled");
                    ViewState["image"] = ConvertHelper.InitialValueDB(row, "pic");
                    Image1.ImageUrl = "~/ShowImage.ashx?dataId=" + base.dataId;
                    Image1.Attributes.Add("FileName", "aaaasssss");
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
                UserModel model = new UserModel();
                if (base.IsNewMode)
                {
                    if (biz.CheckContainID(txt_emp_code.Text))
                    {
                        base.DisplayMessageDialogAndFocus("ไม่สามารถบันทึกรายการได้เนื่องจากรหัสซ้ำ", "txt_emp_code");
                        return;
                    }
                    model.USR_User_Profile.create_by = ApplicationWebInfo.UserID;
                    model.USR_User.create_by = ApplicationWebInfo.UserID;
                }
                else
                {
                    model.USR_User_Profile.user_profile_id = base.dataId;
                    model.USR_User.user_id = base.dataId;
                }
                model.USR_User_Profile.title_id = ConvertHelper.ToInt(ddl_title.SelectedValue);
                model.USR_User_Profile.emp_code = txt_emp_code.Text;
                model.USR_User_Profile.name = txt_emp_name.Text;
                model.USR_User_Profile.lastname = txt_emp_last.Text;
                model.USR_User_Profile.age = ConvertHelper.ToInt(txt_emp_age.Text);
                model.USR_User_Profile.bithdate = ConvertHelper.ToDateTime(txt_emp_birth.Text, ConfigurationInfo.FORMATE_DATE_DISPLAY, ConfigurationInfo.CULTUREINFO_DISPLAY);
                model.USR_User_Profile.card = txt_emp_card.Text;
                model.USR_User_Profile.tel = txt_emp_tel.Text;
                model.USR_User_Profile.email = txt_emp_email.Text;
                model.USR_User_Profile.address = txt_emp_address.Text;
                model.USR_User_Profile.subdistict = ConvertHelper.ToInt(ddl_subdistict.SelectedValue);
                model.USR_User_Profile.distict = ConvertHelper.ToInt(ddl_distict.SelectedValue);
                model.USR_User_Profile.province = ConvertHelper.ToInt(ddl_province.SelectedValue);
                model.USR_User_Profile.zipcode = txt_zipcode.Text;
                model.USR_User_Profile.pic = UploadImage();
                if (model.USR_User_Profile.pic == null)
                {
                   model.USR_User_Profile.pic = ViewState["image"] != null ? (byte[])ViewState["image"] : null;
                }
                model.USR_User_Profile.pic_filename = txt_FileName.Text;
                model.USR_User_Profile.description = txtdescription.Text;
                model.USR_User_Profile.is_del = false;
                model.USR_User_Profile.is_enabled = ConvertHelper.ToBoolean(is_enabled.Checked);
                model.USR_User_Profile.update_by = ApplicationWebInfo.UserID;
                //----------------USER--------------------//
                model.USR_User.user_name = txt_user_name.Text;
                model.USR_User.user_password = txt_user_password.Text;
                model.USR_User.user_namedis = txt_user_disname.Text;
                model.USR_User.user_type = 0;
                model.USR_User.is_del = false;
                model.USR_User.is_enabled = ConvertHelper.ToBoolean(is_enabled.Checked);
                model.USR_User.update_by = ApplicationWebInfo.UserID;
                //----------------USER--------------------//
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
                        base.ShowMessageAndRedirect(SuccessMessage, typeof(EmployeeList));
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
            base.RedirectToBackPage(typeof(EmployeeList));
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

        protected void Upload(object sender, EventArgs e)
        {


        }



        #endregion Events


    }
}