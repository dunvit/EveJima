using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EveJimaIGB.BLL;
using EveJimaIGB.Bookmarks;
using EveJimaIGB.Monitoring;
using log4net;
using WBrowser;

namespace EveJimaIGB
{
    public delegate void BrowserBeforeShowDialog();

    public delegate void BrowserAfterBeforeShowDialog();

    public partial class IGBrowser : UserControl
    {
        //private Hashtable tabs = new Hashtable();
        private readonly ILog _logger = LogManager.GetLogger(string.Empty);
        public BrowserBeforeShowDialog OnBrowserBeforeShowDialog;
        public BrowserAfterBeforeShowDialog OnBrowserAfterShowDialog;
        public event Action OnForceResize;

        public Favorites Favorites { get; set; }

        public bool IsShowFavorites { get; set; }

        

        public bool IsOpenKillBoardInNewTab { get; set; }

        private LinkMonitoring linkMonitoring { get; }

        private bool isDeleteTabPageAction;

        public IGBrowser()
        {
            InitializeComponent();

            favoritesPanel.Visible = false;

            IsShowFavorites = false;

            Favorites = new Favorites();

            linkMonitoring = new LinkMonitoring();
            linkMonitoring.GetUrlFromFile += Event_GetUrl;
        }

        public void Initialization()
        {
            Global.Configuration = new Config();
        }

