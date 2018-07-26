using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EvaJimaCore;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class eveCrlTravelHistory : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(string.Empty);

        public event Action<string> OnUseModule;

        private string lastCheckSolarSystemName;

        public eveCrlTravelHistory()
        {
            InitializeComponent();

            cmdExecute.Value = Global.Messages.Get("Tab_TravelHistory_ShowNewSignatures");
            txtNewSignaturesLabel.Text = Global.Messages.Get("Tab_TravelHistory_NewSignaturesLabel");
            lblHelp.Text = Global.Messages.Get("Tab_TravelHistory_Help");

            listCosmicSignatures.DrawMode = DrawMode.OwnerDrawFixed;
            listCosmicSignatures.DrawItem += listBox_DrawItem;
        }

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (e.Index > -1)
            {
                object item = list.Items[e.Index];
                e.DrawBackground();
                e.DrawFocusRectangle();
                Brush brush = new SolidBrush(e.ForeColor);
                SizeF size = e.Graphics.MeasureString(item.ToString(), e.Font);
                e.Graphics.DrawString(item.ToString(), e.Font, brush, e.Bounds.Left + (e.Bounds.Width / 2 - size.Width / 2), e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2));
            }
        }

        public override void ActivateContainer()
        {
            Log.Debug("[eveCrlTravelHistory.ActivateContainer] Activate \"Travel History\" tab.");

            if(lastCheckSolarSystemName != Global.Pilots.Selected.Location.Name)
            {
                pnlNewSignaturesResults.Visible = false;
            }

            var address = "http://evejima.mikotaj.com/VisitorsCounterTravelHistory.html";

            OnUseModule?.Invoke(address);
        }

        private void Event_ShowNewSignatures(object sender, EventArgs e)
        {
            lastCheckSolarSystemName = Global.Pilots.Selected.Location.Name;

            var signaturesFromClipboard = GetSignaturesFromClipboard();

            var signaturesFromLocationFile = GetSignaturesFromFile();

            var newSignatures = GetNewSignatures(signaturesFromClipboard, signaturesFromLocationFile);

            if(signaturesFromClipboard != null && signaturesFromClipboard.Any())
            {
                UpdateLocationFile(signaturesFromClipboard);
            }

            listCosmicSignatures.Items.Clear();

            foreach(var newSignature in newSignatures)
            {
                listCosmicSignatures.Items.Add(newSignature);
            }

            pnlNewSignaturesResults.Visible = true;
        }

        private void UpdateLocationFile(IEnumerable<string> signaturesFromClipboard)
        {
            Log.DebugFormat("[eveCrlTravelHistory.UpdateLocationFile] Start save signatures to location file for = {0}", Global.Pilots.Selected.Location.Name);

            try
            {
                var fileName = @"Data/TravelHistory/" + Global.Pilots.Selected.Location.Name + ".txt";

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var signatureFromClipboard in signaturesFromClipboard)
                    {
                        writer.WriteLine(signatureFromClipboard.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlTravelHistory.UpdateLocationFile] Critical error = {0}", ex.Message);
            }

            
        }

        private IEnumerable<string> GetNewSignatures(IEnumerable<string> signaturesFromClipboard, IEnumerable<string> signaturesFromLocationFile)
        {
            Log.DebugFormat("[eveCrlTravelHistory.GetNewSignatures] Start get signatures from file for = {0}", Global.Pilots.Selected.Location.Name);

            var signatures = new List<string>();

            try
            {
                foreach(var signatureFromClipboard in signaturesFromClipboard)
                {
                    var isNewSignature = true;

                    foreach (var signatureFromLocationFile in signaturesFromLocationFile)
                    {
                        if(signatureFromLocationFile.Trim() == signatureFromClipboard.Trim()) isNewSignature = false;
                    }

                    if(isNewSignature) signatures.Add(signatureFromClipboard);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlTravelHistory.GetNewSignatures] Critical error = {0}", ex.Message);
            }

            return signatures;
        }

        private IEnumerable<string> GetSignaturesFromFile()
        {
            Log.DebugFormat("[eveCrlTravelHistory.GetSignaturesFromFile] Start get signatures from file for = {0}", Global.Pilots.Selected.Location.Name);

            var signatures = new List<string>();

            var fileName = @"Data/TravelHistory/" + Global.Pilots.Selected.Location.Name + ".txt";

            try
            {
                if (File.Exists(fileName) == false) return signatures;

                string line;

                StreamReader file = new StreamReader(fileName);

                while ((line = file.ReadLine()) != null)
                {
                    signatures.Add(line.Trim());
                }

                file.Close();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlTravelHistory.LoadTravelHistorySignatures] Critical error = {0}", ex);
            }

            return signatures;
        }

        private IEnumerable<string> GetSignaturesFromClipboard()
        {
            char tab = '\u0009';

            var txtInClip = Clipboard.GetText();

            Log.DebugFormat("[eveCrlTravelHistory.GetSignaturesFromClipboard] paste for = {0}", txtInClip);

            if (string.IsNullOrEmpty(txtInClip))
            {
                return new List<string>();
            }


            var signatures = new List<string>();

            try
            {
                string[] lines;

                lines = txtInClip.Split(new[] { '\n' }, StringSplitOptions.None);

                foreach (var line in lines)
                {
                    Log.DebugFormat("[eveCrlTravelHistory.GetSignaturesFromClipboard] line = {0}", line);

                    try
                    {
                        var coordinates = line.Replace(tab.ToString(), "[---StarinForReplace---]");
                        var coordinate = coordinates.Split(new[] { @"[---StarinForReplace---]" }, StringSplitOptions.None)[0];
                        var m1 = Regex.Matches(coordinate, @"\d\d\d", RegexOptions.Singleline);

                        foreach (Match m in m1)
                        {
                            var value = m.Groups[0].Value;

                            signatures.Add("[" + coordinate.Replace("\r","") + "]");
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("[eveCrlTravelHistory.GetSignaturesFromClipboard] Critical error = {0}", ex.Message);
                    }
                }
            }
            catch (Exception exExternal)
            {
                Log.ErrorFormat("[eveCrlTravelHistory.GetSignaturesFromClipboard] Critical error = {0}", exExternal.Message);
            }

            return signatures;
        }

        private void eveCrlTravelHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
