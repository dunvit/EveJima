using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Net;
using System.Globalization;
using CefSharp;
using CefSharp.WinForms;
using log4net;

namespace WBrowser
{
    
    public delegate void BrowserChangeShowFavorites(bool isShowFavorites);

    public delegate void BrowserBeforeShowDialog();

    public delegate void BrowserAfterBeforeShowDialog();

    

    public partial class WBrowser : Form
    {
        private static readonly ILog Log = LogManager.GetLogger("All");

        public BrowserChangeShowFavorites OnChangeShowFavorites;
        public BrowserBeforeShowDialog OnBrowserBeforeShowDialog;
        public BrowserAfterBeforeShowDialog OnBrowserAfterShowDialog;

        public static String favXml = @"Browser\favorits.xml", linksXml = @"Browser\links.xml";
        String settingsXml=@"Browser\settings.xml", historyXml=@"Browser\history.xml";
        List<String> urls = new List<String>();
        String homePage;
        XmlDocument settings = new XmlDocument();
        CultureInfo currentCulture;


        public WBrowser()
        {
            InitializeComponent();
            currentCulture = CultureInfo.CurrentCulture;
        }

        public void Navigate(string address)
        {
            if (address == getCurrentBrowser().Address) return;

            try
            {
                adrBarTextBox.Text = address;
                getCurrentBrowser().Load(address);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[WBrowser.Navigate] Critical error. Exception {0}", ex);
            }
            
        }

        public void OpenNewTab(string address)
        {
            try
            {
                addNewTab(address);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[WBrowser.OpenNewTab] Critical error. Exception {0}", ex);
            }
            
        }


        public void FixSize(bool ismax){}


        #region Form load/Closing/Closed
       

        private void setVisibility()
        {
            if (!File.Exists(settingsXml))
            {
                XmlElement r = settings.CreateElement("settings");
                settings.AppendChild(r);
                XmlElement el ;
                
                el=settings.CreateElement("menuBar");
                el.SetAttribute("visible","True");
                r.AppendChild(el);

                el = settings.CreateElement("adrBar");
                el.SetAttribute("visible","True");
                r.AppendChild(el);

                el = settings.CreateElement("linkBar");
                el.SetAttribute("visible","True");
                r.AppendChild(el);

                el = settings.CreateElement("favoritesPanel");
                el.SetAttribute("visible","True");
                r.AppendChild(el);

                el = settings.CreateElement("SplashScreen");
                el.SetAttribute("checked", "True");
                r.AppendChild(el);

                 el = settings.CreateElement("homepage");
                el.InnerText="about:blank";
                r.AppendChild(el);

                el = settings.CreateElement("dropdown");
                el.InnerText = "15";
                r.AppendChild(el);
            }
            else
            {
                settings.Load(settingsXml);
                XmlElement r = settings.DocumentElement;
               
                adrBar.Visible = (r.ChildNodes[1].Attributes[0].Value.Equals("True"));
                linkBar.Visible=(r.ChildNodes[2].Attributes[0].Value.Equals("True"));
                favoritesPanel.Visible = (r.ChildNodes[3].Attributes[0].Value.Equals("True"));
                
                homePage=r.ChildNodes[5].InnerText;
            }

            linksBarToolStripMenuItem.Checked = linkBar.Visible;
            
            commandBarToolStripMenuItem.Checked = adrBar.Visible;
            homePage = settings.DocumentElement.ChildNodes[5].InnerText;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                setVisibility();
                addNewTab();

                if (linkBar.Visible == true) showLinks();
                else while (linkBar.Items.Count > 3) linkBar.Items[linkBar.Items.Count - 1].Dispose();

                showFavorites();

                browserTabControl.MouseClick += Event_TabMouseClick;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[WBrowser.Form1_Load] Critical error. Exception {0}", ex);
            }
            
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeBrowser();
        }

