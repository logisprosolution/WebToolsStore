using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using AT.Framework;
using System.Data;
using WebToolsStore.Data;

namespace WebToolsStore.Biz
{
    public class LoadExHelperBiz : BaseDB<SimpleDS>
    {

        public DataSet SelectReportBill(int id)
        {
            try
            {
                return base.SelectById(id,"SelectReportBill");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet SelectVatType()
        {
            try
            {
                return base.SelectList("SelectVatType");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet SelectPaymentType(int id)
        {
            try
            {
                return base.SelectById(id,"SelectPaymentType");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet SelectSupplyer()
        {
            try
            {
                return base.SelectList("SelectSupplyer");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet SelectCustomer()
        {
            try
            {
                return base.SelectList("SelectCustomer");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet SelectUnit()
        {
            try
            {
                return base.SelectList("SelectUnit");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //public DataSet SelectUnitById(int id)
        //{
        //    try
        //    {
        //        return base.SelectById(id, "SelectUnitById");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        public DataSet SelectCategories()
        {
            try
            {
                return base.SelectList("SelectCategories");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet SelectSubcategoriesById(int id)
        {
            try
            {
                return base.SelectById(id, "SelectSubcategoriesById");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet SelectHeaderStatus(int id)
        {
            try
            {
                return base.SelectById(id, "SelectHeaderStatus");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public DataSet SelectTitle()
        {
            try
            {
                return base.SelectList("SelectTitle");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet SelectProvince()
        {
            try
            {
                return base.SelectList("SelectProvince");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet SelectDocType()
        {
            try
            {
                return base.SelectList("SelectDocType");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet SelectSubDocType(int id)
        {
            try
            {
                return base.SelectById(id, "SelectSubDocType");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet SelectWarehouse()
        {
            try
            {
                return base.SelectList("SelectWarehouse");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet SelectProduct()
        {
            try
            {
                return base.SelectList("SelectProduct");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet SelectDistrictById(int id)
        {
            try
            {
                return base.SelectById(id, "SelectDistrictById");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet SelectSubDistrictById(int id)
        {
            try
            {
                return base.SelectById(id, "SelectSubDistrictById");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet SelectZipCode(int id)
        {
            try
            {
                return base.SelectById(id, "SelectZipCode");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public DataSet SelectARLineByID(string id)
        //{
        //    try
        //    {
        //        LoadExHelperParam.AR_SLMNCODE = id;
        //        return base.SelectById(0, "SelectARLineByID");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //public DataSet SelectStockByID(string SKM_SKU, string SKM_WL)
        //{
        //    try
        //    {
        //        LoadExHelperParam.SKM_SKU = SKM_SKU;
        //        LoadExHelperParam.SKM_WL = SKM_WL;
        //        return base.SelectById(0, "SelectStockByID");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //public DataSet SelectARFileByID(int id)
        //{
        //    try
        //    {
        //        return base.SelectById(id, "SelectARByID");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //public DataSet SelectNewCSV()
        //{
        //    try
        //    {
        //        return base.SelectById(0, "selectNewCSV");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //public bool SelectCheckCompareCSV(DataSet ds)
        //{
        //    try
        //    {
        //        base.SelectByIdTable(ds, "CheckCompareCSV");
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //public DataTable SelectInsertedFiles()
        //{
        //    try
        //    {
        //        return base.SelectByIdTable(0, "InsertedFile");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        //public string SaveData(DataSet ds, string condition)
        //{
        //    if (condition == "CheckCompareCSV")
        //    {
        //        base.InsertData(ds, condition);
        //    }
        //    if (condition == "UpdateMovedFiles")
        //    {
        //        base.InsertData(ds, condition);
        //    }

        //    return "";
        //}

        protected override void DoSelectList(ref DataSet ds, string condition)
        {
            string stringSQL = "";
            if (condition == "SelectVatType")
            {
                stringSQL = "select * from v_vatType";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectVatType");
            }
            if (condition == "SelectSupplyer")
            {
                stringSQL = "select * from MAS_Supplier where is_del = 0";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, condition);
            }
            if (condition == "SelectCustomer")
            {
                stringSQL = "select * from MAS_Customer where is_del = 0";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, condition);
            }
            if (condition == "SelectCategories")
            {
                stringSQL = "select * from MAS_Categories where is_del = 0 and is_enabled = 1";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectCategories");
            }
            if (condition == "SelectTitle")
            {
                stringSQL = "select * from USR_Title where is_del = 0 and is_enabled = 1";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectTitle");
            }
            if (condition == "SelectProvince")
            {
                stringSQL = "select * from MAS_Province order by provinceNameTH";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectProvince");
            }
            if (condition == "SelectUnit")
            {
                stringSQL = "select * from MAS_Unit where is_del = 0 and is_enabled = 1 order by unit_name";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectUnit");
            }
            if (condition == "SelectProduct")
            {
                stringSQL = "select * from MAS_Product where is_del = 0 and is_enabled = 1";
                stringSQL = string.Format(stringSQL);

                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectProduct");
            }
            if (condition == "SelectWarehouse")
            {
                stringSQL = "select * from MAS_Warehouse";
                stringSQL = string.Format(stringSQL);

                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectWarehouse");
            }
            if (condition == "SelectDocType")
            {
                stringSQL = "select * from DOC_Doctype";
                stringSQL = string.Format(stringSQL);

                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectDocType");
            }
        }

        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {
            string stringSQL = "";
            //if (condition == "SelectARByID")
            //{
            //    stringSQL = "select ar_key, ar_name + ' (' + ar_code + ')' as ar_name from ARFILE where AR_ARL =" + id + " and AR_ENABLE='Y'";
            //    stringSQL = string.Format(stringSQL);

            //    SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
            //    LoadData(cmd, ds, "ARFILE");
            //}
            //else if (condition == "SelectARLineByID")
            //{
            //    stringSQL = "select distinct ARL_KEY, ARL_NAME  + ' (' + ARL_CODE + ')' as ARL_NAME from dbo.ARLINE a INNER JOIN dbo.ARFILE b ON b.AR_ARL = a.ARL_KEY where b.AR_SLMNCODE in(" + LoadExHelperParam.AR_SLMNCODE + ") order by ARL_NAME asc";
            //    stringSQL = string.Format(stringSQL);

            //    SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
            //    LoadData(cmd, ds, "ARLineByID");
            //}
            //else if (condition == "SelectStockByID")
            //{
            //    stringSQL = "SELECT Cast(isnull(SUM(skm.SKM_QTY),0) as int) FROM dbo.SKUMOVE skm where skm.SKM_SKU = " + LoadExHelperParam.SKM_SKU + " and (skm.SKM_WL in('" + LoadExHelperParam.SKM_WL + "')) GROUP BY skm.SKM_SKU";
            //    stringSQL = string.Format(stringSQL);

            //    SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
            //    LoadData(cmd, ds, "StockByID");
            //}

            //else if (condition == "selectNewCSV")
            //{
            //    SqlCommand cmd = CreateCommand("up_so_cartList_newcsv_sel", System.Data.CommandType.StoredProcedure);
            //    LoadData(cmd, ds, "selectNewCSV");
            //}
            //else if (condition == "InsertedFile")
            //{
            //    SqlCommand cmd = CreateCommand("up_so_csvmanagement_newfileInsert_sel", System.Data.CommandType.StoredProcedure);
            //    LoadData(cmd, ds, "InsertedFile");
            //}
            //else 

            if (condition == "SelectDistrictById")
            {
                stringSQL = "select * from MAS_District where provinceID =" + id + "order by districtNameTH";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectDistrictById");
            }
            else if (condition == "SelectSubDistrictById")
            {
                stringSQL = "select * from MAS_SubDistrict where districtID =" + id + "order by subDistrictNameTH";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectSubDistrictById");
            }
            else if (condition == "SelectZipCode")
            {
                stringSQL = "select b.zipCode ";
                stringSQL += "from MAS_SubDistrict a left join MAS_District b ";
                stringSQL += "on a.districtID = b.districtID where a.subDistrictID = " + id + "order by subDistrictNameTH";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectZipCode");
            }
            else if (condition == "SelectSubcategoriesById")
            {
                stringSQL = "select * from MAS_Subcategories where categories_id =" + id + "and is_del = 0 and is_enabled = 1 order by subcategories_name";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectSubcategoriesById");
            }
            else if (condition == "SelectSubDocType")
            {
                stringSQL = "select * from DOC_SubDocType where doctype_id =" + id + "order by subDocTypeName";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectSubDocType");
            }
            else if (condition == "SelectReportBill")
            {
                stringSQL = "select * from v_bill where header_id =" + id;
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectReportBill");
            }
            else if (condition == "SelectHeaderStatus")
            {
                stringSQL = "SELECT status_id,status_name FROM DOC_Status where status_group in (" + id + ",'0') order by[status_group] desc";
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectHeaderStatus");
            }
            else if (condition == "SelectPaymentType")
            {
                stringSQL = "select * from v_Payment where not PaymentID =" + id;
                stringSQL = string.Format(stringSQL);
                SqlCommand cmd = CreateCommand(stringSQL, System.Data.CommandType.Text);
                LoadData(cmd, ds, "SelectPaymentType");
            }
        }

        protected override int DoInsertData(DataSet ds, string condition)
        {
            if (condition == "CheckCompareCSV")
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    //SqlCommand cmd = CreateCommand("up_so_cartList_comparepodetail_sel", System.Data.CommandType.StoredProcedure);
                    SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "up_so_cartList_comparepodetail_sel");
                    cmd.Parameters.Add(CreateParameter("csvFileName", dr["csvFileName"].ToString()));
                    cmd.Parameters.Add(CreateParameter("TRH_KEY", Convert.ToInt32(dr["TRH_KEY"])));
                    cmd.Parameters.Add(CreateParameter("DI_Last", dr["DI_Last"].ToString()));
                    cmd.Parameters.Add(CreateParameter("TKH_Last", dr["TKH_Last"].ToString()));
                    cmd.ExecuteNonQuery();
                    //LoadData(cmd, ds, "selectComparePoDetail");
                }
            }
            else if (condition == "UpdateMovedFiles")
            {
                    DataTable dt = ds.Tables[0];
                    SqlCommand cmd = CreateTransactionCommand(System.Data.CommandType.StoredProcedure, "up_so_UpdateMovedFiles_upd");
                    cmd.Parameters.Add(CreateParameter("TKH_last_file", dt.Rows[0]["TKH_last"].ToString()));
                    cmd.ExecuteNonQuery();
            }
            return 0;
        }
    }
}