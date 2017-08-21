using System.Web.Http;

namespace Server.Controllers
{
    public class MapUpdatesController : ApiController
    {
        public string Get(string mapKey, string pilot, long ticks)
        {
            return GlobalData.MapRouter.GetAllUpdates(mapKey, pilot, ticks);
        }
    }
}
