using System.Net;
using EvaJimaCore;
using EveJimaCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJTests
{
    /// <summary>
    /// Summary description for InfrastructureTests
    /// </summary>
    [TestClass]
    public class InfrastructureTests
    {

        [TestMethod]
        public void ESI_Authorize()
        {
            var CCPSSO_AUTH_PORT = "8080";
            var CCPSSO_AUTH_CLIENT_ID = "e136434f8a0c484ab802666f378cac09";
            var CCPSSO_AUTH_SCOPES = "esi-location.read_location.v1 esi-location.read_ship_type.v1 esi-bookmarks.read_character_bookmarks.v1 esi-fleets.read_fleet.v1 esi-ui.open_window.v1 esi-ui.write_waypoint.v1";
            var CCPSSO_AUTH_CLIENT_STATE = "bqbIMfDvaFfI9EPOGYmrVDeih9wPkDFnH3eW7GZY";
            var CLIENT_SECRET = "bqbIMfDvaFfI9EPOGYmrVDeih9wPkDFnH3eW7GZY";

            var refreshToken = "D92l3mOOdXzrAuYaWFtU_m6pDSxWpHyme69VgFl8B1E5_PZTjN8WvTEw0xpMTUEMxaqQ_nbUB5YZQr4eVu_Q6Q2";

            var data = WebUtility.UrlEncode(@"http://localhost:" + CCPSSO_AUTH_PORT + "/WormholeLocator");

            var address = "https://login.eveonline.com/oauth/authorize?response_type=code&redirect_uri=" + data +
                          "&client_id=" + CCPSSO_AUTH_CLIENT_ID +
                          "&scope=" + CCPSSO_AUTH_SCOPES + "&state=" +
                          CCPSSO_AUTH_CLIENT_STATE + "";

            var code = "2roGEvWV991_awgiJDqNqRSjKdyzPWoe2XsBeqCFdIRVo90IAvrlH9HKSxk97Sn70";
            var state = "bqbIMfDvaFfI9EPOGYmrVDeih9wPkDFnH3eW7GZY";

            var Esi = new EsiApi(CCPSSO_AUTH_CLIENT_ID, CLIENT_SECRET);

            Esi.Refresh(refreshToken);

            dynamic characterData = Esi.ObtainingCharacterData();

            long Id = characterData.CharacterID;

            dynamic location = Esi.GetLocation(Id);

            long solarSystemId = location.solar_system_id;

        }
    }
}
