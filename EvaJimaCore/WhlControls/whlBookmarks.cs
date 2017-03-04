using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlBookmarks : baseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(whlBookmarks));

        public whlBookmarks()
        {
            InitializeComponent();
        }

        private void Event_PasteBookmarks(object sender, EventArgs e)
        {
            listLocationBookmarks.Items.Clear();

            var txtInClip = Clipboard.GetText();

            Log.DebugFormat("[whlBookmarks.Event_PasteBookmarks] paste for = {0}", txtInClip);

            if (string.IsNullOrEmpty(txtInClip))
            {
                return;
            }

            string[] lines;

            lines = txtInClip.Split(new[] { '\n' }, StringSplitOptions.None);

            char tab = '\u0009';

            foreach (var line in lines)
            {
                Log.DebugFormat("[whlBookmarks.Event_PasteBookmarks] line = {0}", line);

                try
                {
                    var coordinates = line.Replace(tab.ToString(), "[---StarinForReplace---]");
                    var coordinate = coordinates.Split(new[] { @"[---StarinForReplace---]" }, StringSplitOptions.None)[0];
                    var m1 = Regex.Matches(coordinate, @"\d\d\d", RegexOptions.Singleline);

                    foreach (Match m in m1)
                    {
                        var value = m.Groups[0].Value;

                        listLocationBookmarks.Items.Add("ID = [" + value + "] " + coordinate);
                    }
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("[whlBookmarks.Event_PasteBookmarks] Critical error = {0}", ex);
                }
            }
        }

        private void Event_PasteSignatures(object sender, EventArgs e)
        {
            listCosmicSifnatures.Items.Clear();

            var txtInClip = Clipboard.GetText();

            Log.DebugFormat("[whlBookmarks.Event_PasteSignatures] paste for = {0}", txtInClip);

            if (string.IsNullOrEmpty(txtInClip))
            {
                return;
            }

            string[] lines;

            lines = txtInClip.Split(new[] { '\n' }, StringSplitOptions.None);

            char tab = '\u0009';

            foreach (var line in lines)
            {
                Log.DebugFormat("[whlBookmarks.Event_PasteSignatures] line = {0}", line);

                try
                {
                    var coordinates = line.Replace(tab.ToString(), "[---StarinForReplace---]");
                    var coordinate = coordinates.Split(new[] { @"[---StarinForReplace---]" }, StringSplitOptions.None)[0];
                    var m1 = Regex.Matches(coordinate, @"\d\d\d", RegexOptions.Singleline);

                    foreach (Match m in m1)
                    {
                        var value = m.Groups[0].Value;

                        listCosmicSifnatures.Items.Add("[" + value + "] " + coordinate);
                    }
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("[whlBookmarks.Event_PasteSignatures] Critical error = {0}", ex);
                }
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            Log.Debug("[whlBookmarks.cmdClear_Click] starting");

            try
            {
                var coordinates = listLocationBookmarks.Items.OfType<string>().ToList();
                var signatures = listCosmicSifnatures.Items.OfType<string>().ToList();

                listLocationBookmarks.Items.Clear();
                listCosmicSifnatures.Items.Clear();

                foreach (var coordinate in coordinates)
                {
                    var coordinateId = coordinate.Split('[')[1].Split(']')[0];

                    var isNeedAddToList = true;

                    foreach (var signature in signatures)
                    {
                        var signatureId = signature.Split('[')[1].Split(']')[0];

                        if (coordinateId == signatureId)
                        {
                            isNeedAddToList = false;
                        }
                    }

                    if (isNeedAddToList)
                    {
                        listLocationBookmarks.Items.Add(coordinate);
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
                        listCosmicSifnatures.Items.Add(signature);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlBookmarks.cmdClear_Click] Critical error = {0}", ex);
            }

        }

        private void Event_ClearLists(object sender, EventArgs e)
        {
            listLocationBookmarks.Items.Clear();
            listCosmicSifnatures.Items.Clear();
        }
    }
}
