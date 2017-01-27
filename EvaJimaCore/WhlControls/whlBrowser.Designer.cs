namespace EveJimaCore.WhlControls
{
    partial class whlBrowser
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.cmdBookmark = new System.Windows.Forms.Button();
            this.cmdBlank = new System.Windows.Forms.Button();
            this.cmdFavorits = new System.Windows.Forms.Button();
            this.loadingGif = new System.Windows.Forms.PictureBox();
            this.BrowserCommandExecute = new System.Windows.Forms.Button();
            this.BrowserCommandRefresh = new System.Windows.Forms.Button();
            this.BrowserCommandForward = new System.Windows.Forms.Button();
            this.BrowserCommandBack = new System.Windows.Forms.Button();
            this.browserTabControl = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.cmdAddTabb = new System.Windows.Forms.Button();
            this.cmdCloseTab = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGif)).BeginInit();
            this.browserTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.BackColor = System.Drawing.Color.DimGray;
            this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUrl.Font = new System.Drawing.Font("Verdana", 12F);
            this.txtUrl.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtUrl.Location = new System.Drawing.Point(247, 14);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(629, 20);
            this.txtUrl.TabIndex = 52;
            this.txtUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUrl_KeyDown);
            // 
            // cmdBookmark
            // 
            this.cmdBookmark.BackColor = System.Drawing.Color.Black;
            this.cmdBookmark.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdBookmark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBookmark.Image = global::EveJimaCore.Properties.Resources.not_bookmark;
            this.cmdBookmark.Location = new System.Drawing.Point(103, 12);
            this.cmdBookmark.Name = "cmdBookmark";
            this.cmdBookmark.Size = new System.Drawing.Size(22, 22);
            this.cmdBookmark.TabIndex = 59;
            this.cmdBookmark.UseVisualStyleBackColor = false;
            this.cmdBookmark.Click += new System.EventHandler(this.Event_ClickBookmarkButton);
            // 
            // cmdBlank
            // 
            this.cmdBlank.BackColor = System.Drawing.Color.Black;
            this.cmdBlank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdBlank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBlank.Image = global::EveJimaCore.Properties.Resources.new_document_button;
            this.cmdBlank.Location = new System.Drawing.Point(127, 12);
            this.cmdBlank.Name = "cmdBlank";
            this.cmdBlank.Size = new System.Drawing.Size(22, 22);
            this.cmdBlank.TabIndex = 58;
            this.cmdBlank.UseVisualStyleBackColor = false;
            this.cmdBlank.Click += new System.EventHandler(this.Event_NavigateToBlank);
            // 
            // cmdFavorits
            // 
            this.cmdFavorits.BackColor = System.Drawing.Color.Black;
            this.cmdFavorits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdFavorits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFavorits.Image = global::EveJimaCore.Properties.Resources.book_with_bookmark;
            this.cmdFavorits.Location = new System.Drawing.Point(79, 12);
            this.cmdFavorits.Name = "cmdFavorits";
            this.cmdFavorits.Size = new System.Drawing.Size(22, 22);
            this.cmdFavorits.TabIndex = 57;
            this.cmdFavorits.UseVisualStyleBackColor = false;
            this.cmdFavorits.Click += new System.EventHandler(this.cmdFavorits_Click);
            // 
            // loadingGif
            // 
            this.loadingGif.Image = global::EveJimaCore.Properties.Resources.tumblr_n8iuseEKSr1tg7xcdo1_500;
            this.loadingGif.Location = new System.Drawing.Point(-466, 604);
            this.loadingGif.Name = "loadingGif";
            this.loadingGif.Size = new System.Drawing.Size(500, 281);
            this.loadingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.loadingGif.TabIndex = 17;
            this.loadingGif.TabStop = false;
            this.loadingGif.Visible = false;
            // 
            // BrowserCommandExecute
            // 
            this.BrowserCommandExecute.BackColor = System.Drawing.Color.Black;
            this.BrowserCommandExecute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BrowserCommandExecute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowserCommandExecute.Image = global::EveJimaCore.Properties.Resources.browser_execute;
            this.BrowserCommandExecute.Location = new System.Drawing.Point(219, 12);
            this.BrowserCommandExecute.Name = "BrowserCommandExecute";
            this.BrowserCommandExecute.Size = new System.Drawing.Size(22, 22);
            this.BrowserCommandExecute.TabIndex = 54;
            this.BrowserCommandExecute.UseVisualStyleBackColor = false;
            this.BrowserCommandExecute.Click += new System.EventHandler(this.BrowserCommandExecute_Click);
            // 
            // BrowserCommandRefresh
            // 
            this.BrowserCommandRefresh.BackColor = System.Drawing.Color.Black;
            this.BrowserCommandRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BrowserCommandRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowserCommandRefresh.Image = global::EveJimaCore.Properties.Resources.browser_refresh;
            this.BrowserCommandRefresh.Location = new System.Drawing.Point(54, 12);
            this.BrowserCommandRefresh.Name = "BrowserCommandRefresh";
            this.BrowserCommandRefresh.Size = new System.Drawing.Size(22, 22);
            this.BrowserCommandRefresh.TabIndex = 55;
            this.BrowserCommandRefresh.UseVisualStyleBackColor = false;
            this.BrowserCommandRefresh.Click += new System.EventHandler(this.BrowserCommandRefresh_Click);
            // 
            // BrowserCommandForward
            // 
            this.BrowserCommandForward.BackColor = System.Drawing.Color.Black;
            this.BrowserCommandForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BrowserCommandForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowserCommandForward.Image = global::EveJimaCore.Properties.Resources.browser_forward;
            this.BrowserCommandForward.Location = new System.Drawing.Point(33, 12);
            this.BrowserCommandForward.Name = "BrowserCommandForward";
            this.BrowserCommandForward.Size = new System.Drawing.Size(22, 22);
            this.BrowserCommandForward.TabIndex = 56;
            this.BrowserCommandForward.UseVisualStyleBackColor = false;
            this.BrowserCommandForward.Click += new System.EventHandler(this.BrowserCommandForward_Click);
            // 
            // BrowserCommandBack
            // 
            this.BrowserCommandBack.BackColor = System.Drawing.Color.Black;
            this.BrowserCommandBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BrowserCommandBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowserCommandBack.Image = global::EveJimaCore.Properties.Resources.browser_back;
            this.BrowserCommandBack.Location = new System.Drawing.Point(12, 12);
            this.BrowserCommandBack.Name = "BrowserCommandBack";
            this.BrowserCommandBack.Size = new System.Drawing.Size(22, 22);
            this.BrowserCommandBack.TabIndex = 53;
            this.BrowserCommandBack.UseVisualStyleBackColor = false;
            this.BrowserCommandBack.Click += new System.EventHandler(this.BrowserCommandBack_Click);
            // 
            // browserTabControl
            // 
            this.browserTabControl.Controls.Add(this.tabControl1);
            this.browserTabControl.Location = new System.Drawing.Point(18, 52);
            this.browserTabControl.Name = "browserTabControl";
            this.browserTabControl.Size = new System.Drawing.Size(858, 569);
            this.browserTabControl.TabIndex = 60;
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(450, 295);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            // 
            // cmdAddTabb
            // 
            this.cmdAddTabb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdAddTabb.Location = new System.Drawing.Point(155, 14);
            this.cmdAddTabb.Name = "cmdAddTabb";
            this.cmdAddTabb.Size = new System.Drawing.Size(20, 20);
            this.cmdAddTabb.TabIndex = 61;
            this.cmdAddTabb.Text = "+";
            this.cmdAddTabb.UseVisualStyleBackColor = true;
            this.cmdAddTabb.Click += new System.EventHandler(this.Event_AddNewTab);
            // 
            // cmdCloseTab
            // 
            this.cmdCloseTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCloseTab.Location = new System.Drawing.Point(181, 14);
            this.cmdCloseTab.Name = "cmdCloseTab";
            this.cmdCloseTab.Size = new System.Drawing.Size(20, 20);
            this.cmdCloseTab.TabIndex = 62;
            this.cmdCloseTab.Text = "-";
            this.cmdCloseTab.UseVisualStyleBackColor = true;
            this.cmdCloseTab.Click += new System.EventHandler(this.Event_CloseTab);
            // 
            // whlBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmdCloseTab);
            this.Controls.Add(this.cmdAddTabb);
            this.Controls.Add(this.browserTabControl);
            this.Controls.Add(this.cmdBookmark);
            this.Controls.Add(this.cmdBlank);
            this.Controls.Add(this.cmdFavorits);
            this.Controls.Add(this.loadingGif);
            this.Controls.Add(this.BrowserCommandExecute);
            this.Controls.Add(this.BrowserCommandRefresh);
            this.Controls.Add(this.BrowserCommandForward);
            this.Controls.Add(this.BrowserCommandBack);
            this.Controls.Add(this.txtUrl);
            this.Name = "whlBrowser";
            this.Size = new System.Drawing.Size(896, 640);
            ((System.ComponentModel.ISupportInitialize)(this.loadingGif)).EndInit();
            this.browserTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox loadingGif;
        private System.Windows.Forms.Button BrowserCommandExecute;
        private System.Windows.Forms.Button BrowserCommandRefresh;
        private System.Windows.Forms.Button BrowserCommandForward;
        private System.Windows.Forms.Button BrowserCommandBack;
        public System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button cmdFavorits;
        private System.Windows.Forms.Button cmdBlank;
        private System.Windows.Forms.Button cmdBookmark;
        private System.Windows.Forms.Panel browserTabControl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button cmdAddTabb;
        private System.Windows.Forms.Button cmdCloseTab;
    }
}
