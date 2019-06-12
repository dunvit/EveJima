using EveJimaCore;
using EveJimaCore.BLL;
using EveJimaCore.EjEnvironment;
using EveJimaCore.Universe;
using EveJimaUniverse;
using log4net;

namespace EvaJimaCore
{
    public static class Global
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Global));

        public static WorkEnvironment WorkEnvironment;

        public static ApplicationSettings ApplicationSettings;

        public static PilotsEntity Pilots;

        public static Infrastructure Infrastructure;

        public static UniverseEntity Space;

        public static PlanetarySystems PlanetarySystemsInfo;

        public static InternalBrowser InternalBrowser;

        public static EveJimaPresenter Presenter;

        public static EsiApi EsiTools;

        public static ClipboardEntity Clipboard;


        public static void Initialization()
        {
            ApplicationSettings = new ApplicationSettings();

            Clipboard = new ClipboardEntity();

            WorkEnvironment = new WorkEnvironment();

            Pilots = new PilotsEntity();

            Infrastructure = new Infrastructure();

            Space = new UniverseEntity();
            Space.Initialization();

            Log.DebugFormat("[Global.Initialization] InternalBrowser");
            InternalBrowser = new InternalBrowser();

            Presenter = new EveJimaPresenter();

            EsiTools = new EsiApi(ApplicationSettings.Authorization_ClientId, ApplicationSettings.Authorization_ClientSecret);

            PlanetarySystemsInfo = new PlanetarySystems(EsiTools, Space);
        }

        public static void Dispose()
        {
            InternalBrowser.Dispose();
        }
    }
}
