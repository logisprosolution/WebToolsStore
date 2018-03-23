using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebToolsStore
{
    public class LogFile
    {
        public static void Main()
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log("Test1", w);
                Log("Test2", w);
            }

            using (StreamReader r = File.OpenText("log.txt"))
            {
                DumpLog(r);
            }
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        public static void WriteLogFile(string title, string page, string function, string message)
        {
            CreateLogs();

            StreamWriter log;
            string fileName = "Log_" + DateTime.Today.ToString("yyyyMMdd") + ".txt";
            string path = HttpContext.Current.Server.MapPath("Logs/" + fileName);

            if (!File.Exists(path))
            {
                log = new StreamWriter(path);
            }
            else
            {
                log = File.AppendText(path);
            }
            log.Write("\r\nLog Entry : ");
            log.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            log.WriteLine("  :");
            log.WriteLine("title:" + title + "page:" + page);
            log.WriteLine("function:" + function);
            log.WriteLine("message:" + message);
            log.WriteLine("-------------------------------");
            log.Close();

            GC.Collect();
        }

        private static void CreateLogs()
        {
            if (!Directory.Exists(HttpContext.Current.Server.MapPath("Logs")))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("Logs"));
            }
        }

        //public static void LogMessage(string logMessage)
        //{ 
        //    StreamWriter log;
        //    if (!Directory.Exists("..\\logs"))
        //    {
        //        Directory.CreateDirectory("..\\logs");
        //    }
        //    if (!File.Exists("logfile.txt"))
        //    {
        //        log = new StreamWriter("..\\logs\\logfile.txt");
        //    }
        //    else
        //    {
        //        log = File.AppendText("..\\logs\\logfile.txt");
        //    }
        //    log.WriteLine("Data Time:" + DateTime.Now);
        //    log.WriteLine("Message:" + logMessage);
        //    log.Close();

        //}

    }
}