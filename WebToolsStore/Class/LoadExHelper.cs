using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using WebToolsStore.Biz;


namespace WebToolsStore
{
    public class LoadExHelper
    {
        LoadExHelperBiz biz = new LoadExHelperBiz();

        #region Private Methods

        private void LoadCondition(DataTable table, ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        {
            try
            {
                if (condition == Enumerator.ConditionLoadEx.Empty)
                {
                    DataRow row = table.NewRow();
                    row["code_value"] = 0;
                    row["desc_thai"] = string.Empty;
                    table.Rows.InsertAt(row, 0);
                }
                else if (condition == Enumerator.ConditionLoadEx.All)
                {
                    DataRow row = table.NewRow();
                    row["code_value"] = 0;
                    row["desc_thai"] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);

                }
                if (ConvertHelper.IsDataExits(table))
                {
                    ddl.DataSource = table;
                    ddl.DataValueField = "code_value";
                    ddl.DataTextField = "desc_thai";
                    ddl.DataBind();
                    ddl.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                DataRow row = table.NewRow();
                row["genderCode"] = 0;
                row["genderDesc"] = ConstanceInfo.SelectThai;
                table.Rows.InsertAt(row, 0);
            }
        }
        private void LoadCondition(DataTable table, ref DropDownList ddl, Enumerator.ConditionLoadEx condition, string codeValue, string txtDisplay, string valueCut)
        {
            try
            {
                if (condition == Enumerator.ConditionLoadEx.Empty)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = string.Empty;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.All)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.NewRowEmpty)
                {
                    table.Clear();
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);
                }
                
