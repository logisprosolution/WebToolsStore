using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebToolsStore.Data;


namespace WebToolsStore
{
    public class ApplicationWebInfo
    {
        #region User

        private static string USER = "USER";

        public static USR_User User
        {
            get
            {
                if (HttpContext.Current.Session[USER] == null)
                    return null;
                else
                    return (USR_User)HttpContext.Current.Session[USER];
            }
            set { HttpContext.Current.Session[USER] = value; }
        }

        public static string UserDisplayName
        {
            get
            {
                if (HttpContext.Current.Session["UserDisplayName"] == null)
                    return string.Empty;
                else
                    return HttpContext.Current.Session["UserDisplayName"].ToString();
            }
        }
        //public static string Tel
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session[USER] == null)
        //            return string.Empty;
        //        else
        //            return User..Phone.ToString();
        //    }
        //}

        public static int UserID
        {
            get
            {
                if (HttpContext.Current.Session["UserID"] == null)
                    return 0;
                else
                {
                    return ConvertHelper.ToInt(HttpContext.Current.Session["UserID"]);
                }

            }

        }

        public static string UserPassword
        {
            get
            {
                if (HttpContext.Current.Session["UserPassword"] == null)
                    return "";
                else
                {
                    return HttpContext.Current.Session["UserPassword"].ToString();
                }

            }

        }

        public static string UserProfileID
        {
            get
            {
                if (HttpContext.Current.Session["UserProfileID"] == null)
                    return "";
                else
                {
                    return HttpContext.Current.Session["UserProfileID"].ToString();
                }

            }

        }

        public static int ShopID
        {
            get
            {
                if (HttpContext.Current.Session["ShopID"] == null)
                    return 0;
                else
                {
                    return ConvertHelper.ToInt(HttpContext.Current.Session["ShopID"]);
                }

            }

        }

        public static int WL_KEY
        {
            get
            {
                if (HttpContext.Current.Session["WL_KEY"] == null)
                    return 0;
                else
                {
                    return ConvertHelper.ToInt(HttpContext.Current.Session["WL_KEY"]);
                }

            }

        }

        public static string WL_CODE
        {
            get
            {
                if (HttpContext.Current.Session["WL_CODE"] == null)
                    return "";
                else
                {
                    return ConvertHelper.ToString(HttpContext.Current.Session["WL_CODE"]);
                }

            }

        }

        public static string WL_NAME
        {
            get
            {
                if (HttpContext.Current.Session["WL_NAME"] == null)
                    return "";
                else
                {
                    return ConvertHelper.ToString(HttpContext.Current.Session["WL_NAME"]);
                }

            }

        }


        //public static int GroupID
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session[USER] == null)
        //            return -1;
        //        else
        //            return User.user_info[0].GroupId;

        //    }

        //}

        #endregion User
    }
}