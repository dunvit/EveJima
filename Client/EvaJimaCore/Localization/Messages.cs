using EvaJimaCore;
using EveJimaCore.UiTools;

namespace EveJimaCore.Localization
{
    public class Messages
    {

        public static string Get(string key, string defaultValue = "None")
        {
            if (DebugTools.IsInDesignMode() == false )
            {
                return GetMessageByLanguageKey(key, Global.ApplicationSettings.LanguageId);
            }

            return defaultValue != "None" ? defaultValue : key;
        }

        private static string GetMessageByLanguageKey(string key, int language)
        {

            switch (language)
            {
                case 0:
                    return English.ResourceManager.GetString(key);

                case 1:
                    return Russian.ResourceManager.GetString(key);

                default:
                    return English.ResourceManager.GetString(key);
            }
        }
    }
}