        private void Event_GetUrl(string url)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Event_GetUrl(url)));
                return;
            }

            try
            {
                if (TryOpenUrlInExistTab(url)) return;

                adrBarTextBox.Text = url;
                OpenNewTab(url);

                OnForceResize?.Invoke();
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("[IGBrowser.Event_GetUrl] Critical error on open new tab from file with url {0} Exception is {1}", url, ex.Message);
            }
        }


        

        private bool TryOpenUrlInExistTab(string url)
        {
            for(var i = 0; i < browserTabControl.TabPages.Count; i++)
            {
                if (browserTabControl.TabPages[i] == null) continue;

                if (browserTabControl.TabPages[i].Tag == null) continue;

                var tab = browserTabControl.TabPages[i].Tag as InternalWebBrowser;

                try
                {
                    if (tab.Url != url) continue;

                    var index = tab.Id;

                    adrBarTextBox.Text = url;

                    browserTabControl.SelectedTab = browserTabControl.TabPages[index];

                    OnForceResize?.Invoke();

                    return true;
                }
                catch (Exception ex)
                {
                    _logger.ErrorFormat("[IGBrowser.TryOpenUrlInExistTab] Critical error on read tab data. Exception is {0}", ex);
                }

                if (tab == null) continue;

                
            }

            return false;
        }

        public void OpenNewTab(string url = "about:blank")
        {
            _logger.DebugFormat("[IGBrowser.OpenNewTab] Browser open new tab with url {0}", url);

            if (TryOpenUrlInExistTab(url)) return;

            browserTabControl.SuspendLayout();

            var tabPage = new TabPage(url)
            {
                Dock = DockStyle.Fill
            };

            adrBarTextBox.Text = url;

            var internalWebBrowser = new InternalWebBrowser(url) { TabPage = tabPage };

            tabPage.Controls.Add(internalWebBrowser.Control.Instance);

            browserTabControl.TabPages.Add(tabPage);

            browserTabControl.SelectTab(tabPage);

            browserTabControl.ResumeLayout(true);

            internalWebBrowser.Id = browserTabControl.SelectedIndex;

            internalWebBrowser.OnTitleChanged += OnTitleChanged;
            internalWebBrowser.OnDocumentComplete += OnDocumentComplete;

            tabPage.Tag = internalWebBrowser;
        }

        private void OnDocumentComplete(TabPage webBrowserTabPage, int id, string address)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnDocumentComplete(webBrowserTabPage, id, address)));
                return;
            }

            if(id == browserTabControl.SelectedIndex)
            {
                UpdateNavigationButtons();

                adrBarTextBox.Text = address;
            }

        }

        private void UpdateNavigationButtons()
        {
            if (!(browserTabControl.TabPages[browserTabControl.SelectedIndex].Tag is InternalWebBrowser internalWebBrowser)) return;

            adrBarTextBox.Text = internalWebBrowser.Url ?? "about:blank";

            cmdMoveBrowserBack.Enabled = internalWebBrowser.IsCanMovePrevious;

            cmdMoveBrowserForward.Enabled = internalWebBrowser.IsCanMoveNext;
        }

        private void OnTitleChanged(TabPage tabPage, string title)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnTitleChanged(tabPage, title)));
                return;
            }

            try
            {
                tabPage.Text = title;

            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("[IGBrowser.OnTitleChanged] Critical error. Exception {0}", ex);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            favoritesPanel.Visible = !favoritesPanel.Visible;

            IsShowFavorites = !IsShowFavorites;
        }

        private void browserTabControl_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (browserTabControl.SelectedIndex == 0 && isDeleteTabPageAction == false)
            {
                adrBarTextBox.Text = "about:blank";
                OpenNewTab();
            }

            isDeleteTabPageAction = false;

            UpdateNavigationButtons();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Navigate(adrBarTextBox.Text);
        }

        private void adrBarTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate(adrBarTextBox.Text);
            }
        }

        private void Navigate(string url)
        {
            var index = browserTabControl.SelectedIndex;

            if (browserTabControl.TabPages[index].Tag is InternalWebBrowser internalWebBrowser) internalWebBrowser.Navigate(url);
        }

        private void adrBarTextBox_Click(object sender, EventArgs e)
        {
            adrBarTextBox.SelectAll();
        }

        private void adrBarTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Navigate(adrBarTextBox.SelectedItem.ToString());
        }

        private void cmdMoveBrowserBack_Click(object sender, EventArgs e)
        {
            var index = browserTabControl.SelectedIndex;

            if(!(browserTabControl.TabPages[index].Tag is InternalWebBrowser internalWebBrowser)) return;

            if (internalWebBrowser.IsCanMovePrevious)
            {
                internalWebBrowser.NavigatePrevious();
                adrBarTextBox.Text = internalWebBrowser.Url;
                UpdateNavigationButtons();
            }
        }

        private void cmdMoveBrowserForward_Click(object sender, EventArgs e)
        {
            var index = browserTabControl.SelectedIndex;

            if(!(browserTabControl.TabPages[index].Tag is InternalWebBrowser internalWebBrowser)) return;

            if (internalWebBrowser.IsCanMoveNext)
            {
                internalWebBrowser.NavigateNext();
                adrBarTextBox.Text = internalWebBrowser.Url;
                UpdateNavigationButtons();
            }
        }

        private void IGBrowser_Load(object sender, EventArgs e)
        {
            Favorites.Show(favTreeView,imgList, linkContextMenu, favContextMenu);
        }

        private void CmdAddToFavorits_Click(object sender, EventArgs e)
        {
            var index = browserTabControl.SelectedIndex;

            if (!(browserTabControl.TabPages[index].Tag is InternalWebBrowser internalWebBrowser)) return;

            if(internalWebBrowser.Url == "") return;

            OnBrowserBeforeShowDialog?.Invoke();

            var dlg = new AddFavorites(internalWebBrowser.Url);
            var res = dlg.ShowDialog();

            if (res == DialogResult.OK)
            {
                Favorites.AddFavorit(internalWebBrowser.Url, dlg.favName, favTreeView, imgList, favContextMenu);
            }
            dlg.Close();

            OnBrowserAfterShowDialog?.Invoke();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            favoritesPanel.Visible = !favoritesPanel.Visible;

            IsShowFavorites = !IsShowFavorites;
        }

        private void favTreeView_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private string adress = "";
        private string name = "";

        private void favTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                favTreeView.SelectedNode = e.Node;
                adress = e.Node.ToolTipText;
                name = e.Node.Text;
            }
            else
            {
                adrBarTextBox.Text = e.Node.ToolTipText;
                Navigate(e.Node.ToolTipText);
            }
        }

        private void openToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Navigate(adress);
        }

        private void openInNewTabToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenNewTab(adress);
        }

        private void renameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OnBrowserBeforeShowDialog?.Invoke();

            Favorites.RenameFavorit(adress, name, favTreeView);

            OnBrowserAfterShowDialog?.Invoke();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OnBrowserBeforeShowDialog?.Invoke();

            Favorites.DeleteFavorit(adress, name, favTreeView);

            OnBrowserAfterShowDialog?.Invoke();
        }

        private void closeTabToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteTabPage();
        }

        private void DeleteTabPage()
        {
            var index = (int)closeTabContext.Tag;

            if(index == -1 || index == 0) return;
            

            if (!(browserTabControl.TabPages[index].Tag is InternalWebBrowser internalWebBrowser)) return;

            internalWebBrowser.Dispose();

            var selectedIndexBeforeRemove = browserTabControl.SelectedIndex;

            if (selectedIndexBeforeRemove == index && browserTabControl.TabPages.Count == 2)
            {
                browserTabControl.TabPages.RemoveAt(index);
                return;
            }

            if (selectedIndexBeforeRemove == index && browserTabControl.TabPages.Count > index + 1)
            {
                browserTabControl.SelectedTab = browserTabControl.TabPages[index];
            }

            if (selectedIndexBeforeRemove == index && browserTabControl.TabPages.Count == index + 1)
            {
                browserTabControl.SelectedTab = browserTabControl.TabPages[index - 1];
            }

            browserTabControl.TabPages.RemoveAt(index);
        }

        private void browserTabControl_MouseClick(object sender, MouseEventArgs e)
        {
            var index = 0;

            if (e.Button == MouseButtons.Right)
            {
                closeTabContext.Tag = -1;

                var relativeClickedPosition = e.Location;
                var screenClickedPosition = (sender as Control).PointToScreen(relativeClickedPosition);

                // Start from 1 because first tab (index = 0) is "new"
                for (int i = 1; i < browserTabControl.TabCount; ++i)
                {
                    if (browserTabControl.GetTabRect(i).Contains(relativeClickedPosition))
                    {
                        closeTabContext.Tag = i;
                        closeTabContext.Show(screenClickedPosition);
                    }
                }

                
            }

            if (e.Button == MouseButtons.Middle)
            {
                for (var i = 0; i < browserTabControl.TabCount; i++)
                {
                    if (!browserTabControl.GetTabRect(i).Contains(e.Location)) continue;

                    index = i;

                    break;
                }

                if (index == 0) return;

                if (!(browserTabControl.TabPages[index].Tag is InternalWebBrowser internalWebBrowser)) return;

                internalWebBrowser.Dispose();

                var selectedIndexBeforeRemove = browserTabControl.SelectedIndex;

                if (selectedIndexBeforeRemove == index && browserTabControl.TabPages.Count == 2)
                {
                    browserTabControl.TabPages.RemoveAt(index);
                    return;
                }

                if (selectedIndexBeforeRemove == index && browserTabControl.TabPages.Count > index + 1)
                {
                    browserTabControl.SelectedTab = browserTabControl.TabPages[index];
                }

                if (selectedIndexBeforeRemove == index && browserTabControl.TabPages.Count == index + 1)
                {
                    browserTabControl.SelectedTab = browserTabControl.TabPages[index - 1];
                }

                browserTabControl.TabPages.RemoveAt(index);
            }
        }

        private void cmdMaximazeMinimaze_Click(object sender, EventArgs e)
        {
            if(adrBar.Visible)
            {
                favoritesPanel.Visible = false;
                linkBar.Visible = false;
                adrBar.Visible = false;
                browserTabControl.Appearance = TabAppearance.FlatButtons;
                browserTabControl.ItemSize = new Size(0, 1);
                browserTabControl.SizeMode = TabSizeMode.Fixed;
            }
            else
            {
                favoritesPanel.Visible = true;
                linkBar.Visible = true;
                adrBar.Visible = true;
                browserTabControl.Appearance = TabAppearance.Normal;
                browserTabControl.ItemSize = new Size(42, 18);
                browserTabControl.SizeMode = TabSizeMode.Normal;
            }
            
        }
    }
}