                if (ConvertHelper.IsDataExits(table))
                {
                    ddl.DataSource = table;
                    ddl.DataValueField = codeValue;
                    ddl.DataTextField = txtDisplay;
                    ddl.DataBind();
                    ddl.SelectedIndex = 0;

                    if (!ConvertHelper.IsStringEmpty(valueCut))
                    {
                        ddl.Items.Remove(ddl.Items.FindByValue(valueCut));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void LoadCondition(DataTable table, ref DropDownList ddl, Enumerator.ConditionLoadEx condition, string codeValue, string txtDisplay)
        {
            try
            {
                if (condition == Enumerator.ConditionLoadEx.Empty)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = string.Empty;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.All)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.None)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.AllThai;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.NewRowEmpty)
                {
                    table.Clear();
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);
                }
                if (ConvertHelper.IsDataExits(table))
                {
                    ddl.DataSource = table;
                    ddl.DataValueField = codeValue;
                    ddl.DataTextField = txtDisplay;
                    ddl.DataBind();
                    ddl.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void LoadCondition(DataTable table, ref DropDownList ddl, Enumerator.ConditionLoadEx condition, string codeValue, string txtDisplay, int slectedIndex)
        {
            try
            {
                if (condition == Enumerator.ConditionLoadEx.Empty)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = string.Empty;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.All)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.NewRowEmpty)
                {
                    table.Clear();
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);
                }
                if (ConvertHelper.IsDataExits(table))
                {
                    ddl.DataSource = table;
                    ddl.DataValueField = codeValue;
                    ddl.DataTextField = txtDisplay;
                    ddl.DataBind();
                    ddl.SelectedIndex = slectedIndex;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void LoadCondition(DataTable table, ref DropDownList ddl, Enumerator.ConditionLoadEx condition, string codeValue, string txtDisplay, bool isSelected)
        {
            try
            {
                if (condition == Enumerator.ConditionLoadEx.Empty)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = string.Empty;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.All)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.NewRowEmpty)
                {
                    table.Clear();
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);
                }
                if (ConvertHelper.IsDataExits(table))
                {
                    ddl.DataSource = table;
                    ddl.DataValueField = codeValue;
                    ddl.DataTextField = txtDisplay;
                    ddl.DataBind();
                    if (isSelected)
                    {
                        ddl.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void LoadCondition(DataTable table, ref RadioButtonList rdo, Enumerator.ConditionLoadEx condition)
        {
            try
            {
                if (condition == Enumerator.ConditionLoadEx.Empty)
                {
                    DataRow row = table.NewRow();
                    row["code_value"] = 0;
                    row["desc_thai"] = string.Empty;
                    table.Rows.InsertAt(row, 0);
                }
                else if (condition == Enumerator.ConditionLoadEx.All)
                {
                    DataRow row = table.NewRow();
                    row["code_value"] = 0;
                    row["desc_thai"] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);

                }
                if (ConvertHelper.IsDataExits(table))
                {
                    rdo.DataSource = table;
                    rdo.DataValueField = "code_value";
                    rdo.DataTextField = "desc_thai";
                    rdo.DataBind();
                    rdo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void LoadCondition(DataTable table, ref RadioButtonList rdo, Enumerator.ConditionLoadEx condition, string codeValue, string txtDisplay)
        {
            try
            {
                if (condition == Enumerator.ConditionLoadEx.Empty)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = string.Empty;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.All)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.NewRowEmpty)
                {
                    table.Clear();
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);
                }
                if (ConvertHelper.IsDataExits(table))
                {
                    rdo.DataSource = table;
                    rdo.DataValueField = codeValue;
                    rdo.DataTextField = txtDisplay;
                    rdo.DataBind();
                    rdo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void LoadCondition(DataTable table, ref RadioButtonList rdo, Enumerator.ConditionLoadEx condition, string codeValue, string txtDisplay, int slectedIndex)
        {
            try
            {
                if (condition == Enumerator.ConditionLoadEx.Empty)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = string.Empty;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.All)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.NewRowEmpty)
                {
                    table.Clear();
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);
                }
                if (ConvertHelper.IsDataExits(table))
                {
                    rdo.DataSource = table;
                    rdo.DataValueField = codeValue;
                    rdo.DataTextField = txtDisplay;
                    rdo.DataBind();
                    rdo.SelectedIndex = slectedIndex;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void LoadCondition(DataTable table, ref RadioButtonList rdo, Enumerator.ConditionLoadEx condition, string codeValue, string txtDisplay, bool isSelected)
        {
            try
            {
                if (condition == Enumerator.ConditionLoadEx.Empty)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = string.Empty;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.All)
                {
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);

                }
                else if (condition == Enumerator.ConditionLoadEx.NewRowEmpty)
                {
                    table.Clear();
                    DataRow row = table.NewRow();
                    row[codeValue] = 0;
                    row[txtDisplay] = ConstanceInfo.SelectThai;
                    table.Rows.InsertAt(row, 0);
                }
                if (ConvertHelper.IsDataExits(table))
                {
                    rdo.DataSource = table;
                    rdo.DataValueField = codeValue;
                    rdo.DataTextField = txtDisplay;
                    rdo.DataBind();
                    if (isSelected)
                    {
                        rdo.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void LoadCondition(DataTable table, ref CheckBoxList chk, Enumerator.ConditionLoadEx condition)
        {
            try
            {
                if (condition == Enumerator.ConditionLoadEx.Empty)
                {
                    DataRow row = table.NewRow();
                    row["code_value"] = 0;
                    row["desc_thai"] = string.Empty;
                    table.Rows.InsertAt(row, 0);
                }
                else if (condition == Enumerator.ConditionLoadEx.All)
                {
                    DataRow row = table.NewRow();
                    row["code_value"] = 0;
                    row["desc_thai"] = ConstanceInfo.AllEng;
                    table.Rows.InsertAt(row, 0);

                }
                if (ConvertHelper.IsDataExits(table))
                {
                    chk.DataSource = table;
                    chk.DataValueField = "code_value";
                    chk.DataTextField = "desc_thai";
                    chk.DataBind();
                    chk.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion Private Methods

        #region Master Table

        //public void LoadSkuType(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectSkuType();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "skuTypeID", "skuTypeNameTH");
        //}
        //public void LoadBrand(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectBrand();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "brandID", "brandNameTH");
        //}
        //public void LoadSuppliers(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectSuppliers();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "supplierID", "supplierNameTH");
        //}

        //public void LoadUnit(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectUnit();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "unitID", "unitNameTH");
        //}
        //public void LoadShop(int companyID, ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectShopByID(companyID);
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "shopID", "shopNameTH");
        //}

        //public void LoadShopCutValue(int companyID, ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectShopByID(companyID);
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "shopID", "shopNameTH", companyID.ToString());
        //}

        //public void LoadWarehouse(int shopID, ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectWarehouseByID(shopID);
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "warehouseID", "warehouseNameTH");
        //}

        //public void LoadSubDocType(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectSubDocType();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "subDocTypeID", "subDocTypeNameTH");
        //}

        //public void LoadSKU(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectSKU();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "skuID", "skuNameTH");
        //}

        //public void LoadPriceTag(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectPriceTag();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "priceTagID", "priceTagNameTH");
        //}

        //public void LoadGoodsPrice(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectGoodsPrice();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "goodsPriceID", "goodsPriceName");
        //}

        //public void LoadProductSortingType(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectProductSortingType();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "productSortingTypeID", "productSortingTypeNameTH");
        //}


        //public void LoadNegativeStock(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectNegativeStock();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "negativeStockID", "negativeStockNameTH");
        //}

        //public void LoadUserApprover(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectUserApprover();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "userID", "displayName");
        //}


        //public void LoadARLine(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectARLine();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "ARL_KEY", "ARL_NAME");
        //}
        //public void LoadARLineByID(ref DropDownList ddl, Enumerator.ConditionLoadEx condition, string id)
        //{
        //    DataSet tds = biz.SelectARLineByID(id);
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "ARL_KEY", "ARL_NAME");
        //}
        //public string LoadStockByID(ref RadioButton ddl, Enumerator.ConditionLoadEx condition, string SKM_SKU, string SKM_WL)
        //{
        //    DataSet tds = biz.SelectStockByID(SKM_SKU, SKM_WL);
        //    if (tds.Tables != null)
        //    {
        //        if (tds.Tables[0].Rows.Count != 0)
        //        {
        //            return tds.Tables[0].Rows[0][0].ToString();
        //        }
        //    }
        //    return "0";
        //}
        //public DataSet LoadARFileByID(int id)
        //{
        //    return biz.SelectARFileByID(id);
        //}

        //public void LoadTitle(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectTitle();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "titleCode", "titleShortNameThai");
        //}

        //public void LoadProvince(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectProvince();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "provinceCode", "provinceName");
        //}

        //public void LoadProvinceByGeography(ref DropDownList ddl, int id, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectProvinceByGeography(id);
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "provinceCode", "provinceName");
        //}

        //public void LoadDistrict(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectDistrict();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "districtCode", "districtName");
        //}

        //public void LoadDistrictByProvince(ref DropDownList ddl, int id, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectDistrictByProvince(id);
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "districtCode", "districtName");
        //}

        //public void LoadSubDistrict(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectSubDistrict();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "subDistrictCode", "subDistrictName");
        //}

        //public void LoadSubDistrictByDistrict(ref DropDownList ddl, int id, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectSubDistrictByDistrict(id);
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "subDistrictCode", "subDistrictName");
        //}

        //public void LoadColor(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectColor();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "colorCode", "colorNameThai");
        //}

        //public void LoadGeography(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectGeography();
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "geoCode", "geoName");
        //}
        public void LoadVatType(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectVatType();
            LoadCondition(tds.Tables[0], ref ddl, condition, "VatTypeID", "VatTypeNameTH");
        }
        public void LoadPaymentType(ref DropDownList ddl,int id, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectPaymentType(id);
            LoadCondition(tds.Tables[0], ref ddl, condition, "PaymentID", "PaymentNameTH");
        }
        public void LoadSupplyer(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectSupplyer();
            LoadCondition(tds.Tables[0], ref ddl, condition, "supplier_id", "supplier_name");
        }
        public void LoadCustomer(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectCustomer();
            LoadCondition(tds.Tables[0], ref ddl, condition, "customer_id", "customer_name");
        }
        public void LoadUnit(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectUnit();
            LoadCondition(tds.Tables[0], ref ddl, condition, "unit_id", "unit_name");
        }
        //public void LoadUnitById(ref DropDownList ddl, int id, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectUnitById(id);
        //    LoadCondition(tds.Tables[0], ref ddl, condition, "unit_id", "unit_name");
        //}
        public void LoadCategories(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectCategories();
            LoadCondition(tds.Tables[0], ref ddl, condition, "categories_id", "categories_name");
        }
        public void LoadSubcategoriesById(ref DropDownList ddl, int id, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectSubcategoriesById(id);
            LoadCondition(tds.Tables[0], ref ddl, condition, "subcategories_id", "subcategories_name");
        }
        public void LoadHeaderStatus(ref DropDownList ddl, int id, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectHeaderStatus(id);
            LoadCondition(tds.Tables[0], ref ddl, condition, "status_id", "status_name");
        }      
        public void LoadTitle(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectTitle();
            LoadCondition(tds.Tables[0], ref ddl, condition, "title_id", "title_name");
        }
        public void LoadProvince(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectProvince();
            LoadCondition(tds.Tables[0], ref ddl, condition, "provinceID", "provinceNameTH");
        }
        public void LoadDistrictById(ref DropDownList ddl, int id, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectDistrictById(id);
            LoadCondition(tds.Tables[0], ref ddl, condition, "districtID", "districtNameTH");
        }
        public void LoadSubDistrictById(ref DropDownList ddl, int id, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectSubDistrictById(id);
            LoadCondition(tds.Tables[0], ref ddl, condition, "subDistrictID", "subDistrictNameTH");
        }
        public void LoadZipCode(int id, Enumerator.ConditionLoadEx condition, ref TextBox txtb)
        {
            DataSet tds = biz.SelectZipCode(id);
            txtb.Text = tds.Tables[0].Rows[0]["zipCode"].ToString();
        }
        public void LoadDocType(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectDocType();
            LoadCondition(tds.Tables[0], ref ddl, condition, "doctype_id", "doctype_name");
        }
        public void LoadSubDocType(int id, ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectSubDocType(id);
            LoadCondition(tds.Tables[0], ref ddl, condition, "subDocTypeID", "subDocTypeName");
        }
        public void LoadWarehouse(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectWarehouse();
            LoadCondition(tds.Tables[0], ref ddl, condition, "warehouse_id", "warehouse_name");
        }
        public void LoadProduct(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        {
            DataSet tds = biz.SelectProduct();
            LoadCondition(tds.Tables[0], ref ddl, condition, "product_id", "product_name");
        }



        #endregion Master Table

        #region View Table
        //public DataSet LoadOccupation(int occupationClass)
        //{
        //    return biz.SelectOccupation(occupationClass);
        //}
        //public void LoadOccupation(ref DropDownList ddl, Enumerator.ConditionLoadEx condition, int occupationClass)
        //{
        //    DataSet tds = biz.SelectOccupation(occupationClass);
        //    LoadCondition(tds.Tables[0], ref ddl, condition);
        //}

        #endregion View Table

        #region Other Methods

        public DataTable GenDataTableCart()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("transDTID", typeof(int)));
            dt.Columns.Add(new DataColumn("transID", typeof(int)));
            dt.Columns.Add(new DataColumn("goodsID", typeof(int)));
            dt.Columns.Add(new DataColumn("goodsName", typeof(string)));
            dt.Columns.Add(new DataColumn("unitName", typeof(string)));
            dt.Columns.Add(new DataColumn("quantity", typeof(double)));
            dt.Columns.Add(new DataColumn("price", typeof(decimal)));
            dt.Columns.Add(new DataColumn("discount", typeof(decimal)));
            dt.Columns.Add(new DataColumn("cost", typeof(decimal)));
            dt.Columns.Add(new DataColumn("total", typeof(decimal)));
            return dt;
        }

