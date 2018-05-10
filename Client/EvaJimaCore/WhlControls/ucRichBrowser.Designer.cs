namespace EveJimaCore.WhlControls
{
    partial class ucRichBrowser
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
            this.igBrowser1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.igBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.igBrowser1.Favorites = favorites1;
            this.igBrowser1.IsShowFavorites = false;
            this.igBrowser1.Location = new System.Drawing.Point(0, 0);
            this.igBrowser1.Name = "igBrowser1";
            this.igBrowser1.Size = new System.Drawing.Size(907, 435);
            this.igBrowser1.TabIndex = 0;
            // 
            // ucRichBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.igBrowser1);
            this.DoubleBuffered = true;
            this.Name = "ucRichBrowser";
            this.Size = new System.Drawing.Size(907, 435);
            this.Load += new System.EventHandler(this.ucRichBrowser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EveJimaIGB.IGBrowser igBrowser1;
    }
}
