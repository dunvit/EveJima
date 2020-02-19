using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EveJimaCore.UiTools;
using EveJimaCore.WhlControls;
using log4net;

namespace EveJimaCore.Main
{
    public partial class EveJimaToolbar : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(string.Empty);

        private readonly Dictionary<string, Control> _toolbarControls = new Dictionary<string, Control>();
        private Hashtable _tabs = new Hashtable();
        public string ActivePanelName { get; set; }
        public event Action<PanelMetaData> OnSelectElement;

        delegate void EnableControl(Control item);

        public EveJimaToolbar(Form eveJimaWindow)
        {
            InitializeComponent();

            tabControl1.SizeMode = TabSizeMode.Fixed;

            if (DebugTools.IsInDesignMode()) return;

            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            
            Width = 570;
            Height = 295;

            

            foreach(TabPage tabControl1TabPage in tabControl1.TabPages)
            {
                var browserControl = tabControl1TabPage.Controls[0] as BaseContainer;
                if(browserControl!= null)
                    browserControl.ParentWindow = eveJimaWindow;
            }

            
        }

        public void Initialize(Hashtable tabs)
        {
            _tabs = tabs;

            try
            {
                for (var i = 0; i <= 5; i++)
                {
                    var element = GetElementByIndex(i);

                    if(element.IsCombo)
                    {
                        var combo = CreateComboControl(element);

                        AddElementsToCombo(element, combo);

                        combo.ResetSize();

                        combo.OnElementChanged += elementChanged_Event;

                        _toolbarControls.Add(element.Name, combo);

                        Controls.Add(combo);
                    }
                    else
                    {
                        var label = CreateLabelControl(element);

                        label.Click += Event_ClickOnPanelOpenerButton;

                        _toolbarControls.Add(element.Name, label);

                        Controls.Add(label);
                    }
                }
            }
            catch(Exception e)
            {
                
            }

            Refresh();

            RelocateDynamicButtons();
        }

        private void AddElementsToCombo(PanelMetaData element, ejcComboBox combo)
        {
            var smallJobs = _tabs.Values.Cast<PanelMetaData>().Where(data => data.IsComboElement && data.ParentElement == element.Name).ToArray().OrderBy(entry => entry.ComboIndex);

            foreach(var data in smallJobs)
            {
                combo.AddItem(new ejcComboboxItem { Text = Localization.Messages.Get(data.LabelKey), Value = data.Name });
            }
        }

        private Control GetElementByTag(string tag)
        {
            foreach(Control control in Controls)
            {
                if(control.Tag != null)
                {
                    if(control.Tag.ToString() == tag)
                    {
                        return control;
                    }
                }
            }

            return null;
        }

