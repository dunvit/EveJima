using EvaJimaCore;

namespace EveJimaCore.BLL
{
    public class EveJimaMessages
    {
        public string Get(string key)
        {
            return Tools.GetValue(key, Global.ApplicationSettings.LanguageId);
        }
    }
}
