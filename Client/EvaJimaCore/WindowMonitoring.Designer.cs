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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowMonitoring));
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblVersionID = new System.Windows.Forms.Label();
            this.TitleBar = new System.Windows.Forms.Panel();
            this.cmdHide = new System.Windows.Forms.Button();
            this.btnBrowserMin = new System.Windows.Forms.Button();
            this.btnBrowserMax = new System.Windows.Forms.Button();
            this.cmdPin = new System.Windows.Forms.Button();
            this.btnOpenBrowserAndStartUrl = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdMinimazeRestore = new System.Windows.Forms.Button();
            this.VersionBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.crlNotificay = new System.Windows.Forms.NotifyIcon(this.components);
            this.RefreshActivePilot = new System.Windows.Forms.Timer(this.components);
            this.cmdVersion1 = new EveJimaCore.WhlControls.ejButton();
            this._mapToolbarControl1 = new EveJimaCore.Logic.ToolBar.MapToolbarControl();
            this.cmdOpenWebBrowser1 = new EveJimaCore.WhlControls.ejButton();
            this.cmdShowContainerBookmarks1 = new EveJimaCore.WhlControls.ejButton();
            this.cmdShowContainerPilots1 = new EveJimaCore.WhlControls.ejButton();
            this.cmdShowContainerSolarSystem1 = new EveJimaCore.WhlControls.ejButton();
            this.cmdMap = new EveJimaCore.WhlControls.ejButton();
            this.cmdAuthirizationPanel1 = new EveJimaCore.WhlControls.ejButton();
            this.TitleBar.SuspendLayout();
            this.VersionBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.pnlContainer.Location = new System.Drawing.Point(4, 57);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(548, 261);
            this.pnlContainer.TabIndex = 8;
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
            this.TitleBar.Controls.Add(this.cmdHide);
            this.TitleBar.Controls.Add(this.btnBrowserMin);
            this.TitleBar.Controls.Add(this.btnBrowserMax);
            this.TitleBar.Controls.Add(this.cmdPin);
            this.TitleBar.Controls.Add(this.btnOpenBrowserAndStartUrl);
            this.TitleBar.Controls.Add(this.cmdClose);
            this.TitleBar.Controls.Add(this.cmdMinimazeRestore);
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(795, 28);
            this.TitleBar.TabIndex = 47;
            this.TitleBar.DoubleClick += new System.EventHandler(this.Event_TitleBarDoubleClick);
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Event_TitleBarMouseDown);
            // 
            // cmdHide
            // 
            this.cmdHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdHide.BackColor = System.Drawing.Color.Black;
            this.cmdHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdHide.Image = global::EveJimaCore.Properties.Resources.hide;
            this.cmdHide.Location = new System.Drawing.Point(727, 1);
            this.cmdHide.Name = "cmdHide";
            this.cmdHide.Size = new System.Drawing.Size(22, 22);
            this.cmdHide.TabIndex = 49;
            this.cmdHide.UseVisualStyleBackColor = false;
            this.cmdHide.Click += new System.EventHandler(this.Event_Hide);
            // 
            // btnBrowserMin
            // 
            this.btnBrowserMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowserMin.BackColor = System.Drawing.Color.Black;
            this.btnBrowserMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowserMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowserMin.Image = global::EveJimaCore.Properties.Resources.minimize2;
            this.btnBrowserMin.Location = new System.Drawing.Point(383, 2);
            this.btnBrowserMin.Name = "btnBrowserMin";
            this.btnBrowserMin.Size = new System.Drawing.Size(22, 22);
            this.btnBrowserMin.TabIndex = 48;
            this.btnBrowserMin.UseVisualStyleBackColor = false;
            this.btnBrowserMin.Visible = false;
            this.btnBrowserMin.Click += new System.EventHandler(this.btnBrowserMin_Click);
            // 
            // btnBrowserMax
            // 
            this.btnBrowserMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowserMax.BackColor = System.Drawing.Color.Black;
            this.btnBrowserMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowserMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowserMax.Image = global::EveJimaCore.Properties.Resources.minimize1;
            this.btnBrowserMax.Location = new System.Drawing.Point(409, 2);
            this.btnBrowserMax.Name = "btnBrowserMax";
            this.btnBrowserMax.Size = new System.Drawing.Size(22, 22);
            this.btnBrowserMax.TabIndex = 47;
            this.btnBrowserMax.UseVisualStyleBackColor = false;
            this.btnBrowserMax.Visible = false;
            this.btnBrowserMax.Click += new System.EventHandler(this.btnBrowserMax_Click);
            // 
            // cmdPin
            // 
            this.cmdPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPin.BackColor = System.Drawing.Color.Black;
            this.cmdPin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdPin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPin.Image = global::EveJimaCore.Properties.Resources.pin;
            this.cmdPin.Location = new System.Drawing.Point(685, 1);
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
            this.btnOpenBrowserAndStartUrl.Location = new System.Drawing.Point(707, 1);
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
            this.cmdClose.Location = new System.Drawing.Point(767, 1);
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
            this.cmdMinimazeRestore.Location = new System.Drawing.Point(747, 1);
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
            // crlNotificay
            // 
            this.crlNotificay.Icon = ((System.Drawing.Icon)(resources.GetObject("crlNotificay.Icon")));
            this.crlNotificay.Text = "Eve JIma";
            this.crlNotificay.Visible = true;
            this.crlNotificay.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.crlNotificay_MouseDoubleClick);
            // 
            // RefreshActivePilot
            // 
            this.RefreshActivePilot.Enabled = true;
            this.RefreshActivePilot.Interval = 1000;
            this.RefreshActivePilot.Tick += new System.EventHandler(this.Event_RefreshActivePilot);
            // 
            // cmdVersion1
            // 
            this.cmdVersion1.AutoSize = true;
            this.cmdVersion1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdVersion1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdVersion1.FlatAppearance.BorderSize = 0;
            this.cmdVersion1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdVersion1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdVersion1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdVersion1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdVersion1.ForeColor = System.Drawing.Color.Silver;
            this.cmdVersion1.Location = new System.Drawing.Point(10, 408);
            this.cmdVersion1.Name = "cmdVersion1";
            this.cmdVersion1.Size = new System.Drawing.Size(63, 23);
            this.cmdVersion1.TabIndex = 72;
            this.cmdVersion1.Text = "Version";
            this.cmdVersion1.UseVisualStyleBackColor = true;
            this.cmdVersion1.Visible = false;
            // 
            // _mapToolbarControl1
            // 
            this._mapToolbarControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this._mapToolbarControl1.Location = new System.Drawing.Point(95, 592);
            this._mapToolbarControl1.Name = "_mapToolbarControl1";
            this._mapToolbarControl1.SelectedTab = "Authorization";
            this._mapToolbarControl1.Size = new System.Drawing.Size(448, 32);
            this._mapToolbarControl1.TabIndex = 71;
            this._mapToolbarControl1.Visible = false;
            // 
            // cmdOpenWebBrowser1
            // 
            this.cmdOpenWebBrowser1.AutoSize = true;
            this.cmdOpenWebBrowser1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdOpenWebBrowser1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdOpenWebBrowser1.FlatAppearance.BorderSize = 0;
            this.cmdOpenWebBrowser1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdOpenWebBrowser1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdOpenWebBrowser1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenWebBrowser1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenWebBrowser1.ForeColor = System.Drawing.Color.Silver;
            this.cmdOpenWebBrowser1.Location = new System.Drawing.Point(363, 31);
            this.cmdOpenWebBrowser1.Name = "cmdOpenWebBrowser1";
            this.cmdOpenWebBrowser1.Size = new System.Drawing.Size(91, 23);
            this.cmdOpenWebBrowser1.TabIndex = 70;
            this.cmdOpenWebBrowser1.Text = "Web Browser";
            this.cmdOpenWebBrowser1.UseVisualStyleBackColor = true;
            // 
            // cmdShowContainerBookmarks1
            // 
            this.cmdShowContainerBookmarks1.AutoSize = true;
            this.cmdShowContainerBookmarks1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdShowContainerBookmarks1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdShowContainerBookmarks1.FlatAppearance.BorderSize = 0;
            this.cmdShowContainerBookmarks1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdShowContainerBookmarks1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdShowContainerBookmarks1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdShowContainerBookmarks1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowContainerBookmarks1.ForeColor = System.Drawing.Color.Silver;
            this.cmdShowContainerBookmarks1.Location = new System.Drawing.Point(289, 31);
            this.cmdShowContainerBookmarks1.Name = "cmdShowContainerBookmarks1";
            this.cmdShowContainerBookmarks1.Size = new System.Drawing.Size(81, 23);
            this.cmdShowContainerBookmarks1.TabIndex = 69;
            this.cmdShowContainerBookmarks1.Text = "Bookmarks";
            this.cmdShowContainerBookmarks1.UseVisualStyleBackColor = true;
            // 
            // cmdShowContainerPilots1
            // 
            this.cmdShowContainerPilots1.AutoSize = true;
            this.cmdShowContainerPilots1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdShowContainerPilots1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdShowContainerPilots1.FlatAppearance.BorderSize = 0;
            this.cmdShowContainerPilots1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdShowContainerPilots1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdShowContainerPilots1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdShowContainerPilots1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowContainerPilots1.ForeColor = System.Drawing.Color.Silver;
            this.cmdShowContainerPilots1.Location = new System.Drawing.Point(245, 31);
            this.cmdShowContainerPilots1.Name = "cmdShowContainerPilots1";
            this.cmdShowContainerPilots1.Size = new System.Drawing.Size(48, 23);
            this.cmdShowContainerPilots1.TabIndex = 68;
            this.cmdShowContainerPilots1.Text = "Pilots";
            this.cmdShowContainerPilots1.UseVisualStyleBackColor = true;
            // 
            // cmdShowContainerSolarSystem1
            // 
            this.cmdShowContainerSolarSystem1.AutoSize = true;
            this.cmdShowContainerSolarSystem1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdShowContainerSolarSystem1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdShowContainerSolarSystem1.FlatAppearance.BorderSize = 0;
            this.cmdShowContainerSolarSystem1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdShowContainerSolarSystem1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdShowContainerSolarSystem1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdShowContainerSolarSystem1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowContainerSolarSystem1.ForeColor = System.Drawing.Color.Silver;
            this.cmdShowContainerSolarSystem1.Location = new System.Drawing.Point(159, 31);
            this.cmdShowContainerSolarSystem1.Name = "cmdShowContainerSolarSystem1";
            this.cmdShowContainerSolarSystem1.Size = new System.Drawing.Size(92, 23);
            this.cmdShowContainerSolarSystem1.TabIndex = 67;
            this.cmdShowContainerSolarSystem1.Text = "Solar System";
            this.cmdShowContainerSolarSystem1.UseVisualStyleBackColor = true;
            // 
            // cmdMap
            // 
            this.cmdMap.AutoSize = true;
            this.cmdMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdMap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdMap.FlatAppearance.BorderSize = 0;
            this.cmdMap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdMap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMap.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMap.ForeColor = System.Drawing.Color.DimGray;
            this.cmdMap.Location = new System.Drawing.Point(95, 31);
            this.cmdMap.Name = "cmdMap";
            this.cmdMap.Size = new System.Drawing.Size(65, 23);
            this.cmdMap.TabIndex = 66;
            this.cmdMap.Text = "Location";
            this.cmdMap.UseVisualStyleBackColor = true;
            // 
            // cmdAuthirizationPanel1
            // 
            this.cmdAuthirizationPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdAuthirizationPanel1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdAuthirizationPanel1.FlatAppearance.BorderSize = 0;
            this.cmdAuthirizationPanel1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdAuthirizationPanel1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdAuthirizationPanel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAuthirizationPanel1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAuthirizationPanel1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.cmdAuthirizationPanel1.Location = new System.Drawing.Point(4, 31);
            this.cmdAuthirizationPanel1.Name = "cmdAuthirizationPanel1";
            this.cmdAuthirizationPanel1.Size = new System.Drawing.Size(95, 23);
            this.cmdAuthirizationPanel1.TabIndex = 65;
            this.cmdAuthirizationPanel1.Text = "Authorization";
            this.cmdAuthirizationPanel1.UseVisualStyleBackColor = true;
            // 
            // WindowMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1443, 1053);
            this.Controls.Add(this.cmdVersion1);
            this.Controls.Add(this._mapToolbarControl1);
            this.Controls.Add(this.cmdOpenWebBrowser1);
            this.Controls.Add(this.cmdShowContainerBookmarks1);
            this.Controls.Add(this.cmdShowContainerPilots1);
            this.Controls.Add(this.cmdShowContainerSolarSystem1);
            this.Controls.Add(this.cmdMap);
            this.Controls.Add(this.cmdAuthirizationPanel1);
            this.Controls.Add(this.TitleBar);
            this.Controls.Add(this.VersionBar);
            this.Controls.Add(this.pnlContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WindowMonitoring";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EveJima";
            this.Activated += new System.EventHandler(this.WindowMonitoring_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindowMonitoring_FormClosing);
            this.Load += new System.EventHandler(this.WindowMonitoring_Load);
            this.Shown += new System.EventHandler(this.WindowMonitoring_Shown);
            this.ResizeEnd += new System.EventHandler(this.Event_WindowEndResize);
            this.LocationChanged += new System.EventHandler(this.Event_LocationChange);
            this.DoubleClick += new System.EventHandler(this.Event_WindowDoubleClick);
            this.Resize += new System.EventHandler(this.Event_WindowResize);
            this.TitleBar.ResumeLayout(false);
            this.VersionBar.ResumeLayout(false);
            this.VersionBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdMinimazeRestore;
        private System.Windows.Forms.Button cmdPin;
        //private System.Windows.Forms.Label lblSolarSystemName;
        public System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblVersionID;
        private System.Windows.Forms.Button btnOpenBrowserAndStartUrl;
        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.Panel VersionBar;
        private System.Windows.Forms.Label label1;
        private whlButton cmdVersion;
        private System.Windows.Forms.Button btnBrowserMax;
        private System.Windows.Forms.Button btnBrowserMin;
        private System.Windows.Forms.NotifyIcon crlNotificay;
        private System.Windows.Forms.Button cmdHide;
        private System.Windows.Forms.Timer RefreshActivePilot;
        private WhlControls.ejButton cmdAuthirizationPanel1;
        private WhlControls.ejButton cmdMap;
        private WhlControls.ejButton cmdShowContainerSolarSystem1;
        private WhlControls.ejButton cmdShowContainerPilots1;
        private WhlControls.ejButton cmdShowContainerBookmarks1;
        private WhlControls.ejButton cmdOpenWebBrowser1;
        private Logic.ToolBar.MapToolbarControl _mapToolbarControl1;
        private WhlControls.ejButton cmdVersion1;
    }
}