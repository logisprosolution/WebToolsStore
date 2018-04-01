using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class ProductIngredientBiz : BaseDB<MAS_Ingredient>
    {
        #region Biz Methods
        public ProductIngredientBiz() : base()
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

        public DataTable SelectProductPrice(int id)
        {
            return base.SelectByIdTable(id, "SelectProductPrice");
        }

        public DataTable SelectProductIngredient(int id)
        {
            return base.SelectByIdTable(id, "SelectProductIngredient");
        }

        public int SaveData(MAS_Ingredient model, string condition, bool isNewMode)
        {
            int result = -1;
            if (condition == SAVE_INFO)
            {
                result = base.InsertData(model, condition, isNewMode);
            }
            else if (condition == SAVE_DETAIL)  //Save Product SelectProductIngredient
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
            SqlCommand cmd = CreateCommand("udp_MAS_Product_lst", System.Data.CommandType.StoredProcedure);
            cmd.Parameters.Add(CreateParameter("searchText", condition));
            LoadData(cmd, ds, base.SELECT_LIST);
        }

        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {
            if (condition == SELECT_INFO)
            {
                SqlCommand cmd = CreateCommand("udp_MAS_Ingredient_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("product_id", id));
                LoadData(cmd, ds, SELECT_INFO);
            }
            else if (condition == SELECT_DETAIL)
            {
                SqlCommand cmd = CreateCommand("udp_MAS_Product_Price_lst", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("product_id", id));
                LoadData(cmd, ds, SELECT_DETAIL);
            }
            //else if (condition == "SelectMaxID")
            //{
            //    SqlCommand cmd = CreateCommand("udp_MaxID_Product", System.Data.CommandType.StoredProcedure);
            //    LoadData(cmd, ds, "SelectMaxID");
            //}
            //else if (condition == "SelectProductPrice")
            //{
            //    SqlCommand cmd = CreateCommand("udp_SelectProductPrice_sel", System.Data.CommandType.StoredProcedure);
            //    cmd.Parameters.Add(CreateParameter("product_price_id", id));
            //    LoadData(cmd, ds, condition);
            //}
            else if (condition == "SelectProductIngredient")
            {
                SqlCommand cmd = CreateCommand("udp_SelectIngredient_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("product_price_id", id));
                LoadData(cmd, ds, condition);
            }

        }

        //protected override int DoInsertData(MAS_Ingredient model, string condition, bool isNewMode)
        //{
        //    int value = -1;
        //    if (condition == SAVE_INFO)
        //    {
        //        if (model != null)
        //        {
        //            SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Product_ups");

        //            if (isNewMode)
        //            {
        //                cmd.Parameters.Add(CreateParameter("product_id", 0, ParameterDirection.Output));
        //            }
        //            else
        //            {
        //                cmd.Parameters.Add(CreateParameter("product_id", model.MAS_Product.product_id));
        //            }
        //            cmd.Parameters.Add(CreateParameter("product_code", model.MAS_Product.product_code));
        //            cmd.Parameters.Add(CreateParameter("product_name", model.MAS_Product.product_name));
        //            //cmd.Parameters.Add(CreateParameter("product_pic", model.product_pic));
        //            cmd.Parameters.Add(CreateParameter("description", model.MAS_Product.description));
        //            cmd.Parameters.Add(CreateParameter("is_del", model.MAS_Product.is_del));
        //            cmd.Parameters.Add(CreateParameter("is_enabled", model.MAS_Product.is_enabled));
        //            cmd.Parameters.Add(CreateParameter("create_by", model.MAS_Product.create_by));
        //            cmd.Parameters.Add(CreateParameter("update_by", model.MAS_Product.update_by));
        //            cmd.Parameters.Add(CreateParameter("subcategories_id", model.MAS_Product.subcategories_id));
        //            cmd.Parameters.Add(CreateParameter("warehouse_default", model.MAS_Product.warehouse_default));
        //            cmd.Parameters.Add(CreateParameter("product_unit", model.MAS_Product.product_unit));
        //            cmd.ExecuteNonQuery();
        //            value = ConvertToInt(cmd.Parameters["product_id"].Value);

        //            SqlCommand cmd2 = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Ingredient_ups");
        //            int i = 1;
        //            foreach (MAS_Ingredient detail in model.MasIngredientList)
        //            {
        //                cmd2.Parameters.Clear();
        //                if (detail.ingredient_id == 0)
        //                {
        //                    cmd2.Parameters.Add(CreateParameter("ingredient_id", 0, ParameterDirection.Output));
        //                    cmd2.Parameters.Add(CreateParameter("product_id", value));
        //                }
        //                else
        //                {
        //                    cmd2.Parameters.Add(CreateParameter("ingredient_id", detail.ingredient_id));
        //                    cmd2.Parameters.Add(CreateParameter("product_id", detail.product_id));
        //                }
        //                cmd2.Parameters.Add(CreateParameter("product_unit", detail.product_unit));
        //                cmd2.Parameters.Add(CreateParameter("product_qty", detail.product_qty));
        //                cmd2.Parameters.Add(CreateParameter("is_default", detail.is_default));
        //                cmd2.Parameters.Add(CreateParameter("is_enabled", detail.is_enabled));
        //                cmd2.Parameters.Add(CreateParameter("is_del", detail.is_del));
        //                cmd2.Parameters.Add(CreateParameter("create_date", detail.create_date));
        //                cmd2.Parameters.Add(CreateParameter("create_by", detail.create_by));
        //                cmd2.Parameters.Add(CreateParameter("update_date", detail.update_date));
        //                cmd2.Parameters.Add(CreateParameter("update_by", detail.update_by));
        //                cmd2.ExecuteNonQuery();
        //                i++;
        //            }
        //        }
        //    }
        //    else if(condition == SAVE_DETAIL)
        //    {
        //        if (model != null)
        //        {
        //            SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Ingredient_ups");

        //            if (isNewMode)
        //            {
        //                cmd.Parameters.Add(CreateParameter("ingredient_id", 0, ParameterDirection.Output));
        //            }
        //            else
        //            {
        //                cmd.Parameters.Add(CreateParameter("ingredient_id", model.MAS_Ingredient.ingredient_id));
        //            }
        //            cmd.Parameters.Add(CreateParameter("product_id", model.MAS_Ingredient.product_id));
        //            cmd.Parameters.Add(CreateParameter("product_unit", model.MAS_Ingredient.product_unit));
        //            cmd.Parameters.Add(CreateParameter("product_qty", model.MAS_Ingredient.product_qty));
        //            cmd.Parameters.Add(CreateParameter("is_default", model.MAS_Ingredient.is_default));
        //            cmd.Parameters.Add(CreateParameter("is_del", model.MAS_Ingredient.is_del));
        //            cmd.Parameters.Add(CreateParameter("is_enabled", model.MAS_Ingredient.is_enabled));
        //            cmd.Parameters.Add(CreateParameter("create_by", model.MAS_Ingredient.create_by));
        //            cmd.Parameters.Add(CreateParameter("update_by", model.MAS_Ingredient.update_by));
        //            cmd.ExecuteNonQuery();
        //            value = ConvertToInt(cmd.Parameters["ingredient_id"].Value);
        //        }
        //    }
        //    return value;
        //}

        //protected override int DoDeleteData(int id, string user, string condition)
        //{
        //    int result = -1;
        //    if (condition == base.DELETE_LIST)
        //    {
        //        SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Product_del");
        //        cmd.Parameters.Add(CreateParameter("product_id", id));
        //        result = cmd.ExecuteNonQuery();
        //    }
        //    else if (condition == base.DELETE_DETAIL)
        //    {
        //        SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_MAS_Product_Price_del");
        //        cmd.Parameters.Add(CreateParameter("product_price_id", id));
        //        result = cmd.ExecuteNonQuery();
        //    }

        //    return result;
        //}

        #endregion Override Methods
    }
}