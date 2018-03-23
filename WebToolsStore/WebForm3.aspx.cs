using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebToolsStore.Biz;

namespace WebToolsStore
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        CategoriesBiz biz = new CategoriesBiz();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgv1.DataSource = biz.SelectList("");
                dgv1.DataBind();
            }
        }

        //private static DataTable GetData(string query)
        //{
        //    string strConnString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(strConnString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandText = query;
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                sda.SelectCommand = cmd;
        //                using (DataSet ds = new DataSet())
        //                {
        //                    DataTable dt = new DataTable();
        //                    sda.Fill(dt);
        //                    return dt;
        //                }
        //            }
        //        }
        //    }
        //}

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerId = dgv1.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView dgv2 = e.Row.FindControl("dgv2") as GridView;
                dgv2.DataSource = biz.SelectList("");
                dgv2.DataBind();
            }
        }
    }
}