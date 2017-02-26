namespace WBrowser
{
    partial class WBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WBrowser));
            this.toolBarContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linksBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adrBar = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.img = new System.Windows.Forms.ToolStripButton();
            this.adrBarTextBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.googleSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.liveSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.browserTabControl = new System.Windows.Forms.TabControl();
            this.closeTabContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeTabToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateTabToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.NewTab = new System.Windows.Forms.TabPage();
            this.linkBar = new System.Windows.Forms.ToolStrip();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.favoritesPanel = new System.Windows.Forms.Panel();
            this.favoritesTabControl = new System.Windows.Forms.TabControl();
            this.favTabPage = new System.Windows.Forms.TabPage();
            this.favTreeView = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.linkContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInNewTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInNewWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInNewTabToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInNewWindowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.histContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInNewTabToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInNewWindowToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.addToFavoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarContextMenu.SuspendLayout();
            this.adrBar.SuspendLayout();
            this.browserTabControl.SuspendLayout();
            this.closeTabContext.SuspendLayout();
            this.linkBar.SuspendLayout();
            this.favoritesPanel.SuspendLayout();
            this.favoritesTabControl.SuspendLayout();
            this.favTabPage.SuspendLayout();
            this.linkContextMenu.SuspendLayout();
            this.favContextMenu.SuspendLayout();
            this.histContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBarContextMenu
            // 
            this.toolBarContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBarToolStripMenuItem,
            this.commandBarToolStripMenuItem,
            this.linksBarToolStripMenuItem});
            this.toolBarContextMenu.Name = "toolBarContextMenu";
            this.toolBarContextMenu.Size = new System.Drawing.Size(137, 70);
            // 
            // menuBarToolStripMenuItem
            // 
            this.menuBarToolStripMenuItem.CheckOnClick = true;
            this.menuBarToolStripMenuItem.Name = "menuBarToolStripMenuItem";
            this.menuBarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.menuBarToolStripMenuItem.Text = "Menu Bar";
            // 
            // commandBarToolStripMenuItem
            // 
            this.commandBarToolStripMenuItem.CheckOnClick = true;
            this.commandBarToolStripMenuItem.Name = "commandBarToolStripMenuItem";
            this.commandBarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.commandBarToolStripMenuItem.Text = "Address Bar";
            this.commandBarToolStripMenuItem.Click += new System.EventHandler(this.commandBarToolStripMenuItem_Click);
            // 
            // linksBarToolStripMenuItem
            // 
            this.linksBarToolStripMenuItem.Name = "linksBarToolStripMenuItem";
            this.linksBarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.linksBarToolStripMenuItem.Text = "Links Bar";
            this.linksBarToolStripMenuItem.Click += new System.EventHandler(this.linksBarToolStripMenuItem_Click);
            // 
            // adrBar
            // 
            this.adrBar.AllowItemReorder = true;
            this.adrBar.BackColor = System.Drawing.Color.Silver;
            this.adrBar.ContextMenuStrip = this.toolBarContextMenu;
            this.adrBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.img,
            this.adrBarTextBox,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripSplitButton1,
            this.searchTextBox});
            this.adrBar.Location = new System.Drawing.Point(0, 0);
            this.adrBar.Name = "adrBar";
            this.adrBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.adrBar.Size = new System.Drawing.Size(795, 38);
            this.adrBar.Stretch = true;
            this.adrBar.TabIndex = 0;
            this.adrBar.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 35);
            this.toolStripButton1.Text = "Back";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(33, 35);
            this.toolStripButton2.Text = "Fwd";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // img
            // 
            this.img.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.img.Image = ((System.Drawing.Image)(resources.GetObject("img.Image")));
            this.img.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(23, 35);
            // 
            // adrBarTextBox
            // 
            this.adrBarTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.adrBarTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.adrBarTextBox.DropDownHeight = 300;
            this.adrBarTextBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.adrBarTextBox.IntegralHeight = false;
            this.adrBarTextBox.Name = "adrBarTextBox";
            this.adrBarTextBox.Size = new System.Drawing.Size(400, 38);
            this.adrBarTextBox.DropDown += new System.EventHandler(this.adrBarTextBox_DropDown);
            this.adrBarTextBox.SelectedIndexChanged += new System.EventHandler(this.adrBarTextBox_SelectedIndexChanged);
            this.adrBarTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.adrBarTextBox_KeyDown);
            this.adrBarTextBox.Click += new System.EventHandler(this.adrBarTextBox_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(26, 35);
            this.toolStripButton3.Text = "Go";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 35);
            this.toolStripButton4.Text = "Refresh";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 35);
            this.toolStripButton5.Text = "Stop";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 35);
            this.toolStripButton7.Text = "Favorits";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 35);
            this.toolStripButton8.Text = "Add to favorites";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.googleSearch,
            this.liveSearch});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 35);
            this.toolStripSplitButton1.Text = "Search";
            // 
            // googleSearch
            // 
            this.googleSearch.Checked = true;
            this.googleSearch.CheckOnClick = true;
            this.googleSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.googleSearch.Name = "googleSearch";
            this.googleSearch.Size = new System.Drawing.Size(150, 22);
            this.googleSearch.Text = "Google Search";
            this.googleSearch.Click += new System.EventHandler(this.googleSearch_Click);
            // 
            // liveSearch
            // 
            this.liveSearch.CheckOnClick = true;
            this.liveSearch.Name = "liveSearch";
            this.liveSearch.Size = new System.Drawing.Size(150, 22);
            this.liveSearch.Text = "Live Search";
            this.liveSearch.Click += new System.EventHandler(this.liveSearch_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(150, 23);
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // browserTabControl
            // 
            this.browserTabControl.ContextMenuStrip = this.closeTabContext;
            this.browserTabControl.Controls.Add(this.NewTab);
            this.browserTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserTabControl.Location = new System.Drawing.Point(148, 63);
            this.browserTabControl.Name = "browserTabControl";
            this.browserTabControl.SelectedIndex = 0;
            this.browserTabControl.Size = new System.Drawing.Size(647, 494);
            this.browserTabControl.TabIndex = 1;
            this.browserTabControl.SelectedIndexChanged += new System.EventHandler(this.browserTabControl_SelectedIndexChanged);
            this.browserTabControl.TabIndexChanged += new System.EventHandler(this.browserTabControl_TabIndexChanged);
            // 
            // closeTabContext
            // 
            this.closeTabContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeTabToolStripMenuItem1,
            this.duplicateTabToolStripMenuItem1});
            this.closeTabContext.Name = "contextMenuStrip1";
            this.closeTabContext.Size = new System.Drawing.Size(192, 48);
            // 
            // closeTabToolStripMenuItem1
            // 
            this.closeTabToolStripMenuItem1.Name = "closeTabToolStripMenuItem1";
            this.closeTabToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeTabToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.closeTabToolStripMenuItem1.Text = "CloseTab";
            this.closeTabToolStripMenuItem1.Click += new System.EventHandler(this.closeTabToolStripMenuItem1_Click);
            // 
            // duplicateTabToolStripMenuItem1
            // 
            this.duplicateTabToolStripMenuItem1.Name = "duplicateTabToolStripMenuItem1";
            this.duplicateTabToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.duplicateTabToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.duplicateTabToolStripMenuItem1.Text = "Duplicate Tab ";
            this.duplicateTabToolStripMenuItem1.Click += new System.EventHandler(this.duplicateTabToolStripMenuItem1_Click);
            // 
            // NewTab
            // 
            this.NewTab.BackColor = System.Drawing.Color.Silver;
            this.NewTab.Location = new System.Drawing.Point(4, 22);
            this.NewTab.Name = "NewTab";
            this.NewTab.Padding = new System.Windows.Forms.Padding(3);
            this.NewTab.Size = new System.Drawing.Size(639, 468);
            this.NewTab.TabIndex = 0;
            this.NewTab.Text = "New";
            // 
            // linkBar
            // 
            this.linkBar.BackColor = System.Drawing.Color.Silver;
            this.linkBar.ContextMenuStrip = this.toolBarContextMenu;
            this.linkBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton6,
            this.toolStripSeparator1,
            this.toolStripButton9});
            this.linkBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.linkBar.Location = new System.Drawing.Point(0, 38);
            this.linkBar.Name = "linkBar";
            this.linkBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.linkBar.Size = new System.Drawing.Size(795, 25);
            this.linkBar.TabIndex = 3;
            this.linkBar.Text = "toolStrip2";
            this.linkBar.VisibleChanged += new System.EventHandler(this.linkBar_VisibleChanged);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(74, 22);
            this.toolStripButton6.Text = "Favorites";
            this.toolStripButton6.ToolTipText = "View Favorites, History";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.toolStripButton9.Size = new System.Drawing.Size(30, 22);
            this.toolStripButton9.Text = "Add to Favorites Bar";
            this.toolStripButton9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // favoritesPanel
            // 
            this.favoritesPanel.Controls.Add(this.favoritesTabControl);
            this.favoritesPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.favoritesPanel.Location = new System.Drawing.Point(0, 63);
            this.favoritesPanel.Name = "favoritesPanel";
            this.favoritesPanel.Size = new System.Drawing.Size(148, 494);
            this.favoritesPanel.TabIndex = 4;
            this.favoritesPanel.VisibleChanged += new System.EventHandler(this.favoritesPanel_VisibleChanged);
            // 
            // favoritesTabControl
            // 
            this.favoritesTabControl.Controls.Add(this.favTabPage);
            this.favoritesTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.favoritesTabControl.Location = new System.Drawing.Point(0, 0);
            this.favoritesTabControl.Name = "favoritesTabControl";
            this.favoritesTabControl.SelectedIndex = 0;
            this.favoritesTabControl.Size = new System.Drawing.Size(148, 494);
            this.favoritesTabControl.TabIndex = 0;
            // 
            // favTabPage
            // 
            this.favTabPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.favTabPage.Controls.Add(this.favTreeView);
            this.favTabPage.Location = new System.Drawing.Point(4, 22);
            this.favTabPage.Name = "favTabPage";
            this.favTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.favTabPage.Size = new System.Drawing.Size(140, 468);
            this.favTabPage.TabIndex = 0;
            this.favTabPage.Text = "Favorites";
            this.favTabPage.UseVisualStyleBackColor = true;
            // 
            // favTreeView
            // 
            this.favTreeView.BackColor = System.Drawing.Color.Silver;
            this.favTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.favTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.favTreeView.ImageIndex = 0;
            this.favTreeView.ImageList = this.imgList;
            this.favTreeView.ItemHeight = 20;
            this.favTreeView.Location = new System.Drawing.Point(3, 3);
            this.favTreeView.Name = "favTreeView";
            this.favTreeView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.favTreeView.SelectedImageIndex = 0;
            this.favTreeView.ShowNodeToolTips = true;
            this.favTreeView.Size = new System.Drawing.Size(130, 458);
            this.favTreeView.TabIndex = 0;
            this.favTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "folder.gif");
            this.imgList.Images.SetKeyName(1, "net.png");
            this.imgList.Images.SetKeyName(2, "calendar.png");
            this.imgList.Images.SetKeyName(3, "link.png");
            // 
            // linkContextMenu
            // 
            this.linkContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.openInNewTabToolStripMenuItem,
            this.openInNewWindowToolStripMenuItem,
            this.toolStripMenuItem5,
            this.deleteToolStripMenuItem,
            this.renameToolStripMenuItem});
            this.linkContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.linkContextMenu.Name = "linkContextMenu";
            this.linkContextMenu.Size = new System.Drawing.Size(191, 120);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // openInNewTabToolStripMenuItem
            // 
            this.openInNewTabToolStripMenuItem.Name = "openInNewTabToolStripMenuItem";
            this.openInNewTabToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openInNewTabToolStripMenuItem.Text = "Open in New Tab";
            this.openInNewTabToolStripMenuItem.Click += new System.EventHandler(this.openInNewTabToolStripMenuItem_Click);
            // 
            // openInNewWindowToolStripMenuItem
            // 
            this.openInNewWindowToolStripMenuItem.Name = "openInNewWindowToolStripMenuItem";
            this.openInNewWindowToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openInNewWindowToolStripMenuItem.Text = "Open in New Window";
            this.openInNewWindowToolStripMenuItem.Click += new System.EventHandler(this.openInNewWindowToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(187, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // favContextMenu
            // 
            this.favContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem2,
            this.openInNewTabToolStripMenuItem1,
            this.openInNewWindowToolStripMenuItem1,
            this.toolStripMenuItem7,
            this.deleteToolStripMenuItem1,
            this.renameToolStripMenuItem1});
            this.favContextMenu.Name = "favContextMenu";
            this.favContextMenu.Size = new System.Drawing.Size(191, 120);
            // 
            // openToolStripMenuItem2
            // 
            this.openToolStripMenuItem2.Name = "openToolStripMenuItem2";
            this.openToolStripMenuItem2.Size = new System.Drawing.Size(190, 22);
            this.openToolStripMenuItem2.Text = "Open";
            this.openToolStripMenuItem2.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // openInNewTabToolStripMenuItem1
            // 
            this.openInNewTabToolStripMenuItem1.Name = "openInNewTabToolStripMenuItem1";
            this.openInNewTabToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.openInNewTabToolStripMenuItem1.Text = "Open in New Tab";
            this.openInNewTabToolStripMenuItem1.Click += new System.EventHandler(this.openInNewTabToolStripMenuItem_Click);
            // 
            // openInNewWindowToolStripMenuItem1
            // 
            this.openInNewWindowToolStripMenuItem1.Name = "openInNewWindowToolStripMenuItem1";
            this.openInNewWindowToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.openInNewWindowToolStripMenuItem1.Text = "Open in New Window";
            this.openInNewWindowToolStripMenuItem1.Click += new System.EventHandler(this.openInNewWindowToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(187, 6);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // renameToolStripMenuItem1
            // 
            this.renameToolStripMenuItem1.Name = "renameToolStripMenuItem1";
            this.renameToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.renameToolStripMenuItem1.Text = "Rename";
            this.renameToolStripMenuItem1.Click += new System.EventHandler(this.renameToolStripMenuItem1_Click);
            // 
            // histContextMenu
            // 
            this.histContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem3,
            this.openInNewTabToolStripMenuItem2,
            this.openInNewWindowToolStripMenuItem2,
            this.toolStripMenuItem12,
            this.addToFavoritesToolStripMenuItem,
            this.deleteToolStripMenuItem2});
            this.histContextMenu.Name = "histContextMenu";
            this.histContextMenu.Size = new System.Drawing.Size(191, 120);
            // 
            // openToolStripMenuItem3
            // 
            this.openToolStripMenuItem3.Name = "openToolStripMenuItem3";
            this.openToolStripMenuItem3.Size = new System.Drawing.Size(190, 22);
            this.openToolStripMenuItem3.Text = "Open";
            this.openToolStripMenuItem3.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // openInNewTabToolStripMenuItem2
            // 
            this.openInNewTabToolStripMenuItem2.Name = "openInNewTabToolStripMenuItem2";
            this.openInNewTabToolStripMenuItem2.Size = new System.Drawing.Size(190, 22);
            this.openInNewTabToolStripMenuItem2.Text = "Open in New Tab";
            this.openInNewTabToolStripMenuItem2.Click += new System.EventHandler(this.openInNewTabToolStripMenuItem_Click);
            // 
            // openInNewWindowToolStripMenuItem2
            // 
            this.openInNewWindowToolStripMenuItem2.Name = "openInNewWindowToolStripMenuItem2";
            this.openInNewWindowToolStripMenuItem2.Size = new System.Drawing.Size(190, 22);
            this.openInNewWindowToolStripMenuItem2.Text = "Open in New Window";
            this.openInNewWindowToolStripMenuItem2.Click += new System.EventHandler(this.openInNewWindowToolStripMenuItem_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(187, 6);
            // 
            // addToFavoritesToolStripMenuItem
            // 
            this.addToFavoritesToolStripMenuItem.Name = "addToFavoritesToolStripMenuItem";
            this.addToFavoritesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addToFavoritesToolStripMenuItem.Text = "Add To Favorites";
            // 
            // deleteToolStripMenuItem2
            // 
            this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
            this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(190, 22);
            this.deleteToolStripMenuItem2.Text = "Delete";
            this.deleteToolStripMenuItem2.Click += new System.EventHandler(this.deleteToolStripMenuItem2_Click);
            // 
            // WBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 557);
            this.Controls.Add(this.browserTabControl);
            this.Controls.Add(this.favoritesPanel);
            this.Controls.Add(this.linkBar);
            this.Controls.Add(this.adrBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WBrowser";
            this.Tag = "0";
            this.Text = "WBrowser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WBrowser_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolBarContextMenu.ResumeLayout(false);
            this.adrBar.ResumeLayout(false);
            this.adrBar.PerformLayout();
            this.browserTabControl.ResumeLayout(false);
            this.closeTabContext.ResumeLayout(false);
            this.linkBar.ResumeLayout(false);
            this.linkBar.PerformLayout();
            this.favoritesPanel.ResumeLayout(false);
            this.favoritesTabControl.ResumeLayout(false);
            this.favTabPage.ResumeLayout(false);
            this.linkContextMenu.ResumeLayout(false);
            this.favContextMenu.ResumeLayout(false);
            this.histContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip adrBar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.TabControl browserTabControl;
        private System.Windows.Forms.TabPage NewTab;
        private System.Windows.Forms.ToolStripTextBox searchTextBox;
        private System.Windows.Forms.ContextMenuStrip closeTabContext;
        private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ContextMenuStrip toolBarContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linksBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.Panel favoritesPanel;
        private System.Windows.Forms.ToolStripButton img;
        private System.Windows.Forms.ContextMenuStrip linkContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openInNewTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInNewWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripMenuItem duplicateTabToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip favContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openInNewTabToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openInNewWindowToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem1;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolStrip linkBar;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem googleSearch;
        private System.Windows.Forms.ToolStripMenuItem liveSearch;
        private System.Windows.Forms.ContextMenuStrip histContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem openInNewTabToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openInNewWindowToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem addToFavoritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
        private System.Windows.Forms.ToolStripComboBox adrBarTextBox;
        private System.Windows.Forms.TabControl favoritesTabControl;
        private System.Windows.Forms.TabPage favTabPage;
        private System.Windows.Forms.TreeView favTreeView;
    }
}

