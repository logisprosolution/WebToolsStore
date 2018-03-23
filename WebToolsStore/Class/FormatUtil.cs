using System;
using System.Data;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace WebToolsStore
{
    public class FormatUtil
    {
        #region FormatUtil

        #endregion FormatUtil

        #region Isnumeric

        public static bool Isnumeric(object value)
        {
            double tmp;
            if (value != null)
                return double.TryParse(value.ToString(), out tmp);
            else
                return false;
        }

        #endregion Isnumeric

        #region Isdatetime

        public static bool Isdatetime(object value)
        {
            DateTime tmp;
            return DateTime.TryParse(value.ToString(), out tmp);
        }

        #endregion Isdatetime

        #region NowTimeToIntTime

        /// <summary>
        /// Change Now time to int time form "HHMMSS".
        /// </summary>
        /// <returns>int represent now int format</returns>
        public static int NowTimeToIntTime()
        {
            int nowTimeInt = 0;
            try
            {
                nowTimeInt = DateTimeToIntTime(DateTime.Now);
                //(DateTime.Now);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nowTimeInt;
        }

        #endregion NowTimeToIntTime

        #region DateTimeToIntTime

        public static int DateTimeToIntTime(DateTime dateTime)
        {
            int timeInt = 0;
            try
            {
                string timeString = dateTime.ToString("HHmmss");
                timeInt = Convert.ToInt32(timeString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return timeInt;
        }

        #endregion DateTimeToIntTime

        #region IntTimeToTodayTime

        /// <summary>
        /// Change int form "HHMMSS" to date is today and use time from parameter.
        /// </summary>
        /// <param name="timeIntForm">int time format "HHMMSS"</param>
        /// <returns>datetime concate today date and time from parameter</returns>
        public static DateTime IntTimeToTodayTime(int timeIntForm)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            double HH = timeIntForm / 10000;
            double ss = timeIntForm % 100;
            double MM = (timeIntForm - 10000 * (int)HH) / 100;
            //TODO: ยังไม่ได้แก้ให้ใช้ ApplicationDateTime
            DateTime result = DateTime.Today.AddHours(HH).AddMinutes(MM).AddSeconds(ss);
            return result;
        }

        #endregion IntTimeToTodayTime

        #region PriceFormat

        public static string PriceFormat(decimal price, bool isDigit)
        {
            string retString = string.Empty;
            if (Math.Round(price, 2) == 0M)
                retString = "0.00";
            else
            {
                //if (price < 1M)
                //    Console.WriteLine("");
                if (isDigit)
                {
                    retString = price.ToString("#,##0.00");
                }
                else
                {
                    if (price == Convert.ToInt64(price))
                        retString = price.ToString("#,##0");
                    else
                        retString = price.ToString("#,##0.00");
                }
            }
            return retString;
        }

        public static string PriceFormat(object price, bool isDigit)
        {
            string retString = string.Empty;
            double dPrice;
            if (double.TryParse(price.ToString(), out dPrice))
            {
                if (Math.Round(dPrice, 2) == 0)
                    retString = string.Empty;
                else
                {
                    if (isDigit)
                        retString = dPrice.ToString("#,##0.00");
                    else
                    {
                        if (dPrice == Convert.ToInt64(dPrice))
                            retString = dPrice.ToString("#,##0");
                        else
                            retString = dPrice.ToString("#,##0.00");
                    }
                }
            }
            else
                retString = price.ToString();

            return retString;
        }

        public static string PriceFormat(object price, string unit, bool isDigit)
        {
            string ret = PriceFormat(price, isDigit);
            if (ret != string.Empty)
                ret += unit;
            return ret;
        }

        public static string PriceFormat(object price, bool sign, string unit, bool isDigit)
        {
            string retString = PriceFormat(price, unit, isDigit);
            if (retString != string.Empty)
            {
                if (Isnumeric(price))
                {
                    if (sign)
                    {
                        if (Convert.ToDecimal(price) > 0)
                            return "+" + retString;
                    }
                }
                else
                    return price.ToString();
            }
            return retString;
        }

        #endregion PriceFormat

        #region PriceBySideFormat

        public static string PriceBySideFormat(object price, string buySellSide, bool isDigit)
        {
            string retString = PriceFormat(price, isDigit);
            if (buySellSide.ToUpper() == "B")
                retString = "+" + retString;
            else if (buySellSide.ToUpper() == "S")
                retString = "-" + retString;

            return retString;
        }

        #endregion PriceBySideFormat

        #region VolumeFormat

        public static string VolumeFormat(object volume, bool comma)
        {
            string ret = string.Empty;

            double lVolume;
            if (double.TryParse(volume.ToString(), out lVolume))
            {
                if (lVolume == 0)
                    ret = string.Empty;
                else
                {
                    if (comma)
                        ret = lVolume.ToString("#,###");
                    else
                        ret = lVolume.ToString("F0"); //ret = volume.ToString();
                }
            }
            else
                ret = volume.ToString();

            return ret;
        }

        #endregion VolumeFormat

        #region ValueFormat

        public static string ValueFormat(decimal value, bool comma)
        {
            string retString = string.Empty;

            if (value == 0M)
                retString = "0";
            else
            {
                //double dPrice = Convert.ToDouble(value);
                //if (dPrice == Convert.ToInt64(dPrice))
                if (value == Convert.ToInt64(value))
                {
                    if (comma)
                        retString = value.ToString("#,###");
                    else
                        retString = value.ToString("####");
                }
                else
                {
                    if (comma)
                        retString = value.ToString("#,###.##");
                    else
                        retString = value.ToString("####.##");
                }
            }

            return retString;
        }

        #endregion VolumeFormat

        #region PriceFormat5Digit

        public static string PriceFormat5Digit(object price)
        {
            string retString = string.Empty;
            double dPrice;
            if (double.TryParse(price.ToString(), out dPrice))
            {
                if (Math.Round(dPrice, 2) == 0)
                    retString = string.Empty;
                else
                {
                    if (dPrice == Convert.ToInt64(dPrice))
                        retString = dPrice.ToString("#,##0");
                    else
                        retString = dPrice.ToString("#,##0.00000");
                }
            }
            else
                retString = price.ToString();

            return retString;
        }

        #endregion PriceFormat5Digit

        #region PriceFormat4Digit
        public static string PriceFormat4Digit(object price)
        {
            string retString = string.Empty;
            double dPrice;
            if (double.TryParse(price.ToString(), out dPrice))
            {
                //if (Math.Round(dPrice, 2) == 0)
                //    retString = string.Empty;
                //else
                //{
                //    if (dPrice == Convert.ToInt64(dPrice))
                //        retString = dPrice.ToString("#,##0");
                //    else
                retString = dPrice.ToString("#,##0.0000");
                //}
            }
            else
                retString = price.ToString();

            return retString;
        }
        #endregion PriceFormat4Digit

    }
}
