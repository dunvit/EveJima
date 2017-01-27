namespace EveJimaCore
{
    partial class WindowMonitoring
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
            this.lblSolarSystemName = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.RefreshTokenTimer = new System.Windows.Forms.Timer(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblVersionID = new System.Windows.Forms.Label();
            this.TitleBar = new System.Windows.Forms.Panel();
            this.cmdPin = new System.Windows.Forms.Button();
            this.btnOpenBrowserAndStartUrl = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdMinimazeRestore = new System.Windows.Forms.Button();
            this.VersionBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdVersion = new whlButton();
            this.cmdShowContainerSolarSystem = new whlButton();
            this.cmdOpenWebBrowser = new whlButton();
            this.cmdAuthirizationPanel = new whlButton();
            this.cmdLocation = new whlButton();
            this.cmdShowContainerBookmarks = new whlButton();
            this.cmdShowContainerPilots = new whlButton();
            this.TitleBar.SuspendLayout();
            this.VersionBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSolarSystemName
            // 
            this.lblSolarSystemName.BackColor = System.Drawing.Color.Transparent;
            this.lblSolarSystemName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolarSystemName.ForeColor = System.Drawing.Color.LightGray;
            this.lblSolarSystemName.Location = new System.Drawing.Point(5, 5);
            this.lblSolarSystemName.Name = "lblSolarSystemName";
            this.lblSolarSystemName.Size = new System.Drawing.Size(252, 18);
            this.lblSolarSystemName.TabIndex = 5;
            this.lblSolarSystemName.DoubleClick += new System.EventHandler(this.Event_TitleBarDoubleClick);
            this.lblSolarSystemName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Event_TitleBarMouseDown);
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.Black;
            this.pnlContainer.Location = new System.Drawing.Point(11, 63);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(542, 224);
            this.pnlContainer.TabIndex = 8;
            // 
            // RefreshTokenTimer
            // 
            this.RefreshTokenTimer.Enabled = true;
            this.RefreshTokenTimer.Interval = 2000;
            this.RefreshTokenTimer.Tick += new System.EventHandler(this.RefreshTokenTimer_Tick);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DarkGray;
            this.label18.Location = new System.Drawing.Point(276, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 23);
            this.label18.TabIndex = 42;
            this.label18.Text = "Created by";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DarkOrange;
            this.label19.Location = new System.Drawing.Point(382, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(157, 23);
            this.label19.TabIndex = 43;
            this.label19.Text = "Dunkan Su-Shiloff";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.DarkGray;
            this.label20.Location = new System.Drawing.Point(82, 4);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 16);
            this.label20.TabIndex = 44;
            this.label20.Text = "version ";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVersionID
            // 
            this.lblVersionID.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionID.ForeColor = System.Drawing.Color.Olive;
            this.lblVersionID.Location = new System.Drawing.Point(137, 1);
            this.lblVersionID.Name = "lblVersionID";
            this.lblVersionID.Size = new System.Drawing.Size(77, 23);
            this.lblVersionID.TabIndex = 45;
            this.lblVersionID.Text = "1.12";
            this.lblVersionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.Black;
            this.TitleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleBar.Controls.Add(this.cmdPin);
            this.TitleBar.Controls.Add(this.btnOpenBrowserAndStartUrl);
            this.TitleBar.Controls.Add(this.cmdClose);
            this.TitleBar.Controls.Add(this.cmdMinimazeRestore);
            this.TitleBar.Controls.Add(this.lblSolarSystemName);
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(800, 28);
            this.TitleBar.TabIndex = 47;
            this.TitleBar.DoubleClick += new System.EventHandler(this.Event_TitleBarDoubleClick);
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Event_TitleBarMouseDown);
            // 
            // cmdPin
            // 
            this.cmdPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPin.BackColor = System.Drawing.Color.Black;
            this.cmdPin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdPin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPin.Image = global::EveJimaCore.Properties.Resources.pin;
            this.cmdPin.Location = new System.Drawing.Point(703, 1);
            this.cmdPin.Name = "cmdPin";
            this.cmdPin.Size = new System.Drawing.Size(22, 22);
            this.cmdPin.TabIndex = 3;
            this.cmdPin.UseVisualStyleBackColor = false;
            this.cmdPin.Click += new System.EventHandler(this.cmdPin_Click);
            // 
            // btnOpenBrowserAndStartUrl
            // 
            this.btnOpenBrowserAndStartUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenBrowserAndStartUrl.BackColor = System.Drawing.Color.Black;
            this.btnOpenBrowserAndStartUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenBrowserAndStartUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenBrowserAndStartUrl.Image = global::EveJimaCore.Properties.Resources.url;
            this.btnOpenBrowserAndStartUrl.Location = new System.Drawing.Point(727, 1);
            this.btnOpenBrowserAndStartUrl.Name = "btnOpenBrowserAndStartUrl";
            this.btnOpenBrowserAndStartUrl.Size = new System.Drawing.Size(22, 22);
            this.btnOpenBrowserAndStartUrl.TabIndex = 46;
            this.btnOpenBrowserAndStartUrl.UseVisualStyleBackColor = false;
            this.btnOpenBrowserAndStartUrl.Click += new System.EventHandler(this.Event_OpenBrowserContainer);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.BackColor = System.Drawing.Color.Black;
            this.cmdClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Image = global::EveJimaCore.Properties.Resources.close;
            this.cmdClose.Location = new System.Drawing.Point(772, 1);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(22, 22);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdMinimazeRestore
            // 
            this.cmdMinimazeRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMinimazeRestore.BackColor = System.Drawing.Color.Black;
            this.cmdMinimazeRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdMinimazeRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMinimazeRestore.Image = global::EveJimaCore.Properties.Resources.minimize;
            this.cmdMinimazeRestore.Location = new System.Drawing.Point(750, 1);
            this.cmdMinimazeRestore.Name = "cmdMinimazeRestore";
            this.cmdMinimazeRestore.Size = new System.Drawing.Size(22, 22);
            this.cmdMinimazeRestore.TabIndex = 2;
            this.cmdMinimazeRestore.UseVisualStyleBackColor = false;
            this.cmdMinimazeRestore.Click += new System.EventHandler(this.cmdMinimazeRestore_Click);
            // 
            // VersionBar
            // 
            this.VersionBar.BackColor = System.Drawing.Color.Transparent;
            this.VersionBar.Controls.Add(this.label1);
            this.VersionBar.Controls.Add(this.label18);
            this.VersionBar.Controls.Add(this.label19);
            this.VersionBar.Controls.Add(this.label20);
            this.VersionBar.Controls.Add(this.lblVersionID);
            this.VersionBar.Location = new System.Drawing.Point(10, 330);
            this.VersionBar.Name = "VersionBar";
            this.VersionBar.Size = new System.Drawing.Size(540, 28);
            this.VersionBar.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(8, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "EveJima";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdVersion
            // 
            this.cmdVersion.BackColor = System.Drawing.Color.Black;
            this.cmdVersion.ForeColor = System.Drawing.Color.Crimson;
            this.cmdVersion.IsActive = true;
            this.cmdVersion.IsTabControlButton = false;
            this.cmdVersion.Location = new System.Drawing.Point(481, 38);
            this.cmdVersion.Name = "cmdVersion";
            this.cmdVersion.Size = new System.Drawing.Size(68, 26);
            this.cmdVersion.TabIndex = 56;
            this.cmdVersion.Value = "Version";
            this.cmdVersion.Click += new System.EventHandler(this.Event_ShowVersion);
            // 
            // cmdShowContainerSolarSystem
            // 
            this.cmdShowContainerSolarSystem.BackColor = System.Drawing.Color.Black;
            this.cmdShowContainerSolarSystem.ForeColor = System.Drawing.Color.LightGray;
            this.cmdShowContainerSolarSystem.IsActive = true;
            this.cmdShowContainerSolarSystem.IsTabControlButton = false;
            this.cmdShowContainerSolarSystem.Location = new System.Drawing.Point(166, 38);
            this.cmdShowContainerSolarSystem.Name = "cmdShowContainerSolarSystem";
            this.cmdShowContainerSolarSystem.Size = new System.Drawing.Size(92, 26);
            this.cmdShowContainerSolarSystem.TabIndex = 55;
            this.cmdShowContainerSolarSystem.Value = "Solar System";
            this.cmdShowContainerSolarSystem.Click += new System.EventHandler(this.Event_ShowContainerSolarSystem);
            // 
            // cmdOpenWebBrowser
            // 
            this.cmdOpenWebBrowser.BackColor = System.Drawing.Color.Black;
            this.cmdOpenWebBrowser.ForeColor = System.Drawing.Color.LightGray;
            this.cmdOpenWebBrowser.IsActive = true;
            this.cmdOpenWebBrowser.IsTabControlButton = false;
            this.cmdOpenWebBrowser.Location = new System.Drawing.Point(389, 38);
            this.cmdOpenWebBrowser.Name = "cmdOpenWebBrowser";
            this.cmdOpenWebBrowser.Size = new System.Drawing.Size(93, 26);
            this.cmdOpenWebBrowser.TabIndex = 54;
            this.cmdOpenWebBrowser.Value = "Web Browser";
            this.cmdOpenWebBrowser.Click += new System.EventHandler(this.Event_OpenBrowserContainer);
            // 
            // cmdAuthirizationPanel
            // 
            this.cmdAuthirizationPanel.BackColor = System.Drawing.Color.Black;
            this.cmdAuthirizationPanel.ForeColor = System.Drawing.Color.LightGray;
            this.cmdAuthirizationPanel.IsActive = true;
            this.cmdAuthirizationPanel.IsTabControlButton = true;
            this.cmdAuthirizationPanel.Location = new System.Drawing.Point(11, 38);
            this.cmdAuthirizationPanel.Name = "cmdAuthirizationPanel";
            this.cmdAuthirizationPanel.Size = new System.Drawing.Size(91, 26);
            this.cmdAuthirizationPanel.TabIndex = 53;
            this.cmdAuthirizationPanel.Value = "Authorization";
            this.cmdAuthirizationPanel.Click += new System.EventHandler(this.cmdAuthirizationPanel_Click);
            // 
            // cmdLocation
            // 
            this.cmdLocation.BackColor = System.Drawing.Color.Black;
            this.cmdLocation.ForeColor = System.Drawing.Color.LightGray;
            this.cmdLocation.IsActive = false;
            this.cmdLocation.IsTabControlButton = false;
            this.cmdLocation.Location = new System.Drawing.Point(101, 38);
            this.cmdLocation.Name = "cmdLocation";
            this.cmdLocation.Size = new System.Drawing.Size(66, 26);
            this.cmdLocation.TabIndex = 52;
            this.cmdLocation.Value = "Location";
            this.cmdLocation.Click += new System.EventHandler(this.Event_ShowContainerSolarSystemInfo);
            // 
            // cmdShowContainerBookmarks
            // 
            this.cmdShowContainerBookmarks.BackColor = System.Drawing.Color.Black;
            this.cmdShowContainerBookmarks.ForeColor = System.Drawing.Color.LightGray;
            this.cmdShowContainerBookmarks.IsActive = true;
            this.cmdShowContainerBookmarks.IsTabControlButton = false;
            this.cmdShowContainerBookmarks.Location = new System.Drawing.Point(305, 38);
            this.cmdShowContainerBookmarks.Name = "cmdShowContainerBookmarks";
            this.cmdShowContainerBookmarks.Size = new System.Drawing.Size(85, 26);
            this.cmdShowContainerBookmarks.TabIndex = 51;
            this.cmdShowContainerBookmarks.Value = "Bookmarks";
            this.cmdShowContainerBookmarks.Click += new System.EventHandler(this.Event_ShowContainerCoordinates);
            // 
            // cmdShowContainerPilots
            // 
            this.cmdShowContainerPilots.BackColor = System.Drawing.Color.Black;
            this.cmdShowContainerPilots.ForeColor = System.Drawing.Color.LightGray;
            this.cmdShowContainerPilots.IsActive = true;
            this.cmdShowContainerPilots.IsTabControlButton = false;
            this.cmdShowContainerPilots.Location = new System.Drawing.Point(257, 38);
            this.cmdShowContainerPilots.Name = "cmdShowContainerPilots";
            this.cmdShowContainerPilots.Size = new System.Drawing.Size(49, 26);
            this.cmdShowContainerPilots.TabIndex = 50;
            this.cmdShowContainerPilots.Value = "Pilots";
            this.cmdShowContainerPilots.Click += new System.EventHandler(this.Event_ShowContainerPilots);
            // 
            // WindowMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1443, 1053);
            this.Controls.Add(this.cmdVersion);
            this.Controls.Add(this.cmdShowContainerSolarSystem);
            this.Controls.Add(this.cmdOpenWebBrowser);
            this.Controls.Add(this.cmdAuthirizationPanel);
            this.Controls.Add(this.cmdLocation);
            this.Controls.Add(this.cmdShowContainerBookmarks);
            this.Controls.Add(this.cmdShowContainerPilots);
            this.Controls.Add(this.TitleBar);
            this.Controls.Add(this.VersionBar);
            this.Controls.Add(this.pnlContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowMonitoring";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EveJima";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindowMonitoring_FormClosing);
            this.Load += new System.EventHandler(this.WindowMonitoring_Load);
            this.ResizeEnd += new System.EventHandler(this.Event_WindowResizeEnd);
            this.DoubleClick += new System.EventHandler(this.Event_WindowDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowMonitoring_MouseDown);
            this.Resize += new System.EventHandler(this.WindowMonitoring_Resize);
            this.TitleBar.ResumeLayout(false);
            this.VersionBar.ResumeLayout(false);
            this.VersionBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdMinimazeRestore;
        private System.Windows.Forms.Button cmdPin;
        private System.Windows.Forms.Label lblSolarSystemName;
        public System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Timer RefreshTokenTimer;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblVersionID;
        private System.Windows.Forms.Button btnOpenBrowserAndStartUrl;
        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.Panel VersionBar;
        
        private whlButton cmdShowContainerPilots;
        private whlButton cmdShowContainerBookmarks;
        private whlButton cmdLocation;
        private whlButton cmdAuthirizationPanel;
        private whlButton cmdOpenWebBrowser;
        private System.Windows.Forms.Label label1;
        private whlButton cmdShowContainerSolarSystem;
        private whlButton cmdVersion;



    }
}