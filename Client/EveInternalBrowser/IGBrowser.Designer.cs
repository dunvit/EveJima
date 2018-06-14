namespace EveJimaIGB
{
    partial class IGBrowser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IGBrowser));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.adrBar = new System.Windows.Forms.ToolStrip();
            this.cmdMoveBrowserBack = new System.Windows.Forms.ToolStripButton();
            this.cmdMoveBrowserForward = new System.Windows.Forms.ToolStripButton();
            this.adrBarTextBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.cmdAddToFavorits = new System.Windows.Forms.ToolStripButton();
            this.favoritesPanel = new System.Windows.Forms.Panel();
            this.favoritesTabControl = new System.Windows.Forms.TabControl();
            this.favTabPage = new System.Windows.Forms.TabPage();
            this.favTreeView = new System.Windows.Forms.TreeView();
            this.browserTabControl = new System.Windows.Forms.TabControl();
            this.closeTabContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeTabToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.NewTab = new System.Windows.Forms.TabPage();
            this.favContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInNewTabToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.linkContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInNewTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInNewWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.linkBar = new System.Windows.Forms.ToolStrip();
            this.cmdMaximazeMinimaze = new System.Windows.Forms.Button();
            this.adrBar.SuspendLayout();
            this.favoritesPanel.SuspendLayout();
            this.favoritesTabControl.SuspendLayout();
            this.favTabPage.SuspendLayout();
            this.browserTabControl.SuspendLayout();
            this.closeTabContext.SuspendLayout();
            this.favContextMenu.SuspendLayout();
            this.linkContextMenu.SuspendLayout();
            this.linkBar.SuspendLayout();
            this.SuspendLayout();
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
            // adrBar
            // 
            this.adrBar.AllowItemReorder = true;
            this.adrBar.BackColor = System.Drawing.Color.Silver;
            this.adrBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdMoveBrowserBack,
            this.cmdMoveBrowserForward,
            this.adrBarTextBox,
            this.toolStripButton3,
            this.toolStripButton7,
            this.cmdAddToFavorits});
            this.adrBar.Location = new System.Drawing.Point(0, 0);
            this.adrBar.Name = "adrBar";
            this.adrBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.adrBar.Size = new System.Drawing.Size(974, 38);
            this.adrBar.Stretch = true;
            this.adrBar.TabIndex = 1;
            this.adrBar.Text = "toolStrip1";
            // 
            // cmdMoveBrowserBack
            // 
            this.cmdMoveBrowserBack.Enabled = false;
            this.cmdMoveBrowserBack.Image = ((System.Drawing.Image)(resources.GetObject("cmdMoveBrowserBack.Image")));
            this.cmdMoveBrowserBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdMoveBrowserBack.Name = "cmdMoveBrowserBack";
            this.cmdMoveBrowserBack.Size = new System.Drawing.Size(36, 35);
            this.cmdMoveBrowserBack.Text = "Back";
            this.cmdMoveBrowserBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdMoveBrowserBack.Click += new System.EventHandler(this.cmdMoveBrowserBack_Click);
            // 
            // cmdMoveBrowserForward
            // 
            this.cmdMoveBrowserForward.Enabled = false;
            this.cmdMoveBrowserForward.Image = ((System.Drawing.Image)(resources.GetObject("cmdMoveBrowserForward.Image")));
            this.cmdMoveBrowserForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdMoveBrowserForward.Name = "cmdMoveBrowserForward";
            this.cmdMoveBrowserForward.Size = new System.Drawing.Size(33, 35);
            this.cmdMoveBrowserForward.Text = "Fwd";
            this.cmdMoveBrowserForward.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdMoveBrowserForward.Click += new System.EventHandler(this.cmdMoveBrowserForward_Click);
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
            // cmdAddToFavorits
            // 
            this.cmdAddToFavorits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdAddToFavorits.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddToFavorits.Image")));
            this.cmdAddToFavorits.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdAddToFavorits.Name = "cmdAddToFavorits";
            this.cmdAddToFavorits.Size = new System.Drawing.Size(23, 35);
            this.cmdAddToFavorits.Text = "Add to favorites";
            this.cmdAddToFavorits.Click += new System.EventHandler(this.CmdAddToFavorits_Click);
            // 
            // favoritesPanel
            // 
            this.favoritesPanel.Controls.Add(this.favoritesTabControl);
            this.favoritesPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.favoritesPanel.Location = new System.Drawing.Point(0, 63);
            this.favoritesPanel.Name = "favoritesPanel";
            this.favoritesPanel.Size = new System.Drawing.Size(148, 509);
            this.favoritesPanel.TabIndex = 5;
            // 
            // favoritesTabControl
            // 
            this.favoritesTabControl.Controls.Add(this.favTabPage);
            this.favoritesTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.favoritesTabControl.Location = new System.Drawing.Point(0, 0);
            this.favoritesTabControl.Name = "favoritesTabControl";
            this.favoritesTabControl.SelectedIndex = 0;
            this.favoritesTabControl.Size = new System.Drawing.Size(148, 509);
            this.favoritesTabControl.TabIndex = 0;
            // 
            // favTabPage
            // 
            this.favTabPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.favTabPage.Controls.Add(this.favTreeView);
            this.favTabPage.Location = new System.Drawing.Point(4, 22);
            this.favTabPage.Name = "favTabPage";
            this.favTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.favTabPage.Size = new System.Drawing.Size(140, 483);
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
            this.favTreeView.Size = new System.Drawing.Size(130, 473);
            this.favTreeView.TabIndex = 0;
            this.favTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.favTreeView_NodeMouseClick);
            this.favTreeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.favTreeView_MouseClick);
            // 
            // browserTabControl
            // 
            //this.browserTabControl.ContextMenuStrip = this.closeTabContext;
            this.browserTabControl.Controls.Add(this.NewTab);
            this.browserTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserTabControl.Location = new System.Drawing.Point(148, 63);
            this.browserTabControl.Name = "browserTabControl";
            this.browserTabControl.SelectedIndex = 0;
            this.browserTabControl.Size = new System.Drawing.Size(826, 509);
            this.browserTabControl.TabIndex = 6;
            this.browserTabControl.SelectedIndexChanged += new System.EventHandler(this.browserTabControl_SelectedIndexChanged_1);
            this.browserTabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.browserTabControl_MouseClick);
            // 
            // closeTabContext
            // 
            this.closeTabContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeTabToolStripMenuItem1});
            this.closeTabContext.Name = "contextMenuStrip1";
            this.closeTabContext.Size = new System.Drawing.Size(181, 48);
            // 
            // closeTabToolStripMenuItem1
            // 
            this.closeTabToolStripMenuItem1.Name = "closeTabToolStripMenuItem1";
            this.closeTabToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.closeTabToolStripMenuItem1.Text = "CloseTab";
            this.closeTabToolStripMenuItem1.Click += new System.EventHandler(this.closeTabToolStripMenuItem1_Click);
            // 
            // NewTab
            // 
            this.NewTab.BackColor = System.Drawing.Color.Silver;
            this.NewTab.Location = new System.Drawing.Point(4, 22);
            this.NewTab.Name = "NewTab";
            this.NewTab.Padding = new System.Windows.Forms.Padding(3);
            this.NewTab.Size = new System.Drawing.Size(818, 483);
            this.NewTab.TabIndex = 0;
            this.NewTab.Text = "New";
            // 
            // favContextMenu
            // 
            this.favContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem2,
            this.openInNewTabToolStripMenuItem1,
            this.toolStripMenuItem7,
            this.deleteToolStripMenuItem1,
            this.renameToolStripMenuItem1});
            this.favContextMenu.Name = "favContextMenu";
            this.favContextMenu.Size = new System.Drawing.Size(166, 98);
            // 
            // openToolStripMenuItem2
            // 
            this.openToolStripMenuItem2.Name = "openToolStripMenuItem2";
            this.openToolStripMenuItem2.Size = new System.Drawing.Size(165, 22);
            this.openToolStripMenuItem2.Text = "Open";
            this.openToolStripMenuItem2.Click += new System.EventHandler(this.openToolStripMenuItem2_Click);
            // 
            // openInNewTabToolStripMenuItem1
            // 
            this.openInNewTabToolStripMenuItem1.Name = "openInNewTabToolStripMenuItem1";
            this.openInNewTabToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.openInNewTabToolStripMenuItem1.Text = "Open in New Tab";
            this.openInNewTabToolStripMenuItem1.Click += new System.EventHandler(this.openInNewTabToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(162, 6);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // renameToolStripMenuItem1
            // 
            this.renameToolStripMenuItem1.Name = "renameToolStripMenuItem1";
            this.renameToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.renameToolStripMenuItem1.Text = "Rename";
            this.renameToolStripMenuItem1.Click += new System.EventHandler(this.renameToolStripMenuItem1_Click);
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
            // 
            // openInNewTabToolStripMenuItem
            // 
            this.openInNewTabToolStripMenuItem.Name = "openInNewTabToolStripMenuItem";
            this.openInNewTabToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openInNewTabToolStripMenuItem.Text = "Open in New Tab";
            // 
            // openInNewWindowToolStripMenuItem
            // 
            this.openInNewWindowToolStripMenuItem.Name = "openInNewWindowToolStripMenuItem";
            this.openInNewWindowToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openInNewWindowToolStripMenuItem.Text = "Open in New Window";
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
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.renameToolStripMenuItem.Text = "Rename";
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
            // linkBar
            // 
            this.linkBar.BackColor = System.Drawing.Color.Silver;
            this.linkBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton6,
            this.toolStripSeparator1});
            this.linkBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.linkBar.Location = new System.Drawing.Point(0, 38);
            this.linkBar.Name = "linkBar";
            this.linkBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.linkBar.Size = new System.Drawing.Size(974, 25);
            this.linkBar.TabIndex = 4;
            this.linkBar.Text = "toolStrip2";
            // 
            // cmdMaximazeMinimaze
            // 
            this.cmdMaximazeMinimaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMaximazeMinimaze.Location = new System.Drawing.Point(930, 528);
            this.cmdMaximazeMinimaze.Name = "cmdMaximazeMinimaze";
            this.cmdMaximazeMinimaze.Size = new System.Drawing.Size(23, 22);
            this.cmdMaximazeMinimaze.TabIndex = 0;
            this.cmdMaximazeMinimaze.Text = "+";
            this.cmdMaximazeMinimaze.UseVisualStyleBackColor = true;
            this.cmdMaximazeMinimaze.Click += new System.EventHandler(this.cmdMaximazeMinimaze_Click);
            // 
            // IGBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.cmdMaximazeMinimaze);
            this.Controls.Add(this.browserTabControl);
            this.Controls.Add(this.favoritesPanel);
            this.Controls.Add(this.linkBar);
            this.Controls.Add(this.adrBar);
            this.Name = "IGBrowser";
            this.Size = new System.Drawing.Size(974, 572);
            this.Load += new System.EventHandler(this.IGBrowser_Load);
            this.adrBar.ResumeLayout(false);
            this.adrBar.PerformLayout();
            this.favoritesPanel.ResumeLayout(false);
            this.favoritesTabControl.ResumeLayout(false);
            this.favTabPage.ResumeLayout(false);
            this.browserTabControl.ResumeLayout(false);
            this.closeTabContext.ResumeLayout(false);
            this.favContextMenu.ResumeLayout(false);
            this.linkContextMenu.ResumeLayout(false);
            this.linkBar.ResumeLayout(false);
            this.linkBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolStrip adrBar;
        private System.Windows.Forms.ToolStripButton cmdMoveBrowserBack;
        private System.Windows.Forms.ToolStripButton cmdMoveBrowserForward;
        private System.Windows.Forms.ToolStripComboBox adrBarTextBox;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton cmdAddToFavorits;
        private System.Windows.Forms.Panel favoritesPanel;
        private System.Windows.Forms.TabControl favoritesTabControl;
        private System.Windows.Forms.TabPage favTabPage;
        private System.Windows.Forms.TreeView favTreeView;
        private System.Windows.Forms.TabControl browserTabControl;
        private System.Windows.Forms.TabPage NewTab;
        private System.Windows.Forms.ContextMenuStrip favContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openInNewTabToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip linkContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openInNewTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInNewWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip linkBar;
        private System.Windows.Forms.ContextMenuStrip closeTabContext;
        private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem1;
        private System.Windows.Forms.Button cmdMaximazeMinimaze;
    }
}
