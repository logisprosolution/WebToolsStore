using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class ProductPriceBiz : BaseDB<MAS_Product_Price>
    {
        #region Biz Methods
        public ProductPriceBiz() : base() {

        }
        public DataTable SelectList(string searchText)
        {
            return base.SelectListTable(searchText);
        }
        public bool CheckContainID(string codeValue)
        {
            base.dataModel.product_price_code = codeValue;
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

        public int SaveData(MAS_Product_Price model, string condition, bool isNewMode)
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
                SqlCommand cmd = CreateCommand("udp_MAS_Product_Price_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("product_price_id", id));
                LoadData(cmd, ds, SELECT_INFO);
            }
            else if (condition == "SelectMaxID")
            {
                SqlCommand cmd = CreateCommand("udp_MaxID_Product_Price", System.Data.CommandType.StoredProcedure);
                LoadData(cmd, ds, "SelectMaxID");
            }
            else if (condition == "CheckContainID")
            {
                string stringSQL = "select top 1 * from MAS_Product_Price where product_price_code = " + "'" + dataModel.product_price_code + "'";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, condition, true);
            }
        }

        protected override int DoInsertData(MAS_Product_Price model, string condition, bool isNewMode)
        {
            int value = -1;
            if (condition == SAVE_INFO)
            {
                if (model != null)
                {
                    SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Product_Price_ups");
                    if (isNewMode)
                    {
                        cmd.Parameters.Add(CreateParameter("product_price_id", 0, ParameterDirection.Output));
                    }
                    else
                    {
                        cmd.Parameters.Add(CreateParameter("product_price_id", model.product_price_id));
                    }
                    cmd.Parameters.Add(CreateParameter("product_price_code", model.product_price_code));
                    cmd.Parameters.Add(CreateParameter("product_price_name", model.product_price_name));
                    cmd.Parameters.Add(CreateParameter("unit_id", model.unit_id));
                    cmd.Parameters.Add(CreateParameter("cost", model.cost));
                    cmd.Parameters.Add(CreateParameter("price_Cash", model.price_Cash));
                    cmd.Parameters.Add(CreateParameter("price_Credit", model.price_Credit));
                    cmd.Parameters.Add(CreateParameter("price_CashExtra", model.price_CashExtra));
                    cmd.Parameters.Add(CreateParameter("description", model.description));
                    cmd.Parameters.Add(CreateParameter("is_enabled", model.is_enabled));
                    cmd.Parameters.Add(CreateParameter("is_del", model.is_del));
                    cmd.Parameters.Add(CreateParameter("create_date", model.create_date));
                    cmd.Parameters.Add(CreateParameter("create_by", model.create_by));
                    cmd.Parameters.Add(CreateParameter("update_date", model.update_date));
                    cmd.Parameters.Add(CreateParameter("update_by", model.update_by));
                    cmd.Parameters.Add(CreateParameter("product_id", model.product_id));
                    cmd.ExecuteNonQuery();
                    value = ConvertToInt(cmd.Parameters["product_price_id"].Value);
                }
            }
            return value;
        }

        protected override int DoDeleteData(int id, string user, string condition)
        {
            int result = -1;
            if (condition == base.DELETE_LIST)
            {
                SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Product_Price_del");
                cmd.Parameters.Add(CreateParameter("product_price_id", id));
                result = cmd.ExecuteNonQuery();
            }
            
            return result;
        }

        #endregion Override Methods
    }
}