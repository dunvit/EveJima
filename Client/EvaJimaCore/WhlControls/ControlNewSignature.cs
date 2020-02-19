using System;
using EvaJimaCore;

namespace EveJimaCore.WhlControls
{
    public partial class ControlNewSignature : BaseContainer
    {
        public ControlNewSignature()
        {
            InitializeComponent();
        }

        private void cmdZkillboard_Click(object sender, EventArgs e)
        {
            Global.ApplicationSettings.Common.Monitoring.IsMonitoringEnabled = !Global.ApplicationSettings.Common.Monitoring.IsMonitoringEnabled;

            if (Global.ApplicationSettings.Common.Monitoring.IsMonitoringEnabled)
            {
                cmdZkillboard.Value = "Stop monitoring";
            }
            else
            {
                cmdZkillboard.Value = "Start monitoring";
            }
        }

        public override void ActivateContainer()
        {
            
            if (Global.ApplicationSettings.Common.Monitoring.IsMonitoringEnabled)
            {
                

                cmdZkillboard.Value = "Stop monitoring";
            }
            else
            {
                label1.Text = DateTime.Now.ToLongTimeString() + @" - " + Global.ApplicationSettings.Common.Monitoring.Message;

                Global.ApplicationSettings.Common.Monitoring.Message = "";

                cmdZkillboard.Value = "Start monitoring";
            }
        }
    }
}
