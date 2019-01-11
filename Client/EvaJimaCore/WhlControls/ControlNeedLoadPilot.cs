using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class ControlNeedLoadPilot : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ControlNeedLoadPilot));

        public BrowserNavigate OnBrowserNavigate;

        public ControlNeedLoadPilot()
        {
            InitializeComponent();

            lblAuthorizationInfo.Text = Localization.Messages.Get("TextNeedAuthorization");
        }

    }
}
