using EvaJimaCore;
using log4net;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EveJimaCore.WhlControls
{
    public partial class ControlEditPilots : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(string.Empty);

        public event Action OnClose;

        private bool _isDeleted;

        public ControlEditPilots()
        {
            InitializeComponent();

            cmdReturn.Value = Localization.Messages.Get("Tab_EditPilots_Return");
            cmdDelete.Value = Localization.Messages.Get("Tab_EditPilots_Delete");
            cmdSaveChanges.Value = Localization.Messages.Get("Tab_EditPilots_Save");
            lblNeedRestart.Text = Localization.Messages.Get("Tab_EditPilots_Message_NeedRestart");
            lblAfterDeleteNotification.Text = Localization.Messages.Get("Tab_EditPilots_Message_AfterDelete");

            cmdReturn.Click += cmdReturn_Click;
        }

        public override void ActivateContainer()
        {
            LoadAllPilotes();
            _isDeleted = false;

            crlPilotPortrait.Visible = true;
            cmdDelete.Visible = true;
            cmbPilots.Visible = true;
        }

        private void LoadAllPilotes()
        {
            cmbPilots.Items.Clear();

            foreach (var pilot in Global.ApplicationSettings.Pilots)
            {
                try
                {
                    cmbPilots.Items.Add(pilot.Item1.Trim());
                    cmbPilots.Text = pilot.Item1.Trim();
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("[eveCrlEditPilots.LoadAllPilotes] Critical error. Exception {0}", ex);
                }

            }

            RefreshPilotInformation(cmbPilots.Text);
        }

        private void cmdReturn_Click(object sender, EventArgs e)
        {
            OnClose?.Invoke();
        }

        private void Event_SelectPilot(object sender, EventArgs e)
        {
            RefreshPilotInformation(cmbPilots.Text);
        }

        private void RefreshPilotInformation(string pilotName)
        {
            var pilot = Global.Pilots.GetPilotInformation(pilotName);

            if (pilotName == "")
            {
                crlPilotPortrait.Visible = false;
                cmdDelete.Visible = false;
                cmbPilots.Visible = false;
            }
            else
            {
                crlPilotPortrait.Visible = true;
                cmdDelete.Visible = true;
                cmbPilots.Visible = true;
            }

            if(_isDeleted)
            {
                cmdSaveChanges.Enabled = true;
            }
            else
            {
                cmdSaveChanges.Enabled = false;
            }

            if (pilot == null) return;
        

            crlPilotPortrait.Image = pilot.Portrait;
            crlPilotPortrait.Refresh();
        }

        private void Event_DeletePilot(object sender, EventArgs e)
        {
            var pilots = new List<string>();

            _isDeleted = true;

            foreach (var pilot in cmbPilots.Items)
            {
                try
                {
                    if(pilot.ToString() != cmbPilots.Text)
                    {
                        pilots.Add(pilot.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("[eveCrlEditPilots.Event_DeletePilot] Critical error. Exception {0}", ex);
                }

            }

            cmbPilots.Items.Clear();

            foreach(var pilot in pilots)
            {
                cmbPilots.Items.Add(pilot.Trim());
                cmbPilots.Text = pilot.Trim();
            }


            RefreshPilotInformation(cmbPilots.Text);
        }

        private void Event_DeletePilots(object sender, EventArgs e)
        {
            Global.ApplicationSettings.Pilots = DeletePilots(cmbPilots.Items, Global.ApplicationSettings.Pilots);
            Global.ApplicationSettings.Save();
            Global.Presenter.Close();
        }

        private List<Tuple<string, string, string, string>> DeletePilots(ComboBox.ObjectCollection cmbPilotsItemsm, List<Tuple<string, string, string, string>> pilotsFromSettings)
        {
            var pilotsAfterDelete = new List<Tuple<string, string, string, string>>();

            foreach (var pilot in cmbPilotsItemsm)
            {
                try
                {
                    foreach (var pilotFromSettings in pilotsFromSettings)
                    {
                        if (pilot.ToString() == pilotFromSettings.Item1)
                        {
                            pilotsAfterDelete.Add(pilotFromSettings);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("[eveCrlEditPilots.Event_DeletePilots] Critical error. Exception {0}", ex);
                }
            }

            return pilotsAfterDelete;
        }

        private void Event_ReturnToAuthorization(object sender, EventArgs e)
        {
            Global.Presenter.ChangeScreen("Authorization");
        }

        private void cmdDelete_Load(object sender, EventArgs e)
        {

        }
    }
}
