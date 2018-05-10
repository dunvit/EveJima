using EvaJimaCore;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlNeedLoadPilot : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(whlNeedLoadPilot));

        public BrowserNavigate OnBrowserNavigate;

        public whlNeedLoadPilot()
        {
            InitializeComponent();

            lblAuthorizationInfo.Text = Tools.GetValue("TextNeedAuthorization", Global.ApplicationSettings.LanguageId);
        }

    }
}