        public DataTable GenDataTable(string tableName)
        {
            DataTable dt = new DataTable(tableName);
            dt.Columns.Add(new DataColumn("running", typeof(int)));
            dt.Columns.Add(new DataColumn("runningByCSV", typeof(int)));
            dt.Columns.Add(new DataColumn("ARID", typeof(int)));
            dt.Columns.Add(new DataColumn("ARCode", typeof(string)));
            dt.Columns.Add(new DataColumn("ARName", typeof(string)));
            dt.Columns.Add(new DataColumn("SKU_KEY", typeof(string)));
            dt.Columns.Add(new DataColumn("total", typeof(decimal)));
            dt.Columns.Add(new DataColumn("GOODS_KEY", typeof(string)));
            dt.Columns.Add(new DataColumn("GOODS_CODE", typeof(string)));
            dt.Columns.Add(new DataColumn("goodsName", typeof(string)));
            dt.Columns.Add(new DataColumn("locationName", typeof(string)));
            dt.Columns.Add(new DataColumn("qty", typeof(int)));
            dt.Columns.Add(new DataColumn("skuQty", typeof(int)));
            dt.Columns.Add(new DataColumn("unitQty", typeof(int)));
            dt.Columns.Add(new DataColumn("unitName", typeof(string)));
            dt.Columns.Add(new DataColumn("isVat", typeof(bool)));
            dt.Columns.Add(new DataColumn("isCredit", typeof(bool)));
            dt.Columns.Add(new DataColumn("docTypeName", typeof(string)));
            dt.Columns.Add(new DataColumn("docTypeID", typeof(int)));
            dt.Columns.Add(new DataColumn("payTypeID", typeof(int)));
            dt.Columns.Add(new DataColumn("payTypeName", typeof(string)));
            dt.Columns.Add(new DataColumn("price", typeof(decimal)));
            dt.Columns.Add(new DataColumn("perPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("extra", typeof(decimal)));
            dt.Columns.Add(new DataColumn("discount", typeof(decimal)));
            dt.Columns.Add(new DataColumn("discount_KeyIn", typeof(string)));
            dt.Columns.Add(new DataColumn("cost", typeof(decimal)));
            dt.Columns.Add(new DataColumn("kg", typeof(float)));
            dt.Columns.Add(new DataColumn("liter", typeof(float)));
            dt.Columns.Add(new DataColumn("sum", typeof(decimal)));
            dt.Columns.Add(new DataColumn("poCode", typeof(string)));
            dt.Columns.Add(new DataColumn("csvFileName", typeof(string)));
            dt.Columns.Add(new DataColumn("create_by", typeof(string)));
            dt.Columns.Add(new DataColumn("ip_client", typeof(string)));
            
            return dt;
        }

        public DataTable GenDataTableCSV(string tableName)
        {
            DataTable dt = new DataTable(tableName);
            dt.Columns.Add(new DataColumn("AR", typeof(string)));
            dt.Columns.Add(new DataColumn("goods", typeof(string)));
            dt.Columns.Add(new DataColumn("qty", typeof(string)));
            dt.Columns.Add(new DataColumn("price", typeof(string)));
            dt.Columns.Add(new DataColumn("discount", typeof(string)));
            dt.Columns.Add(new DataColumn("location", typeof(string)));
            dt.Columns.Add(new DataColumn("docTypeName", typeof(string)));
            dt.Columns.Add(new DataColumn("payTypeName", typeof(string)));
            dt.Columns.Add(new DataColumn("running", typeof(int)));
            return dt;
        }

        // map csv columns
        public DataRow MapCSVColumns(DataRow row, int running)
        {
            try
            {
                DataTable dt = GenDataTableCSV("temp");
                DataRow newRow = dt.NewRow();
                newRow["AR"] = ConvertHelper.InitialValueDB(row, "ARCode") + " " + ConvertHelper.InitialValueDB(row, "ARName");
                newRow["goods"] = ConvertHelper.InitialValueDB(row, "GOODS_CODE");
                newRow["qty"] = ConvertHelper.InitialValueDB(row, "qty");
                newRow["price"] = ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(row, "price")) + ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(row, "extra"));
                newRow["discount"] = (ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(row, "discount")) > 0) ? ConvertHelper.InitialValueDB(row, "qty").Trim(' ') + "*" + (ConvertHelper.ToDecimal(ConvertHelper.InitialValueDB(row, "discount"))) + "º." : "";
                newRow["location"] = ConvertHelper.InitialValueDB(row, "locationName");
                newRow["docTypeName"] = ConvertHelper.InitialValueDB(row, "docTypeName");
                newRow["payTypeName"] = ConvertHelper.InitialValueDB(row, "payTypeName");
                newRow["running"] = running;
                //dt.Rows.Add(newRow);
                return newRow;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public DataTable SelectInsertedFiles()
        //{
        //    return biz.SelectInsertedFiles();
        //}

        //public void UpdateMovedFiles(string TKH_last)
        //{
        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable("TKH_last");
        //    dt.Columns.Add(new DataColumn("TKH_last", typeof(string)));
        //    DataRow dr = dt.NewRow();
        //    dr["TKH_last"] = TKH_last;
        //    dt.Rows.Add(dr);
        //    ds.Tables.Add(dt);

        //    biz.SaveData(ds, "UpdateMovedFiles");
        //}

        //public void MoveUsedFiles(string ServerName)
        //{
        //    string CSVFolder = "CSV_FILES\\";
        //    string BackupFolder = "CSV_FILES_BACKUP\\";
        //    try 
	       // {	        
		      //  string csvFileName = "";
        //        string dateFolder ="";
        //        string TKH_last ="";
        //        DataTable dt = SelectInsertedFiles();
        //        TextFile fileHelp = new TextFile();
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            csvFileName = ConvertHelper.InitialValueDB(dr, "csvFileName");
        //            dateFolder = ConvertHelper.InitialValueDB(dr, "DI_DATE") + "\\";
        //            TKH_last = ConvertHelper.InitialValueDB(dr, "TKH_last");

        //            fileHelp.MoveFile(ServerName + CSVFolder, ServerName + BackupFolder + dateFolder, csvFileName, ".txt");
        //            UpdateMovedFiles(TKH_last);
        //        }
	       // }
	       // catch (Exception)
	       // {
		
		      //  throw;
	       // }
        //}

        //public void LoadCountry(ref DropDownList ddl, Enumerator.ConditionLoadEx condition)
        //{
        //    DataSet tds = biz.SelectCountry();
        //    LoadCondition(tds.Tables[0], ref ddl, condition);
        //}

        //public void LoadProvinceByCountry(ref DropDownList ddl, Enumerator.ConditionLoadEx condition, string code)
        //{
        //    DataSet tds = biz.SelectProvinceByCountry(code);
        //    LoadCondition(tds.Tables[0], ref ddl, condition);
        //}

        //public void LoadDistrictByProvince(ref DropDownList ddl, Enumerator.ConditionLoadEx condition, string code)
        //{
        //    DataSet tds = biz.SelectDistrictByProvince(code);
        //    LoadCondition(tds.Tables[0], ref ddl, condition);
        //}

        //public void LoadSubDistrictByDistrict(ref DropDownList ddl, Enumerator.ConditionLoadEx condition, string code)
        //{
        //    DataSet tds = biz.SelectSubDistrictByDistrict(code);
        //    LoadCondition(tds.Tables[0], ref ddl, condition);
        //}
        //public void LoadZipCodeBySubDistrict(ref DropDownList ddl, Enumerator.ConditionLoadEx condition, string subDistrict)
        //{
        //    DataSet tds = biz.SelectZipCodeBySubDistrict(subDistrict);
        //    LoadCondition(tds.Tables[0], ref ddl, condition);
        //}

        //public static List<LocationParam> LoadProvinceByCountry(string countryCode)
        //{
        //    List<LocationParam> list = new List<LocationParam>();
        //    try
        //    {
        //        LoadExHelperBiz hbiz = new LoadExHelperBiz();
        //        LocationDS tds = hbiz.SelectProvinceByCountry(countryCode);
        //        LocationParam pa = new LocationParam();
        //        pa.Code_value = "0";
        //        pa.Desc_thai = ConstanceInfo.SelectThai;
        //        list.Add(pa);

        //        foreach (DataRow row in tds.Location.Rows)
        //        {
        //            pa = new LocationParam();
        //            pa.Code_value = row["code_value"].ToString();
        //            pa.Desc_thai = row["desc_thai"].ToString(); ;
        //            list.Add(pa);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return list;
        //}

        //public static List<LocationParam> LoadDistrictByProvince(string code)
        //{
        //    List<LocationParam> list = new List<LocationParam>();
        //    try
        //    {
        //        LoadExHelperBiz hbiz = new LoadExHelperBiz();
        //        LocationDS tds = hbiz.SelectDistrictByProvince(code);
        //        LocationParam pa = new LocationParam();
        //        pa.Code_value = "0";
        //        pa.Desc_thai = ConstanceInfo.SelectThai;
        //        list.Add(pa);

        //        foreach (DataRow row in tds.Location.Rows)
        //        {
        //            pa = new LocationParam();
        //            pa.Code_value = row["code_value"].ToString();
        //            pa.Desc_thai = row["desc_thai"].ToString(); ;
        //            list.Add(pa);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return list;
        //}

        //public static List<LocationParam> LoadSubDistrictByDistrict(string code)
        //{
        //    List<LocationParam> list = new List<LocationParam>();
        //    try
        //    {
        //        LoadExHelperBiz hbiz = new LoadExHelperBiz();
        //        LocationDS tds = hbiz.SelectSubDistrictByDistrict(code);
        //        LocationParam pa = new LocationParam();
        //        pa.Code_value = "0";
        //        pa.Desc_thai = ConstanceInfo.SelectThai;
        //        list.Add(pa);

        //        foreach (DataRow row in tds.Location.Rows)
        //        {
        //            pa = new LocationParam();
        //            pa.Code_value = row["code_value"].ToString();
        //            pa.Desc_thai = row["desc_thai"].ToString(); ;
        //            list.Add(pa);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return list;
        //}

        #endregion Other Methods
    }
}