        public void DisposeBrowser()
        {
            try
            {
                var pages = browserTabControl.TabPages;

                foreach (TabPage page in pages)
                {
                    if (page.Controls.Count > 0)
                    {
                        var control = page.Controls[0] as ChromiumWebBrowser;

                        if (control != null)
                        {
                            //Log.DebugFormat("[whlBrowser.AddTab] Dispose browser address {0}", control.Address);
                            control.Dispose();
                        }
                    }
                }

                Cef.Shutdown();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[WBrowser.DisposeBrowser] Critical error. Exception {0}", ex);
            }


        }
        //form closed
        private void WBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (File.Exists(settingsXml))
                {
                    settings.Save(settingsXml);
                    File.Delete("source.txt");
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[WBrowser.WBrowser_FormClosed] Critical error. Exception {0}", ex);
            }
            
            
        }

         #endregion

        #region FAVORITES,LINKS,HISTORY METHODS 

        //addFavorit method
        private void addFavorit(String url, string name)
        {
            XmlDocument myXml = new XmlDocument();
            XmlElement el = myXml.CreateElement("favorit");
            el.SetAttribute("url", url);
            el.InnerText = name;
            if (!File.Exists(favXml))
            {
                XmlElement root = myXml.CreateElement("favorites");
                myXml.AppendChild(root);
                root.AppendChild(el);
            }
            else
            {
                myXml.Load(favXml);
                myXml.DocumentElement.AppendChild(el);
            }
            if (favoritesPanel.Visible == true)
            {
                TreeNode node = new TreeNode(el.InnerText, faviconIndex(el.GetAttribute("url")), faviconIndex(el.GetAttribute("url")));
                node.ToolTipText = el.GetAttribute("url");
                node.Name = el.GetAttribute("url");
                node.ContextMenuStrip = favContextMenu;
                favTreeView.Nodes.Add(node);
            }
            myXml.Save(favXml);
        }
        //addLink method
        private void addLink(String url, string name)
        {
            XmlDocument myXml = new XmlDocument();
            XmlElement el = myXml.CreateElement("link");
            el.SetAttribute("url", url);
            el.InnerText = name;

            if (!File.Exists(linksXml))
            {
                XmlElement root = myXml.CreateElement("links");
                myXml.AppendChild(root);
                root.AppendChild(el);
            }
            else
            {
                myXml.Load(linksXml);
                myXml.DocumentElement.AppendChild(el);
            }
            if (linkBar.Visible == true)
            {
                ToolStripButton b =
                          new ToolStripButton(el.InnerText, getFavicon(url), items_Click, el.GetAttribute("url"));
                b.ToolTipText = el.GetAttribute("url");
                b.MouseUp += new MouseEventHandler(b_MouseUp);
                linkBar.Items.Add(b);
            }

            if (favoritesPanel.Visible == true)
            {
                TreeNode node = new TreeNode(el.InnerText, faviconIndex(url), faviconIndex(el.GetAttribute("url")));
                node.Name = el.GetAttribute("url");
                node.ToolTipText = el.GetAttribute("url");
                node.ContextMenuStrip = linkContextMenu;
                favTreeView.Nodes[0].Nodes.Add(node);
            }
            myXml.Save(linksXml);
        }
        //delete link method
        private void deleteLink()
        {
             if (favoritesPanel.Visible == true)
                favTreeView.Nodes[0].Nodes[adress].Remove();
             if (linkBar.Visible == true)
                 linkBar.Items.RemoveByKey(adress);
            XmlDocument myXml = new XmlDocument();
            myXml.Load(linksXml);
            XmlElement root = myXml.DocumentElement;
            foreach (XmlElement x in root.ChildNodes)
            {
                if (x.GetAttribute("url").Equals(adress))
                {
                    root.RemoveChild(x);
                    break;
                }
            }

            myXml.Save(linksXml);
        }
        //renameLink method
        private void renameLink()
        {
            OnBrowserBeforeShowDialog();

            RenameLink rl = new RenameLink(name);
            if (rl.ShowDialog() == DialogResult.OK)
            {
                XmlDocument myXml = new XmlDocument();
                myXml.Load(linksXml);
                foreach (XmlElement x in myXml.DocumentElement.ChildNodes)
                {
                    if (x.InnerText.Equals(name))
                    {
                        x.InnerText = rl.newName.Text;
                        break;
                    }
                }
                if(linkBar.Visible==true)
                  linkBar.Items[adress].Text = rl.newName.Text;
                if(favoritesPanel.Visible==true)
                favTreeView.Nodes[0].Nodes[adress].Text = rl.newName.Text;
                myXml.Save(linksXml);
            }
            rl.Close();

            OnBrowserAfterShowDialog();
        }
        //delete favorit method
        private void deleteFavorit()
        {
            favTreeView.SelectedNode.Remove();

            XmlDocument myXml = new XmlDocument();
            myXml.Load(favXml);
            XmlElement root = myXml.DocumentElement;
            foreach (XmlElement x in root.ChildNodes)
            {
                if (x.GetAttribute("url").Equals(adress))
                {
                    root.RemoveChild(x);
                    break;
                }
            }

            myXml.Save(favXml);

        }
        //renameFavorit method
        private void renameFavorit()
        {
            OnBrowserBeforeShowDialog();

            RenameLink rl = new RenameLink(name);
            if (rl.ShowDialog() == DialogResult.OK)
            {
                XmlDocument myXml = new XmlDocument();
                myXml.Load(favXml);
                foreach (XmlElement x in myXml.DocumentElement.ChildNodes)
                {
                    if (x.InnerText.Equals(name))
                    {
                        x.InnerText = rl.newName.Text;
                        break;
                    }
                }
                favTreeView.Nodes[adress].Text = rl.newName.Text;
                myXml.Save(favXml);
            }
            rl.Close();

            OnBrowserAfterShowDialog();
        }

        //addHistory method
        private void addHistory(Uri url,string data)
        {
            XmlDocument myXml = new XmlDocument();
            int i=1;
            XmlElement el = myXml.CreateElement("item");
            el.SetAttribute("url", url.ToString());
            el.SetAttribute("lastVisited", data);

            if (!File.Exists(historyXml))
            {
                XmlElement root = myXml.CreateElement("history");
                myXml.AppendChild(root);
                el.SetAttribute("times", "1");
                root.AppendChild(el);
            }
            else
            {
                myXml.Load(historyXml);

                foreach (XmlElement x in myXml.DocumentElement.ChildNodes)
                {
                    if (x.GetAttribute("url").Equals(url.ToString()))
                    {
                        i = int.Parse(x.GetAttribute("times")) + 1;
                        myXml.DocumentElement.RemoveChild(x);
                        break;
                    }
                }

                el.SetAttribute("times", i.ToString());
                myXml.DocumentElement.InsertBefore(el, myXml.DocumentElement.FirstChild);
            } 
            myXml.Save(historyXml);
        }
