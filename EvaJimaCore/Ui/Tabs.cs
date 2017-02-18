using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using EveJimaCore;
using EveJimaCore.Ui;
using EveJimaCore.WhlControls;

namespace EvaJimaCore.Ui
{
    public class Tabs
    {
        public DelegateOnChangeTab OnChangeTab;

        private Tab activeTab;

        public WindowMonitoring Parent { get; set; }

        private readonly Hashtable _list = new Hashtable();

        public void AddTab(string name, TabSize size, whlButton button, baseContainer container)
        {
            var sizeTab = new Size(564, 325);

            switch (size)
            {
                case TabSize.Medium:
                    sizeTab = new Size(896, 640);
                    break;
                case TabSize.Large:
                    sizeTab = new Size(896, 602);
                    break;
            }
            if (button != null)
            {
                button.Click += Event_ShowContainer;
                button.Tag = name;
            }
            

            container.Hide();
            if (button != null)
            {
                button.IsTabControlButton = true;
            }

            _list.Add(name, new Tab() { Name = name, Size = sizeTab , Button = button, Container = container});
        }

        private void Event_ShowContainer(object sender, EventArgs e)
        {
            var button = sender as whlButton;

            Activate(button.Tag.ToString());
        }

        public void Activate(string tabName)
        {
            if (activeTab != null)
            {
                if (activeTab.Name != tabName)
                {
                    activeTab.IsActive = false;
                    activeTab.Container.Hide();
                }
            }

            activeTab = GetTab(tabName);

            activeTab.IsActive = true;
            Parent.pnlContainer.BringToFront();

            if (Parent.IsWebBrowserMaximize == false)
            {
                activeTab.Button.BringToFront();
            }

            activeTab.Container.BringToFront();
            activeTab.Container.Show();

            if (OnChangeTab != null) OnChangeTab(tabName);

            
            if (Parent.IsWebBrowserMaximize == false)
            {
                Resize();
            }
        }

        public void Resize()
        {
            if (Parent == null) return;

            Parent.Size = Active().Size;

            Parent.pnlContainer.Size = new Size(Active().Size.Width - 26, Active().Size.Height - 95);

            activeTab.Container.Size = new Size(Active().Size.Width - 26, Active().Size.Height - 95);

            Parent.Refresh();
        }

        public Tab Active()
        {
            foreach (Tab tab in _list.Values)
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
            return _list.Values.Cast<Tab>().FirstOrDefault(tab => tab.Name == name);
        }
    }

    
}
