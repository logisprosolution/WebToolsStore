using System;
using System.Collections.Generic;
using System.Data;

namespace WebToolsStore.Data
{
    public class DocModel
    {
        private DOC_Header _header = new DOC_Header();

        public virtual DOC_Header Doc_Header
        {
            get { return _header; }
            set { _header = value; }
        }

        private DOC_Detail _detail = new DOC_Detail();

        public virtual DOC_Detail Doc_Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }

        private List<DOC_Detail> _docDetailList = new List<DOC_Detail>();
        public virtual List<DOC_Detail> DocDetailList
        {
            get { return _docDetailList; }
            set { _docDetailList = value; }
        }

        private List<DOC_Detail> _docDetailList2 = new List<DOC_Detail>();
        public virtual List<DOC_Detail> DocDetailList2
        {
            get { return _docDetailList2; }
            set { _docDetailList2 = value; }
        }

        private List<DOC_Detail_Ingredient> _docIngredientList = new List<DOC_Detail_Ingredient>();
        public virtual List<DOC_Detail_Ingredient> DocIngredientList
        {
            get { return _docIngredientList; }
            set { _docIngredientList = value; }
        }

        private List<DOC_Detail_Ingredient> _docIngredientList2 = new List<DOC_Detail_Ingredient>();
        public virtual List<DOC_Detail_Ingredient> DocIngredientList2
        {
            get { return _docIngredientList2; }
            set { _docIngredientList2 = value; }
        }
        private string _searchText;

        public virtual string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; }
        }

        private int _supplyer_id;

        public virtual int Supplyer_Id
        {
            get { return _supplyer_id; }
            set { _supplyer_id = value; }
        }

        private int _customer_id;

        public virtual int Customer_Id
        {
            get { return _customer_id; }
            set { _customer_id = value; }
        }

        private DateTime? _searchDate;

        public virtual DateTime? SearchDate
        {
            get { return _searchDate; }
            set { _searchDate = value; }
        }

        private int _doctype_id;

        public virtual int Doctype_id
        {
            get { return _doctype_id; }
            set { _doctype_id = value; }
        }

        private int _subdoctype_id;

        public virtual int SubDoctype_id
        {
            get { return _subdoctype_id; }
            set { _subdoctype_id = value; }
        }

        private int? _detail_status;

        public virtual int? Detail_status
        {
            get { return _detail_status; }
            set { _detail_status = value; }
        }
    }
}