//delete history
        private void deleteHistory()
        {
            XmlDocument myXml = new XmlDocument();
            myXml.Load(historyXml);
            XmlElement root = myXml.DocumentElement;
            foreach (XmlElement x in root.ChildNodes)
            {
                if (x.GetAttribute("url").Equals(adress))
                {
                    root.RemoveChild(x);
                    break;
                }
            }
            
            myXml.Save(historyXml);
        }

        #endregion

        #region TABURI
 
        private void addNewTab(string url = "about:blank")
        {
            if(InvokeRequired)
            {
                Invoke(new Action(() => addNewTab(url)));
                return;
            }



            browserTabControl.SuspendLayout();

            var browser = new ChromiumWebBrowser(url) { Dock = DockStyle.Fill };

            var tabPage = new TabPage(url)
            {
                Dock = DockStyle.Fill
            };

            browser.BackColor = Color.Silver;

            browser.CreateControl();

            browser.Tag = tabPage;

            

            tabPage.Controls.Add(browser);

            browserTabControl.TabPages.Insert(browserTabControl.TabCount - 1, tabPage);

            browserTabControl.SelectTab(tabPage);

            browserTabControl.ResumeLayout(true);
            
            browser.LoadingStateChanged += OnBrowserLoadingStateChanged;
            browser.TitleChanged += OnBrowserTitleChanged;
            
        }

        public bool OnBeforePopup(IWebBrowser browser, string url, ref int x, ref int y, ref int width, ref int height)
        {
            Invoke((Action)(() =>
            {
                var tabPage = new TabPage(url)
                {
                    Dock = DockStyle.Fill
                };
                browserTabControl.Controls.Add(tabPage);
                browserTabControl.SelectedTab = tabPage;
            }));

            return true;
        }

        private void Event_TabMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                var tc = sender as TabControl;

                if (e.Y <= tc.ItemSize.Height)
                {
                    var tabIndex = e.X / tc.ItemSize.Width;
                    if (tabIndex < tc.TabPages.Count )
                    {
                        CloseTab(tabIndex);
                    }
                }
            }
        }

        private void CloseTab(int index)
        {
            if(browserTabControl.TabPages[index].Controls.Count > 0)
            {
                var control = browserTabControl.TabPages[index].Controls[0] as ChromiumWebBrowser;

                if(control != null)
                {
                    try
                    {
                        //control.Dispose();
                    }
                    catch(Exception ex)
                    {
                        var a = ex;
                    }
                }
            }

            //browserTabControl.TabPages.RemoveAt(index);
            browserTabControl.TabPages[index].Dispose();
        }

        private void browserTabControl_TabIndexChanged(object sender, EventArgs e)
        {
            var a = browserTabControl.SelectedTab;
        }


        private void DocumentComplete(ChromiumWebBrowser currentBrowser, TabPage tab)
        {
            var text = "Blank Page";
            var host = "";
            var myUri = new Uri("about:blank");

            if (!currentBrowser.Address.Equals("about:blank"))
            {
                myUri = new Uri(currentBrowser.Address);
                text = myUri.Host;
                host = myUri.Host;
            }

            if (getCurrentBrowser().CanGoBack) toolStripButton1.Enabled = true;
            else toolStripButton1.Enabled = false;

            if (getCurrentBrowser().CanGoForward) toolStripButton2.Enabled = true;
            else toolStripButton2.Enabled = false;

            if (tab == browserTabControl.SelectedTab)
            {
                adrBarTextBox.Text = currentBrowser.Address;
            }

            browserTabControl.SelectedTab.Text = text;

            img.Image = favicon(currentBrowser.Address, "net.png");

            if (!urls.Contains(host))
                urls.Add(host);

            if (!currentBrowser.Address.Equals("about:blank"))
            {
                addHistory(myUri, DateTime.Now.ToString(currentCulture));

            }
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnBrowserTitleChanged(sender, args)));
                return;
            }

            try
            {
                var tab = (TabPage)((ChromiumWebBrowser)sender).Tag;

                var title = args.Title.Substring(0, 20);

                tab.Text = title;
            }
            catch (Exception ex)
            {
                //Log.ErrorFormat("[whlBrowser.InvokeOnUiThreadIfRequired] Critical error. Exception {0}", ex);
            }
        }

        private void OnBrowserLoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => OnBrowserLoadingStateChanged(sender, e)));
                    return;
                }

                DocumentComplete(((ChromiumWebBrowser)sender), (TabPage)((ChromiumWebBrowser)sender).Tag);
            }
        }
        
        private void closeTab()
        {
            if (browserTabControl.TabCount != 2)
            {
                //var page = browserTabControl.TabPages[browserTabControl.SelectedIndex];

                //if (page.Controls.Count > 0)
                //{
                //    var control = page.Controls[0] as ChromiumWebBrowser;

                //    if (control != null)
                //    {
                //        //Log.DebugFormat("[whlBrowser.AddTab] Dispose browser address {0}", control.Address);
                //        control.Dispose();
                //    }
                //}

                CloseTab(browserTabControl.SelectedIndex);
            }

        }
        
        private void browserTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (browserTabControl.SelectedIndex == browserTabControl.TabPages.Count - 1) addNewTab();
            else
            {
                if (getCurrentBrowser().Address != null)
                    adrBarTextBox.Text = getCurrentBrowser().Address;
                else adrBarTextBox.Text = "about:blank";

                if (getCurrentBrowser().CanGoBack) toolStripButton1.Enabled = true;
                else toolStripButton1.Enabled = false;

                if (getCurrentBrowser().CanGoForward) toolStripButton2.Enabled = true;
                else toolStripButton2.Enabled = false;
            }
        }


        private void closeTabToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            closeTab();
        }
        private void duplicateTabToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (getCurrentBrowser().Address != null)
            {
                Uri dup_url = new Uri(getCurrentBrowser().Address);
                addNewTab(dup_url.AbsoluteUri);
            }
            else addNewTab();
        }
        #endregion

        #region FAVICON
       
        // favicon
        public static Image favicon(String u, string file)
        {
                Uri url = new Uri(u);
                String iconurl = "http://" + url.Host + "/favicon.ico";
                
                try
                {
                    WebRequest request = WebRequest.Create(iconurl);

                    WebResponse response = request.GetResponse();

                    Stream s = response.GetResponseStream();
                    return Image.FromStream(s);
                }
                catch (Exception ex)
                {
                    return null;
                }
            
           
        }
        //favicon index
        private int faviconIndex(string url)
        {
            Uri key = new Uri(url);
            if (!imgList.Images.ContainsKey(key.Host.ToString()))
                imgList.Images.Add(key.Host.ToString(), favicon(url, "link.png"));
            return imgList.Images.IndexOfKey(key.Host.ToString());
        }
        //getFavicon from key
        private Image getFavicon(string key)
        {
            Uri url = new Uri(key);
            if (!imgList.Images.ContainsKey(url.Host.ToString()))
                imgList.Images.Add(url.Host.ToString(), favicon(key
                    , "link.png"));
            return imgList.Images[url.Host.ToString()];
        }
        #endregion

        #region     TOOL CONTEXT MENU
        /* TOOL CONTEXT MENU*/

        //link bar
        private void linksBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linkBar.Visible = !linkBar.Visible;
            linksBarToolStripMenuItem.Checked = linkBar.Visible;
            settings.DocumentElement.ChildNodes[2].Attributes[0].Value = linkBar.Visible.ToString();
        }
        //menu bar

        //address bar
        private void commandBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adrBar.Visible = !adrBar.Visible;
            commandBarToolStripMenuItem.Checked = adrBar.Visible;
            settings.DocumentElement.ChildNodes[1].Attributes[0].Value = adrBar.Visible.ToString();
        }
        #endregion

        #region ADDRESS BAR
        /*ADDRESS BAR*/

        private ChromiumWebBrowser getCurrentBrowser()
        {
            return (ChromiumWebBrowser)browserTabControl.SelectedTab.Controls[0];
        }
        //ENTER
        private void adrBarTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate(adrBarTextBox.Text);
            }
        }
        //select all from adr bar
        private void adrBarTextBox_Click(object sender, EventArgs e)
        {
            adrBarTextBox.SelectAll();
        }


        private void showUrl()
        {
            if (File.Exists(historyXml))
            {
                XmlDocument myXml = new XmlDocument();
                myXml.Load(historyXml);
                int i = 0;
                int num=int.Parse(settings.DocumentElement.ChildNodes[6].InnerText.ToString());
                foreach (XmlElement el in myXml.DocumentElement.ChildNodes)
                {
                    if (num <= i++ ) break;
                    else  adrBarTextBox.Items.Add(el.GetAttribute("url").ToString());
                           
                }
            }
        }

        private void adrBarTextBox_DropDown(object sender, EventArgs e)
        {
            adrBarTextBox.Items.Clear();
            showUrl();
        }
        
        private void adrBarTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Navigate(adrBarTextBox.SelectedItem.ToString());
        }

         
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (getCurrentBrowser().CanGoBack)
            {
                getCurrentBrowser().Back();
                adrBarTextBox.Text = getCurrentBrowser().Address;
            }
                
        }
        
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (getCurrentBrowser().CanGoForward)
            {
                getCurrentBrowser().Forward();
                adrBarTextBox.Text = getCurrentBrowser().Address;
            }
            
        }
        //go
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Navigate(adrBarTextBox.Text);

        }
        //refresh
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().Refresh();
        }
        //stop

        public bool IsMaximazed = false;

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().Stop();
        }
        //favorits
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            favoritesPanel.Visible = !favoritesPanel.Visible;
            settings.DocumentElement.ChildNodes[3].Attributes[0].Value = favoritesPanel.Visible.ToString();
        }
        //add to favorits
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (getCurrentBrowser().Address != "")
            {
                OnBrowserBeforeShowDialog();

                AddFavorites dlg = new AddFavorites(getCurrentBrowser().Address);
                DialogResult res = dlg.ShowDialog();

                if (res == DialogResult.OK)
                {
                    if (dlg.favFile == "Favorites")
                        addFavorit(getCurrentBrowser().Address, dlg.favName);
                    else addLink(getCurrentBrowser().Address, dlg.favName);
                }
                dlg.Close();

                OnBrowserAfterShowDialog();
            }

        }
        //search
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            
            if (googleSearch.Checked)
                Navigate("http://google.com/search?q=" + searchTextBox.Text);
            else
                Navigate("http://search.live.com/results.aspx?q="+searchTextBox.Text);
        }

        private void googleSearch_Click(object sender, EventArgs e)
        {
            liveSearch.Checked =!googleSearch.Checked;
        }

        private void liveSearch_Click(object sender, EventArgs e)
        {
            googleSearch.Checked = !liveSearch.Checked;
        }

        #endregion

        #region LINKS BAR

        /*LINKS BAR*/

        string adress, name;

        public bool IsShowFavorites = true;

        //favorits button
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            favoritesPanel.Visible = !favoritesPanel.Visible;

            IsShowFavorites = !IsShowFavorites;

            settings.DocumentElement.ChildNodes[3].Attributes[0].Value = favoritesPanel.Visible.ToString();

            if (OnChangeShowFavorites != null)
            {
                OnChangeShowFavorites(favoritesPanel.Visible);
            }
        }

        public void HideFavorites()
        {
            favoritesPanel.Visible = false;
        }


        //add to favorits bar button
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (getCurrentBrowser().Address != "")
                addLink(getCurrentBrowser().Address, getCurrentBrowser().Address);
        }

        //showLinks on link bar
        private void showLinks()
        {
            if (File.Exists(linksXml))
            {
                XmlDocument myXml = new XmlDocument();
                myXml.Load(linksXml);
                XmlElement root = myXml.DocumentElement;
                foreach (XmlElement el in root.ChildNodes)
                {
                    ToolStripButton b =
                        new ToolStripButton(el.InnerText, getFavicon(el.GetAttribute("url")), items_Click, el.GetAttribute("url"));

                    b.ToolTipText = el.GetAttribute("url");
                    b.MouseUp += new MouseEventHandler(b_MouseUp);
                    linkBar.Items.Add(b);
                }
            }
        }
        //click link button
        private void items_Click(object sender, EventArgs e)
        {
            ToolStripButton b = (ToolStripButton)sender;
            Navigate(b.ToolTipText);
        }
        //show context menu on button
        private void b_MouseUp(object sender, MouseEventArgs e)
        {
            ToolStripButton b = (ToolStripButton)sender;
            adress = b.ToolTipText;
            name = b.Text;

            if (e.Button == MouseButtons.Right)
                linkContextMenu.Show(MousePosition);
        }
