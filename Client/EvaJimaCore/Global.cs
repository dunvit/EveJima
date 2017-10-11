using EveJimaCore;
using EveJimaCore.BLL;
using EveJimaCore.BLL.LostAndFound;
using EveJimaCore.BLL.Map;
using EveJimaUniverse;
using log4net;

namespace EvaJimaCore
{
    public static class Global
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Global));

        public static WorkEnvironment WorkEnvironment;

        public static ApplicationSettings ApplicationSettings;

        public static MapApiFunctions MapApiFunctions;

        public static PilotsEntity Pilots;

        public static Infrastructure Infrastructure;

        public static Universe Space;

        public static InternalBrowser InternalBrowser;

        public static MetricsWriter Metrics;

        public static LostSolarSystems LostAndFoundOffice;

        public static EveJimaPresenter Presenter;

        public static void Initialization()
        {
            ApplicationSettings = new ApplicationSettings();

            MapApiFunctions = new MapApiFunctions();
            MapApiFunctions.Initialization(ApplicationSettings.Server_MapAddress);

            WorkEnvironment = new WorkEnvironment();

            Metrics = new MetricsWriter();

            Pilots = new PilotsEntity();

            Infrastructure = new Infrastructure();

            Space = new Universe();
            Space.Initialization();

            Log.DebugFormat("[Global.Initialization] InternalBrowser");
            InternalBrowser = new InternalBrowser();

            LostAndFoundOffice = new LostSolarSystems();

            Presenter = new EveJimaPresenter();

        }

        public static void Dispose()
        {
            InternalBrowser.Dispose();
        }
    }
}
