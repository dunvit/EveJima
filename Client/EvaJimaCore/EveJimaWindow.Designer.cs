namespace EveJimaCore
{
    sealed partial class EveJimaWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EveJimaWindow));
            this.eveJimaToolbar1 = new EveJimaCore.Main.EveJimaToolbar(this);
            this.crlTitlebar = new EveJimaCore.Main.EveJimaTitlebar();
            this.crlNotificay = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // eveJimaToolbar1
            // 
            this.eveJimaToolbar1.ActivePanelName = null;
            this.eveJimaToolbar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eveJimaToolbar1.BackColor = System.Drawing.Color.Black;
            this.eveJimaToolbar1.Location = new System.Drawing.Point(2, 29);
            this.eveJimaToolbar1.Name = "eveJimaToolbar1";
            this.eveJimaToolbar1.Size = new System.Drawing.Size(1173, 411);
            this.eveJimaToolbar1.TabIndex = 1;
            // 
            // crlTitlebar
            // 
            this.crlTitlebar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crlTitlebar.BackColor = System.Drawing.Color.Black;
            this.crlTitlebar.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.crlTitlebar.Location = new System.Drawing.Point(2, 1);
            this.crlTitlebar.Name = "crlTitlebar";
            this.crlTitlebar.Size = new System.Drawing.Size(1173, 27);
            this.crlTitlebar.TabIndex = 3;
            // 
            // crlNotificay
            // 
            this.crlNotificay.Icon = ((System.Drawing.Icon)(resources.GetObject("crlNotificay.Icon")));
            this.crlNotificay.Text = "Eve JIma";
            this.crlNotificay.Visible = true;
            this.crlNotificay.Click += new System.EventHandler(this.Event_RestoreApplicationFromTray);
            this.crlNotificay.DoubleClick += new System.EventHandler(this.Event_RestoreApplicationFromTray);
            // 
            // EveJimaWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1177, 442);
            this.Controls.Add(this.eveJimaToolbar1);
            this.Controls.Add(this.crlTitlebar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EveJimaWindow";
            this.Text = "EveJimaWindow";
            this.Activated += new System.EventHandler(this.Event_ActivateWindow);
            this.LocationChanged += new System.EventHandler(this.Event_LocationChange);
            this.Resize += new System.EventHandler(this.EveJimaWindow_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private Main.EveJimaToolbar eveJimaToolbar1;
        private Main.EveJimaTitlebar crlTitlebar;
        private System.Windows.Forms.NotifyIcon crlNotificay;
    }
}