//visible change
        private void linkBar_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region LINK, FAVORITES, HISTORY CONTEXT MENU
        /*GENERAL*/

        //open
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Navigate(adress);
        }
        //open in new tab
        private void openInNewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewTab();
            Navigate(adress);
        }
        //open in new window
        private void openInNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WBrowser new_form = new WBrowser();
            new_form.Show();
            new_form.Navigate(adress);
        }
                     /*LINK CONTEXT MENU*/
        //delete link
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteLink();
        }
        //rename link
        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renameLink();
        }
                          /*FAVORITES CONTEXT MENU*/
        //delete favorit
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deleteFavorit();
        }
        //rename favorit
        private void renameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            renameFavorit();
        }
           
              /*HISTORY CONTEXT MENU */



//delete history
        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            deleteHistory();
        }

        private void closeTabContext_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        //add to favorites


        #endregion

        #region FAVORITES WINDOW

        private void showFavorites()
        {
            XmlDocument myXml = new XmlDocument();
            TreeNode link = new TreeNode("Links",0,0);
            link.NodeFont =new  Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            favTreeView.Nodes.Add(link);

            if (File.Exists(favXml))
            {
                myXml.Load(favXml);

                foreach (XmlElement el in myXml.DocumentElement.ChildNodes)
                {
                    TreeNode node = 
                        new TreeNode(el.InnerText,faviconIndex(el.GetAttribute("url")), faviconIndex(el.GetAttribute("url")));
                    node.ToolTipText = el.GetAttribute("url");
                    node.Name = el.GetAttribute("url");
                    node.ContextMenuStrip = favContextMenu;
                    favTreeView.Nodes.Add(node);
                }

            }

            if (File.Exists(linksXml))
            {
                myXml.Load(linksXml);

                foreach (XmlElement el in myXml.DocumentElement.ChildNodes)
                {
                    TreeNode node = 
                        new TreeNode(el.InnerText, faviconIndex(el.GetAttribute("url")), faviconIndex(el.GetAttribute("url")));
                    node.ToolTipText = el.GetAttribute("url");
                    node.Name = el.GetAttribute("url");
                    node.ContextMenuStrip = linkContextMenu;
                    favTreeView.Nodes[0].Nodes.Add(node);
                }

            }

        }
//node click
        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                favTreeView.SelectedNode = e.Node;
                adress = e.Node.ToolTipText;
                name = e.Node.Text;
            }
            else
                    Navigate(e.Node.ToolTipText);

        }

        private void favoritesPanel_VisibleChanged(object sender, EventArgs e)
        {
            //if (favoritesPanel.Visible == true)
            //{
            //    showFavorites();
            //}
            //else
            //{
            //    favTreeView.Nodes.Clear();
            //}
        }


        #endregion

        


    }
}
