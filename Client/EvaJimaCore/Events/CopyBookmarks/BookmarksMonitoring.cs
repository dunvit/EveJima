using System;
using System.Threading;
using System.Windows.Forms;
using EvaJimaCore;

namespace EveJimaCore.Monitoring
{
    public class BookmarksMonitoring : Events.AbstractMonitor
    {
        public override void EraseEvent()
        {

            try
            {
                if (!Global.ApplicationSettings.IsSignatureRebuildEnabled)
                {
                    _logger.Debug("[BookmarksMonitoring.Event_Refresh] Exit because signatures rebuilder is disabled.");
                    return;
                }

                var txtInClip = GetClipBoradData().Trim();

                _logger.Debug("[BookmarksMonitoring.Event_Refresh] Get text from clipboard: " + txtInClip);

                var parts = txtInClip.Split('\t');

                if (parts.Length == 6)
                {
                    #region Solo signature

                    var signatureCode = parts[0];
                    var signatureType = parts[2];
                    var signatureName = parts[3];

                    var isDetected = false;

                    var label = "[" + signatureCode + "]";

                    if (signatureType.ToUpper().IndexOf("ЧЕРВОТОЧИНА", StringComparison.Ordinal) > -1 || signatureType.ToUpper().IndexOf("WORMHOLE", StringComparison.Ordinal) > -1)
                    {
                        label = "WH " + label + "";
                        isDetected = true;
                    }

                    if (signatureType.ToUpper().IndexOf("ГАЗ", StringComparison.Ordinal) > -1 || signatureType.ToUpper().IndexOf("GAS SITE", StringComparison.Ordinal) > -1)
                    {
                        label = "Gas " + label + " " + signatureName;
                        isDetected = true;
                    }

                    if (signatureType.ToUpper().IndexOf("ДАННЫЕ", StringComparison.Ordinal) > -1 || signatureType.ToUpper().IndexOf("DATA SITE", StringComparison.Ordinal) > -1 || signatureType.ToUpper().IndexOf("ИНФОРМАЦИОН", StringComparison.Ordinal) > -1)
                    {
                        label = "Data " + label + " " + signatureName;
                        isDetected = true;
                    }

                    if (signatureType.ToUpper().IndexOf("АРТЕФАКТЫ", StringComparison.Ordinal) > -1 || signatureType.ToUpper().IndexOf("RELIC SITE", StringComparison.Ordinal) > -1 || signatureType.ToUpper().IndexOf("АРХЕОЛОГИЧ", StringComparison.Ordinal) > -1)
                    {
                        label = "Relic " + label + " " + signatureName;
                        isDetected = true;
                    }

                    try
                    {
                        if (isDetected == false)
                        {
                            label = label + " " + signatureName;
                        }

                        _logger.Debug("[BookmarksMonitoring.Event_Refresh] label: " + label);

                        Thread.CurrentThread.ApartmentState = ApartmentState.STA;

                        _logger.Debug("[BookmarksMonitoring.Event_Refresh] ApartmentState.STA: " + label);

                        clipboardSetText(label);

                        _logger.Debug("[BookmarksMonitoring.Event_Refresh] SetClipBoradData: " + GetClipBoradData().Trim());
                    }
                    catch (Exception ex)
                    {
                        var a = ex.Message;
                        _logger.ErrorFormat("[BookmarksMonitoring.Event_Refresh] Set text to clipboard error = {0}", ex.Message);
                    }
                    #endregion
                }
            }
            catch (Exception exception)
            {
                _logger.ErrorFormat("[BookmarksMonitoring.Event_Refresh] Critical error = {0}", exception.Message);


            }
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

        //protected string clipboardGetText()
        //{
        //    var clipboardThread = new Thread(() => clipBoardThreadWorkerGet);
        //    clipboardThread.SetApartmentState(ApartmentState.STA);
        //    clipboardThread.IsBackground = false;
        //    clipboardThread.Start();
        //}

        protected void clipboardSetText(string inTextToCopy)
        {
            var clipboardThread = new Thread(() => clipBoardThreadWorkerSet(inTextToCopy));
            clipboardThread.SetApartmentState(ApartmentState.STA);
            clipboardThread.IsBackground = false;
            clipboardThread.Start();
        }

        private void clipBoardThreadWorkerSet(string inTextToCopy)
        {
            Clipboard.SetText(inTextToCopy);
        }

        private string clipBoardThreadWorkerGet()
        {
            return Clipboard.GetText();
        }
    }
}
