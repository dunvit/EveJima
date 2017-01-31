using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml;
using System.Net;

namespace WBrowser
{
    public partial class Form1 : Form
    {  String favXml="favorits.xml", linksXml="links.xml";
        public Form1()
        {
            InitializeComponent();
        }
        #region Form load/Closing/favicon
 // form load
        private void Form1_Load(object sender, EventArgs e)
        {
            addNewTab();
            this.toolStripStatusLabel1.Text = "Done";
            adrBarTextBox.Focus();
            this.linksBarToolStripMenuItem.Checked = linkBar.Visible;
            this.menuBarToolStripMenuItem.Checked = menuBar.Visible;
            this.commandBarToolStripMenuItem.Checked = adrBar.Visible;
            showLinks();

        }
//form closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (browserTabControl.TabCount != 2)
            {
                DialogResult dlg_res = (new Close()).ShowDialog();

                if (dlg_res == DialogResult.No) { e.Cancel = true; closeTab(); }
                else if (dlg_res == DialogResult.Cancel) e.Cancel = true;
                else Application.ExitThread();
            }
        }
//get favicon
        private Image favicon(String u, string file)
        {
            Uri url = new Uri(u);
            String iconurl = "http://" + url.Host + "/favicon.ico";

            WebRequest request = WebRequest.Create(iconurl);
            try
            {
                WebResponse response = request.GetResponse();

                Stream s = response.GetResponseStream();
                return Image.FromStream(s);
            }
            catch (Exception ex)
            {
                return Image.FromFile(file);
            }
        }
        #endregion

        #region TABURI
        /*TAB-uri*/

//addNewTab method
        private void addNewTab()
        {
            TabPage tpage = new TabPage("Blank Page");
            browserTabControl.TabPages.Insert(browserTabControl.TabCount - 1, tpage);
            WebBrowser browser = new WebBrowser();
           // browser.GoHome();     
            tpage.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            browserTabControl.SelectTab(tpage);
            browser.ProgressChanged += new WebBrowserProgressChangedEventHandler(Form1_ProgressChanged);
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(Form1_DocumentCompleted);
            browser.Navigating +=new WebBrowserNavigatingEventHandler(Form1_Navigating);
            browser.CanGoBackChanged += new EventHandler(browser_CanGoBackChanged);
            browser.CanGoForwardChanged += new EventHandler(browser_CanGoForwardChanged);
        }
//closeTab method
        private void closeTab()
        {
            if (browserTabControl.TabCount != 2)
            {
                browserTabControl.TabPages.RemoveAt(browserTabControl.SelectedIndex);
            }
           
        }
//selected index changed
        private void browserTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (browserTabControl.SelectedIndex == browserTabControl.TabPages.Count - 1) addNewTab();
            else
            {
               if (getCurrentBrowser().CanGoBack) toolStripButton1.Enabled = true;
               else toolStripButton1.Enabled = false;

               if (getCurrentBrowser().CanGoForward) toolStripButton2.Enabled = true;
                else toolStripButton2.Enabled = false;
            }
        }

        /* tab context menu */

        private void closeTabToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            closeTab();
        }
        private void duplicateTabToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (getCurrentBrowser().Url != null)
            {
                Uri dup_url = getCurrentBrowser().Url;
                addNewTab();
                getCurrentBrowser().Url = dup_url;

            }
            else addNewTab();
        }
        #endregion

        #region     TOOL CONTEXT MENU
        /* TOOL CONTEXT MENU*/

//link bar
        private void linksBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linkBar.Visible = !linkBar.Visible;
            this.linksBarToolStripMenuItem.Checked = linkBar.Visible;
        }
//menu bar
        private void menuBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuBar.Visible = !menuBar.Visible;
            this.menuBarToolStripMenuItem.Checked = menuBar.Visible;
        }
//address bar
        private void commandBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adrBar.Visible = !adrBar.Visible;
            this.commandBarToolStripMenuItem.Checked = adrBar.Visible;
        }
        #endregion

        #region ADDRESS BAR 
        /*ADDRESS BAR*/

        private WebBrowser getCurrentBrowser()
        {
            return (WebBrowser)browserTabControl.SelectedTab.Controls[0];
        }
