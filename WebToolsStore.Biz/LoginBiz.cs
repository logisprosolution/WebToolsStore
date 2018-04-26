using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using AT.Framework;
using WebToolsStore.Data;

namespace WebToolsStore.Biz
{
    public class LoginBiz : BaseDB<LogInModel>
    {
        public DataTable SelectLogin()
        {
            //databaseUsage = (int)enumDB.DB2;
            return base.SelectByIdTable(0, "Login");
        }

        public DataTable GetPermission(int id)
        {
            return base.SelectByIdTable(id, "GetPermission");
        }

        protected override void DoSelectById(int id, ref DataSet ds, string condition)
        {

            if (condition == "Login")
            {
                SqlCommand cmd = CreateCommand("up_login_login_sel_byID", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("user_name", dataModel.user_name));
                cmd.Parameters.Add(CreateParameter("user_password", dataModel.user_password));
                LoadData(cmd, ds, "Login");
            }
            else if (condition == "GetPermission")
            {
                SqlCommand cmd = CreateCommand("up_login_GetPermission_sel_byID", System.Data.CommandType.StoredProcedure);
                cmd.Parameters.Add(CreateParameter("user_id", id));
                LoadData(cmd, ds, "GetPermission");
            }
        }
    }
}