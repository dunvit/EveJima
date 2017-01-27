using System.Collections;
using System.Drawing;
using System.Linq;

namespace EvaJimaCore.Ui
{
    public class Tabs
    {
        private Hashtable List { get; set; }

        public Tabs()
        {
            List = new Hashtable();

            var smallSize = new Size(564, 325);
            var mediumSize = new Size(896, 640);
            var versionSize = new Size(896, 602);

            List.Add("Authorization", new Tab() { Name = "Authorization" , Size = smallSize});
            List.Add("Location", new Tab() { Name = "Location", Size = smallSize });
            List.Add("SolarSystem", new Tab() { Name = "SolarSystem", Size = smallSize });
            List.Add("Pilots", new Tab() { Name = "Pilots", Size = smallSize });
            List.Add("Bookmarks", new Tab() { Name = "Bookmarks", Size = smallSize });
            List.Add("Signatures", new Tab() { Name = "Signatures", Size = smallSize });
            List.Add("WebBrowser", new Tab() { Name = "WebBrowser", Size = mediumSize });
            List.Add("Version", new Tab() { Name = "Version", Size = versionSize });

            Activate("Authorization");
        }


        public void Activate(string tabName)
        {
            foreach (Tab tab in List.Values)
            {
                tab.IsActive = false;
            }

            GetTab(tabName).IsActive = true;
        }

        public Tab Active()
        {
            foreach (Tab tab in List.Values)
            {
                if (tab.IsActive)
                {
                    return tab;
                }
            }

            return null;
        }

        private Tab GetTab(string name)
        {
            return List.Values.Cast<Tab>().FirstOrDefault(tab => tab.Name == name);
        }
    }

    public class Tab
    {
        public string Name { get; set; }

        public Size Size { get; set; }

        public Size CompactSize = new Size(300, 29);

        public bool IsMinimized { get; set; }

        public bool IsActive { get; set; }
    }
}
