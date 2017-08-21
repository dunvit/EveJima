using System.Web.Http;

namespace Server.Controllers
{
    public class UpdateSolarSystemCoordinatesController : ApiController
    {
        public string Get(string mapKey, string system, string pilot, int positionX, int positionY, long ticks)
        {
            return GlobalData.MapRouter.UpdateSolarSystemCoordinates(mapKey, system, pilot, positionX, positionY, ticks);
        }

    }
}
