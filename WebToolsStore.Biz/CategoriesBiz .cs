using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class CategoriesBiz : BaseDB<MAS_Categories>
    {
        #region Biz Methods
        public CategoriesBiz() : base() {

        }
        public DataTable SelectList(string searchText)
        {
            return base.SelectListTable(searchText);
        }
        public bool CheckContainID(string codeValue)
        {
            base.dataModel.categories_code = codeValue;
            DataTable dt = base.SelectByIdTable(0, "CheckContainID");
            if (dt.Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public int SaveData(MAS_Categories model, string condition, bool isNewMode)
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
        public int DeleteDetail(int id, string user, string condition)
        {
            int result = -1;
            if (condition == base.DELETE_DETAIL)
            {
                result = base.DeleteData(id, user, condition);
            }
            return result;
        }
        #endregion Biz Methods

        #region Override Methods

        protected override void DoSelectList(ref DataSet ds, string condition)
        {
            SqlCommand cmd = CreateCommand("udp_MAS_Categories_lst", System.Data.CommandType.StoredProcedure);
            cmd.Parameters.Add(CreateParameter("searchText", condition));
            LoadData(cmd, ds, base.SELECT_LIST);
        }

        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {
            if (condition == SELECT_INFO)
            {
                SqlCommand cmd = CreateCommand("udp_MAS_Categories_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("categories_id", id));
                LoadData(cmd, ds, SELECT_INFO);
            }
            else if (condition == SELECT_DETAIL)
            {
                SqlCommand cmd = CreateCommand("udp_MAS_Subcategories_lst", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("categories_id", id));
                LoadData(cmd, ds, SELECT_DETAIL);
            }
            else if (condition == "SelectMaxID")
            {
                SqlCommand cmd = CreateCommand("udp_MaxID_Categories", System.Data.CommandType.StoredProcedure);
                LoadData(cmd, ds, "SelectMaxID");
            }
            else if (condition == "CheckContainID")
            {
                string stringSQL = "select top 1 * from MAS_Categories where categories_code = " + "'" + dataModel.categories_code + "'";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, condition, true);
            }
        }

        protected override int DoInsertData(MAS_Categories model, string condition, bool isNewMode)
        {
            int value = -1;
            if (condition == SAVE_INFO)
            {
                if (model != null)
                {
                    SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Categories_ups");
                    if (isNewMode)
                    {
                        cmd.Parameters.Add(CreateParameter("categories_id", 0, ParameterDirection.Output));
                    }
                    else
                    {
                        cmd.Parameters.Add(CreateParameter("categories_id", model.categories_id));
                    }
                    cmd.Parameters.Add(CreateParameter("categories_code", model.categories_code));
                    cmd.Parameters.Add(CreateParameter("categories_name", model.categories_name));
                    cmd.Parameters.Add(CreateParameter("categories_index", model.categories_index));
                    cmd.Parameters.Add(CreateParameter("description", model.description));
                    cmd.Parameters.Add(CreateParameter("is_del", model.is_del));
                    cmd.Parameters.Add(CreateParameter("is_enabled", model.is_enabled));
                    cmd.Parameters.Add(CreateParameter("create_by", model.create_by));
                    cmd.Parameters.Add(CreateParameter("update_by", model.update_by));
                    cmd.ExecuteNonQuery();
                    value = ConvertToInt(cmd.Parameters["categories_id"].Value);
                }
            }
            return value;
        }

        protected override int DoDeleteData(int id, string user, string condition)
        {
            int result = -1;
            if (condition == base.DELETE_LIST)
            {
                SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Categories_del");
                cmd.Parameters.Add(CreateParameter("categories_id", id));
                result = cmd.ExecuteNonQuery();
            }else if (condition == base.DELETE_DETAIL)
            {
                SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Subcategories_del");
                cmd.Parameters.Add(CreateParameter("subcategories_id", id));
                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        #endregion Override Methods
    }
}