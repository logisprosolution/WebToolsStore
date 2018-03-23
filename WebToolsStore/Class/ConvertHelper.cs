using System;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;

namespace WebToolsStore
{
    public static class ConvertHelper
    {

        #region Absolute
        public static double Absolute(double val)
        {
            return System.Math.Abs(val);
        }
        public static decimal Absolute(decimal val)
        {
            return System.Math.Abs(val);
        }
        #endregion Absolute

        #region Digit2
        public static double Digit2(double val)
        {
            return System.Math.Round(val, 2);
        }
        public static decimal Digit2(decimal val)
        {
            return System.Math.Round(val, 2);
        }
        #endregion Digit2

        #region Round
        public static double Round(double val)
        {
            if (val > 0)
                val = val - 0.01;
            Int64 value = Convert.ToInt64(val);
            return ToDouble(value);
        }
        public static decimal Round(decimal val)
        {
            if (val > 0)
                val = val - ToDecimal(0.01);
            Int64 value = Convert.ToInt64(val);
            return ToDecimal(value);
        }
        #endregion Round

        #region ToInt
        public static int ToBooleanToInt(DataRow row, string columnName)
        {

            bool val = ToBoolean(row[columnName]);
            return ToInt(val);

        }

        public static string ToBooleanToIntToString(DataRow row, string columnName)
        {

            bool val = ToBoolean(row[columnName]);
            return InitialValueDB(ToInt(val));

        }
        public static int ToInt(DataRow row, string columnName)
        {
            return ToInt(row[columnName]);
        }
        public static int ToInteBao(DataRow row, string columnName)
        {
            return ToInteBao(row[columnName]);
        }

        public static int ToInt(object value)
        {
            int result = -1;
            if (value != null)
            {
                if (value is Boolean)
                {
                    return Convert.ToInt32(value);
                }
                else if (int.TryParse(value.ToString(), out result))
                {
                    //result = Convert.ToInt32("1.2");
                    return result;
                }


                else
                {
                    return Convert.ToInt32(ToDecimal(value));
                    //return  Convert.ToInt32(value);

                }
            }
            return -1;
        }
        public static int ToInteBao(object value)
        {
            int result = -1;
            if (value != null)
            {
                if (value is Boolean)
                {
                    result = Convert.ToInt32(value);
                }
                else if (!(int.TryParse(value.ToString(), out result)))
                {
                    //result = Convert.ToInt32("1.2");
                    result = Convert.ToInt32(ToDecimal(value)); ;
                }

            }
            if (result != 1)
            {
                result = 2;
            }
            return result;
        }
        #endregion ToInt

