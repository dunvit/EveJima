using System;
using EveJimaCore;
using EveJimaCore.BLL;
using EveJimaCore.BLL.LostAndFound;
using EveJimaCore.BLL.Map;
using EveJimaSettings;
using EveJimaUniverse;

namespace EvaJimaCore
{
    public static class Global
    {
        public static WorkEnvironment WorkEnvironment;

        public static Settings Settings;

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

            Settings = new Settings();

            ApplicationSettings = new ApplicationSettings();

            MapApiFunctions = new MapApiFunctions();
            MapApiFunctions.Initialization(ApplicationSettings.Server_MapAddress);

            WorkEnvironment = new WorkEnvironment();

            

            

            Metrics = new MetricsWriter();

            Pilots = new PilotsEntity();

            if (ApplicationSettings.IsConverted == false) Tools.ConvertSettings(ApplicationSettings, Settings, WorkEnvironment);

            Infrastructure = new Infrastructure();

            Space = new Universe();
            Space.Initialization();

            InternalBrowser = new InternalBrowser();

            LostAndFoundOffice = new LostSolarSystems();

            Presenter = new EveJimaPresenter();
        }
    }
}
