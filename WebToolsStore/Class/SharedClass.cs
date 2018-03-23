using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebToolsStore
{

    public class SharedClass
    {

        public string CheckCost(decimal perPrice, decimal cost)
        {
            try
            {
                string message = "";
                if (perPrice < cost)
                {
                    message = "ไม่สามารถขายต่ำกว่าทุนได้";
                }
                return message;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        public string CheckCredit(decimal creditAmount, decimal sumTotal, decimal creditLimit)
        {
            try
            {
                string message = "";
                if (creditAmount < sumTotal && creditLimit != 0)
                {
                    message = "ขออภัย วงเงินของท่านไม่เพียงพอ";
                }
                return message;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DataRow> CheckAvaliable(DataTable dt, string GOODS_KEY, int skuQty, int utqQty, string locationName, bool isCredit, bool isVat, bool isTransfer)
        {
            try
            {
                List<DataRow> deletedRows = new List<DataRow>();
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["GOODS_KEY"].ToString() == GOODS_KEY)
                    {
                        skuQty += (ConvertHelper.ToInt(dr["qty"].ToString()) * utqQty);

                        if (dr["docTypeName"].ToString() == GetDocTypeName(locationName, isCredit, isVat, isTransfer) && ConvertHelper.ToBoolean(dr["isVat"]) == isVat && ConvertHelper.ToBoolean(dr["isCredit"]) == isCredit)
                        {
                            deletedRows.Add(dr);
                        }
                    }
                }
                return deletedRows;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetDocTypeName(string locationName, bool isCredit, bool isVat, bool isTransfer)
        {
            try
            {
                if (isTransfer == true)
                {
                    return "DMXX";
                }
                if (locationName == "XXX" || locationName == "CGOD")
                {
                    if (isCredit)
                    {
                        if (isVat)
                        {
                            return "SIV";
                        }
                        else
                        {
                            return "SIN";
                        }
                    }
                    else
                    {
                        if (isVat)
                        {
                            return "SCV";
                        }
                        else
                        {
                            return "SCN";
                        }
                    }
                }
                else
                {
                    if (isCredit)
                    {
                        if (isVat)
                        {
                            return "SISV";
                        }
                        else
                        {
                            return "SISN";
                        }
                    }
                    else
                    {
                        if (isVat)
                        {
                            return "SCSV";
                        }
                        else
                        {
                            return "SCSN";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

                

                
    }
}