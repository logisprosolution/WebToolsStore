using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class RoleBiz : BaseDB<RoleModel>
    {
        #region Biz Methods
        public RoleBiz() : base()
        {

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

        public DataTable SelectDetail(int id)
        {
            return base.SelectByIdTable(id, SELECT_DETAIL);
        }
        public DataTable SelectOthers(int id)
        {
            return base.SelectByIdTable(id, SELECT_OTHERS);
        }

        public int SaveData(RoleModel model, string condition, bool isNewMode)
        {
            int result = -1;
            result = base.InsertData(model, condition, isNewMode);
            return result;
        }

        public int DeleteData(int id, string user, string condition)
        {
            int result = -1;
            result = base.DeleteData(id, user, condition);
            return result;
        }
        #endregion Biz Methods

        #region Override Methods

        protected override void DoSelectList(ref DataSet ds, string condition)
        {
            SqlCommand cmd = CreateCommand("udp_USR_Role_lst", System.Data.CommandType.StoredProcedure);
            cmd.Parameters.Add(CreateParameter("searchText", condition));
            LoadData(cmd, ds, base.SELECT_LIST);
        }

        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {
            if (condition == SELECT_INFO)
            {
                SqlCommand cmd = CreateCommand("udp_USR_Role_Submenu_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("role_id", id));
                LoadData(cmd, ds, SELECT_INFO);
            }
            else if (condition == SELECT_DETAIL)
            {
                SqlCommand cmd = CreateCommand("udp_USR_User_Role_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("role_id", id));
                LoadData(cmd, ds, SELECT_DETAIL);
            }
            else if (condition == SELECT_OTHERS)
            {
                SqlCommand cmd = CreateCommand("udp_USR_User_Role_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("user_id", id));
                LoadData(cmd, ds, SELECT_OTHERS);
            }
            else if (condition == "SelectMaxID")
            {
                SqlCommand cmd = CreateCommand("udp_MaxID_Role", System.Data.CommandType.StoredProcedure);
                LoadData(cmd, ds, "SelectMaxID");
            }
        }

        protected override int DoInsertData(RoleModel model, string condition, bool isNewMode)
        {
            int value = -1;
            if (condition == SAVE_INFO)
            {
                if (model != null)
                {
                    SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_USR_Role_ups");
                    if (isNewMode)
                    {
                        cmd.Parameters.Add(CreateParameter("role_id", 0, ParameterDirection.Output));
                    }
                    else
                    {
                        cmd.Parameters.Add(CreateParameter("role_id", model.USR_Role.role_id));
                    }
                    cmd.Parameters.Add(CreateParameter("role_code", model.USR_Role.role_code));
                    cmd.Parameters.Add(CreateParameter("role_name", model.USR_Role.role_name));
                    cmd.Parameters.Add(CreateParameter("role_value", model.USR_Role.role_value));
                    cmd.Parameters.Add(CreateParameter("is_del", model.USR_Role.is_del));
                    cmd.Parameters.Add(CreateParameter("is_enabled", model.USR_Role.is_enabled));
                    cmd.Parameters.Add(CreateParameter("create_by", model.USR_Role.create_by));
                    cmd.Parameters.Add(CreateParameter("update_by", model.USR_Role.update_by));
                    cmd.ExecuteNonQuery();
                    value = ConvertToInt(cmd.Parameters["role_id"].Value);
                }
            }
            else if (condition == SAVE_DETAIL)
            {
                if (model != null)
                {
                    if (model.RoleSubmenuList != null)
                    {
                        if (model.RoleSubmenuList.Count != 0)
                        {
                            SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_USR_Role_Submenu_ups");
                            int i = 1;
                            foreach (USR_Role_Submenu detail in model.RoleSubmenuList)
                            {
                                cmd.Parameters.Clear();
                                if (detail.role_id == 0)
                                {
                                    cmd.Parameters.Add(CreateParameter("role_id", 0, ParameterDirection.Output));
                                    cmd.Parameters.Add(CreateParameter("submenu_id", value));
                                }
                                else
                                {
                                    cmd.Parameters.Add(CreateParameter("role_id", detail.role_id));
                                    cmd.Parameters.Add(CreateParameter("submenu_id", detail.submenu_id));
                                }
                                cmd.Parameters.Add(CreateParameter("is_view", detail.is_view));
                                cmd.Parameters.Add(CreateParameter("is_add", detail.is_add));
                                cmd.Parameters.Add(CreateParameter("is_edit", detail.is_edit));
                                cmd.Parameters.Add(CreateParameter("is_delete", detail.is_delete));
                                cmd.Parameters.Add(CreateParameter("is_search", detail.is_search));
                                cmd.ExecuteNonQuery();
                                i++;
                            }
                            cmd = null;
                            value = 0;
                        }
                    }
                }
            }
            else if (condition == SAVE_OTHERS)
            {
                if (model != null)
                {
                    if (model.UserRoleList != null)
                    {
                        if (model.UserRoleList.Count != 0)
                        {
                            SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_USR_User_Role_ups");
                            int i = 1;
                            foreach (USR_User_Role detail in model.UserRoleList)
                            {
                                cmd.Parameters.Clear();
                                if (detail.running_id == 0)
                                {
                                    cmd.Parameters.Add(CreateParameter("running_id", 0, ParameterDirection.Output));
                                    cmd.Parameters.Add(CreateParameter("role_id", detail.role_id));
                                }
                                else
                                {
                                    cmd.Parameters.Add(CreateParameter("running_id", detail.running_id));
                                    cmd.Parameters.Add(CreateParameter("role_id", detail.role_id));
                                }
                                cmd.Parameters.Add(CreateParameter("user_id", detail.user_id));
                                cmd.Parameters.Add(CreateParameter("user_name", detail.user_name));
                                cmd.Parameters.Add(CreateParameter("is_enabled", detail.is_enabled));
                                cmd.Parameters.Add(CreateParameter("is_del", detail.is_del));
                                cmd.Parameters.Add(CreateParameter("create_date", detail.create_date));
                                cmd.Parameters.Add(CreateParameter("create_by", detail.create_by));
                                cmd.Parameters.Add(CreateParameter("update_date", detail.update_date));
                                cmd.Parameters.Add(CreateParameter("update_by", detail.update_by));
                                cmd.ExecuteNonQuery();
                                i++;
                            }
                            cmd = null;
                            value = 0;
                        }
                    }
                }
            }
            return value;
        }

        protected override int DoDeleteData(int id, string user, string condition)
        {
            int result = -1;
            if (condition == base.DELETE_LIST)
            {
                SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_USR_Role_del");
                cmd.Parameters.Add(CreateParameter("role_id", id));
                result = cmd.ExecuteNonQuery();
            }
            else if (condition == base.DELETE_DETAIL)
            {
                SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_USR_User_Role_del");
                cmd.Parameters.Add(CreateParameter("user_is", id));
                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        #endregion Override Methods
    }
}