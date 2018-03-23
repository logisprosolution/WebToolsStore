using System;
using System.Data;
using System.Configuration;

namespace WebToolsStore
{
    public class ConfigurationInfo
    {
        //

        private static string eXCEL_FORMATE_DATE;
        public static string EXCEL_FORMATE_DATE
        {
            get
            {
                if (string.IsNullOrEmpty(eXCEL_FORMATE_DATE))
                    eXCEL_FORMATE_DATE = ConfigurationManager.AppSettings["EXCEL_FORMATE_DATE"];
                return eXCEL_FORMATE_DATE;
            }
        }
        //TEMPLATE_FILE_NAME
        private static string tEMPLATE_FILE_NAME;
        public static string TEMPLATE_FILE_NAME
        {
            get
            {
                if (string.IsNullOrEmpty(tEMPLATE_FILE_NAME))
                    tEMPLATE_FILE_NAME = ConfigurationManager.AppSettings["TEMPLATE_FILE_NAME"];
                return tEMPLATE_FILE_NAME;
            }
        }
        private static string eXCEL_CULTUREINFO;
        public static string EXCEL_CULTUREINFO
        {
            get
            {
                if (string.IsNullOrEmpty(eXCEL_CULTUREINFO))
                    eXCEL_CULTUREINFO = ConfigurationManager.AppSettings["EXCEL_CULTUREINFO"];
                return eXCEL_CULTUREINFO;
            }
        }

        private static string fAC_EXCEL_CULTUREINFO;
        public static string FAC_EXCEL_CULTUREINFO
        {
            get
            {
                if (string.IsNullOrEmpty(fAC_EXCEL_CULTUREINFO))
                    fAC_EXCEL_CULTUREINFO = ConfigurationManager.AppSettings["FAC_EXCEL_CULTUREINFO"];
                return fAC_EXCEL_CULTUREINFO;
            }
        }
        //
        private static string eXCEL_CONNECTION;
        public static string EXCEL_CONNECTION
        {
            get
            {
                if (string.IsNullOrEmpty(eXCEL_CONNECTION))
                    eXCEL_CONNECTION = ConfigurationManager.AppSettings["EXCEL_CONNECTION"];
                return eXCEL_CONNECTION;
            }
        }
        private static string folderFileUpload;
        public static string FolderFileUpload
        {
            get
            {
                if (string.IsNullOrEmpty(folderFileUpload))
                    folderFileUpload = ConfigurationManager.AppSettings["FolderFileUpload"];
                return folderFileUpload;
            }
        }
        private static string fORMATE_DATE_TIME_UPLOAD;
        public static string FORMATE_DATE_TIME_UPLOAD
        {
            get
            {
                if (string.IsNullOrEmpty(fORMATE_DATE_TIME_UPLOAD))
                    fORMATE_DATE_TIME_UPLOAD = ConfigurationManager.AppSettings["FORMATE_DATE_TIME_UPLOAD"];
                return fORMATE_DATE_TIME_UPLOAD;
            }
        }
        //
        private static string fORMATE_RECEIVE;
        public static string FORMATE_RECEIVE
        {
            get
            {
                if (string.IsNullOrEmpty(fORMATE_RECEIVE))
                    fORMATE_RECEIVE = ConfigurationManager.AppSettings["FORMATE_RECEIVE"];
                return fORMATE_RECEIVE;
            }
        }
        //
        //
        private static string lOGINMODE;
        public static string LOGINMODE
        {
            get
            {
                if (string.IsNullOrEmpty(lOGINMODE))
                    lOGINMODE = ConfigurationManager.AppSettings["LOGINMODE"];
                return lOGINMODE;
            }
        }
        private static string aPPLICATION_ID;
        public static string APPLICATION_ID
        {
            get
            {
                if (string.IsNullOrEmpty(aPPLICATION_ID))
                    aPPLICATION_ID = ConfigurationManager.AppSettings["APPLICATION_ID"];
                return aPPLICATION_ID;
            }
        }

        private static string cULTUREINFO_BATCHNUMBER;
        public static string CULTUREINFO_BATCHNUMBER
        {
            get
            {
                if (string.IsNullOrEmpty(cULTUREINFO_BATCHNUMBER))
                    cULTUREINFO_BATCHNUMBER = ConfigurationManager.AppSettings["CULTUREINFO_BATCHNUMBER"];
                return cULTUREINFO_BATCHNUMBER;
            }
        }

        private static string fORMATE_DATE_BATCHNUMBER;
        public static string FORMATE_DATE_BATCHNUMBER
        {
            get
            {
                if (string.IsNullOrEmpty(fORMATE_DATE_BATCHNUMBER))
                    fORMATE_DATE_BATCHNUMBER = ConfigurationManager.AppSettings["FORMATE_DATE_BATCHNUMBER"];
                return fORMATE_DATE_BATCHNUMBER;
            }
        }

