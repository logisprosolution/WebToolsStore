using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class ReportBiz : BaseDB<ReportModel>
    {
        #region Biz Methods

        public ReportBiz() : base()
        {

        }
        public DataTable SelectList()
        {
            return base.SelectListTable("");
        }

        public DataSet SelectTransAll()
        {
            return base.SelectById(0, "v_transAll");
        }
        public DataSet SelectStock(int id)
        {
            return base.SelectById(id, "v_stock");
        }
        public DataSet SelectBill(int id)
        {
            return base.SelectById(id, "v_bill");
        }

        #endregion Biz Methods

        #region Override Methods

        protected override void DoSelectList(ref DataSet ds, string condition)
        {
            SqlCommand cmd = CreateCommand("udp_SKU_Unit_lst", System.Data.CommandType.StoredProcedure);
            LoadData(cmd, ds, base.SELECT_LIST);
        }

        //protected override void DoSelectByIdTModel(int id, ref ReportDS model, string condition)
        //{
        //    if (condition == "SelectTransAll")
        //    {
        //        DataRow dr = base.dataModel.v_TransAll.Rows[0];

        //        SqlCommand cmd = CreateCommand("up_Report_TransAll_sel", System.Data.CommandType.StoredProcedure);
        //        //cmd.Parameters.Add(CreateParameter("shopID", dr[model.v_TransAll.shopIDColumn.ColumnName]));
        //        cmd.Parameters.Add(CreateParameter("shopID", id));
        //        LoadData(cmd, model, model.v_TransAll.TableName);
        //    }
        //}
        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {
            if (condition == "v_transAll")
            {
                SqlCommand cmd = CreateCommand("up_Report_TransAll_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("DocTypeID", base.dataModel.DocTypeID));
                cmd.Parameters.Add(CreateParameter("wareHouseID", base.dataModel.WareHouseID));
                cmd.Parameters.Add(CreateParameter("productID", base.dataModel.ProductID));
                cmd.Parameters.Add(CreateParameter("SubDocTypeID", base.dataModel.SubDocTypeID));
                cmd.Parameters.Add(CreateParameter("header_date_from", base.dataModel.Header_date_from));
                cmd.Parameters.Add(CreateParameter("header_date_to", base.dataModel.Header_date_to));
                LoadData(cmd, ds, "v_transAll");
            }
            else if (condition == "v_bill")
            {
                SqlCommand cmd = CreateCommand("up_Report_Bill_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("header_id", id));
                LoadData(cmd, ds, "v_bill");
            }
            if (condition == "v_stock")
            {
                SqlCommand cmd = CreateCommand("up_Report_Stock_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("product_id", id));
                cmd.Parameters.Add(CreateParameter("SearchText", base.dataModel.SearchText));
                cmd.Parameters.Add(CreateParameter("Categories_Id", base.dataModel.CategoryID));
                cmd.Parameters.Add(CreateParameter("SubCategories_Id", base.dataModel.SubcategoryID));
                cmd.Parameters.Add(CreateParameter("WareHouseID", base.dataModel.WareHouseID));
                LoadData(cmd, ds, "v_stock");
            }
        }

        #endregion Override Methods
    }
}