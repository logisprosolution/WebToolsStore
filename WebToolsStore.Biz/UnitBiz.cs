using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class UnitBiz : BaseDB<MAS_Unit>
    {
        #region Biz Methods
        public UnitBiz() : base() {

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

        public int SaveData(MAS_Unit model, string condition, bool isNewMode)
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
            SqlCommand cmd = CreateCommand("udp_MAS_Unit_lst", System.Data.CommandType.StoredProcedure);
            cmd.Parameters.Add(CreateParameter("searchText", condition));
            LoadData(cmd, ds, base.SELECT_LIST);
        }

        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {
            if (condition == SELECT_INFO)
            {
                SqlCommand cmd = CreateCommand("udp_MAS_Unit_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("unit_id", id));
                LoadData(cmd, ds, SELECT_INFO);
            }
            else if (condition == "SelectMaxID")
            {
                SqlCommand cmd = CreateCommand("udp_MaxID_Unit", System.Data.CommandType.StoredProcedure);
                LoadData(cmd, ds, "SelectMaxID");
            }
        }

        protected override int DoInsertData(MAS_Unit model, string condition, bool isNewMode)
        {
            int value = -1;
            if (condition == SAVE_INFO)
            {
                if (model != null)
                {
                    SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Unit_ups");
                    if (isNewMode)
                    {
                        cmd.Parameters.Add(CreateParameter("unit_id", 0, ParameterDirection.Output));
                    }
                    else
                    {
                        cmd.Parameters.Add(CreateParameter("unit_id", model.unit_id));
                    }
                    cmd.Parameters.Add(CreateParameter("unit_code", model.unit_code));
                    cmd.Parameters.Add(CreateParameter("unit_name", model.unit_name));
                    cmd.Parameters.Add(CreateParameter("unit_value", model.unit_value));
                    cmd.Parameters.Add(CreateParameter("is_del", model.is_del));
                    cmd.Parameters.Add(CreateParameter("is_enabled", model.is_enabled));
                    cmd.Parameters.Add(CreateParameter("create_by", model.create_by));
                    cmd.Parameters.Add(CreateParameter("update_by", model.update_by));
                    cmd.ExecuteNonQuery();
                    value = ConvertToInt(cmd.Parameters["unit_id"].Value);
                }
            }
            return value;
        }

        protected override int DoDeleteData(int id, string user, string condition)
        {
            int result = -1;
            if (condition == base.DELETE_LIST)
            {
                SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Unit_del");
                cmd.Parameters.Add(CreateParameter("unit_id", id));
                result = cmd.ExecuteNonQuery();
            }
            
            return result;
        }

        #endregion Override Methods
    }
}