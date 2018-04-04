using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class DocBiz : BaseDB<DocModel>
    {
        #region Biz Methods
        public DocBiz() : base()
        {

        }
        public DataTable SelectList(string searchText)
        {
            return base.SelectListTable(searchText);
        }

        public DataTable SelectInfo(int id)
        {
            return base.SelectByIdTable(id, SELECT_INFO);
        }

        public DataTable SelectDetail(int id)
        {
            return base.SelectByIdTable(id, SELECT_DETAIL);
        }
        public DataTable SelectDetailIngredient(int id)
        {
            return base.SelectByIdTable(id, "SelectDetailIngredient");
        }
        public DataTable SelectProductPrice(int id)
        {
            return base.SelectByIdTable(id, "SelectProductPrice");
        }
        public DataTable SelectProduct(int id)
        {
            return base.SelectByIdTable(id, "SelectProduct");
        }
        public string SelectAddress_Supplier(int id)
        {
            DataTable dt = base.SelectByIdTable(id, "SelectAddress_Supplier");
            return dt.Rows[0]["Address"].ToString();
        }
        public string SelectAddress_Customer(int id)
        {
            DataTable dt = base.SelectByIdTable(id, "SelectAddress_Customer");
            return dt.Rows[0]["Address"].ToString();
        }
        public int SaveData(DocModel model, string condition, bool isNewMode)
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
            SqlCommand cmd = CreateCommand("udp_DOC_Header_lst", System.Data.CommandType.StoredProcedure);
            cmd.Parameters.Add(CreateParameter("searchText", condition));
            cmd.Parameters.Add(CreateParameter("subdoctype_id", dataModel.SubDoctype_id));
            LoadData(cmd, ds, base.SELECT_LIST);
        }

        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {
            if (condition == SELECT_INFO)
            {
                SqlCommand cmd = CreateCommand("udp_DOC_Header_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("header_id", id));
                LoadData(cmd, ds, SELECT_INFO);
            }
            else if (condition == SELECT_DETAIL)
            {
                SqlCommand cmd = CreateCommand("udp_DOC_Detail_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("header_id", id));
                cmd.Parameters.Add(CreateParameter("detail_status", dataModel.Detail_status));
                LoadData(cmd, ds, SELECT_DETAIL);
            }
            else if (condition == "SelectDetailIngredient")
            {
                SqlCommand cmd = CreateCommand("udp_DOC_Detail_Ingredient_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("header_id", id));
                LoadData(cmd, ds, condition);
            }
            else if (condition == "SelectProductPrice")
            {
                SqlCommand cmd = CreateCommand("udp_SelectProductPrice_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("product_price_id", id));
                LoadData(cmd, ds, condition);
            }
            else if (condition == "SelectProduct")
            {
                SqlCommand cmd = CreateCommand("udp_SelectPrice_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("product_id", id));
                LoadData(cmd, ds, condition);
            }
            else if (condition == "SelectAddress_Supplier")
            {
                SqlCommand cmd = CreateCommand("udp_SelectAddress_Supplier", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("supplier_id", id));
                LoadData(cmd, ds, condition);
            }
            else if (condition == "SelectAddress_Customer")
            {
                SqlCommand cmd = CreateCommand("udp_SelectAddress_Customer", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("customer_id", id));
                LoadData(cmd, ds, condition);
            }
        }

        protected override int DoInsertData(DocModel model, string condition, bool isNewMode)
        {
            int value = -1;
            if (condition == SAVE_INFO)
            {
                if (model != null)
                {
                    SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_DOC_Header_ups");
                    if (isNewMode)
                    {
                        cmd.Parameters.Add(CreateParameter("header_id", 0, ParameterDirection.Output));
                    }
                    else
                    {
                        cmd.Parameters.Add(CreateParameter("header_id", model.Doc_Header.header_id));
                    }
                    cmd.Parameters.Add(CreateParameter("header_code", model.Doc_Header.header_code));
                    cmd.Parameters.Add(CreateParameter("header_date", model.Doc_Header.header_date));
                    cmd.Parameters.Add(CreateParameter("header_date_from", model.Doc_Header.header_date_from));
                    cmd.Parameters.Add(CreateParameter("header_date_to", model.Doc_Header.header_date_to));
                    cmd.Parameters.Add(CreateParameter("header_supplier_id", model.Doc_Header.header_supplier_id));
                    cmd.Parameters.Add(CreateParameter("header_supplier_name", model.Doc_Header.header_supplier_name));
                    cmd.Parameters.Add(CreateParameter("header_customer_id", model.Doc_Header.header_customer_id));
                    cmd.Parameters.Add(CreateParameter("header_customer_name", model.Doc_Header.header_customer_name));
                    cmd.Parameters.Add(CreateParameter("header_address", model.Doc_Header.header_address));
                    cmd.Parameters.Add(CreateParameter("header_remark", model.Doc_Header.header_remark));
                    cmd.Parameters.Add(CreateParameter("header_status", model.Doc_Header.header_status));
                    cmd.Parameters.Add(CreateParameter("is_enabled", model.Doc_Header.is_enabled));
                    cmd.Parameters.Add(CreateParameter("is_del", model.Doc_Header.is_del));
                    cmd.Parameters.Add(CreateParameter("create_date", model.Doc_Header.create_date));
                    cmd.Parameters.Add(CreateParameter("create_by", model.Doc_Header.create_by));
                    cmd.Parameters.Add(CreateParameter("update_date", model.Doc_Header.update_date));
                    cmd.Parameters.Add(CreateParameter("update_by", model.Doc_Header.update_by));
                    cmd.Parameters.Add(CreateParameter("subDocTypeID", model.Doc_Header.subDocTypeID));
                    cmd.Parameters.Add(CreateParameter("vat_id", model.Doc_Header.vat_id));
                    cmd.Parameters.Add(CreateParameter("payment_id", model.Doc_Header.payment_id));
                    cmd.Parameters.Add(CreateParameter("payment_date", model.Doc_Header.payment_date));
                    cmd.Parameters.Add(CreateParameter("header_warehouse_from", model.Doc_Header.header_warehouse_from));
                    cmd.Parameters.Add(CreateParameter("header_warehouse_to", model.Doc_Header.header_warehouse_to));
                    cmd.Parameters.Add(CreateParameter("header_total", model.Doc_Header.header_total));
                    cmd.Parameters.Add(CreateParameter("header_receive", model.Doc_Header.header_receive));
                    cmd.Parameters.Add(CreateParameter("header_discout", model.Doc_Header.header_discout));
                    cmd.Parameters.Add(CreateParameter("header_vat", model.Doc_Header.header_vat));
                    cmd.Parameters.Add(CreateParameter("header_net", model.Doc_Header.header_net));
                    cmd.Parameters.Add(CreateParameter("header_deposit", model.Doc_Header.header_deposit));
                    cmd.Parameters.Add(CreateParameter("header_added", model.Doc_Header.header_added));
                    cmd.Parameters.Add(CreateParameter("header_refund", model.Doc_Header.header_refund));
                    cmd.Parameters.Add(CreateParameter("header_ref", model.Doc_Header.header_ref));
                    cmd.ExecuteNonQuery();
                    value = ConvertToInt(cmd.Parameters["header_id"].Value);

                    //save detail
                    SqlCommand cmd2 = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_DOC_Detail_ups");
                    int i = 1;
                    foreach (DOC_Detail detail in model.DocDetailList)
                    {
                        cmd2.Parameters.Clear();
                        if (detail.detail_id == 0)
                        {
                            cmd2.Parameters.Add(CreateParameter("detail_id", 0, ParameterDirection.Output));
                            cmd2.Parameters.Add(CreateParameter("header_id", value));
                        }
                        else
                        {
                            cmd2.Parameters.Add(CreateParameter("detail_id", detail.detail_id));
                            cmd2.Parameters.Add(CreateParameter("header_id", detail.header_id));
                        }
                        cmd2.Parameters.Add(CreateParameter("product_id", detail.product_id));
                        cmd2.Parameters.Add(CreateParameter("product_price_id", detail.product_price_id));
                        cmd2.Parameters.Add(CreateParameter("product_price_code", detail.product_price_code));
                        cmd2.Parameters.Add(CreateParameter("product_price_name", detail.product_price_name));
                        cmd2.Parameters.Add(CreateParameter("unit_id", detail.unit_id));
                        cmd2.Parameters.Add(CreateParameter("unit_name", detail.unit_name));
                        cmd2.Parameters.Add(CreateParameter("detail_qty", detail.detail_qty));
                        cmd2.Parameters.Add(CreateParameter("detail_price", detail.detail_price));
                        cmd2.Parameters.Add(CreateParameter("detail_discount", detail.detail_discount));
                        cmd2.Parameters.Add(CreateParameter("detail_total", detail.detail_total));
                        cmd2.Parameters.Add(CreateParameter("detail_status", detail.detail_status));
                        cmd2.Parameters.Add(CreateParameter("detail_remark", detail.detail_remark));
                        cmd2.Parameters.Add(CreateParameter("is_del", detail.is_del));
                        cmd2.Parameters.Add(CreateParameter("used_qty", detail.used_qty));
                        cmd2.Parameters.Add(CreateParameter("detail_warehouse", detail.detail_warehouse));
                        cmd2.Parameters.Add(CreateParameter("subDocTypeID", model.Doc_Header.subDocTypeID));
                        cmd2.Parameters.Add(CreateParameter("unit_value", detail.unit_value));
                        cmd2.Parameters.Add(CreateParameter("PaytypeID", detail.PaytypeID));
                        cmd2.ExecuteNonQuery();

                        //save detail_ingredient
                        int value2 = ConvertToInt(cmd2.Parameters["detail_id"].Value);
                        int index = ConvertToInt(cmd2.Parameters["PaytypeID"].Value);
                        var DocIngredientList = model.DocIngredientList.FindAll(x => x.product_price_id == detail.product_price_id && x.PaytypeID == index);
                        SqlCommand cmd4 = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_DOC_Detail_Ingredient_ups");
                        int a = 1;
                        foreach (DOC_Detail_Ingredient detail_ingredient in DocIngredientList)
                        {
                            cmd4.Parameters.Clear();
                            if (detail_ingredient.running == 0)
                            {
                                cmd4.Parameters.Add(CreateParameter("running", 0, ParameterDirection.Output));
                                cmd4.Parameters.Add(CreateParameter("detail_id", value2));
                            }
                            else
                            {
                                cmd4.Parameters.Add(CreateParameter("running", detail_ingredient.running));
                                cmd4.Parameters.Add(CreateParameter("detail_id", detail_ingredient.detail_id));
                            }
                            cmd4.Parameters.Add(CreateParameter("detail_price", detail_ingredient.detail_price));
                            cmd4.Parameters.Add(CreateParameter("PaytypeID", detail_ingredient.PaytypeID));
                            cmd4.Parameters.Add(CreateParameter("ingredient_id", detail_ingredient.ingredient_id));
                            cmd4.Parameters.Add(CreateParameter("product_id", detail_ingredient.product_id));
                            cmd4.Parameters.Add(CreateParameter("product_unit", detail_ingredient.product_unit));
                            cmd4.Parameters.Add(CreateParameter("product_qty", detail_ingredient.product_qty));
                            cmd4.Parameters.Add(CreateParameter("product_price_id", detail_ingredient.product_price_id));
                            cmd4.Parameters.Add(CreateParameter("is_enabled", detail_ingredient.is_enabled));
                            cmd4.Parameters.Add(CreateParameter("is_del", detail_ingredient.is_del));
                            cmd4.Parameters.Add(CreateParameter("create_date", detail_ingredient.create_date));
                            cmd4.Parameters.Add(CreateParameter("create_by", detail_ingredient.create_by));
                            cmd4.Parameters.Add(CreateParameter("update_date", detail_ingredient.update_date));
                            cmd4.Parameters.Add(CreateParameter("update_by", detail_ingredient.update_by));
                            cmd4.ExecuteNonQuery();
                            a++;
                        }
                        cmd4 = null;
                        i++;
                    }
                    cmd2 = null;

                    if (model.DocDetailList2 != null)
                    {
                        if (model.DocDetailList2.Count != 0)
                        {
                            SqlCommand cmd3 = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_DOC_Detail_ups");
                            i = 1;
                            foreach (DOC_Detail detail in model.DocDetailList2)
                            {
                                cmd3.Parameters.Clear();
                                if (detail.detail_id == 0)
                                {
                                    cmd3.Parameters.Add(CreateParameter("detail_id", 0, ParameterDirection.Output));
                                    cmd3.Parameters.Add(CreateParameter("header_id", value));
                                }
                                else
                                {
                                    cmd3.Parameters.Add(CreateParameter("detail_id", detail.detail_id));
                                    cmd3.Parameters.Add(CreateParameter("header_id", detail.header_id));
                                }
                                cmd3.Parameters.Add(CreateParameter("product_id", detail.product_id));
                                cmd3.Parameters.Add(CreateParameter("product_price_id", detail.product_price_id));
                                cmd3.Parameters.Add(CreateParameter("product_price_code", detail.product_price_code));
                                cmd3.Parameters.Add(CreateParameter("product_price_name", detail.product_price_name));
                                cmd3.Parameters.Add(CreateParameter("unit_id", detail.unit_id));
                                cmd3.Parameters.Add(CreateParameter("unit_name", detail.unit_name));
                                cmd3.Parameters.Add(CreateParameter("detail_qty", detail.detail_qty));
                                cmd3.Parameters.Add(CreateParameter("detail_price", detail.detail_price));
                                cmd3.Parameters.Add(CreateParameter("detail_discount", detail.detail_discount));
                                cmd3.Parameters.Add(CreateParameter("detail_total", detail.detail_total));
                                cmd3.Parameters.Add(CreateParameter("detail_status", detail.detail_status));
                                cmd3.Parameters.Add(CreateParameter("detail_remark", detail.detail_remark));
                                cmd3.Parameters.Add(CreateParameter("is_del", detail.is_del));
                                cmd3.Parameters.Add(CreateParameter("used_qty", detail.used_qty));
                                cmd3.Parameters.Add(CreateParameter("detail_warehouse", detail.detail_warehouse));
                                cmd3.Parameters.Add(CreateParameter("subDocTypeID", detail.subDocTypeID));
                                cmd3.Parameters.Add(CreateParameter("unit_value", detail.unit_value));
                                cmd3.Parameters.Add(CreateParameter("PaytypeID", detail.PaytypeID));
                                cmd3.ExecuteNonQuery();

                                int value3 = ConvertToInt(cmd3.Parameters["detail_id"].Value);
                                int index = ConvertToInt(cmd3.Parameters["PaytypeID"].Value);
                                var DocIngredientList2 = model.DocIngredientList2.FindAll(x => x.product_price_id == detail.product_price_id && x.PaytypeID == index);
                                SqlCommand cmd5 = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_DOC_detail_ingredient_ups");
                                int a = 1;
                                foreach (DOC_Detail_Ingredient detail_ingredient in DocIngredientList2)
                                {
                                    cmd5.Parameters.Clear();
                                    if (detail_ingredient.running == 0)
                                    {
                                        cmd5.Parameters.Add(CreateParameter("running", 0, ParameterDirection.Output));
                                        cmd5.Parameters.Add(CreateParameter("detail_id", value3));
                                    }
                                    else
                                    {
                                        cmd5.Parameters.Add(CreateParameter("running", detail_ingredient.running));
                                        cmd5.Parameters.Add(CreateParameter("detail_id", detail_ingredient.detail_id));
                                    }
                                    cmd5.Parameters.Add(CreateParameter("detail_price", detail_ingredient.detail_price));
                                    cmd5.Parameters.Add(CreateParameter("PaytypeID", detail_ingredient.PaytypeID));
                                    cmd5.Parameters.Add(CreateParameter("ingredient_id", detail_ingredient.ingredient_id));
                                    cmd5.Parameters.Add(CreateParameter("product_id", detail_ingredient.product_id));
                                    cmd5.Parameters.Add(CreateParameter("product_unit", detail_ingredient.product_unit));
                                    cmd5.Parameters.Add(CreateParameter("product_qty", detail_ingredient.product_qty));
                                    cmd5.Parameters.Add(CreateParameter("product_price_id", detail_ingredient.product_price_id));
                                    cmd5.Parameters.Add(CreateParameter("is_enabled", detail_ingredient.is_enabled));
                                    cmd5.Parameters.Add(CreateParameter("is_del", detail_ingredient.is_del));
                                    cmd5.Parameters.Add(CreateParameter("create_date", detail_ingredient.create_date));
                                    cmd5.Parameters.Add(CreateParameter("create_by", detail_ingredient.create_by));
                                    cmd5.Parameters.Add(CreateParameter("update_date", detail_ingredient.update_date));
                                    cmd5.Parameters.Add(CreateParameter("update_by", detail_ingredient.update_by));
                                    cmd5.ExecuteNonQuery();
                                    a++;
                                }
                                cmd5 = null;
                                i++;
                            }
                            cmd3 = null;
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
                SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_DOC_Header_del");
                cmd.Parameters.Add(CreateParameter("header_id", id));
                result = cmd.ExecuteNonQuery();
            }
            if (condition == base.DELETE_DETAIL)
            {
                SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "udp_DOC_Detail_del");
                cmd.Parameters.Add(CreateParameter("header_id", id));
                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        #endregion Override Methods
    }
}