using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using WebToolsStore.Biz;

namespace WebToolsStore
{
    /// <summary>
    /// Summary description for ShowImage
    /// </summary>
    public class ShowImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Int32 id;
            if (context.Request.QueryString["dataId"] != null)
                id = Convert.ToInt32(context.Request.QueryString["dataId"]);
            else
                throw new ArgumentException("No parameter specified");


            string functionName = context.Request.QueryString["dataId2"];

            context.Response.ContentType = "image/jpeg";
            Stream strm = ShowUploadImage(id, functionName);
            if (strm != null)
            {
                byte[] buffer = new byte[4096];
                int byteSeq = strm.Read(buffer, 0, 4096);

                while (byteSeq > 0)
                {
                    context.Response.OutputStream.Write(buffer, 0, byteSeq);
                    byteSeq = strm.Read(buffer, 0, 4096);
                }
                //context.Response.BinaryWrite(buffer);
            }
        }

        public Stream ShowUploadImage(int id, string functionName)
        {
            string fieldName = "";
            DataTable dt = new DataTable();
            if (functionName == "User")
            {
                UserBiz biz = new UserBiz();
                dt = biz.SelectInfo(id);
                fieldName = "pic";
            }
            else if (functionName == "Product")
            {
                ProductBiz biz = new ProductBiz();
                dt = biz.SelectInfo(id);
                fieldName = "product_pic";
            }

            object img = null;
            if (ConvertHelper.IsDataExists(dt))
            {
                img = dt.Rows[0][fieldName];
            }
            try
            {
                return new MemoryStream((byte[])img);
            }
            catch
            {
                return null;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}