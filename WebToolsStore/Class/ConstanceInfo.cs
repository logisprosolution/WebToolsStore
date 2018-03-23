using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace WebToolsStore
{
    public class ConstanceInfo
    {
        public const string UserName = "user_name";
        public const string RESULT_TOTAL = "Search Results {0} Record(s)";
        public const string PERCENT = "P";
        public const string NET = "A";
        public const string F = "F";
        public const string M = "M";
        public const string FORMATEID = "yyyyMMdd";
        public const string DBCONNECTION = "DbConnection";
        public const string StringEmpty = "";
        public const string AllThai = "ทั้งหมด";
        public const string AllEng = "All";
        public const string SelectThai = "กรุณาเลือก";
        public const string SelectEng = "Please select";
        public const string RIT = "0004";
        public const string RIC = "0001";
        public const string RECEIVED_NUMBER = "0001";
        public const string CC_BATCH_NUMBER = "0003";
        public const string TREATY_BATCH_NUMBER = "0003";
        public const string AMOUNT_CODE_DEPOSIT = "0001";
        public const string AMOUNT_CODE_WITHDRAWAL = "0002";
        public const string CASH_CALL_NON_REFUND = "0002";
        public const string CASH_CALL_REQUEST = "0001";
        public const string CASH_CALL_RECEIVED = "0002";
        public const string CASHCALLCREATERICDS = "TDS_CASHCALLCREATERICDS_CASHCALLUPDATERICLIST_CASHCALLUPDATERICINFO";
        public const string CASHCALLUPDATESELECTRIC = "CASHCALLUPDATESELECTRIC";
        public const string KeyReportParameters = "ParamReports";
        public const string TYPE_BRING_FORWARD = "TYPE_BRING_FORWARD";
        public const string CASHCALLMAINDS_CASHCALLUPLOADSTATEMENTINFO = "CASHCALLMAINDS_CASHCALLUPLOADSTATEMENTINFO";
        public const string TREATY_UPLOADEXCEL_INFO = "TREATY_UPLOADEXCEL_INFO";
        public const string TOTAL = "Total";
        public const string FORMAT_BATCH_NUMBER = "FORMAT_BATCH_NUMBER";

        public static bool IsValidateStringEmpty(object value)
        {

            if ((value == null) || (string.IsNullOrEmpty(value.ToString())))
            {
                return true;
            }
            return false;
        }
        public static string ValidateAll(object value)
        {

            if ((value == null) || (value.ToString() == AllThai))
            {
                return string.Empty;
            }
            else if ((value == null) || (value.ToString() == AllEng))
            {
                return string.Empty;
            }

            return value.ToString();
        }
        public static bool IsAll(object value)
        {

            if ((value == null) || (value.ToString() == AllThai))
            {
                return true;
            }
            else if ((value == null) || (value.ToString() == AllEng))
            {
                return true;
            }
            return false;
        }
    }
}
