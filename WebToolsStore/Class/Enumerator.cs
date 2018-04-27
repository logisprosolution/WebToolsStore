using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace WebToolsStore
{
    public class Enumerator
    {

        public enum ReportFileType
        {
            [Description("pdf file"), NameTypeReportAttribute("pdf")]
            PDF = 1,
            [Description("crytal report file"), NameTypeReportAttribute("rpt")]
            RPT = 2,
            [Description("excel file"), NameTypeReportAttribute("xls")]
            XLS = 4

        }

        public enum DeleteFileType
        {
            [Description("Delete file premium"), NameTypeReportAttribute("Premium")]
            Premium = 1,
            [Description("Delete file claim"), NameTypeReportAttribute("Claim")]
            Claim = 2,


        }
        public enum PolicyOwnerType
        {
            Reinsured = 2,
            Parties = 1,
        }
        public enum PremiumType
        {
            [Description("Edit Permium"), ValueEnumAttribute("0001")]
            PREMIUM = 1,
            [Description("Adj Premium"), ValueEnumAttribute("0002")]
            ADJ_PREMIUM = 2,
        }
        public enum ActionFlag
        {
            [Description("เพิ่มข้อมูล"), NameTypeReportAttribute("เพิ่มข้อมูล")]
            ADD = 1,
            [Description("แก้ไขข้อมูล"), NameTypeReportAttribute("แก้ไขข้อมูล")]
            EIDT = 2,
            [Description("ยกเลิก"), NameTypeReportAttribute("ยกเลิก")]
            CANCEL = 4

        }
        public enum ClaimType
        {
            [Description("cash call movement"), ValueEnumAttribute("0001")]
            CASH_CALL_MOVEMENT = 1,
            [Description("claim paid"), ValueEnumAttribute("0002")]
            CLAIM_PAID = 2,
            [Description("None"), ValueEnumAttribute("0003")]
            NONE = 3,
            [Description("cash call balance"), ValueEnumAttribute("0004")]
            CASH_CALL_BALANCE = 4,
            [Description("adj cash call"), ValueEnumAttribute("0005")]
            ADJ_CASH_CALL = 5,
            [Description("adj claim"), ValueEnumAttribute("0006")]
            ADJ_CLAIM = 6
        }

        public enum FormatNumber
        {
            [Description("format bathchnumber cash call treaty"), ValueEnumAttribute("0003")]
            CC_BATCH_NUMBER = 3,
            [Description("format bathchnumber claim paid facutative"), ValueEnumAttribute("0006")]
            FC_BATCH_NUMBER = 6,
            [Description("format ric treaty"), ValueEnumAttribute("0001")]
            RIC = 1,
            [Description("format rif treaty"), ValueEnumAttribute("0007")]
            RIF = 7,
            [Description("format bathchnumber premium facultative"), ValueEnumAttribute("0008")]
            FP_BATCH_NUMBER = 8,
            [Description("format rit treaty"), ValueEnumAttribute("0004")]
            RIT = 4,
            [Description("format bathchnumber treaty  monthly"), ValueEnumAttribute("0005")]
            TREATY_BATCH_MONTHLY = 5,
            [Description("format bathchnumber treaty  quarter"), ValueEnumAttribute("0002")]
            TREATY_BATCH_QUARTER = 2
        }

        public enum Status_Of_Claim
        {
            [Description("PENDIN"), ValueEnumAttribute("0001")]
            PENDIN = 1,
            [Description("CLOSE"), ValueEnumAttribute("0002")]
            CLOSE = 2,
            [Description("CLOSED WITHOUT PAYMENT"), ValueEnumAttribute("0003")]
            CLOSED_WITHOUT_PAYMENT = 3
        }

        public enum ConditionLoadEx
        {
            None,
            All,
            Empty,
            NewRowEmpty,
            Else
        }

        public enum PayType
        {
            [Description("RQ"), ValueEnumAttribute("0001")]
            RQ = 1,
            [Description("CA"), ValueEnumAttribute("0002")]
            CA = 2,
        }

        public class ValueEnumAttribute : Attribute
        {
            private string valueEnum;
            public string ValueEnum
            {
                get { return valueEnum; }
            }
            public ValueEnumAttribute(string valueEnum)
            {
                this.valueEnum = valueEnum;
            }

            public static string GetAttributeValue(FieldInfo field)
            {
                object[] obj = field.GetCustomAttributes(false);
                foreach (object var in obj)
                {
                    if (var is ValueEnumAttribute)
                    {
                        ValueEnumAttribute codeType = var as ValueEnumAttribute;
                        return codeType.ValueEnum;
                    }
                }
                return string.Empty;

            }
        }
        public class NameTypeReportAttribute : Attribute
        {
            private string rameTypeReport;
            public string NameTypeReport
            {
                get { return rameTypeReport; }
            }
            public NameTypeReportAttribute(string rameTypeReport)
            {
                this.rameTypeReport = rameTypeReport;
            }

            public static string GetAttributeValue(FieldInfo field)
            {
                object[] obj = field.GetCustomAttributes(false);
                foreach (object var in obj)
                {
                    if (var is NameTypeReportAttribute)
                    {
                        NameTypeReportAttribute codeType = var as NameTypeReportAttribute;
                        return codeType.NameTypeReport;
                    }
                }
                return string.Empty;

            }
        }

        public enum ActionMode
        {
            None = 0,
            InsertDataNew = 1,
            Update = 2,
            VerifyData = 3,
        }

        public enum SubMenu
        {
            Title = 1,
            Employee = 2,
            Supplier = 3,
            Customer = 4,
            Unit = 5,
            Categories = 6,
            Product = 7,
            Order = 8,
            Receiveproduct = 9,
            Sell = 10,
            SellOnCredit = 11,
            Change = 12,
            Role = 13
        }
    }
}
