using EveJimaCore;
using EveJimaCore.BLL;
using EveJimaSettings;

namespace EvaJimaCore
{
    public static class Global
    {
        public static Settings Settings;

        public static PilotsEntity Pilots;

        public static Infrastructure Infrastructure;

        public static SpaceEntity Space;

        public static InternalBrowser InternalBrowser;

        public static void Initialization()
        {

            Settings = new Settings();

            Pilots = new PilotsEntity();

            Infrastructure = new Infrastructure();

            Space = new SpaceEntity();

            InternalBrowser = new InternalBrowser();
        }
    }
}
