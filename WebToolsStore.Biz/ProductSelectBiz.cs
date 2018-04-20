using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class ProductSelectBiz : BaseDB<ProductModel>
    {
        #region Biz Methods
        public ProductSelectBiz() : base()
        {

        }
        public DataTable SelectProduct(int productid,string searchText, int categories_id, int subCategories_id,int warehouseID)
        {
            dataModel.ProductID = productid;
            dataModel.SearchText = searchText;
            dataModel.Categories_Id = categories_id;
            dataModel.SubCategories_Id = subCategories_id;
            dataModel.WareHouseID = warehouseID;
            return base.SelectListTable("SelectProduct");
        }
        public DataTable SelectProductStock(string searchText, int categories_id, int subCategories_id, int warehouseID)
        {
            dataModel.SearchText = searchText;
            dataModel.Categories_Id = categories_id;
            dataModel.SubCategories_Id = subCategories_id;
            dataModel.WareHouseID = warehouseID;
            return base.SelectListTable("SelectProductStock");
        }
        public DataTable SelectPrice(int id)
        {
            return base.SelectByIdTable(id, "SelectPrice");
        }
        
        #endregion Biz Methods

        #region Override Methods

        protected override void DoSelectList(ref DataSet ds, string condition)
        {
            if (condition == "SelectProduct")
            {
                SqlCommand cmd = CreateCommand("udp_SelectProduct_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("product_id", dataModel.ProductID));
                cmd.Parameters.Add(CreateParameter("SearchText", dataModel.SearchText));
                cmd.Parameters.Add(CreateParameter("Categories_Id", dataModel.Categories_Id));
                cmd.Parameters.Add(CreateParameter("SubCategories_Id", dataModel.SubCategories_Id));
                cmd.Parameters.Add(CreateParameter("WareHouseID", dataModel.WareHouseID));
                LoadData(cmd, ds, condition);
            }
            if (condition == "SelectProductStock")
            {
                SqlCommand cmd = CreateCommand("udp_SelectProductStock_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("SearchText", dataModel.SearchText));
                cmd.Parameters.Add(CreateParameter("Categories_Id", dataModel.Categories_Id));
                cmd.Parameters.Add(CreateParameter("SubCategories_Id", dataModel.SubCategories_Id));
                cmd.Parameters.Add(CreateParameter("WareHouseID", dataModel.WareHouseID));
                LoadData(cmd, ds, condition);
            }
            
        }

        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {
            
            if (condition == "SelectPrice")
            {
                SqlCommand cmd = CreateCommand("udp_SelectPrice_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("product_id", id));
                LoadData(cmd, ds, "SelectPrice");
            }
            
        }
        #endregion Override Methods
    }
}