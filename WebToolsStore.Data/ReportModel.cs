using System.Data;

namespace WebToolsStore.Data
{
    public class ReportModel
    {
        private DataSet ds = new DataSet();
        public virtual DataSet DS
        {
            get { return ds; }
            set { ds = value; }
        }

        private int? shopID;
        public virtual int? ShopID
        {
            get { return shopID; }
            set { shopID = value; }
        }

        private int? wareHouseID;
        public virtual int? WareHouseID
        {
            get { return wareHouseID; }
            set { wareHouseID = value; }
        }
        private int? docTypeID;
        public virtual int? DocTypeID
        {
            get { return docTypeID; }
            set { docTypeID = value; }
        }
        private int? subDocTypeID;
        public virtual int? SubDocTypeID
        {
            get { return subDocTypeID; }
            set { subDocTypeID = value; }
        }
        private int? productID;
        public virtual int? ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        private string header_date_from;
        public virtual string Header_date_from
        {
            get { return header_date_from; }
            set { header_date_from = value; }
        }
        private string header_date_to;
        public virtual string Header_date_to
        {
            get { return header_date_to; }
            set { header_date_to = value; }
        }
        private int? categoryID;
        public virtual int? CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }
        private int? subCategoryID;
        public virtual int? SubcategoryID
        {
            get { return subCategoryID; }
            set { subCategoryID = value; }
        }

        private string searchText;
        public virtual string SearchText
        {
            get { return searchText; }
            set { searchText = value; }
        }
    }
}