        private ejcComboBox CreateComboControl(PanelMetaData element)
        {
            var combo = new ejcComboBox
            {
                Cursor = element.Enabled ? Cursors.Hand : DefaultCursor,
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold),
                ForeColor = element.Enabled ? Color.Silver : Color.DimGray,
                Location = new Point(3, 3),
                Name = element.Name,
                Size = new Size(70, 26),
                Text = Localization.Messages.Get(element.LabelKey),
                AutoSize = true
            };
            return combo;
        }

        private Label CreateLabelControl(PanelMetaData element)
        {
            var label = new Label
            {
                Text = Localization.Messages.Get(element.LabelKey),
                Visible = true,
                Name = element.Name,
                Location = new Point(3, 8),
                Cursor = element.Enabled ? Cursors.Hand : DefaultCursor,
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold),
                ForeColor = element.Enabled ? Color.Silver : Color.DimGray,
                AutoSize = true,
                Tag = element.Name
            };
            return label;
        }

        private void RelocateDynamicButtons()
        {
            for(var i = 0; i <= 5; i++)
            {
                var leftPosition = (i == 0) ? 3 : Controls[GetElementByIndex(i - 1).Name].Left + Controls[GetElementByIndex(i - 1).Name].Width;

                var control = Controls[GetElementByIndex(i).Name];

                control.Location = new Point(leftPosition, control.Location.Y);
                control.Refresh();
            }
        }

        private PanelMetaData GetElementByIndex(int index)
        {
            return _tabs.Values.Cast<PanelMetaData>().FirstOrDefault(element => element.Index == index);
        }

        private PanelMetaData GetElementByName(string name)
        {
            return _tabs.Values.Cast<PanelMetaData>().FirstOrDefault(element => element.Name == name);
        }

        public void SelectPilotSetAllTabsEnabled()
        {
            foreach (PanelMetaData tab in _tabs.Values)
            {
                tab.Enabled = true;
                EnableControlByTag(tab.Name);
            }
        }

        private void EnableControlByTag(string tag)
        {
            EnableControlAction(GetElementByTag(tag));
        }

        private void EnableControlAction(Control control)
        {
            if (control == null) return;

            if (control.InvokeRequired)
            {
                var d = new EnableControl(EnableControlAction);
                Invoke(d, control);
            }
            else
            {
                if (control != null)
                {
                    control.Cursor = Cursors.Hand;
                    control.ForeColor = Color.Silver;
                    control.Refresh();
                }
            }
        }

        private void Event_ClickOnPanelOpenerButton(object sender, EventArgs e)
        {
            var element = ((Control)sender).Tag as string;

            if(element == null) return;

            var panelMetaData = (PanelMetaData)_tabs[element];

            if (panelMetaData.Enabled == false) return;

            ActivatePanel(element);
        }
        

        private void elementChanged_Event(string element)
        {
            var panelMetaData = (PanelMetaData)_tabs[element];

            var senderCombo = Controls[panelMetaData.ParentElement] as ejcComboBox;
            senderCombo.ResetSize();
            senderCombo.Refresh();

            RelocateDynamicButtons();

            if (panelMetaData.Enabled == false)
            {
                ActivatePanel("NeedLoadPilot");
                return;
            }

            ActivatePanel(element);
        }

        public PanelMetaData GetActivePanelMetaData()
        {
            return _tabs.Values.Cast<PanelMetaData>().FirstOrDefault(x => x.Name == ActivePanelName);
        }

        public PanelMetaData BrowserNavigate(string address)
        {
            ActivatePanel("Browser");

            return GetElementByName("Browser");
        }

        public void ActivatePanel(string panelName)
        {
            if (InvokeRequired) 
            {
                Invoke(new Action(() => ActivatePanel(panelName)));
                return;
            }

            try
            {
                ActivePanelName = panelName;

                foreach (var key in _toolbarControls.Keys)
                {
                    var panelMetaData = (PanelMetaData)_tabs[key];

                    if(panelMetaData == null)
                    {
                        var senderCombo = Controls[key] as ejcComboBox;

                        senderCombo.ForeColor = Color.Silver;

                        continue;
                    }

                    var button = _toolbarControls[key];

                    if (panelMetaData.Enabled)
                    {
                        button.ForeColor = Color.Silver;
                    }
                    else
                    {
                        button.ForeColor = Color.DimGray;
                        button.Cursor = DefaultCursor;
                    }
                }

                if (_toolbarControls.ContainsKey(panelName)) _toolbarControls[panelName].ForeColor = Color.DarkGoldenrod;

                var element = GetElementByName(panelName);

                if(element.IsComboElement)
                {
                    var senderCombo = Controls[element.ParentElement] as ejcComboBox;

                    senderCombo.ActivateItem(panelName);
                    senderCombo.ForeColor = Color.DarkGoldenrod;
                }

                if(element != null)
                    OnSelectElement?.Invoke(element);

                ActivateTab(element);

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[EveJimaToolbar.ActivatePanel] Critical error = {0}", ex);
            }
        }

        //public void ActivatePilot()
        //{
        //    var control = tabControl1.TabPages["Authorization"].Controls[0] as ControlAuthorization;
        //}

        public void ActivateTab(PanelMetaData panel)
        {
            if (InvokeRequired) 
            {
                Invoke(new Action(() => ActivateTab(panel)));
                return;
            }

            var control = tabControl1.TabPages[panel.Name];

            if (control == null) return;

            var element = control.Controls[0];
            if (element != null) ((BaseContainer)element).ActivateContainer();

            tabControl1.Size = new Size(panel.Size.Width, panel.Size.Height);

            Size = panel.Size;

            foreach (TabPage tab in tabControl1.TabPages)
            {
                try
                {
                    if (tab.Tag != null && tab.Tag.ToString() == panel.Name)
                    {
                        tabControl1.SelectedTab = tab;
                    }
                }
                catch (Exception e)
                {
                    Log.ErrorFormat("[EveJimaTabs.ActivateTab] Critical error. Exception {0}", e);
                }
            }

            Refresh();
        }

        private void EveJimaToolbar_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
