using System.Windows.Forms;
using EveJimaCore.EjEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJTests.EjEnvironment
{
    [TestClass]
    public class ClipboardTests
    {
        [TestMethod]
        public void Test_SetValue()
        {
            var clipboard = new ClipboardEntity();

            Clipboard.SetText("Test1");

             var clipboardString = clipboard.GetValue();

            Assert.AreEqual("Test1", clipboardString);
        }

        [TestMethod]
        public void Test_GetPreviousValue()
        {
            var clipboard = new ClipboardEntity();

            Clipboard.SetText("Test1");

            clipboard.GetValue();

            Clipboard.SetText("Test2");

            clipboard.GetValue();

            var clipboardString = clipboard.GetPreviousValue();

            Assert.AreEqual("Test1", clipboardString);
        }
    }
}
