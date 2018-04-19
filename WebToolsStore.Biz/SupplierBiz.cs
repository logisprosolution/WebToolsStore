using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class SupplierBiz : BaseDB<MAS_Supplier>
    {
        #region Biz Methods
        public SupplierBiz() : base() {

        }
        public DataTable SelectList(string searchText)
        {
            return base.SelectListTable(searchText);
        }
        public bool CheckContainID(string codeValue)
        {
            base.dataModel.supplier_code = codeValue;
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

        public int SaveData(MAS_Supplier model, string condition, bool isNewMode)
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
            SqlCommand cmd = CreateCommand("udp_MAS_Supplier_lst", System.Data.CommandType.StoredProcedure);
            cmd.Parameters.Add(CreateParameter("searchText", condition));
            LoadData(cmd, ds, base.SELECT_LIST);
        }

        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {
            if (condition == SELECT_INFO)
            {
                SqlCommand cmd = CreateCommand("udp_MAS_Supplier_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("supplier_id", id));
                LoadData(cmd, ds, SELECT_INFO);
            }
            else if (condition == "SelectMaxID")
            {
                SqlCommand cmd = CreateCommand("udp_MaxID_Supplier", System.Data.CommandType.StoredProcedure);
                LoadData(cmd, ds, "SelectMaxID");
            }
            else if (condition == "CheckContainID")
            {
                string stringSQL = "select top 1 * from MAS_Supplier where supplier_code = " + "'" + dataModel.supplier_code + "'";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, condition, true);
            }
        }

        protected override int DoInsertData(MAS_Supplier model, string condition, bool isNewMode)
        {
            int value = -1;
            if (condition == SAVE_INFO)
            {
                if (model != null)
                {
                    SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Supplier_ups");
                    if (isNewMode)
                    {
                        cmd.Parameters.Add(CreateParameter("supplier_id", 0, ParameterDirection.Output));
                    }
                    else
                    {
                        cmd.Parameters.Add(CreateParameter("supplier_id", model.supplier_id));
                    }
                    cmd.Parameters.Add(CreateParameter("supplier_code", model.supplier_code));
                    cmd.Parameters.Add(CreateParameter("supplier_name", model.supplier_name));
                    cmd.Parameters.Add(CreateParameter("supplier_tel1", model.supplier_tel1));
                    cmd.Parameters.Add(CreateParameter("supplier_tel2", model.supplier_tel2));
                    cmd.Parameters.Add(CreateParameter("supplier_fax", model.supplier_fax));
                    cmd.Parameters.Add(CreateParameter("supplier_email", model.supplier_email));
                    cmd.Parameters.Add(CreateParameter("supplier_address", model.supplier_address));
                    cmd.Parameters.Add(CreateParameter("supplier_subdistict", model.supplier_subdistict));
                    cmd.Parameters.Add(CreateParameter("supplier_distict", model.supplier_distict));
                    cmd.Parameters.Add(CreateParameter("supplier_province", model.supplier_province));
                    cmd.Parameters.Add(CreateParameter("supplier_zipcode", model.supplier_zipcode));
                    cmd.Parameters.Add(CreateParameter("description", model.description));
                    cmd.Parameters.Add(CreateParameter("is_del", model.is_del));
                    cmd.Parameters.Add(CreateParameter("is_enabled", model.is_enabled));
                    cmd.Parameters.Add(CreateParameter("create_by", model.create_by));
                    cmd.Parameters.Add(CreateParameter("update_by", model.update_by));
                    cmd.ExecuteNonQuery();
                    value = ConvertToInt(cmd.Parameters["supplier_id"].Value);
                }
            }
            return value;
        }

        protected override int DoDeleteData(int id, string user, string condition)
        {
            int result = -1;
            if (condition == base.DELETE_LIST)
            {
                SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Supplier_del");
                cmd.Parameters.Add(CreateParameter("supplier_id", id));
                result = cmd.ExecuteNonQuery();
            }
            
            return result;
        }

        #endregion Override Methods
    }
}