using System;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EveJimaIGB
{
    public static class Tools
    {
        #region
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        #endregion

        public static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            var buff = new StringBuilder(nChars);
            var handle = GetForegroundWindow();

            return GetWindowText(handle, buff, nChars) > 0 ? buff.ToString() : null;
        }


        public static Encoding GetEncodingFrom(NameValueCollection responseHeaders, Encoding defaultEncoding = null)
        {
            if (responseHeaders == null)
                throw new ArgumentNullException("responseHeaders");

            //Note that key lookup is case-insensitive
            var contentType = responseHeaders["Content-Type"];
            if (contentType == null)
                return defaultEncoding;

            var contentTypeParts = contentType.Split(';');
            if (contentTypeParts.Length <= 1)
                return defaultEncoding;

            var charsetPart =
                contentTypeParts.Skip(1).FirstOrDefault(
                    p => p.TrimStart().StartsWith("charset", StringComparison.InvariantCultureIgnoreCase));
            if (charsetPart == null)
                return defaultEncoding;

            var charsetPartParts = charsetPart.Split('=');
            if (charsetPartParts.Length != 2)
                return defaultEncoding;

            var charsetName = charsetPartParts[1].Trim();
            if (charsetName == "")
                return defaultEncoding;

            try
            {
                return Encoding.GetEncoding(charsetName);
            }
            catch (ArgumentException ex)
            {
                throw new Exception(
                    charsetName + "The server returned data in an unknown encoding: " + charsetName);
            }

        }
    }
}
