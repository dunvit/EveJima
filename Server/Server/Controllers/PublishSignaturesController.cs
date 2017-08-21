using System.Web.Http;

namespace Server.Controllers
{
    public class PublishSignaturesController : ApiController
    {
        public string Get(string pilotName, string key, string system, string signatures, long ticks)
        {
            return GlobalData.MapRouter.PublishSignatures(pilotName, key, system, signatures, ticks);
        }
    }
}
