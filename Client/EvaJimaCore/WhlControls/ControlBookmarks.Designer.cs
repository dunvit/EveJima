namespace EveJimaCore.WhlControls
{
    partial class ControlBookmarks
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
            this.cmdPasteCosmicSifnatures = new EveJimaCore.whlButton();
            this.cmdPasteLocationBookmarks = new EveJimaCore.whlButton();
            this.cmdClear = new EveJimaCore.whlButton();
            this.cmdClearLists = new EveJimaCore.whlButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listCosmicSifnatures
            // 
            this.listCosmicSifnatures.BackColor = System.Drawing.Color.Black;
            this.listCosmicSifnatures.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listCosmicSifnatures.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.listCosmicSifnatures.ForeColor = System.Drawing.Color.LightGray;
            this.listCosmicSifnatures.FormattingEnabled = true;
            this.listCosmicSifnatures.Location = new System.Drawing.Point(287, 39);
            this.listCosmicSifnatures.Name = "listCosmicSifnatures";
            this.listCosmicSifnatures.Size = new System.Drawing.Size(267, 169);
            this.listCosmicSifnatures.TabIndex = 54;
            // 
            // listLocationBookmarks
            // 
            this.listLocationBookmarks.BackColor = System.Drawing.Color.Black;
            this.listLocationBookmarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listLocationBookmarks.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.listLocationBookmarks.ForeColor = System.Drawing.Color.LightGray;
            this.listLocationBookmarks.FormattingEnabled = true;
            this.listLocationBookmarks.Location = new System.Drawing.Point(14, 39);
            this.listLocationBookmarks.Name = "listLocationBookmarks";
            this.listLocationBookmarks.Size = new System.Drawing.Size(264, 169);
            this.listLocationBookmarks.TabIndex = 53;
            // 
            // cmdPasteCosmicSifnatures
            // 
            this.cmdPasteCosmicSifnatures.BackColor = System.Drawing.Color.Black;
            this.cmdPasteCosmicSifnatures.ForeColor = System.Drawing.Color.LightGray;
            this.cmdPasteCosmicSifnatures.IsActive = true;
            this.cmdPasteCosmicSifnatures.IsTabControlButton = false;
            this.cmdPasteCosmicSifnatures.Location = new System.Drawing.Point(349, 222);
            this.cmdPasteCosmicSifnatures.Name = "cmdPasteCosmicSifnatures";
            this.cmdPasteCosmicSifnatures.Size = new System.Drawing.Size(205, 26);
            this.cmdPasteCosmicSifnatures.TabIndex = 59;
            this.cmdPasteCosmicSifnatures.Value = "Paste Cosmic Signatures";
            this.cmdPasteCosmicSifnatures.Click += new System.EventHandler(this.Event_PasteSignatures);
            // 
            // cmdPasteLocationBookmarks
            // 
            this.cmdPasteLocationBookmarks.BackColor = System.Drawing.Color.Black;
            this.cmdPasteLocationBookmarks.ForeColor = System.Drawing.Color.LightGray;
            this.cmdPasteLocationBookmarks.IsActive = true;
            this.cmdPasteLocationBookmarks.IsTabControlButton = false;
            this.cmdPasteLocationBookmarks.Location = new System.Drawing.Point(14, 222);
            this.cmdPasteLocationBookmarks.Name = "cmdPasteLocationBookmarks";
            this.cmdPasteLocationBookmarks.Size = new System.Drawing.Size(205, 26);
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
            this.cmdClear.Location = new System.Drawing.Point(225, 222);
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
            this.cmdClearLists.Location = new System.Drawing.Point(601, 360);
            this.cmdClearLists.Name = "cmdClearLists";
            this.cmdClearLists.Size = new System.Drawing.Size(126, 26);
            this.cmdClearLists.TabIndex = 60;
            this.cmdClearLists.Value = "Clear";
            this.cmdClearLists.Click += new System.EventHandler(this.Event_ClearLists);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 61;
            this.label1.Text = "Need to scan:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(284, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 62;
            this.label2.Text = "Need to delete:";
            this.label2.Visible = false;
            // 
            // ControlBookmarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClearLists);
            this.Controls.Add(this.cmdPasteCosmicSifnatures);
            this.Controls.Add(this.cmdPasteLocationBookmarks);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.listCosmicSifnatures);
            this.Controls.Add(this.listLocationBookmarks);
            this.DoubleBuffered = true;
            this.Name = "ControlBookmarks";
            this.Size = new System.Drawing.Size(571, 256);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listCosmicSifnatures;
        private System.Windows.Forms.ListBox listLocationBookmarks;
        private whlButton cmdClear;
        private whlButton cmdPasteLocationBookmarks;
        private whlButton cmdPasteCosmicSifnatures;
        private whlButton cmdClearLists;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