        private static string fORMATE_YEAR_BATCHNUMBER;
        public static string FORMATE_YEAR_BATCHNUMBER
        {
            get
            {
                if (string.IsNullOrEmpty(fORMATE_YEAR_BATCHNUMBER))
                    fORMATE_YEAR_BATCHNUMBER = ConfigurationManager.AppSettings["FORMATE_YEAR_BATCHNUMBER"];
                return fORMATE_YEAR_BATCHNUMBER;
            }
        }
        private static string cURRENT_RECEIVE;
        public static string CURRENT_RECEIVE
        {
            get
            {
                if (string.IsNullOrEmpty(cURRENT_RECEIVE))
                    cURRENT_RECEIVE = ConfigurationManager.AppSettings["CURRENT_RECEIVE"];
                return cURRENT_RECEIVE;
            }
        }
        private static string userName;

        public static string UserName
        {
            get
            {
                if (string.IsNullOrEmpty(userName))
                    userName = ConfigurationManager.AppSettings["USERNAME"];
                return userName;
            }
        }
        private static string password;

        public static string Password
        {
            get
            {
                if (string.IsNullOrEmpty(password))
                    password = ConfigurationManager.AppSettings["PASSWORD"];
                return password;
            }
        }


        private static string companyCode;

        public static string CompanyCode
        {
            get
            {
                if (string.IsNullOrEmpty(companyCode))
                    companyCode = ConfigurationManager.AppSettings["Company_Code"];
                return companyCode;
            }
        }
        //FORMATE_RECEIVE400

        private static string fORMATE_RECEIVE400;

        public static string FORMATE_RECEIVE400
        {
            get
            {
                if (string.IsNullOrEmpty(fORMATE_RECEIVE400))
                    fORMATE_RECEIVE400 = ConfigurationManager.AppSettings["FORMATE_RECEIVE400"];
                return fORMATE_RECEIVE400;
            }
        }
        private static string cURRENT_400;

        public static string CURRENT_400
        {
            get
            {
                if (string.IsNullOrEmpty(cURRENT_400))
                    cURRENT_400 = ConfigurationManager.AppSettings["CURRENT_400"];
                return cURRENT_400;
            }
        }

        private static string sUCCESS;

        public static string SUCCESS
        {
            get
            {
                if (string.IsNullOrEmpty(sUCCESS))
                    sUCCESS = ConfigurationManager.AppSettings["SUCCESS"];
                return sUCCESS;
            }
        }
        //REPLACE_CAR_REGNO

        private static string rEPLACE_CAR_REGNO;

        public static string REPLACE_CAR_REGNO
        {
            get
            {
                if (string.IsNullOrEmpty(rEPLACE_CAR_REGNO))
                    rEPLACE_CAR_REGNO = ConfigurationManager.AppSettings["REPLACE_CAR_REGNO"];
                return rEPLACE_CAR_REGNO;
            }
        }

        private static string nEW_CAR_REGNO;

        public static string NEW_CAR_REGNO
        {
            get
            {
                if (string.IsNullOrEmpty(nEW_CAR_REGNO))
                    nEW_CAR_REGNO = ConfigurationManager.AppSettings["NEW_CAR_REGNO"];
                return nEW_CAR_REGNO;
            }
        }
        private static string proxyHost;

        public static string ProxyHost
        {
            get
            {
                if (string.IsNullOrEmpty(proxyHost))
                    proxyHost = ConfigurationManager.AppSettings["ProxyHost"];
                return proxyHost;
            }
        }
        private static int proxyPort = -1;

        public static int ProxyPort
        {
            get
            {
                if (proxyPort == -1)
                    proxyPort = ConvertHelper.ToInt(ConfigurationManager.AppSettings["ProxyPort"]);
                return proxyPort;
            }
        }

        private static string proxyUser;

        public static string ProxyUser
        {
            get
            {
                if (string.IsNullOrEmpty(proxyUser))
                    proxyUser = ConfigurationManager.AppSettings["ProxyUser"];
                return proxyUser;
            }
        }
        private static string proxyPassword;

        public static string ProxyPassword
        {
            get
            {
                if (string.IsNullOrEmpty(proxyPassword))
                    proxyPassword = ConfigurationManager.AppSettings["ProxyPassword"];
                return proxyPassword;
            }
        }

        public static bool IsUseProxy
        {
            get
            {
                return ConvertHelper.ToBoolean(ConfigurationManager.AppSettings["IsUseProxy"]);
            }
        }

        public static string CULTUREINFO_DISPLAY
        {
            get
            {
                return ConfigurationManager.AppSettings["CULTUREINFO_DISPLAY"];
            }
        }
        public static string FORMATE_DATE_DISPLAY
        {
            get
            {
                return ConfigurationManager.AppSettings["FORMATE_DATE_DISPLAY"];
            }
        }
        public static string FORMATE_DATE_TIME_DISPLAY
        {
            get
            {
                return ConfigurationManager.AppSettings["FORMATE_DATE_TIME_DISPLAY"];
            }
        }
        public static string FORMATE_DATE_TIME_DISPLAY_TO_EBAO
        {
            get
            {
                return ConfigurationManager.AppSettings["FORMATE_DATE_TIME_DISPLAY_TO_EBAO"];
            }
        }

        public static string MEMBERCONNECTION
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MemberConnection"].ConnectionString;
            }
        }

        public static string DBCONNECTION
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            }
        }
        public static string GetConnectionExcel(string pathFile)
        {
            return string.Format(ConfigurationInfo.EXCEL_CONNECTION, pathFile);
        }
    }
}
