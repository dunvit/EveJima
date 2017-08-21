using System.Web.Http;

namespace Server.Controllers
{
    public class DeleteSignatureController : ApiController
    {
        public string Get(string pilotName, string key, string system, string code, long ticks)
        {
            return GlobalData.MapRouter.DeleteSignature(pilotName, key, system, code, ticks);
        }

    }
}
