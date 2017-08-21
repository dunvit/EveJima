using System.Net;
using System.Net.Http;
using System.Web.Http;
using Server.BLL;

namespace Server.Controllers
{
    public class LostAndFoundController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var data = LostAndFoundActions.List();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        public string Get(string action, string publisher, string wormholeName, string reward)
        {
            return LostAndFoundActions.Add(action, publisher, wormholeName, reward);
        }

        public string Get(string action, string publisher, string wormholeName)
        {
            return LostAndFoundActions.Delete(action, publisher, wormholeName);
        }


    }
}
