using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Server.Controllers
{
    public class MonitoringController : ApiController
    {
        public string Get()
        {
            var fileName = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
            string data = "";

            using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/Data/" + fileName + ".txt")))
            {
                // Read the stream to a string, and write the string to the console.
                data = sr.ReadToEnd();
                
            }

            return data;
        }
    }
}