        #region ToString
        public static string ToString(object value)
        {

            if (value == null)
                return string.Empty;
            return value.ToString();
        }
        public static string ToStringEmpty(DataRow row, string colName)
        {
            return ToStringEmpty(row[colName]);
        }
        public static string ToStringEmpty(object value)
        {
            try
            {
                if (value == null)
                    return string.Empty;
                if (value.ToString().ToUpper() == "(EMPTY)")
                    return string.Empty;
                return value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string ToStringEmpty(object value, bool isTrim)
        {
            try
            {
                if (value == null)
                    return string.Empty;
                if (isTrim)
                {
                    value = value.ToString().Trim();
                    return value.ToString();
                }
                else
                    return value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion ToString

        public static float ToFloat(object value)
        {
            float result = 0;
            if (value != null)
                float.TryParse(value.ToString(), out result);
            return result;
        }
        #region ToDecimal

        public static decimal ToDecimal(object value)
        {
            decimal result = 0M;
            if (value != null)
                decimal.TryParse(value.ToString(), out result);
            return result;
        }


        public static double ToDouble(object value)
        {
            double result = 0;
            if (value != null)
                double.TryParse(value.ToString(), out result);
            return result;
        }
        public static decimal ToDecimalAndAbs(object value)
        {
            decimal result = 0M;
            if (value != null)
                decimal.TryParse(value.ToString(), out result);
            return Absolute(result);
        }

        public static double ToDoubleAndAbs(object value)
        {
            double result = 0;
            if (value != null)
                double.TryParse(value.ToString(), out result);
            return Absolute(result);
        }
        #endregion ToDecimal

        public static bool IsStringEmpty(object val)
        {
            return (ConvertHelper.ToStringEmpty(val) == string.Empty);
        }
        public static bool IsStringEmpty(DataRow row, string colName)
        {
            return (ConvertHelper.ToStringEmpty(row, colName) == string.Empty);
        }
        public static bool IsStringEmptyOrZero(DataRow row, string colName)
        {
            string val = ConvertHelper.ToStringEmpty(row, colName);
            return (string.IsNullOrEmpty(val) || (val == "0"));
        }
        public static bool IsStringEmpty(object val, bool isTrim)
        {
            return (ConvertHelper.ToStringEmpty(val, isTrim) == string.Empty);
        }

        #region IsIdentity
        public static bool IsIdentity(string ID)
        {
            string identity = ID;
            int pin = 0;
            int j = 13;
            int pin_num = 0;
            if (string.IsNullOrEmpty(identity))
                return false;
            if (identity.Length != 13)
                return false;
            for (int i = 0; i < identity.Length; i++)
            {
                if (i != 12)
                {
                    pin = ToInt(identity.Substring(i, 1)) * j + pin;
                }
                j--;
            }
            pin_num = (11 - (pin % 11)) % 10;
            return (ToInt(identity.Substring(12, 1)) == pin_num);
        }

        #endregion IsIdentity

        #region ToDateTime

        public static DateTime ToDateTime(object value)
        {
            DateTime result = DateTime.Now;
            value = value.ToString().Trim();
            //CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            if (DateTime.TryParseExact(value.ToString(), ConfigurationInfo.FORMATE_DATE_DISPLAY,
                                       new CultureInfo(ConfigurationInfo.CULTUREINFO_DISPLAY), DateTimeStyles.None, out result))
                return result;
            else
                if (DateTime.TryParse(value.ToString(), out result))
                    return result;
            throw new Exception("Error ToDateTime");
            //return result;
        }
        public static DateTime ToDateTimeFrom(object value)
        {
            DateTime result = DateTime.Now;
            value = value.ToString().Trim();
            //CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            if (DateTime.TryParseExact(value.ToString(), ConfigurationInfo.FORMATE_DATE_DISPLAY,
                                       new CultureInfo(ConfigurationInfo.CULTUREINFO_DISPLAY), DateTimeStyles.None, out result))
                return result.Date;
            else
                if (DateTime.TryParse(value.ToString(), out result))
                    return result.Date;
            throw new Exception("Error ToDateTime");
            //return result;
        }
        public static DateTime ToDateTimeFromeBao(object value)
        {
            DateTime result = DateTime.Now;
            value = value.ToString().Trim();
            //CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            if (DateTime.TryParseExact(value.ToString(), ConfigurationInfo.FORMATE_DATE_TIME_DISPLAY_TO_EBAO,
                                       new CultureInfo(ConfigurationInfo.CULTUREINFO_DISPLAY), DateTimeStyles.None, out result))
                return result;
            else
                if (DateTime.TryParse(value.ToString(), out result))
                    return result;
            throw new Exception("Error ToDateTime");
            //return result;
        }
        public static DateTime ToDateTimeTo(object value)
        {
            DateTime result = DateTime.Now;
            value = value.ToString().Trim();
            //CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            if (DateTime.TryParseExact(value.ToString(), ConfigurationInfo.FORMATE_DATE_DISPLAY,
                                       new CultureInfo(ConfigurationInfo.CULTUREINFO_DISPLAY), DateTimeStyles.None, out result))
                return result.AddDays(1).Date;
            else
                if (DateTime.TryParse(value.ToString(), out result))
                    return result.AddDays(1).Date;
            throw new Exception("Error ToDateTime");
            //return result;
        }
        public static DateTime ToDateTime(object value, string format)
        {
            DateTime result = DateTime.Now;
            value = value.ToString().Trim();
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            if (DateTime.TryParseExact(value.ToString(), format,
                                       new CultureInfo(currentCulture.Name), DateTimeStyles.None, out result))
                return result;
            else
                if (DateTime.TryParse(value.ToString(), out result))
                    return result;
            throw new Exception("Error ToDateTime");
            //return result;
        }
        public static DateTime ToDateTime(string value, string format, string nameCultureInfo)
        {
            DateTime result = DateTime.Now;
            value = value.ToString().Trim();
            //CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            if (DateTime.TryParseExact(value, format,new CultureInfo(nameCultureInfo), DateTimeStyles.None, out result))
                return result;
            else
                if (DateTime.TryParse(value.ToString(), out result))
                    return result;
            throw new Exception("Error ToDateTime");
        }
        public static DateTime ToDateTime(object value, bool isResultDateNow)
        {
            DateTime result = DateTime.Now;
            value = value.ToString().Trim();
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            if (DateTime.TryParseExact(value.ToString(), ConfigurationInfo.FORMATE_DATE_DISPLAY,
                                       new CultureInfo(currentCulture.Name), DateTimeStyles.None, out result))
                return result;
            else
                if (DateTime.TryParse(value.ToString(), out result))
                    return result;
            if (isResultDateNow)
                return DateTime.Now;
            throw new Exception("Error ToDateTime");
            //return result;
        }
        public static DateTime? ToDateTimeResultNull(object value)
        {
            DateTime result = DateTime.Now;
            value = value.ToString().Trim();
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            if (DateTime.TryParseExact(value.ToString(), ConfigurationInfo.FORMATE_DATE_DISPLAY,
                                       new CultureInfo(currentCulture.Name), DateTimeStyles.None, out result))
                return result;
            else
            {
                if (DateTime.TryParse(value.ToString(), out result))
                    return result;
                else
                    return null;
            }
        }
        #endregion ToDateTime

        #region ToDateStart
        /// <summary>
        /// use datetimpicker .Text
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateStart(object value)
        {
            DateTime result = DateTime.Now;
            value = value.ToString().Trim();
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            if (DateTime.TryParseExact(value.ToString(), ConfigurationInfo.FORMATE_DATE_DISPLAY,
                                       new CultureInfo(currentCulture.Name), DateTimeStyles.None, out result))
            {
                result = result.AddHours(00).AddMinutes(00);
            }
            else
            {
                if (DateTime.TryParse(value.ToString(), out result))
                {
                    result = result.AddHours(00).AddMinutes(00);

                }
            }

            return result;
        }



        public static DateTime GetStartDefault
        {
            get
            {
                DateTime val = DateTime.Now;
                DateTime result = new DateTime(val.Year, val.Month + (1 - val.Month), 1, 0, 00, 00);
                return result;
            }
        }

        public static DateTime GetStartDefaultBack1Year
        {
            get
            {
                DateTime val = DateTime.Now;
                DateTime result = new DateTime(val.Year - 1, val.Month, val.Day, 0, 00, 00);
                return result;
            }
        }

        public static DateTime DateEndofYear
        {
            get
            {
                DateTime val = DateTime.Now;
                DateTime result = new DateTime(val.Year, 12, 31, 23, 59, 00);
                return result;
            }
        }
        #endregion ToDateStart

        #region ToDateStop

        public static DateTime ToDateStop(object value)
        {
            DateTime result = DateTime.Now;
            value = value.ToString().Trim();
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            if (DateTime.TryParseExact(value.ToString(), ConfigurationInfo.FORMATE_DATE_DISPLAY,
                                       new CultureInfo(currentCulture.Name), DateTimeStyles.None, out result))
            {
                result = result.AddHours(23).AddMinutes(59);
            }
            else
            {
                if (DateTime.TryParse(value.ToString(), out result))
                {
                    result = result.AddHours(23).AddMinutes(59);
                }
            }
            return result;
        }

        #endregion ToDateStop

        #region InitialValueDB
        public static string InitialValueDB(object value)
        {
            string result = string.Empty;
            if (value is DateTime)
                result = ToDateDisplay(value);
            else if (value is decimal)
                result = FormatUtil.PriceFormat(ToDecimal(value), true);
            else if (value is double)
                result = FormatUtil.PriceFormat(ToDecimal(value), true);
            else if (value is int)
                result = ToInt(value).ToString();
            else if (value is string)
                result = ToStringEmpty(value);
            else if (value != null)
                result = value.ToString();
            else if (value == null)
                result = string.Empty;
            return result;
        }

        public static string InitialValueDB(DataRow row, string columnName)
        {
            return (row[columnName] is DBNull ? string.Empty : InitialValueDB(row[columnName]));

        }
        public static string InitialValueEmptyToZero(DataRow row, string columnName)
        {
            string result = string.Empty;
            result = (row[columnName] is DBNull ? string.Empty : InitialValueDB(row[columnName]));
            if (string.IsNullOrEmpty(result))
            {
                return "0"; ;
            }
            return result;

        }

        #endregion InitialValueDB

        #region InitialValueDBNumber
        public static string InitialValueDBNumber(object value)
        {
            return FormatUtil.PriceFormat(ToDecimal(value), true);
        }
        #endregion InitialValueDBNumber

        #region ToDateDisplay
        public static string ToDateDisplay(object value)
        {
            // value = null;
            //if ((value == null) || (string.IsNullOrEmpty(value.ToString())))
            //    return string.Empty;
            //DateTime dt = DateTime.Now;
            //DateTime.TryParse(value.ToString(), out  dt);
            //CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            //return dt.ToString(ConfigurationInfo.FORMATE_DATE_DISPLAY, new CultureInfo(currentCulture.Name));
            return ToDateDisplay(value, ConfigurationInfo.FORMATE_DATE_DISPLAY);
        }
        #endregion ToDateDisplay

        #region ToDateDisplay
        public static string ToDateDisplay(object value, string format)
        {
            // value = null;
            if ((value == null) || (string.IsNullOrEmpty(value.ToString())))
                return string.Empty;
            DateTime dt = DateTime.Now;
            DateTime.TryParse(value.ToString(), out  dt);
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            return dt.ToString(format, new CultureInfo(currentCulture.Name));
        }
        public static string ToDateDisplay(DataRow row, string columnName, string format)
        {
            // value = null;
            object value = row[columnName];
            if ((value == null) || (string.IsNullOrEmpty(value.ToString())))
                return string.Empty;
            DateTime dt = DateTime.Now;
            DateTime.TryParse(value.ToString(), out  dt);
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            return dt.ToString(format, new CultureInfo(currentCulture.Name));
        }
        #endregion ToDateDisplay

        #region ToDateDisplay
        public static string ToDateNewCode()
        {
            string result = string.Empty;
            DateTime dt = DateTime.Now;
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            result = dt.ToString(ConfigurationInfo.FORMATE_DATE_BATCHNUMBER, new CultureInfo(ConfigurationInfo.CULTUREINFO_BATCHNUMBER));
            return result;
        }
        public static string ToDateNewCode(string formate)
        {
            string result = string.Empty;
            DateTime dt = DateTime.Now;
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            result = dt.ToString(formate, new CultureInfo(ConfigurationInfo.CULTUREINFO_BATCHNUMBER));
            return result;
        }

        public static string ToYearNewCode()
        {
            string result = string.Empty;
            DateTime dt = DateTime.Now;
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            result = dt.ToString(ConfigurationInfo.FORMATE_YEAR_BATCHNUMBER, new CultureInfo(ConfigurationInfo.CULTUREINFO_BATCHNUMBER));
            return result;
        }
        #endregion ToDateDisplay

        #region ToBoolean
        public static bool ToBoolean(DataRow row, string nameColumn)
        {
            return ToBoolean(InitialValueDB(row, nameColumn));
        }
        public static bool InteBaoToBoolean(int value)
        {
            //1 true,2 false
            return (value == 1);
        }
        public static bool ToBoolean(object value)
        {
            bool result = false;
            bool isConvert = false;
            if (value != null)
            {
                isConvert = bool.TryParse(value.ToString(), out result);
                if (!isConvert)
                {
                    if ((value.ToString() == "1") || (value.ToString() == "0"))
                    {
                        result = Convert.ToBoolean(Convert.ToInt32(value.ToString()));
                    }
                    else
                        return false;
                }
            }
            return result;
        }
        /// <summary>
        /// date from database
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// 




        public static bool IsDataExistsAndZero(object value)
        {
            if ((value != null) && (!string.IsNullOrEmpty(value.ToString())))
            {
                if (value.ToString() != "0")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
        public static bool IsDataExists(DataSet ds)
        {
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                return true;
            else
                return false;
        }
        public static bool IsDataExists(object value)
        {
            if ((value != null) && (!string.IsNullOrEmpty(value.ToString())))
                return true;
            else
                return false;
        }
        public static bool IsDataExists(DataTable dt)
        {
            if ((dt != null) && (dt.Rows.Count > 0))
                return true;
            else
                return false;
        }
        public static bool IsDataExits(DataSet ds)
        {
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                return true;
            else
                return false;
        }
        public static bool IsDataExits(object value)
        {
            if ((value != null) && (!string.IsNullOrEmpty(value.ToString())))
                return true;
            else
                return false;
        }
        public static string GetValueDataGrid(object value)
        {
            if (IsDataExits(value))
                return value.ToString();
            else
                return string.Empty;
        }
        public static bool IsDataExits(DataTable dt)
        {
            if ((dt != null) && (dt.Rows.Count > 0))
                return true;
            else
                return false;
        }

        #endregion ToBoolean

        #region InitialRowsState

        public static void InitialRowsState(DataRow row, DataRowState rowState)
        {
            try
            {
                if (rowState == DataRowState.Modified)
                {
                    if (row.RowState == DataRowState.Modified) return;
                    row.AcceptChanges();
                    row.SetModified();
                }
                else if (rowState == DataRowState.Added)
                {
                    if (row.RowState == DataRowState.Added) return;
                    row.AcceptChanges();
                    row.SetAdded();
                }
                else if (rowState == DataRowState.Deleted)
                {
                    if (row.RowState == DataRowState.Deleted) return;
                    row.AcceptChanges();
                    row.Delete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion InitialRowsState


        public static string ToThaiBaht(decimal amount, bool isNoneAffix, bool isParenthetical)
        {
            string result = ToThaiBaht(amount, isNoneAffix);
            if (isParenthetical)
            {
                result = string.Format("({0})", result);
            }
            return result;
        }

        public static string ToThaiBaht(decimal amount, bool isNoneAffix)
        {
            string result = string.Empty;
            if (isNoneAffix)
            {
                result = ToThaiBaht(amount);
                result = result.Replace("ถ้วน", "");
            }
            else
            {
                result = ToThaiBaht(amount);
            }
            return result;
        }

        public static string ToThaiBaht(decimal amount)
        {
            if (amount == 0)
                return "ศูนย์บาทถ้วน";

            bool isDif = false;
            if (amount < 0)
            {
                isDif = true;
                amount = amount * -1;
            }

            string integerValue;
            string decimalValue;
            string integerTranslatedText;
            string decimalTranslatedText;

            integerValue = amount.ToString("####.00");
            decimalValue = integerValue.Substring(integerValue.Length - 2, 2);
            integerValue = integerValue.Substring(0, integerValue.Length - 3);

            integerTranslatedText = GetCurrencyWord(Convert.ToDecimal(integerValue));

            if (Convert.ToDecimal(decimalValue) != 0)
                decimalTranslatedText = GetCurrencyWord(Convert.ToDecimal(decimalValue));
            else
                decimalTranslatedText = string.Empty;

            if (decimalTranslatedText.Trim() == string.Empty)
                integerTranslatedText += "บาทถ้วน";
            else
                integerTranslatedText += "บาท" + decimalTranslatedText + "สตางค์";

            if (isDif)
            {
                integerTranslatedText = "ลบ" + integerTranslatedText;
            }
            return integerTranslatedText;
        }

        private static string GetCurrencyWord(decimal amount)
        {
            string[] numberTexts = new string[] { "", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] digits = new string[] { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
            string value, aWord, text;
            string numberTranslatedText = string.Empty;
            int length, digitsPosition;

            value = amount.ToString();
            length = value.Length;

            for (int i = 0; i <= length - 1; i++)
            {
                digitsPosition = i - (6 * ((i - 1) / 6));
                aWord = value.Substring((value.Length - 1) - i, 1);
                text = string.Empty;
                switch (digitsPosition)
                {
                    case 0:
                        if (aWord == "1" && length > 1)
                            text = "เอ็ด";
                        else if (aWord != "0")
                            text = numberTexts[Convert.ToInt32(aWord)];

                        break;
                    case 1:
                        if (aWord == "1")
                            text = digits[digitsPosition];
                        else if (aWord == "2")
                            text = "ยี่" + digits[digitsPosition];
                        else if (aWord != "0")
                            text = numberTexts[Convert.ToInt32(aWord)] + digits[digitsPosition];

                        break;
                    case 2:
                        if (aWord != "0")
                            text = numberTexts[Convert.ToInt32(aWord)] + digits[digitsPosition];

                        break;
                    case 3:
                        if (aWord != "0")
                            text = numberTexts[Convert.ToInt32(aWord)] + digits[digitsPosition];

                        break;
                    case 4:
                        if (aWord != "0")
                            text = numberTexts[Convert.ToInt32(aWord)] + digits[digitsPosition];

                        break;
                    case 5:
                        if (aWord != "0")
                            text = numberTexts[Convert.ToInt32(aWord)] + digits[digitsPosition];

                        break;
                    case 6:
                        if (aWord == "0")
                            text = "ล้าน";
                        else if (aWord == "1" && length - 1 > i)
                            text = "เอ็ดล้าน";
                        else
                            text = numberTexts[Convert.ToInt32(aWord)] + digits[digitsPosition];

                        break;
                }
                numberTranslatedText = text + numberTranslatedText;
            }

            return numberTranslatedText;
        }

        #region skip thai bath

        //public static string ToThaiBaht(string txt, bool isNoneAffix, bool isParenthetical)
        //{
        //    string result = ToThaiBaht(txt, isNoneAffix);
        //    if (isParenthetical)
        //    {
        //        result = string.Format("({0})", result);
        //    }
        //    return result;
        //}
        //public static string ToThaiBaht(string txt, bool isNoneAffix)
        //{
        //    string result = string.Empty;
        //    if (isNoneAffix)
        //    {
        //        result = ToThaiBaht(txt);
        //        result = result.Replace("ถ้วน", "");
        //    }
        //    else
        //    {
        //        result = ToThaiBaht(txt);
        //    }
        //    return result;
        //}

        //private static List<string> SplitValue(string value)
        //{
        //    List<string> values = new List<string>();
        //    int condition = 7;
        //    //value = "1234567891234567";
        //    int count = 0;
        //    if (value.Length % condition == 0)
        //        count = value.Length / condition;
        //    else
        //    {
        //        count = (value.Length / condition) + 1;
        //    }
        //    int start = 0;
        //    int length = 0;
        //    string valuadd = string.Empty;
        //    if (count == 0)
        //    {
        //        values.Add(value);
        //        return values;
        //    }
        //    for (int i = 0; i < count; i++)
        //    {
        //        if (value.Length > ((i + 1) * condition))
        //            start = value.Length - ((i + 1) * condition);
        //        else
        //            start = 0;

        //        if ((value.Length > ((i + 1) * condition)))
        //            length = condition;
        //        else
        //            length = value.Length - (i * condition);
        //        values.Add(value.Substring(start, length));
        //    }
        //    return values;
        //}
        //public static string ToThaiBaht(string txt)
        //{
        //    bool isDif = false;
        //    if (txt.Contains("-"))
        //    {
        //        isDif = true;
        //        txt = txt.Replace("-", "");
        //    }
        //    string bahtTxt, n, bahtTH = "";
        //    double amount;
        //    try { amount = Convert.ToDouble(txt); }
        //    catch { amount = 0; }
        //    bahtTxt = amount.ToString("####.00");
        //    string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
        //    string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
        //    string[] temp = bahtTxt.Split('.');
        //    string intVal = temp[0];
        //    string decVal = temp[1];
        //    if (Convert.ToDouble(bahtTxt) == 0)
        //        bahtTH = "ศูนย์บาทถ้วน";
        //    else
        //    {
        //        List<string> values = SplitValue(intVal);
        //        foreach (string value in values)
        //        {
        //            intVal = value;

        //            for (int i = 0; i < intVal.Length; i++)
        //            {
        //                n = intVal.Substring(i, 1);
        //                if (n != "0")
        //                {
        //                    if ((i == (intVal.Length - 1)) && (n == "1"))
        //                        bahtTH += "เอ็ด";
        //                    else if ((i == (intVal.Length - 2)) && (n == "2"))
        //                        bahtTH += "ยี่";
        //                    else if ((i == (intVal.Length - 2)) && (n == "1"))
        //                        bahtTH += "";
        //                    else
        //                        bahtTH += num[Convert.ToInt32(n)];
        //                    bahtTH += rank[(intVal.Length - i) - 1];
        //                }
        //            }
        //        }
        //        bahtTH += "บาท";
        //        if (decVal == "00")
        //            bahtTH += "ถ้วน";
        //        else
        //        {
        //            for (int i = 0; i < decVal.Length; i++)
        //            {
        //                n = decVal.Substring(i, 1);
        //                if (n != "0")
        //                {
        //                    if ((i == decVal.Length - 1) && (n == "1"))
        //                        bahtTH += "เอ็ด";
        //                    else if ((i == (decVal.Length - 2)) && (n == "2"))
        //                        bahtTH += "ยี่";
        //                    else if ((i == (decVal.Length - 2)) && (n == "1"))
        //                        bahtTH += "";
        //                    else
        //                        bahtTH += num[Convert.ToInt32(n)];
        //                    bahtTH += rank[(decVal.Length - i) - 1];
        //                }
        //            }
        //            bahtTH += "สตางค์";
        //        }
        //    }
        //    if (isDif)
        //    {
        //        bahtTH = "ลบ" + bahtTH;
        //    }
        //    return bahtTH;
        //}
        #endregion skip thai bath

        public static string DateTimeSubTract(DateTime start, DateTime end)
        {
            TimeSpan subTract = end.Subtract(start);
            string format = string.Empty;
            string result = string.Empty;
            if ((subTract.Days > 0))
            {
                result = string.Format(" {0} วัน ", subTract.Days);
            }
            if (subTract.Hours > 0)
            {
                result += string.Format(" {0} ชม. ", subTract.Hours);

            }
            if (subTract.Minutes > 0)
            {
                result += string.Format(" {0} นาที", subTract.Minutes);

            }
            return result;
        }


    }
}