//ENTER
        private void adrBarTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getCurrentBrowser().Navigate(adrBarTextBox.Text);
               
            }   
        }
//select all from adr bar
        private void adrBarTextBox_Click(object sender, EventArgs e)
        {
            adrBarTextBox.SelectAll();
        }
//Navigating
        private void Form1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.toolStripStatusLabel1.Text = "Waiting for: " + e.Url.Host.ToString();
            
        }
 //DocumentCompleted
        private void Form1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser currentBrowser = getCurrentBrowser();
            this.toolStripStatusLabel1.Text = "Done";

            this.adrBarTextBox.Text =currentBrowser.Url.ToString();
            browserTabControl.SelectedTab.Text = currentBrowser.Url.Host.ToString();

            img.Image = favicon(currentBrowser.Url.ToString(),"net.png") ;    
            
        }
//ProgressChanged    
        private void Form1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress < e.MaximumProgress)
                toolStripProgressBar1.Value = (int)e.CurrentProgress;
            else toolStripProgressBar1.Value = toolStripProgressBar1.Minimum;

        }
//canGoForwardChanged
        void browser_CanGoForwardChanged(object sender, EventArgs e)
        {
            toolStripButton2.Enabled = !toolStripButton2.Enabled;
        }
//canGoBackChanged
        void browser_CanGoBackChanged(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = !toolStripButton1.Enabled;
        }
//back  
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().GoBack();
        }
//forward
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().GoForward();
        }
//go
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().Navigate(adrBarTextBox.Text);
           
        }
//refresh
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().Refresh();
        }
 //stop
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().Stop();
        }
//favorits
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            favoritesPanel.Visible = !favoritesPanel.Visible;
        }
//add to favorits
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (getCurrentBrowser().Url != null)
            {
                AddFavorites dlg = new AddFavorites(getCurrentBrowser().Url.ToString());
                DialogResult res = dlg.ShowDialog();

                if (res == DialogResult.OK)
                {
                    if (dlg.favFile == "Favorites")
                        addFavorit(getCurrentBrowser().Url.ToString(), dlg.favName);
                    else addLink(getCurrentBrowser().Url.ToString(), dlg.favName);
                }
                dlg.Close();
            }
           
        }
//search
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) getCurrentBrowser().Navigate("google.com");
        }
        #endregion

        #region LINKS BAR

                 /*LINKS BAR*/

        string adress,name;

//favorits button
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            favoritesPanel.Visible = !favoritesPanel.Visible;
        }
//add to favorits bar button
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (getCurrentBrowser().Url != null)
                addLink(getCurrentBrowser().Url.ToString(), getCurrentBrowser().Url.ToString());
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
                      new ToolStripButton(el.InnerText,favicon(el.GetAttribute("url").ToString(),"link.png"),items_Click,el.InnerText);
 
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
            getCurrentBrowser().Navigate(b.ToolTipText);
        }
//show context menu on button
        private void b_MouseUp(object sender, MouseEventArgs e)
        {
            ToolStripButton b = (ToolStripButton)sender;
            adress = b.ToolTipText;
            name = b.Text;

            if(e.Button==MouseButtons.Right)
                linkContextMenu.Show(MousePosition); 
        }
        
                            /* link context menu*/

//open
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().Navigate(adress);
        }
//open in new tab
        private void openInNewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewTab();
            getCurrentBrowser().Navigate(adress);
        }
//open in new window
        private void openInNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 new_form = new Form1();
            new_form.Show();
            new_form.getCurrentBrowser().Navigate(adress);
        }
//delete link
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
//rename link
        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                linkBar.Items[name].Text = rl.newName.Text;
                myXml.Save("links.xml");
            }
            rl.Close();

        }
        #endregion

        #region FAVORITS
        /*FAVORITES*/

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

            ToolStripButton b =
                      new ToolStripButton(el.InnerText,favicon(el.GetAttribute("url"),"link.png"), items_Click, el.InnerText);
            b.ToolTipText = el.GetAttribute("url");
            b.MouseUp += new MouseEventHandler(b_MouseUp);
            linkBar.Items.Add(b);
           
            myXml.Save(linksXml);
        }

