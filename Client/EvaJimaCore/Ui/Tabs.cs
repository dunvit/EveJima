﻿using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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



        public void AddTab(string name, TabSize size, Button button, BaseContainer container)
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

                case TabSize.Map:
                    sizeTab = new Size(1050, 612);
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
                //button.IsTabControlButton = true;
            }
            if(_list.ContainsKey(name)) _list.Remove(name);
            _list.Add(name, new Tab() { Name = name, Size = sizeTab , Button = button, Container = container});
        }

        private void SetActivePanel(string panelName)
        {
            foreach (Tab tab in _list.Values)
            {
                if (tab.Button == null) continue;

                tab.Button.ForeColor = Color.Silver;

                if (tab.Name == panelName)
                {
                    tab.Button.ForeColor = Color.DarkGoldenrod;
                }
            }
        }

        private void Event_ShowContainer(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button.Tag.ToString() == "Map" && Global.Pilots.Selected == null) return;


            foreach (Tab tab in _list.Values)
            {
                if (tab.Button != null)
                {
                    //tab.Button.BackColor = Color.FromArgb(24, 24, 24);
                    tab.Button.ForeColor = Color.Silver;
                }
            }

            //button.BackColor = Color.Black;

            if (button.Tag.ToString() == "Location")
            {
                if (Global.Pilots.Selected == null)
                {
                    //button.IsActive = false;
                    return;
                }

                if (Global.Pilots.Selected.Location.Name == "unknown")
                {
                    //button.IsActive = false;
                    return;
                }
                else
                {
                    //button.IsActive = true;
                }
            }

            foreach (Tab tab in _list.Values)
            {
                if (tab.Button == null) continue;

                if (tab.Name == "Map")
                {
                    if(Global.Pilots.Selected == null)
                    {
                        tab.Button.ForeColor = Color.DimGray;
                        continue;
                    }

                    if (Global.Pilots.Selected.Location.Id == null)
                    {
                        tab.Button.ForeColor = Color.DimGray;
                        // TODO: Disable click event in inactive button "Location"
                        //tab.Button.Enabled = false;
                    }
                    else
                    {
                        tab.Button.ForeColor = Color.Silver;
                        //tab.Button.Enabled = true;
                    }
                }
            }

            

            button.ForeColor = Color.DarkGoldenrod;

            Activate(button.Tag.ToString());
        }

        public void Activate(string tabName)
        {
            Global.Presenter.ChangeScreen(tabName);

            if(tabName == "Map" && Global.Pilots.Selected == null) return;

            //var map = Global.Pilots.Selected.SpaceMap;

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
                if (activeTab.Button != null) activeTab.Button.BringToFront();
            }

            activeTab.Container.BringToFront();
            activeTab.Container.Show();

            activeTab.Container.ActivateContainer();

            if (OnChangeTab != null) OnChangeTab(tabName);

            
            if (Parent.IsWebBrowserMaximize == false)
            {
                Resize();
            }

            SetActivePanel(tabName);
        }

        public void Resize()
        {
            if (Parent == null) return;

            Parent.Size = Active().Size;

            Parent.pnlContainer.Size = new Size(Active().Size.Width - 12, Active().Size.Height - 95);

            activeTab.Container.Size = new Size(Active().Size.Width - 12, Active().Size.Height - 95);

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
