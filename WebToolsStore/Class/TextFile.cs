using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;

namespace WebToolsStore
{
    public class TextFile
    {
        public void ExportDataTabletoFile(DataTable datatable, string delimited, bool exportcolumnsheader,string path, string file)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                //LogFile.LogMessage("Creage : " + path);
            }

            StreamWriter str = new StreamWriter(path+file, false, System.Text.Encoding.Default);
            if (exportcolumnsheader)
            {
                string Columns = string.Empty;
                foreach (DataColumn column in datatable.Columns)
                {
                    Columns += column.ColumnName + delimited;
                }
                str.WriteLine(Columns.Remove(Columns.Length - 1, 1));
            }
            foreach (DataRow datarow in datatable.Rows)
            {
                string row = string.Empty;

                foreach (object items in datarow.ItemArray)
                {

                    row += items.ToString() + delimited;
                }
                str.WriteLine(row.Remove(row.Length - 1, 1));

            }
            //LogFile.LogMessage("Creage : " + path + " Success");
            str.Flush();
            str.Close();

        }

        public void MoveFile(string fromPath, string toPath, string fileName, string fileType)
        {
            try
            {
                if (!Directory.Exists(fromPath))
                {
                    Directory.CreateDirectory(fromPath);
                }
                if (!Directory.Exists(toPath))
                {
                    Directory.CreateDirectory(toPath);
                }

                fromPath += fileName;
                toPath += fileName;
                if (File.Exists(fromPath + fileType))
                {
                    //using (FileStream fs = File.Create(fromPath)) { }

                    if (!File.Exists(toPath + fileType))
                    {
                        //File.Delete(toPath + fileType);
                        File.Copy(fromPath + fileType, toPath + fileType);
                    }
                    File.Delete(fromPath + fileType);
                    Console.WriteLine("{0} was moved to {1}.", fromPath, toPath);
                }

                if (File.Exists(fromPath))
                {
                    Console.WriteLine("The original file still exists, which is unexpected.");
                }
                else
                {
                    Console.WriteLine("The original file no longer exists, which is expected.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteFiles(string path, string fileName)
        {
            try
            {
                File.Delete(path + fileName);
                Console.WriteLine(fileName +"has been deleted");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}