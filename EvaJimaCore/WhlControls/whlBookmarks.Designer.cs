namespace EveJimaCore.WhlControls
{
    partial class whlBookmarks
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
            this.listCosmicSifnatures = new System.Windows.Forms.ListBox();
            this.listLocationBookmarks = new System.Windows.Forms.ListBox();
            this.cmdPasteCosmicSifnatures = new whlButton();
            this.cmdPasteLocationBookmarks = new whlButton();
            this.cmdClear = new whlButton();
            this.cmdClearLists = new whlButton();
            this.SuspendLayout();
            // 
            // listCosmicSifnatures
            // 
            this.listCosmicSifnatures.BackColor = System.Drawing.Color.Black;
            this.listCosmicSifnatures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listCosmicSifnatures.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.listCosmicSifnatures.ForeColor = System.Drawing.Color.LightGray;
            this.listCosmicSifnatures.FormattingEnabled = true;
            this.listCosmicSifnatures.Location = new System.Drawing.Point(338, 19);
            this.listCosmicSifnatures.Name = "listCosmicSifnatures";
            this.listCosmicSifnatures.Size = new System.Drawing.Size(182, 158);
            this.listCosmicSifnatures.TabIndex = 54;
            // 
            // listLocationBookmarks
            // 
            this.listLocationBookmarks.BackColor = System.Drawing.Color.Black;
            this.listLocationBookmarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listLocationBookmarks.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.listLocationBookmarks.ForeColor = System.Drawing.Color.LightGray;
            this.listLocationBookmarks.FormattingEnabled = true;
            this.listLocationBookmarks.Location = new System.Drawing.Point(20, 19);
            this.listLocationBookmarks.Name = "listLocationBookmarks";
            this.listLocationBookmarks.Size = new System.Drawing.Size(182, 158);
            this.listLocationBookmarks.TabIndex = 53;
            // 
            // cmdPasteCosmicSifnatures
            // 
            this.cmdPasteCosmicSifnatures.BackColor = System.Drawing.Color.Black;
            this.cmdPasteCosmicSifnatures.ForeColor = System.Drawing.Color.LightGray;
            this.cmdPasteCosmicSifnatures.IsActive = true;
            this.cmdPasteCosmicSifnatures.IsTabControlButton = false;
            this.cmdPasteCosmicSifnatures.Location = new System.Drawing.Point(338, 183);
            this.cmdPasteCosmicSifnatures.Name = "cmdPasteCosmicSifnatures";
            this.cmdPasteCosmicSifnatures.Size = new System.Drawing.Size(182, 26);
            this.cmdPasteCosmicSifnatures.TabIndex = 59;
            this.cmdPasteCosmicSifnatures.Value = "Paste Cosmic Sifnatures";
            this.cmdPasteCosmicSifnatures.Click += new System.EventHandler(this.Event_PasteSignatures);
            // 
            // cmdPasteLocationBookmarks
            // 
            this.cmdPasteLocationBookmarks.BackColor = System.Drawing.Color.Black;
            this.cmdPasteLocationBookmarks.ForeColor = System.Drawing.Color.LightGray;
            this.cmdPasteLocationBookmarks.IsActive = true;
            this.cmdPasteLocationBookmarks.IsTabControlButton = false;
            this.cmdPasteLocationBookmarks.Location = new System.Drawing.Point(20, 183);
            this.cmdPasteLocationBookmarks.Name = "cmdPasteLocationBookmarks";
            this.cmdPasteLocationBookmarks.Size = new System.Drawing.Size(182, 26);
            this.cmdPasteLocationBookmarks.TabIndex = 58;
            this.cmdPasteLocationBookmarks.Value = "Paste Location Bookmarks";
            this.cmdPasteLocationBookmarks.Click += new System.EventHandler(this.Event_PasteBookmarks);
            // 
            // cmdClear
            // 
            this.cmdClear.BackColor = System.Drawing.Color.Black;
            this.cmdClear.ForeColor = System.Drawing.Color.LightGray;
            this.cmdClear.IsActive = true;
            this.cmdClear.IsTabControlButton = false;
            this.cmdClear.Location = new System.Drawing.Point(214, 19);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(114, 26);
            this.cmdClear.TabIndex = 57;
            this.cmdClear.Value = "Analyze";
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdClearLists
            // 
            this.cmdClearLists.BackColor = System.Drawing.Color.Black;
            this.cmdClearLists.ForeColor = System.Drawing.Color.LightGray;
            this.cmdClearLists.IsActive = true;
            this.cmdClearLists.IsTabControlButton = false;
            this.cmdClearLists.Location = new System.Drawing.Point(214, 183);
            this.cmdClearLists.Name = "cmdClearLists";
            this.cmdClearLists.Size = new System.Drawing.Size(114, 26);
            this.cmdClearLists.TabIndex = 60;
            this.cmdClearLists.Value = "Clear";
            this.cmdClearLists.Click += new System.EventHandler(this.Event_ClearLists);
            // 
            // whlBookmarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmdClearLists);
            this.Controls.Add(this.cmdPasteCosmicSifnatures);
            this.Controls.Add(this.cmdPasteLocationBookmarks);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.listCosmicSifnatures);
            this.Controls.Add(this.listLocationBookmarks);
            this.Name = "whlBookmarks";
            this.Size = new System.Drawing.Size(540, 222);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listCosmicSifnatures;
        private System.Windows.Forms.ListBox listLocationBookmarks;
        private whlButton cmdClear;
        private whlButton cmdPasteLocationBookmarks;
        private whlButton cmdPasteCosmicSifnatures;
        private whlButton cmdClearLists;
    }
}
