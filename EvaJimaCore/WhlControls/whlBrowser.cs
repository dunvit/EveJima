using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DotNetBrowser;
using DotNetBrowser.Events;
using DotNetBrowser.WinForms;
using log4net;
using EveJimaCore.Browser;
using ContextMenu = System.Windows.Forms.ContextMenu;

namespace EveJimaCore.WhlControls
{
    public partial class whlBrowser : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(whlBrowser));

        public OpenWebBrowser OnOpenWebBrowser;

        #region ToolTips
        private readonly ToolTip _toolTipForBookmarkButton = new ToolTip();
        private readonly ToolTip _toolTipForHistoryBackButton = new ToolTip();
        private readonly ToolTip _toolTipForHistoryNextButton = new ToolTip();
        private readonly ToolTip _toolTipForRefreshButton = new ToolTip();
        private readonly ToolTip _toolTipForFavoritsButton = new ToolTip();
        private readonly ToolTip _toolTipForNavigateToBlankButton = new ToolTip();
        #endregion

        public History History { get; set; }

        public Bookmarks Bookmarks { get; set; }

        public whlBrowser()
        {
            InitializeComponent();

            AddTab("about:blank");

            History = new History();

            Bookmarks = new Bookmarks();

            //OnOpenWebBrowser = openWebBrowserFunction;

            #region ToolTips
            _toolTipForBookmarkButton.SetToolTip(cmdBookmark, "Add to bookmarks");
            _toolTipForHistoryBackButton.SetToolTip(BrowserCommandBack, "Click to go back, hold to see history");
            _toolTipForHistoryNextButton.SetToolTip(BrowserCommandForward, "Click to go forward, hold to see history");
            _toolTipForRefreshButton.SetToolTip(BrowserCommandRefresh, "Reload this page");
            _toolTipForFavoritsButton.SetToolTip(cmdFavorits, "Bookmarks");
            _toolTipForNavigateToBlankButton.SetToolTip(cmdBlank, "Click to go to blank page");
            #endregion

            cmdFavorits.ContextMenu = BuildContextMenuForFavorites();



        }

        public void BrowserUrlExecute(string url)
        {
            try
            {
                if (OnOpenWebBrowser != null)
                {
                    try
                    {
                        OnOpenWebBrowser();
                    }
                    catch (Exception ex)
                    {
                        Log.Error("[Browser.History.History] Critical error in load history. Exception = " + ex);
                    }
                }

                if (!CheckIsNeedUpdateWebBrowser(url)) return;

                if (url.Trim() == "http://") return;

                txtUrl.Text = url;

                txtUrl.Refresh();

                LoadUrl(url);

                txtUrl.Focus();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlBrowser.BrowserUrlExecute] Critical error. Exception {0}", ex);
            }

            
        }

        private void LoadUrl(string url)
        {
            try
            {
                ((WinFormsBrowserView)(tabControl1.SelectedTab.Controls[0])).Browser.LoadURL(url);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlBrowser.LoadUrl] Critical error. Exception {0}", ex);
            }
        }

        private void AddTab(string url, int? insertIndex = null)
        {
            try
            {
                browserTabControl.SuspendLayout();

                var appPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Browser";

                BrowserContextParams params1 = new BrowserContextParams(appPath);
                BrowserContext context = new BrowserContext(params1);

                var browser = BrowserFactory.Create(context); 
                var browserView = new WinFormsBrowserView(browser);
                
                browser.LoadURL("about:blank");

                // Add it to the form and fill it to the form window.
                browserView.Dock = DockStyle.Fill;

                var tabPage = new TabPage(url)
                {
                    Dock = DockStyle.Fill
                };

                browserView.Tag = tabPage;

                browser.TitleChangedEvent += delegate(object sender, TitleEventArgs e)
                {
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() =>
                        {
                            var title = e.Title;
                            
                            if (e.Title.Length > 20)
                            {
                                title = e.Title.Substring(0, 20);
                            }

                            tabPage.Text = title;

                            History.UpdateTitle(title);

                            BuildContextMenuFromHistory();
                        }));
                    }
                };

                tabPage.Controls.Add(browserView);

                if (insertIndex == null)
                {
                    tabControl1.TabPages.Add(tabPage);
                }
                else
                {
                    tabControl1.TabPages.Insert(insertIndex.Value, tabPage);
                }

                //Make newly created tab active
                tabControl1.SelectedTab = tabPage;

                browserTabControl.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlBrowser.AddTab] Critical error. Exception {0}", ex);
            }

            
        }

        public void DisposeBrowser()
        {
            var pages = tabControl1.TabPages;
            
            foreach (TabPage page in pages)
            {
                var control = page.Controls[0] as WinFormsBrowserView;

                if (control != null)
                {
                    Log.DebugFormat("[whlBrowser.AddTab] Dispose CefSharp browser address {0}", control.URL);
                    control.Browser.Dispose();
                    control.Dispose();
                }
            }
        }

        private void BrowserUrlRefresh(string url)
        {
            try
            {
                loadingGif.Visible = true;

                if (((WinFormsBrowserView)(tabControl1.SelectedTab.Controls[0])).URL == null) return;

                LoadUrl(url);

                browserTabControl.Visible = false;
                txtUrl.Text = url;

                txtUrl.Focus();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlBrowser.BrowserUrlRefresh] Critical error. Exception {0}", ex);
            }
  
        }

        public void ResizeWebBrowser(int width, int height)
        {
            Width = width - 24;

            Height = height - 110;
            
            browserTabControl.Width = Width - 24;
            
            browserTabControl.Height = Height - 62;

            txtUrl.Width = Width - 8 - txtUrl.Location.X;

            loadingGif.Location = new Point((Width - 24) / 2 - loadingGif.Width / 2, (Height-62) / 2 - loadingGif.Height / 2);

            tabControl1.Size = new Size(browserTabControl.Width, browserTabControl.Height);
        }

        public void BrowserOpen()
        {
            try
            {
                loadingGif.Visible = false;

                if (((WinFormsBrowserView)(tabControl1.SelectedTab.Controls[0])).URL == null)
                {
                    browserTabControl.Visible = false;
                }
                else
                {
                    browserTabControl.Visible = true;
                }

                BuildContextMenuFromHistory();

                txtUrl.Focus();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlBrowser.BrowserOpen] Critical error. Exception {0}", ex);
            }
            
        }

        public bool CheckIsNeedUpdateWebBrowser(string url)
        {
            try
            {
                if (((WinFormsBrowserView)(tabControl1.SelectedTab.Controls[0])).URL == null) return true;

                if (url != ((WinFormsBrowserView)(tabControl1.SelectedTab.Controls[0])).URL) return true;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlBrowser.CheckIsNeedUpdateWebBrowser] Critical error. Url {1} Exception {0}", ex, url);
            }

            return false;
        }

        private void BrowserCommandExecute_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text.StartsWith("http"))
            {
                BrowserUrlExecute(txtUrl.Text);
            }
            else
            {
                BrowserUrlExecute("http://" + txtUrl.Text);
            }
        }

        private void BrowserCommandRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (((WinFormsBrowserView)(tabControl1.SelectedTab.Controls[0])).URL == null) return;

                if (txtUrl.Text.StartsWith("http"))
                {
                    BrowserUrlRefresh(txtUrl.Text);
                }
                else
                {
                    BrowserUrlRefresh("http://" + txtUrl.Text);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlBrowser.BrowserCommandRefresh_Click] Critical error. Exception {0}", ex);
            }

        }

        private void BrowserCommandForward_Click(object sender, EventArgs e)
        {
            var url = History.Next();

            if (string.IsNullOrEmpty(url)) return;

            BrowserUrlExecute(url);
        }

        private void BrowserCommandBack_Click(object sender, EventArgs e)
        {
            var url = History.Previous();

            if (string.IsNullOrEmpty(url)) return;

            BrowserUrlExecute(url);
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUrl.Text.StartsWith("http"))
                {
                    BrowserUrlExecute(txtUrl.Text);
                }
                else
                {
                    BrowserUrlExecute("http://" + txtUrl.Text);
                }
            }
        }

        private void cmdFavorits_Click(object sender, EventArgs e)
        {
            var cmFavorits = BuildContextMenuForFavorites();

            cmFavorits.Show(cmdFavorits, cmdFavorits.PointToClient(Cursor.Position));
        }

        private void Event_NavigateToBlank(object sender, EventArgs e)
        {
            LoadUrl("about:blank");
        }

        private ContextMenu BuildContextMenuForFavorites()
        {
            var cmFavorits = new ContextMenu();

            try
            {
                foreach (var address in Bookmarks.List.Values.ToList().OrderByDescending(k => k.Id).ToList())
                {
                    var menuItem = new MenuItem(address.Title, (sender, args) => BrowserUrlExecute(address.Url));

                    cmFavorits.MenuItems.Add(menuItem);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlBrowser.BuildContextMenuForFavorites] Critical error. Exception {0}", ex);
            }

            return cmFavorits;
        }

        private void BuildContextMenuFromHistory()
        {
            try
            {
                var cmHistoryBack = new ContextMenu();

                if (History == null) return;

                for (var i = 1; i <= 10; i++)
                {
                    var index = History.CurrentIndex - i;

                    if (History.List.ContainsKey(index))
                    {
                        var address = History.List[index];

                        var menuItem = new MenuItem(address.Title, (sender, args) => BrowserUrlExecute(address.Url));

                        cmHistoryBack.MenuItems.Add(menuItem);
                    }
                }

                BrowserCommandBack.ContextMenu = cmHistoryBack;

                var cmHistoryForvard = new ContextMenu();

                for (var i = 1; i <= 10; i++)
                {
                    var index = History.CurrentIndex + i;

                    if (History.List.ContainsKey(index))
                    {
                        var address = History.List[index];

                        var menuItem = new MenuItem(address.Title, (sender, args) => BrowserUrlExecute(address.Url));

                        cmHistoryForvard.MenuItems.Add(menuItem);
                    }
                }

                BrowserCommandForward.ContextMenu = cmHistoryForvard;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlBrowser.BuildContextMenuFromHistory] Critical error. Exception {0}", ex);
            }
           
        }


        private void IsUrlInBookmarks()
        {
            try
            {
                if (((WinFormsBrowserView)(tabControl1.SelectedTab.Controls[0])).URL == null) return;

                if (Bookmarks.IsExist(((WinFormsBrowserView)(tabControl1.SelectedTab.Controls[0])).URL) == false)
                {
                    cmdBookmark.Image = Properties.Resources.not_bookmark;
                    _toolTipForBookmarkButton.SetToolTip(cmdBookmark, "Add to bookmarks");
                }
                else
                {
                    cmdBookmark.Image = Properties.Resources.bookmark;
                    _toolTipForBookmarkButton.SetToolTip(cmdBookmark, "Remove from bookmarks");
                }

                cmdFavorits.ContextMenu = BuildContextMenuForFavorites();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlBrowser.IsUrlInBookmarks] Critical error. Exception {0}", ex);
            }

            
        }

        private void Event_ClickBookmarkButton(object sender, EventArgs e)
        {
            var address = History.GetCurrentAddress();

            if (address == null) return;

            if (Bookmarks.IsExist(address.Url))
            {
                Bookmarks.Remove(address.Url);
            }
            else
            {
                Bookmarks.Add(address);
            }

            IsUrlInBookmarks();
        }

        private void Event_AddNewTab(object sender, EventArgs e)
        {
            AddTab("about:blank");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtUrl.Text = ((WinFormsBrowserView)(tabControl1.SelectedTab.Controls[0])).URL;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlBrowser.tabControl1_SelectedIndexChanged] Critical error. Exception {0}", ex);
            }
            
        }

        private void Event_CloseTab(object sender, EventArgs e)
        {
            if (tabControl1.Controls.Count == 0)
            {
                return;
            }

            try
            {
                var currentIndex = tabControl1.SelectedIndex;

                var tabPage = tabControl1.Controls[currentIndex];

                tabControl1.Controls.Remove(tabPage);

                tabControl1.SelectedIndex = currentIndex - 1;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlBrowser.Event_CloseTab] Critical error. Exception {0}", ex);
            }

            


        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var tabControl = sender as TabControl;
            var tabs = tabControl.TabPages;

            if (tabControl.Controls.Count == 0)
            {
                return;
            }

            if (e.Button == MouseButtons.Middle)
            {
                tabs.Remove(tabs.Cast<TabPage>()
                        .Where((t, i) => tabControl.GetTabRect(i).Contains(e.Location))
                        .First());
            }
        }
    }
}
