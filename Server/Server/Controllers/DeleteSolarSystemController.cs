using System.Web.Http;

namespace Server.Controllers
{
    public class DeleteSolarSystemController : ApiController
    {
        public string Get(string mapKey, string system, string pilotName, long ticks)
        {
            return GlobalData.MapRouter.DeleteSolarSystem(mapKey, system, pilotName, ticks);
        }
    }
}
