
namespace EveJimaCore
{
    partial class MainEveJima
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainEveJima));
            this.TitleBar = new System.Windows.Forms.Panel();
            this.cmdHide = new System.Windows.Forms.Button();
            this.cmdPin = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdMinimazeRestore = new System.Windows.Forms.Button();
            this.pnlContainers = new System.Windows.Forms.Panel();
            this.crlNotificay = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerCheckClipboard = new System.Windows.Forms.Timer(this.components);
            this.RefreshActivePilot = new System.Windows.Forms.Timer(this.components);
            this.timerRefreshTitleBar = new System.Windows.Forms.Timer(this.components);
            this.crlToolbar = new EveJimaCore.Logic.ToolBar.MapToolbarControl();
            this.TitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.Black;
            this.TitleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleBar.Controls.Add(this.cmdHide);
            this.TitleBar.Controls.Add(this.cmdPin);
            this.TitleBar.Controls.Add(this.cmdClose);
            this.TitleBar.Controls.Add(this.cmdMinimazeRestore);
            this.TitleBar.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(795, 28);
            this.TitleBar.TabIndex = 48;
            this.TitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.Event_Toolbar_Paint);
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
            this.cmdHide.Click += new System.EventHandler(this.cmdHide_Click);
            // 
            // cmdPin
            // 
            this.cmdPin.BackColor = System.Drawing.Color.Black;
            this.cmdPin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdPin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPin.Image = global::EveJimaCore.Properties.Resources.pin;
            this.cmdPin.Location = new System.Drawing.Point(3, 1);
            this.cmdPin.Name = "cmdPin";
            this.cmdPin.Size = new System.Drawing.Size(22, 22);
            this.cmdPin.TabIndex = 3;
            this.cmdPin.UseVisualStyleBackColor = false;
            this.cmdPin.Click += new System.EventHandler(this.cmdPin_Click);
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
            this.cmdClose.Click += new System.EventHandler(this.Event_CloseApplication);
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
            this.cmdMinimazeRestore.Click += new System.EventHandler(this.Event_TitleBarDoubleClick);
            // 
            // pnlContainers
            // 
            this.pnlContainers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.pnlContainers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContainers.Location = new System.Drawing.Point(9, 61);
            this.pnlContainers.Name = "pnlContainers";
            this.pnlContainers.Size = new System.Drawing.Size(777, 230);
            this.pnlContainers.TabIndex = 49;
            // 
            // crlNotificay
            // 
            this.crlNotificay.Icon = ((System.Drawing.Icon)(resources.GetObject("crlNotificay.Icon")));
            this.crlNotificay.Text = "Eve JIma";
            this.crlNotificay.Visible = true;
            this.crlNotificay.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.crlNotificay_MouseDoubleClick);
            // 
            // timerCheckClipboard
            // 
            this.timerCheckClipboard.Enabled = true;
            this.timerCheckClipboard.Tick += new System.EventHandler(this.timerCheckClipboard_Tick);
            // 
            // RefreshActivePilot
            // 
            this.RefreshActivePilot.Enabled = true;
            this.RefreshActivePilot.Interval = 1000;
            this.RefreshActivePilot.Tick += new System.EventHandler(this.RefreshActivePilot_Tick);
            // 
            // timerRefreshTitleBar
            // 
            this.timerRefreshTitleBar.Enabled = true;
            this.timerRefreshTitleBar.Interval = 1000;
            this.timerRefreshTitleBar.Tick += new System.EventHandler(this.timerRefreshTitleBar_Tick);
            // 
            // crlToolbar
            // 
            this.crlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.crlToolbar.Location = new System.Drawing.Point(7, 39);
            this.crlToolbar.Name = "crlToolbar";
            this.crlToolbar.SelectedTab = null;
            this.crlToolbar.Size = new System.Drawing.Size(512, 16);
            this.crlToolbar.TabIndex = 50;
            // 
            // MainEveJima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(795, 300);
            this.Controls.Add(this.crlToolbar);
            this.Controls.Add(this.pnlContainers);
            this.Controls.Add(this.TitleBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainEveJima";
            this.Text = "EveJima v2.06";
            this.Activated += new System.EventHandler(this.Event_ActivateWindow);
            this.Load += new System.EventHandler(this.MainEveJima_Load);
            this.ResizeBegin += new System.EventHandler(this.Event_ResizeWindowEnd);
            this.ResizeEnd += new System.EventHandler(this.Event_ResizeWindowEnd);
            this.LocationChanged += new System.EventHandler(this.Event_LocationChangedWindow);
            this.Resize += new System.EventHandler(this.Event_ResizeWindow);
            this.TitleBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.Button cmdHide;
        private System.Windows.Forms.Button cmdPin;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdMinimazeRestore;
        private System.Windows.Forms.Panel pnlContainers;
        private System.Windows.Forms.NotifyIcon crlNotificay;
        private System.Windows.Forms.Timer timerCheckClipboard;
        private System.Windows.Forms.Timer RefreshActivePilot;
        private System.Windows.Forms.Timer timerRefreshTitleBar;
        private Logic.ToolBar.MapToolbarControl crlToolbar;
    }
}