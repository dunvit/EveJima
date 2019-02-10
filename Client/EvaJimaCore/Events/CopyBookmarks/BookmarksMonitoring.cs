using System;
using System.Threading;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaUniverse;

namespace EveJimaCore.Monitoring
{
    public class BookmarksMonitoring : Events.AbstractMonitor
    {
        public bool IsEnabled { get; set; }

        public BookmarksMonitoring(ApplicationSettings settings) : base(settings)
        {
            IsEnabled = Settings.IsSignatureRebuildEnabled;
        }

        public override void EraseEvent()
        {
            if (!IsEnabled)
            {
                Logger.Debug("[BookmarksMonitoring.Event_Refresh] Exit because signatures rebuilder is disabled.");
                return;
            }

            var txtInClip = GetClipBoradData().Trim();

            Logger.Debug("[BookmarksMonitoring.Event_Refresh] Get text from clipboard: " + txtInClip);

            Execute(txtInClip);
        }

        public string Execute(string valueInClipboard)
        {
            var label = "";

            try
            {
                var parts = valueInClipboard.Split('\t');

                if (parts.Length == 6)
                {
                    #region Solo signature

                    var signatureCode = parts[0];
                    var signatureType = GetSignatureType(parts[2]);
                    var signatureName = parts[3];

                    switch(signatureType)
                    {
                        case SignatureType.Relic:
                            label = Settings.SignaturePatternRelic;
                            break;
                        case SignatureType.Data:
                            label = Settings.SignaturePatternData;
                            break;
                        case SignatureType.Gas:
                            label = Settings.SignaturePatternGas;
                            break;
                        case SignatureType.Unknown:
                            label = Settings.SignaturePatternUnknown;
                            break;
                        case SignatureType.WH:
                            label = Settings.SignaturePatternWormhole;
                            break;
                        default:
                            label = Settings.SignaturePatternUnknown;
                            break;
                    }

                    label = label.Replace("%ABC", signatureCode.Split('-')[0]);
                    label = label.Replace("%123", signatureCode.Split('-')[1]);

                    var utcDate = DateTime.UtcNow;

                    label = label.Replace("%ET", utcDate.Hour.ToString("00") + ":" + utcDate.Minute.ToString("00"));

                    label = label.Replace("%NAME", signatureName);

                    if(Global.Pilots != null && Global.Pilots.Selected != null)
                    {
                        label = label.Replace("%USER", Global.Pilots.Selected.Name);
                    }

                    try
                    {
                        Logger.Debug("[BookmarksMonitoring.Event_Refresh] label: " + label);

                        Thread.CurrentThread.ApartmentState = ApartmentState.STA;

                        Logger.Debug("[BookmarksMonitoring.Event_Refresh] ApartmentState.STA: " + label);

                        clipboardSetText(label);

                        Logger.Debug("[BookmarksMonitoring.Event_Refresh] SetClipBoradData: " + GetClipBoradData().Trim());
                    }
                    catch (Exception ex)
                    {
                        Logger.ErrorFormat("[BookmarksMonitoring.Event_Refresh] Set text to clipboard error = {0}", ex.Message);
                    }
                    #endregion
                }
            }
            catch (Exception exception)
            {
                Logger.ErrorFormat("[BookmarksMonitoring.Event_Refresh] Critical error = {0}", exception.Message);
            }

            return label;
        }

        private SignatureType GetSignatureType(string signature)
        {
            if (signature.ToUpper().IndexOf("ЧЕРВОТОЧИНА", StringComparison.Ordinal) > -1 || signature.ToUpper().IndexOf("WORMHOLE", StringComparison.Ordinal) > -1)
            {
                return SignatureType.WH;
            }

            if (signature.ToUpper().IndexOf("ГАЗ", StringComparison.Ordinal) > -1 || signature.ToUpper().IndexOf("GAS SITE", StringComparison.Ordinal) > -1)
            {
                return SignatureType.Gas;
            }

            if (signature.ToUpper().IndexOf("ДАННЫЕ", StringComparison.Ordinal) > -1 || signature.ToUpper().IndexOf("DATA SITE", StringComparison.Ordinal) > -1 || signature.ToUpper().IndexOf("ИНФОРМАЦИОН", StringComparison.Ordinal) > -1)
            {
                return SignatureType.Data;
            }

            if (signature.ToUpper().IndexOf("АРТЕФАКТЫ", StringComparison.Ordinal) > -1 || signature.ToUpper().IndexOf("RELIC SITE", StringComparison.Ordinal) > -1 || signature.ToUpper().IndexOf("АРХЕОЛОГИЧ", StringComparison.Ordinal) > -1)
            {
                return SignatureType.Relic;
            }

            return SignatureType.Unknown;
        }

        private static string GetClipBoradData()
        {
            try
            {
                string clipboardData = null;
                var staThread = new Thread(
                    delegate ()
                    {
                        try
                        {
                            clipboardData = Clipboard.GetText();
                        }
                        catch
                        {
                        }
                    });
                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start();
                staThread.Join();
                return clipboardData;
            }
            catch
            {
                return string.Empty;
            }
        }

        protected void clipboardSetText(string inTextToCopy)
        {
            var clipboardThread = new Thread(() => clipBoardThreadWorkerSet(inTextToCopy));
            clipboardThread.SetApartmentState(ApartmentState.STA);
            clipboardThread.IsBackground = false;
            clipboardThread.Start();
        }

        private void clipBoardThreadWorkerSet(string inTextToCopy)
        {
            try
            {
                Clipboard.SetText(inTextToCopy);
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("[BookmarksMonitoring.clipBoardThreadWorkerSet] Set text to clipboard error = {0}", ex.Message);
            }

        }
    }
}