//add to favorits
        private void addToFavoritsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getCurrentBrowser().Url != null)
            {
                AddFavorites dlg = new AddFavorites(getCurrentBrowser().Url.ToString());
                DialogResult res = dlg.ShowDialog();

                if (res == DialogResult.OK)
                {
                    if (dlg.favFile == "Favorites")
                        addFavorit(getCurrentBrowser().Url.ToString(), dlg.favName);
                    else addLink(getCurrentBrowser().Url.ToString(), dlg.favName);
                }
                dlg.Close();
            }
        }
//add to favorits bar
        private void addToFavoritsBarToolStripMenuItem_Click(object sender, EventArgs e)
        {    
            addLink(getCurrentBrowser().Url.ToString(),getCurrentBrowser().Url.ToString());
        }
//organize favorites
        private void organizeFavoritsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new OrganizeFavorites()).ShowDialog();
        }

//show favorites in menu
        private void favoritesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            XmlDocument myXml = new XmlDocument();
            myXml.Load(favXml);

            for (int i = favoritesToolStripMenuItem.DropDownItems.Count - 1; i > 5; i--)
            {
                favoritesToolStripMenuItem.DropDownItems.RemoveAt(i);
            }
            foreach (XmlElement el in myXml.DocumentElement.ChildNodes)
            {   
                ToolStripMenuItem item = new ToolStripMenuItem(el.InnerText,favicon(el.GetAttribute("url"),"link.png"), fav_Click);
                item.ToolTipText = el.GetAttribute("url");
                favoritesToolStripMenuItem.DropDownItems.Add(item);
            }
        }
//show links in menu
        private void linksMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            XmlDocument myXml = new XmlDocument();
            myXml.Load(linksXml);
            linksMenuItem.DropDownItems.Clear();
            foreach (XmlElement el in myXml.DocumentElement.ChildNodes)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(el.InnerText, favicon(el.GetAttribute("url"), "link.png"), fav_Click);
                item.ToolTipText = el.GetAttribute("url");
                linksMenuItem.DropDownItems.Add(item);
            }
        }
        private void fav_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem m = (ToolStripMenuItem)sender;
            getCurrentBrowser().Navigate(m.ToolTipText);
        }
        #endregion

        #region FILE
        /*FILE*/

//new tab
        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewTab();
        }
//duplicate tab
        private void duplicateTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getCurrentBrowser().Url != null)
            {
                Uri dup_url = getCurrentBrowser().Url;
                addNewTab();
                getCurrentBrowser().Url = dup_url;
                
            }
            else addNewTab();
        }
//new window
        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
             (new Form1()).Show();
           
        }
//close tab
        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeTab();
        }
 //open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Open(getCurrentBrowser())).Show();
        }
//page setup
        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().ShowPageSetupDialog();
        }
//save as
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().ShowSaveAsDialog();
        }
//print
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().ShowPrintDialog();

        }
//print preview
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().ShowPrintPreviewDialog();
        }
        #endregion

        #region EDIT
        /*EDIT*/

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().Document.ExecCommand("Cut", false, null);

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().Document.ExecCommand("Copy", false, null);

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().Document.ExecCommand("Paste", false, null);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().Document.ExecCommand("SelectAll", true, null);
        }
        #endregion

       private void addHistory()
        {
            XmlDocument myXml = new XmlDocument();
            if (!File.Exists("history.xml"))
            {  
                XmlElement root = myXml.CreateElement("history");
                myXml.AppendChild(root);
                XmlElement el = myXml.CreateElement("item");
                el.SetAttribute("url", getCurrentBrowser().Url.ToString());
                el.SetAttribute("date", DateTime.Now.ToString());
                root.AppendChild(el);
                myXml.Save("history.xml");
            }
            else
            {
                myXml.Load("history.xml");
                XmlElement el = myXml.CreateElement("item");
                el.SetAttribute("url", getCurrentBrowser().Url.ToString());
                el.SetAttribute("date", DateTime.Now.Date.ToString());
                myXml.DocumentElement.AppendChild(el);
                myXml.Save("history.xml");

            }
        }

       private void showFavorites()
       {
           ImageListBoxItem i = new ImageListBoxItem("leifewfr",Image.FromFile("link.png"));
           imageListBox1.Add(i);
       }

     

       


      

     
            
      
    }
          
}
