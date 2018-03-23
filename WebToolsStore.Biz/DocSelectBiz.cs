using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class DocSelectBiz : BaseDB<DocModel>
    {
        #region Biz Methods
        public DocSelectBiz() : base()
        {

        }
        public DataTable SelectDocSup(string searchText, int supplyer_id, DateTime? searchDate)
        {
            dataModel.SearchText = searchText;
            dataModel.Supplyer_Id = supplyer_id;
            dataModel.SearchDate = searchDate;
            return base.SelectListTable("SelectDocSup");
        }

        public DataTable SelectDocCus(string searchText, int customer_Id, DateTime? searchDate)
        {
            dataModel.SearchText = searchText;
            dataModel.Customer_Id = customer_Id;
            dataModel.SearchDate = searchDate;
            return base.SelectListTable("SelectDocCus");
        }
        public DataTable SelectDocBookung(string searchText, int customer_Id, DateTime? searchDate)
        {
            dataModel.SearchText = searchText;
            dataModel.Customer_Id = customer_Id;
            dataModel.SearchDate = searchDate;
            return base.SelectListTable("SelectDocBookung");
        }
        public DataTable SelectDetail(int id)
        {
            return base.SelectByIdTable(id, "SelectDetail");
        }
        
        #endregion Biz Methods

        #region Override Methods

        protected override void DoSelectList(ref DataSet ds, string condition)
        {
            if (condition == "SelectDocSup")
            {
                SqlCommand cmd = CreateCommand("udp_SelectDocSup_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("SearchText", dataModel.SearchText));
                cmd.Parameters.Add(CreateParameter("Supplyer_Id", dataModel.Supplyer_Id));
                cmd.Parameters.Add(CreateParameter("SearchDate", dataModel.SearchDate));
                LoadData(cmd, ds, base.SELECT_LIST);
            }
            else if (condition == "SelectDocCus")
            {
                SqlCommand cmd = CreateCommand("udp_SelectDocCus_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("SearchText", dataModel.SearchText));
                cmd.Parameters.Add(CreateParameter("Customer_Id", dataModel.Customer_Id));
                cmd.Parameters.Add(CreateParameter("SearchDate", dataModel.SearchDate));
                LoadData(cmd, ds, base.SELECT_LIST);
            }
            else if (condition == "SelectDocBookung")
            {
                SqlCommand cmd = CreateCommand("udp_SelectDocBookink_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("SearchText", dataModel.SearchText));
                cmd.Parameters.Add(CreateParameter("Customer_Id", dataModel.Customer_Id));
                cmd.Parameters.Add(CreateParameter("SearchDate", dataModel.SearchDate));
                LoadData(cmd, ds, base.SELECT_LIST);
            }
        }

        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {
            
            if (condition == "SelectDetail")
            {
                SqlCommand cmd = CreateCommand("udp_SelectDetail_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("header_id", id));
                LoadData(cmd, ds, "SelectDetail");
            }
            
        }
        #endregion Override Methods
    }
}