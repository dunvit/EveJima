using System.Web.Http;

namespace Server.Controllers
{
    public class DeathNoticeController : ApiController
    {
        // GET api/deathnotice/5
        public string Get(string mapKey, string pilot, string solarSystemFrom, string solarSystemTo, long ticks)
        {
            return GlobalData.MapRouter.DeathNotice(mapKey, pilot, solarSystemFrom, solarSystemTo, ticks);
        }

    }
}
