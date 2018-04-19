using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class CustomerBiz : BaseDB<MAS_Customer>
    {
        #region Biz Methods
        public CustomerBiz() : base() {

        }
        public DataTable SelectList(string searchText)
        {
            return base.SelectListTable(searchText);
        }
        public bool CheckContainID(string codeValue)
        {
            base.dataModel.customer_code = codeValue;
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

        public int SaveData(MAS_Customer model, string condition, bool isNewMode)
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
            SqlCommand cmd = CreateCommand("udp_MAS_Customer_lst", System.Data.CommandType.StoredProcedure);
            cmd.Parameters.Add(CreateParameter("searchText", condition));
            LoadData(cmd, ds, base.SELECT_LIST);
        }

        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {
            if (condition == SELECT_INFO)
            {
                SqlCommand cmd = CreateCommand("udp_MAS_Customer_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("customer_id", id));
                LoadData(cmd, ds, SELECT_INFO);
            }
            else if (condition == "SelectMaxID")
            {
                SqlCommand cmd = CreateCommand("udp_MaxID_Customer", System.Data.CommandType.StoredProcedure);
                LoadData(cmd, ds, "SelectMaxID");
            }
            else if (condition == "CheckContainID")
            {
                string stringSQL = "select top 1 * from MAS_Customer where customer_code = " + "'" + dataModel.customer_code + "'";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, condition, true);
            }
        }

        protected override int DoInsertData(MAS_Customer model, string condition, bool isNewMode)
        {
            int value = -1;
            if (condition == SAVE_INFO)
            {
                if (model != null)
                {
                    SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Customer_ups");
                    if (isNewMode)
                    {
                        cmd.Parameters.Add(CreateParameter("customer_id", 0, ParameterDirection.Output));
                    }
                    else
                    {
                        cmd.Parameters.Add(CreateParameter("customer_id", model.customer_id));
                    }
                    cmd.Parameters.Add(CreateParameter("customer_code", model.customer_code));
                    cmd.Parameters.Add(CreateParameter("customer_name", model.customer_name));
                    cmd.Parameters.Add(CreateParameter("customer_tel1", model.customer_tel1));
                    cmd.Parameters.Add(CreateParameter("customer_tel2", model.customer_tel2));
                    cmd.Parameters.Add(CreateParameter("customer_fax", model.customer_fax));
                    cmd.Parameters.Add(CreateParameter("customer_email", model.customer_email));
                    cmd.Parameters.Add(CreateParameter("customer_address", model.customer_address));
                    cmd.Parameters.Add(CreateParameter("customer_subdistict", model.customer_subdistict));
                    cmd.Parameters.Add(CreateParameter("customer_distict", model.customer_distict));
                    cmd.Parameters.Add(CreateParameter("customer_province", model.customer_province));
                    cmd.Parameters.Add(CreateParameter("customer_zipcode", model.customer_zipcode));
                    cmd.Parameters.Add(CreateParameter("description", model.description));
                    cmd.Parameters.Add(CreateParameter("is_del", model.is_del));
                    cmd.Parameters.Add(CreateParameter("is_enabled", model.is_enabled));
                    cmd.Parameters.Add(CreateParameter("create_by", model.create_by));
                    cmd.Parameters.Add(CreateParameter("update_by", model.update_by));
                    cmd.ExecuteNonQuery();
                    value = ConvertToInt(cmd.Parameters["customer_id"].Value);
                }
            }
            return value;
        }

        protected override int DoDeleteData(int id, string user, string condition)
        {
            int result = -1;
            if (condition == base.DELETE_LIST)
            {
                SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Customer_del");
                cmd.Parameters.Add(CreateParameter("customer_id", id));
                result = cmd.ExecuteNonQuery();
            }
            
            return result;
        }

        #endregion Override Methods
    }
}