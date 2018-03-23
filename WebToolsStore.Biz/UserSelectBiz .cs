using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;
using System.Data;
using System;

namespace WebToolsStore.Biz
{
    public class UserSelectBiz : BaseDB<UserModel>
    {
        #region Biz Methods
        public UserSelectBiz() : base()
        {

        }
        public DataTable SelectList(string searchText, string searchName,string searcthLastname)
        {
            dataModel.SearchText = searchText;
            dataModel.SearchName = searchName;
            dataModel.SearchLastname = searcthLastname;
            return base.SelectListTable("SelectList");
        }        
        #endregion Biz Methods

        #region Override Methods

        protected override void DoSelectList(ref DataSet ds, string condition)
        {
            if (condition == "SelectList")
            {
                SqlCommand cmd = CreateCommand("udp_SelectUser_sel", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("SearchText", dataModel.SearchText));
                cmd.Parameters.Add(CreateParameter("SearchName", dataModel.SearchName));
                cmd.Parameters.Add(CreateParameter("SearchLastname", dataModel.SearchLastname));
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