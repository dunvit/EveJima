using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CsvHelper;
using EvaJimaCore;
using EveJimaCore.BLL;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlTravelHistory : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(whlTravelHistory));
        public StarSystemEntity SolarSystem { get; set; }

        private DelegateShowLocation _delegateShowLocation;

        public whlTravelHistory(DelegateShowLocation delegateShowLocation)
        {
            InitializeComponent();

            _delegateShowLocation = delegateShowLocation;
        }

        public void RefreshSolarSystem(StarSystemEntity location)
        {
            if (SolarSystem == null || SolarSystem.System != location.System)
            {
                LoadTravelHistorySignatures(location);
            }

            SolarSystem = location.Clone() as StarSystemEntity;
        }

        private void LoadTravelHistorySignatures(StarSystemEntity location)
        {
            listHistorySignatures.Items.Clear();
            listCosmicSifnatures.Items.Clear();

            try
            {
                using (var sr = new StreamReader(@"Data/TravelHistory/" + location.System + ".csv"))
                {
                    var records = new CsvReader(sr).GetRecords<BasicCosmicSignature>();

                    foreach (var record in records)
                    {
                        Log.DebugFormat("[whlTravelHistory.LoadTravelHistorySignatures] Read csv row. {0} {1}", record.Key, record.Value);
                        listHistorySignatures.Items.Add(record.Key.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlTravelHistory.LoadTravelHistorySignatures] Critical error = {0}", ex);
            }
            
        }

        private void Event_ReturnToSolarSystem(object sender, EventArgs e)
        {
            _delegateShowLocation();
        }

        private void Event_PasteCosmicSignatures(object sender, EventArgs e)
        {
            listCosmicSifnatures.Items.Clear();

            Log.DebugFormat("[whlTravelHistory.Event_PasteSignatures] paste for = {0}", Clipboard.GetText());

            if (string.IsNullOrEmpty(Clipboard.GetText())) return;

            var lines = Clipboard.GetText().Split(new[] { '\n' }, StringSplitOptions.None);

            const char tab = '\u0009';

            foreach (var line in lines)
            {
                Log.DebugFormat("[whlTravelHistory.Event_PasteSignatures] line = {0}", line);

                try
                {
                    var coordinates = line.Replace(tab.ToString(), "[---StarinForReplace---]");
                    var coordinate = coordinates.Split(new[] { @"[---StarinForReplace---]" }, StringSplitOptions.None)[0];
                    var name = coordinates.Split(new[] { @"[---StarinForReplace---]" }, StringSplitOptions.None)[2];
                    var m1 = Regex.Matches(coordinate, @"\d\d\d", RegexOptions.Singleline);

                    foreach (Match m in m1)
                    {
                        listCosmicSifnatures.Items.Add("[" + coordinate + "] - " + name);
                    }
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("[whlTravelHistory.Event_PasteSignatures] Critical error = {0}", ex);
                }
            }
        }

        private void UpdateTravelHistory()
        {
            var signatures = new Dictionary<string, string>();

            foreach (var item in listHistorySignatures.Items)
            {
                try
                {
                    if (item.ToString().Trim() != string.Empty)
                    {
                        if (item.ToString().Trim().Split(new[] { @"] - " }, StringSplitOptions.None).Count() == 2)
                        {
                            signatures.Add(item.ToString(), DateTime.UtcNow.ToString("dd.MM.yyyy"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("[whlTravelHistory.Event_UpdateTravelHistory] Critical error. Item {1}\n Exception {0}", ex, item);
                }

            }

            using (var sw = new StreamWriter(@"Data/TravelHistory/" + Global.Pilots.Selected.Location.System + ".csv"))
            {
                var writer = new CsvWriter(sw);

                IEnumerable records = signatures.ToList();

                writer.WriteRecords(records);
            }
        }

        private void Event_Analize(object sender, EventArgs e)
        {
            try
            {
                var coordinates = listHistorySignatures.Items.OfType<string>().ToList();
                var signatures = listCosmicSifnatures.Items.OfType<string>().ToList();

                listHistorySignatures.Items.Clear();
                listCosmicSifnatures.Items.Clear();

                foreach (var coordinate in coordinates)
                {
                    var coordinateId = coordinate.Split('[')[1].Split(']')[0];

                    var isNeedAddToList = false;

                    foreach (var signature in signatures)
                    {
                        var signatureId = signature.Split('[')[1].Split(']')[0];

                        if (coordinateId == signatureId)
                        {
                            isNeedAddToList = true;
                        }
                    }

                    if (isNeedAddToList)
                    {
                        listHistorySignatures.Items.Add(coordinate);
                    }
                }

                foreach (var signature in signatures)
                {
                    var signatureId = signature.Split('[')[1].Split(']')[0];


                    var isNeedAddToList = true;

                    foreach (var coordinate in coordinates)
                    {
                        var coordinateId = coordinate.Split('[')[1].Split(']')[0];

                        if (coordinateId == signatureId)
                        {
                            isNeedAddToList = false;
                        }
                    }

                    if (isNeedAddToList)
                    {

                        var data = signature.Split(new[] { @"] - " }, StringSplitOptions.None);

                        if (data[1] == String.Empty)
                        {
                            listCosmicSifnatures.Items.Add(signature);
                        }
                        else
                        {
                            listHistorySignatures.Items.Add(signature);
                        }
                    }
                }

                UpdateTravelHistory();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlTravelHistory.Event_Analize] Critical error = {0}", ex);
            }
        }
    }
}
