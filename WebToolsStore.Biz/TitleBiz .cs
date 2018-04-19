using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class TitleBiz : BaseDB<USR_Title>
    {
        #region Biz Methods
        public TitleBiz() : base() {

        }
        public DataTable SelectList(string searchText)
        {
            return base.SelectListTable(searchText);
        }

        public bool CheckContainID(string codeValue)
        {
            base.dataModel.title_code = codeValue;
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

        public int SaveData(USR_Title model, string condition, bool isNewMode)
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
            SqlCommand cmd = CreateCommand("udp_USR_Title_lst", System.Data.CommandType.StoredProcedure);
            cmd.Parameters.Add(CreateParameter("searchText", condition));
            LoadData(cmd, ds, base.SELECT_LIST);
        }

        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {
            if (condition == SELECT_INFO)
            {
                SqlCommand cmd = CreateCommand("udp_USR_Title_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("title_id", id));
                LoadData(cmd, ds, SELECT_INFO);
            }
            else if (condition == "SelectMaxID")
            {
                SqlCommand cmd = CreateCommand("udp_MaxID_Title", System.Data.CommandType.StoredProcedure);
                LoadData(cmd, ds, "SelectMaxID");
            }
            else if (condition == "CheckContainID")
            {
                string stringSQL = "select top 1 * from USR_Title where title_code = " + "'" + dataModel.title_code + "'";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, condition, true);
            }

        }

        protected override int DoInsertData(USR_Title model, string condition, bool isNewMode)
        {
            int value = -1;
            if (condition == SAVE_INFO)
            {
                if (model != null)
                {
                    SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_USR_Title_ups");
                    if (isNewMode)
                    {
                        cmd.Parameters.Add(CreateParameter("title_id", 0, ParameterDirection.Output));
                    }
                    else
                    {
                        cmd.Parameters.Add(CreateParameter("title_id", model.title_id));
                    }
                    cmd.Parameters.Add(CreateParameter("title_code", model.title_code));
                    cmd.Parameters.Add(CreateParameter("title_name", model.title_name));
                    cmd.Parameters.Add(CreateParameter("is_del", model.is_del));
                    cmd.Parameters.Add(CreateParameter("is_enabled", model.is_enabled));
                    cmd.Parameters.Add(CreateParameter("create_by", model.create_by));
                    cmd.Parameters.Add(CreateParameter("update_by", model.update_by));
                    cmd.ExecuteNonQuery();
                    value = ConvertToInt(cmd.Parameters["title_id"].Value);
                }
            }
            return value;
        }

        protected override int DoDeleteData(int id, string user, string condition)
        {
            int result = -1;
            if (condition == base.DELETE_LIST)
            {
                SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_USR_Title_del");
                cmd.Parameters.Add(CreateParameter("title_id", id));
                result = cmd.ExecuteNonQuery();
            }
            
            return result;
        }

        #endregion Override Methods
    }
}