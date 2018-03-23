using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class UserBiz : BaseDB<UserModel>
    {
        #region Biz Methods
        public UserBiz() : base() {

        }
        public DataTable SelectList(string searchText)
        {
            return base.SelectListTable(searchText);
        }

        public string SelectMaxID()
        {
            DataTable dt = base.SelectByIdTable(0, "SelectMaxID");
            return dt.Rows[0]["maxID"].ToString();
        }

        public DataTable SelectInfo(int id)
        {
            return base.SelectByIdTable(id, SELECT_INFO);
        }

        public int SaveData(UserModel model, string condition, bool isNewMode)
        {
            int result = -1;
            if (condition == SAVE_INFO)
            {
                result = base.InsertData(model, condition, isNewMode);
            }
            return result;
        }

        public int DeleteData(int id, string user, string condition)
        {
            int result = -1;
            if (condition == base.DELETE_LIST)
            {
                result = base.DeleteData(id, user, condition);
            }
            return result;
        }
        #endregion Biz Methods

        #region Override Methods

        protected override void DoSelectList(ref DataSet ds, string condition)
        {
            SqlCommand cmd = CreateCommand("udp_USR_User_Profile_lst", System.Data.CommandType.StoredProcedure);
            cmd.Parameters.Add(CreateParameter("searchText", condition));
            LoadData(cmd, ds, base.SELECT_LIST);
        }

        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {
            if (condition == SELECT_INFO)
            {
                SqlCommand cmd = CreateCommand("udp_USR_User_Profile_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("user_profile_id", id));
                LoadData(cmd, ds, SELECT_INFO);
            }
            else if (condition == "SelectMaxID")
            {
                SqlCommand cmd = CreateCommand("udp_MaxID_User", System.Data.CommandType.StoredProcedure);
                LoadData(cmd, ds, "SelectMaxID");
            }
        }

        protected override int DoInsertData(UserModel model, string condition, bool isNewMode)
        {
            int value = -1;
            if (condition == SAVE_INFO)
            {
                if (model != null)
                {
                    SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_USR_User_Profile_ups");
                    SqlCommand cmd1 = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_USR_User_ups");
                    if (isNewMode)
                    {
                        cmd.Parameters.Add(CreateParameter("user_profile_id", 0, ParameterDirection.Output));
                    }
                    else
                    {
                        cmd.Parameters.Add(CreateParameter("user_profile_id", model.USR_User_Profile.user_profile_id));
                    }
                    cmd.Parameters.Add(CreateParameter("title_id", model.USR_User_Profile.title_id));
                    cmd.Parameters.Add(CreateParameter("emp_code", model.USR_User_Profile.emp_code));
                    cmd.Parameters.Add(CreateParameter("name", model.USR_User_Profile.name));
                    cmd.Parameters.Add(CreateParameter("lastname", model.USR_User_Profile.lastname));
                    cmd.Parameters.Add(CreateParameter("age", model.USR_User_Profile.age));
                    cmd.Parameters.Add(CreateParameter("bithdate", model.USR_User_Profile.bithdate));
                    cmd.Parameters.Add(CreateParameter("tel", model.USR_User_Profile.tel));
                    cmd.Parameters.Add(CreateParameter("email", model.USR_User_Profile.email));
                    cmd.Parameters.Add(CreateParameter("address", model.USR_User_Profile.address));
                    cmd.Parameters.Add(CreateParameter("subdistict", model.USR_User_Profile.subdistict));
                    cmd.Parameters.Add(CreateParameter("distict", model.USR_User_Profile.distict));
                    cmd.Parameters.Add(CreateParameter("province", model.USR_User_Profile.province));
                    cmd.Parameters.Add(CreateParameter("zipcode", model.USR_User_Profile.zipcode));
                    cmd.Parameters.Add(CreateParameter("is_enabled", model.USR_User_Profile.is_enabled));
                    cmd.Parameters.Add(CreateParameter("is_del", model.USR_User_Profile.is_del));
                    cmd.Parameters.Add(CreateParameter("create_date", model.USR_User_Profile.create_date));
                    cmd.Parameters.Add(CreateParameter("create_by", model.USR_User_Profile.create_by));
                    cmd.Parameters.Add(CreateParameter("update_date", model.USR_User_Profile.update_date));
                    cmd.Parameters.Add(CreateParameter("update_by", model.USR_User_Profile.update_by));
                    cmd.Parameters.Add(CreateParameter("description", model.USR_User_Profile.description));
                    cmd.Parameters.Add(CreateParameter("card", model.USR_User_Profile.card));
                    cmd.Parameters.Add(CreateParameter("pic", model.USR_User_Profile.pic));
                    cmd.Parameters.Add(CreateParameter("pic_filename", model.USR_User_Profile.pic_filename));
                    cmd.ExecuteNonQuery();
                    value = ConvertToInt(cmd.Parameters["user_profile_id"].Value);

                    if (isNewMode)
                    {
                        cmd1.Parameters.Add(CreateParameter("user_id", 0, ParameterDirection.Output));
                    }
                    else
                    {
                        cmd1.Parameters.Add(CreateParameter("user_id", model.USR_User.user_id));
                    }
                    cmd1.Parameters.Add(CreateParameter("user_name", model.USR_User.user_name));
                    cmd1.Parameters.Add(CreateParameter("user_password", model.USR_User.user_password));
                    cmd1.Parameters.Add(CreateParameter("user_namedis", model.USR_User.user_namedis));
                    cmd1.Parameters.Add(CreateParameter("user_type", model.USR_User.user_type));
                    cmd1.Parameters.Add(CreateParameter("is_enabled", model.USR_User.is_enabled));
                    cmd1.Parameters.Add(CreateParameter("is_del", model.USR_User.is_del));
                    cmd1.Parameters.Add(CreateParameter("create_date", model.USR_User.create_date));
                    cmd1.Parameters.Add(CreateParameter("create_by", model.USR_User.create_by));
                    cmd1.Parameters.Add(CreateParameter("update_date", model.USR_User.update_date));
                    cmd1.Parameters.Add(CreateParameter("update_by", model.USR_User.update_by));
                    cmd1.Parameters.Add(CreateParameter("user_profile_id", value));

                    cmd1.ExecuteNonQuery();
                }
            }
            return value;
        }

        protected override int DoDeleteData(int id, string user, string condition)
        {
            int result = -1;
            if (condition == base.DELETE_LIST)
            {
                SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_USR_User_Profile_del");
                cmd.Parameters.Add(CreateParameter("user_profile_id", id));
                cmd.Parameters.Add(CreateParameter("user_id", id));
                result = cmd.ExecuteNonQuery();
            }
            
            return result;
        }

        #endregion Override Methods
    }
}