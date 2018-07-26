namespace EveJimaCore.WhlControls
{
    partial class eveCrlTravelHistory
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
            this.lblHelp = new System.Windows.Forms.Label();
            this.cmdExecute = new EveJimaCore.whlButton();
            this.pnlNewSignaturesResults = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listCosmicSignatures = new System.Windows.Forms.ListBox();
            this.txtNewSignaturesLabel = new System.Windows.Forms.Label();
            this.pnlNewSignaturesResults.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHelp
            // 
            this.lblHelp.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.ForeColor = System.Drawing.Color.Gray;
            this.lblHelp.Location = new System.Drawing.Point(75, 39);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(401, 151);
            this.lblHelp.TabIndex = 160;
            this.lblHelp.Text = "For copy all signatures of current solar system click to signatures in Eve Online" +
    ", select all (CRL+A) and copy to clipboard (CRL-C). After this click on button \"" +
    "Show new signatures\" in this control.";
            // 
            // cmdExecute
            // 
            this.cmdExecute.BackColor = System.Drawing.Color.Black;
            this.cmdExecute.ForeColor = System.Drawing.Color.LightGray;
            this.cmdExecute.IsActive = true;
            this.cmdExecute.IsTabControlButton = false;
            this.cmdExecute.Location = new System.Drawing.Point(170, 204);
            this.cmdExecute.Name = "cmdExecute";
            this.cmdExecute.Size = new System.Drawing.Size(211, 26);
            this.cmdExecute.TabIndex = 161;
            this.cmdExecute.Value = "Show new signatures";
            this.cmdExecute.Click += new System.EventHandler(this.Event_ShowNewSignatures);
            // 
            // pnlNewSignaturesResults
            // 
            this.pnlNewSignaturesResults.Controls.Add(this.panel1);
            this.pnlNewSignaturesResults.Controls.Add(this.txtNewSignaturesLabel);
            this.pnlNewSignaturesResults.Location = new System.Drawing.Point(54, 3);
            this.pnlNewSignaturesResults.Name = "pnlNewSignaturesResults";
            this.pnlNewSignaturesResults.Size = new System.Drawing.Size(443, 187);
            this.pnlNewSignaturesResults.TabIndex = 162;
            this.pnlNewSignaturesResults.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.panel1.Controls.Add(this.listCosmicSignatures);
            this.panel1.Location = new System.Drawing.Point(19, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 154);
            this.panel1.TabIndex = 83;
            // 
            // listCosmicSignatures
            // 
            this.listCosmicSignatures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.listCosmicSignatures.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listCosmicSignatures.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.listCosmicSignatures.ForeColor = System.Drawing.Color.LightGray;
            this.listCosmicSignatures.FormattingEnabled = true;
            this.listCosmicSignatures.ItemHeight = 18;
            this.listCosmicSignatures.Location = new System.Drawing.Point(3, 11);
            this.listCosmicSignatures.Name = "listCosmicSignatures";
            this.listCosmicSignatures.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listCosmicSignatures.Size = new System.Drawing.Size(406, 144);
            this.listCosmicSignatures.TabIndex = 81;
            // 
            // txtNewSignaturesLabel
            // 
            this.txtNewSignaturesLabel.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewSignaturesLabel.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtNewSignaturesLabel.Location = new System.Drawing.Point(24, 8);
            this.txtNewSignaturesLabel.Name = "txtNewSignaturesLabel";
            this.txtNewSignaturesLabel.Size = new System.Drawing.Size(398, 23);
            this.txtNewSignaturesLabel.TabIndex = 82;
            this.txtNewSignaturesLabel.Text = "Signatures in last visit";
            this.txtNewSignaturesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eveCrlTravelHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.pnlNewSignaturesResults);
            this.Controls.Add(this.cmdExecute);
            this.Controls.Add(this.lblHelp);
            this.Name = "eveCrlTravelHistory";
            this.Size = new System.Drawing.Size(550, 250);
            this.Load += new System.EventHandler(this.eveCrlTravelHistory_Load);
            this.pnlNewSignaturesResults.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblHelp;
        private whlButton cmdExecute;
        private System.Windows.Forms.Panel pnlNewSignaturesResults;
        private System.Windows.Forms.Label txtNewSignaturesLabel;
        private System.Windows.Forms.ListBox listCosmicSignatures;
        private System.Windows.Forms.Panel panel1;
    }
}
