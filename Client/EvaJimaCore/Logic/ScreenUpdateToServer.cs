using System;
using System.Threading;
using System.Windows.Forms;
using EvaJimaCore;

using log4net;

namespace EveJimaCore.Logic
{
    public partial class ScreenUpdateToServer : Form
    {
        public event Action<string> RefreshMapControl;
        public event Action<string> AuthorizeAllPilotsInAccount;

        readonly ILog _commandsLog = LogManager.GetLogger("CommandsMap");

        public string ActionType { get; set; }

        public string MapKey { get; set; }

        public ScreenUpdateToServer()
        {
            InitializeComponent();
            if(Global.Pilots.Selected != null)
            {
                Global.Pilots.Selected.SpaceMap.OnChangeStatus += Event_ChangeStatus;
            }

            Messages.GetInstance().OnGetGlobalMessage += Event_ChangeStatus;
        }

        private void Event_ChangeStatus(string message)
        {
            _commandsLog.InfoFormat("[ScreenUpdateToServer.Event_ChangeStatus] " + message);

            UpdateActionLog(message);
        }



        public void UpdateActionLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateActionLog(message)));
                return;
            }

            lblUpdateLog.Text = message;
            _commandsLog.InfoFormat("[ScreenUpdateToServer.UpdateActionLog] " + message);
            Refresh();
        }

        private void ScreenUpdateToServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Global.Pilots.Selected.SpaceMap.OnChangeStatus -= Event_ChangeStatus;
        }

        private void ScreenUpdateToServer_Shown(object sender, EventArgs e)
        {
            switch (ActionType)
            {
                case "ChangeMapKey":
                    label1.Text = @"Update server. Please wait.";
                    _commandsLog.InfoFormat("[ScreenUpdateToServer.Event_Activate] " + "Start change mapKey");
                    Global.Pilots.Selected.SpaceMap.Reset(MapKey);

                    Global.ApplicationSettings.UpdatePilotInStorage(Global.Pilots.Selected.Name, Global.Pilots.Selected.Id.ToString(), Global.Pilots.Selected.EsiData.RefreshToken, MapKey);
                    Global.ApplicationSettings.Save();

                    _commandsLog.InfoFormat("[ScreenUpdateToServer.Event_Activate] " + "End change mapKey");
                    if (RefreshMapControl != null) RefreshMapControl(MapKey);
                    Close();
                    break;

                case "ReloadMap":
                    Global.Pilots.Selected.SpaceMap.Reload(MapKey);
                    if (RefreshMapControl != null) RefreshMapControl(MapKey);
                    Close();
                    break;

                case "DeleteSystem":
                    Global.MapApiFunctions.DeleteSolarSystem(Global.Pilots.Selected.SpaceMap, Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName);

                    Global.Pilots.Selected.SpaceMap.RemoveSystem(Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName);

                    
                    Close();
                    break;

                case "LoadAllPilotesFromStorage":
                    label1.Text = @"Load data from CCP SSO (single sign-on) site.";
                    if (AuthorizeAllPilotsInAccount != null) AuthorizeAllPilotsInAccount("");
                    Close();
                    break;
            }

        }

        private void ScreenUpdateToServer_Activated(object sender, EventArgs e)
        {
            
        }
    }

   
}
