using System;
using System.IO;
using System.Web;
using System.Web.Http;
using Server.Tools;

namespace Server.Controllers
{
    public class VersionController : ApiController
    {
        public string Get(string id)
        {
            var data = GetApiLogDetails();

            string sql;

            //int myRequiredScalar = 0;
            //object obj = new object();
            //obj = SqlComm.SqlReturn("SELECT TOP 1 Id FROM BOOKS");
            //if (obj != null) myRequiredScalar = (int)obj;

            sql = "INSERT INTO LoginHistory ( PilotId, IPAddress, Version, LoginDate) VALUES ('temporary empty','" + data.CallerIp + "','" + id + "', SYSDATETIME())";
            SqlComm.SqlExecute(sql);


            var fileName = String.Format("{0:yyyy-MM-dd}", DateTime.Now);

            

            using (StreamWriter _testData = new StreamWriter(HttpContext.Current.Server.MapPath("~/Data/" + fileName + ".txt"), true))
            {
                _testData.WriteLine(String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now) + " Get from version: " + id + " Ip: " + data.CallerIp); // Write the file.
            }

            return "Complete";
        }

        public static LogModel GetApiLogDetails()
        {
            var logModel = new LogModel();
            logModel.TimeStamp = DateTime.Now;
            logModel.CallerIp = HttpContext.Current.Request.UserHostAddress;
            logModel.CallerAgent = HttpContext.Current.Request.UserAgent;
            logModel.CalledUrl = HttpContext.Current.Request.Url.OriginalString;
            return logModel;
        }
    }

    public class LogModel

    {
        public DateTime TimeStamp { get; set; }

        public string CallerIp { get; set; }

        public string CallerAgent { get; set; }

        public string CalledUrl { get; set; }
    }
}
