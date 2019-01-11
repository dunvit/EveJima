namespace EveJimaCore.WhlControls
{
    partial class ControlRichBrowser
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
            EveJimaIGB.Bookmarks.Favorites favorites1 = new EveJimaIGB.Bookmarks.Favorites();
            this.igBrowser1 = new EveJimaIGB.IGBrowser();
            this.SuspendLayout();
            // 
            // igBrowser1
            // 
            this.igBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.igBrowser1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.igBrowser1.Favorites = favorites1;
            this.igBrowser1.IsOpenKillBoardInNewTab = false;
            this.igBrowser1.IsShowFavorites = false;
            this.igBrowser1.Location = new System.Drawing.Point(0, 0);
            this.igBrowser1.Name = "igBrowser1";
            this.igBrowser1.Size = new System.Drawing.Size(907, 412);
            this.igBrowser1.TabIndex = 0;
            // 
            // ControlRichBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.igBrowser1);
            this.DoubleBuffered = true;
            this.Name = "ControlRichBrowser";
            this.Size = new System.Drawing.Size(907, 435);
            this.Load += new System.EventHandler(this.ucRichBrowser_Load);
            this.Resize += new System.EventHandler(this.ControlRichBrowser_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private EveJimaIGB.IGBrowser igBrowser1;
    }
}
