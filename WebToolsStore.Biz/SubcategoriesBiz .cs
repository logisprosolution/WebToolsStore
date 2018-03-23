using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class SubcategoriesBiz : BaseDB<MAS_Subcategories>
    {
        #region Biz Methods
        public SubcategoriesBiz() : base() {

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

        public int SaveData(MAS_Subcategories model, string condition, bool isNewMode)
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

        //protected override void DoSelectList(ref DataSet ds, string condition)
        //{
        //    SqlCommand cmd = CreateCommand("udp_MAS_Categories_lst", System.Data.CommandType.StoredProcedure);
        //    cmd.Parameters.Add(CreateParameter("searchText", condition));
        //    LoadData(cmd, ds, base.SELECT_LIST);
        //}

        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {
            if (condition == SELECT_INFO)
            {
                SqlCommand cmd = CreateCommand("udp_MAS_Subcategories_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("subcategories_id", id));
                LoadData(cmd, ds, SELECT_INFO);
            }
            else if (condition == "SelectMaxID")
            {
                SqlCommand cmd = CreateCommand("udp_MaxID_Subcategories", System.Data.CommandType.StoredProcedure);
                LoadData(cmd, ds, "SelectMaxID");
            }
        }

        protected override int DoInsertData(MAS_Subcategories model, string condition, bool isNewMode)
        {
            int value = -1;
            if (condition == SAVE_INFO)
            {
                if (model != null)
                {
                    SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Subcategories_ups");
                    if (isNewMode)
                    {
                        cmd.Parameters.Add(CreateParameter("subcategories_id", 0, ParameterDirection.Output));
                    }
                    else
                    {
                        cmd.Parameters.Add(CreateParameter("subcategories_id", model.subcategories_id));
                    }
                    cmd.Parameters.Add(CreateParameter("subcategories_code", model.subcategories_code));
                    cmd.Parameters.Add(CreateParameter("subcategories_name", model.subcategories_name));
                    cmd.Parameters.Add(CreateParameter("subcategories_index", model.subcategories_index));
                    cmd.Parameters.Add(CreateParameter("description", model.description));
                    cmd.Parameters.Add(CreateParameter("is_del", model.is_del));
                    cmd.Parameters.Add(CreateParameter("is_enabled", model.is_enabled));
                    cmd.Parameters.Add(CreateParameter("categories_id", model.categories_id));
                    cmd.Parameters.Add(CreateParameter("create_by", model.create_by));
                    cmd.Parameters.Add(CreateParameter("update_by", model.update_by));
                    cmd.ExecuteNonQuery();
                    value = ConvertToInt(cmd.Parameters["subcategories_id"].Value);
                }
            }
            return value;
        }

        protected override int DoDeleteData(int id, string user, string condition)
        {
            int result = -1;
            if (condition == base.DELETE_LIST)
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