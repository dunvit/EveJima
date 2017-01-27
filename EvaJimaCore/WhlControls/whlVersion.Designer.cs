namespace EveJimaCore.WhlControls
{
    partial class whlVersion
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
            this.browserTabControl = new System.Windows.Forms.Panel();
            this.cmdPasteCosmicSifnatures = new whlButton();
            this.SuspendLayout();
            // 
            // browserTabControl
            // 
            this.browserTabControl.BackColor = System.Drawing.Color.LightGray;
            this.browserTabControl.Location = new System.Drawing.Point(11, 6);
            this.browserTabControl.Name = "browserTabControl";
            this.browserTabControl.Size = new System.Drawing.Size(857, 450);
            this.browserTabControl.TabIndex = 61;
            // 
            // cmdPasteCosmicSifnatures
            // 
            this.cmdPasteCosmicSifnatures.BackColor = System.Drawing.Color.Black;
            this.cmdPasteCosmicSifnatures.ForeColor = System.Drawing.Color.LightGray;
            this.cmdPasteCosmicSifnatures.IsActive = true;
            this.cmdPasteCosmicSifnatures.IsTabControlButton = false;
            this.cmdPasteCosmicSifnatures.Location = new System.Drawing.Point(269, 466);
            this.cmdPasteCosmicSifnatures.Name = "cmdPasteCosmicSifnatures";
            this.cmdPasteCosmicSifnatures.Size = new System.Drawing.Size(277, 26);
            this.cmdPasteCosmicSifnatures.TabIndex = 77;
            this.cmdPasteCosmicSifnatures.Value = "Update version";
            this.cmdPasteCosmicSifnatures.Click += new System.EventHandler(this.Event_StartUpdateVersion);
            // 
            // whlVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmdPasteCosmicSifnatures);
            this.Controls.Add(this.browserTabControl);
            this.Name = "whlVersion";
            this.Size = new System.Drawing.Size(880, 502);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel browserTabControl;
        private whlButton cmdPasteCosmicSifnatures;
    }
}
