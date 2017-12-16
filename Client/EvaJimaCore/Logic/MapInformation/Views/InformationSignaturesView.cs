using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL.Map;
using EveJimaCore.Logic.MapInformation.Views;
using EveJimaUniverse;
using log4net;

namespace EveJimaCore.Logic.MapInformation
{
    public partial class InformationSignaturesView : UserControl, IMapInformationControl
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(InformationSignaturesView));

        public event Action<string, List<CosmicSignature>> UpdateSignatures;

        private BindingSource signaturesSource = new BindingSource();

        private string selectedSolarSystemName;

        public InformationSignaturesView()
        {
            InitializeComponent();

            groupBox3.Text = Global.Messages.Get("Tab_Map_Signatures");
            ejButton2.Text = Global.Messages.Get("Tab_Map_PasteSignatures");
            cmdUpdateSignatures.Text = Global.Messages.Get("Tab_Map_UpdateAll");
            ejButton4.Text = Global.Messages.Get("Tab_Map_DeleteAll");
        }

        public void ForceRefresh(Map spaceMap)
        {
            Log.DebugFormat("[InformationSignaturesView.ForceRefresh] start");
            var solarSystem = spaceMap.GetSystem(spaceMap.SelectedSolarSystemName);

            if(solarSystem == null)
            {
                Log.DebugFormat($"[InformationSignaturesView.ForceRefresh] spaceMap.SelectedSolarSystemName {spaceMap.SelectedSolarSystemName} not found");
                return;
            }

            selectedSolarSystemName = solarSystem.Name;
            FillSignaturesContainer(solarSystem.Signatures);
            Log.DebugFormat("[InformationSignaturesView.ForceRefresh] end");
        }

        private void ejButton2_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Clipboard.GetText())) return;

            var lines = Clipboard.GetText().Split(new[] { '\n' }, StringSplitOptions.None);

            var signatures = new List<CosmicSignature>();

            const char tab = '\u0009';

            foreach (var line in lines)
            {
                // Log.DebugFormat("[whlTravelHistory.Event_PasteSignatures] line = {0}", line);

                try
                {
                    var coordinates = line.Replace(tab.ToString(), "[---StarinForReplace---]");
                    var coordinate = coordinates.Split(new[] { @"[---StarinForReplace---]" }, StringSplitOptions.None)[0];
                    var type = coordinates.Split(new[] { @"[---StarinForReplace---]" }, StringSplitOptions.None)[2];
                    var name = coordinates.Split(new[] { @"[---StarinForReplace---]" }, StringSplitOptions.None)[1];
                    var label = coordinates.Split(new[] { @"[---StarinForReplace---]" }, StringSplitOptions.None)[3];
                    var m1 = Regex.Matches(coordinate, @"\d\d\d", RegexOptions.Singleline);

                    foreach (Match m in m1)
                    {
                        //listCosmicSifnatures.Items.Add("[" + coordinate + "] - " + name);
                        var signature = new CosmicSignature();
                        signature.Code = coordinate;
                        signature.SolarSystemName = Global.Pilots.Selected.SpaceMap.LocationSolarSystemName;
                        //var type = record.Key.Split(new[] { @" - " }, StringSplitOptions.None)[1];
                        signature.Type = SignatureType.Unknown;

                        signature.Name = "Cosmic Signature";

                        if (type.ToUpper().IndexOf("ЧЕРВОТОЧИНА") > -1 || type.ToUpper().IndexOf("WORMHOLE") > -1)
                        {
                            signature.Name = type + " " + label;
                            signature.Type = SignatureType.WH;
                        }

                        if (type.ToUpper().IndexOf("ГАЗ") > -1 || type.ToUpper().IndexOf("GAS SITE") > -1)
                        {
                            signature.Name = type + " " + label;
                            signature.Type = SignatureType.Gas;
                        }

                        if (type.ToUpper().IndexOf("ДАННЫЕ") > -1 || type.ToUpper().IndexOf("DATA SITE") > -1)
                        {
                            signature.Name = type + " " + label;
                            signature.Type = SignatureType.Data;
                        }

                        if (type.ToUpper().IndexOf("АРТЕФАКТЫ") > -1 || type.ToUpper().IndexOf("RELIC SITE") > -1)
                        {
                            signature.Name = type + " " + label;
                            signature.Type = SignatureType.Relic;
                        }

                        //bool isNeedAddSignature = true;


                        signatures.Add(signature);
                    }
                }
                catch (Exception ex)
                {
                    //Log.ErrorFormat("[whlTravelHistory.Event_PasteSignatures] Critical error = {0}", ex);
                }
            }

            FillSignaturesContainer(signatures);

        }

        private void FillSignaturesContainer(IEnumerable<CosmicSignature> signatures)
        {
            signaturesSource = new BindingSource();

            foreach (var cosmicSignature in signatures)
            {
                signaturesSource.Add(new CosmicSignature { Type = cosmicSignature.Type, Code = cosmicSignature.Code, Name = cosmicSignature.Name });
            }

            if (dataGridView1.Columns.Contains("Code")) dataGridView1.Columns.Remove("Code");
            if (dataGridView1.Columns.Contains("Name")) dataGridView1.Columns.Remove("Name");
            if (dataGridView1.Columns.Contains("Type")) dataGridView1.Columns.Remove("Type");

            DataGridViewColumn code = new DataGridViewTextBoxColumn();
            code.Width = 65;
            code.DataPropertyName = "Code";
            code.Name = "Code";
            dataGridView1.Columns.Add(code);

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Width = 130;
            column.DataPropertyName = "Name";
            column.Name = "Name";
            dataGridView1.Columns.Add(column);

            var combo = new DataGridViewComboBoxColumn
            {
                Width = 70,
                FlatStyle = FlatStyle.Flat,
                DataSource = Enum.GetValues(typeof(SignatureType)),
                DataPropertyName = "Type",
                Name = "Type"
            };
            dataGridView1.Columns.Add(combo);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = signaturesSource;

            foreach (DataGridViewRow row in dataGridView1.Rows)
                if (row.Cells[2].Value.ToString() == "Cosmic Signature")
                {
                    row.DefaultCellStyle.BackColor = Color.DarkRed;
                }

            dataGridView1.ClearSelection();
        }

        private void cmdUpdateSignatures_Click(object sender, EventArgs e)
        {
            var signatures = new List<CosmicSignature>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var signature = new CosmicSignature
                {
                    Name = row.Cells["Name"].Value.ToString(),
                    Code = row.Cells["Code"].Value.ToString(),
                    SolarSystemName = selectedSolarSystemName
                };

                var signatureType = row.Cells["Type"].Value.ToString();

                var type = (SignatureType)Enum.Parse(typeof(SignatureType), signatureType, true);

                signature.Type = type;

                signatures.Add(signature);
            }

            if (UpdateSignatures != null) UpdateSignatures(selectedSolarSystemName, signatures);
        }

        private void ejButton4_Click(object sender, EventArgs e)
        {
            FillSignaturesContainer(new List<CosmicSignature>() );

            if (UpdateSignatures != null) UpdateSignatures(selectedSolarSystemName, new List<CosmicSignature>());
        }
    }
}
