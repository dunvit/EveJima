namespace EveJimaCore.WhlControls
{
    partial class whlTravelHistory
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
            this.listHistorySignatures = new System.Windows.Forms.ListBox();
            this.txtSolarSystemStaticIData = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdAnalize = new whlButton();
            this.cmdPasteCosmicSifnatures = new whlButton();
            this.cmdTravelHistory = new whlButton();
            this.SuspendLayout();
            // 
            // listCosmicSifnatures
            // 
            this.listCosmicSifnatures.BackColor = System.Drawing.Color.Black;
            this.listCosmicSifnatures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listCosmicSifnatures.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.listCosmicSifnatures.ForeColor = System.Drawing.Color.LightGray;
            this.listCosmicSifnatures.FormattingEnabled = true;
            this.listCosmicSifnatures.Location = new System.Drawing.Point(192, 30);
            this.listCosmicSifnatures.Name = "listCosmicSifnatures";
            this.listCosmicSifnatures.Size = new System.Drawing.Size(176, 184);
            this.listCosmicSifnatures.TabIndex = 75;
            // 
            // listHistorySignatures
            // 
            this.listHistorySignatures.BackColor = System.Drawing.Color.Black;
            this.listHistorySignatures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listHistorySignatures.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.listHistorySignatures.ForeColor = System.Drawing.Color.LightGray;
            this.listHistorySignatures.FormattingEnabled = true;
            this.listHistorySignatures.Location = new System.Drawing.Point(10, 30);
            this.listHistorySignatures.Name = "listHistorySignatures";
            this.listHistorySignatures.Size = new System.Drawing.Size(176, 184);
            this.listHistorySignatures.TabIndex = 78;
            // 
            // txtSolarSystemStaticIData
            // 
            this.txtSolarSystemStaticIData.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolarSystemStaticIData.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtSolarSystemStaticIData.Location = new System.Drawing.Point(8, 4);
            this.txtSolarSystemStaticIData.Name = "txtSolarSystemStaticIData";
            this.txtSolarSystemStaticIData.Size = new System.Drawing.Size(178, 23);
            this.txtSolarSystemStaticIData.TabIndex = 80;
            this.txtSolarSystemStaticIData.Text = "Signatures in last visit";
            this.txtSolarSystemStaticIData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label1.Location = new System.Drawing.Point(192, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 23);
            this.label1.TabIndex = 81;
            this.label1.Text = "Current signatures";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdAnalize
            // 
            this.cmdAnalize.BackColor = System.Drawing.Color.Black;
            this.cmdAnalize.ForeColor = System.Drawing.Color.LightGray;
            this.cmdAnalize.IsActive = true;
            this.cmdAnalize.IsTabControlButton = false;
            this.cmdAnalize.Location = new System.Drawing.Point(375, 62);
            this.cmdAnalize.Name = "cmdAnalize";
            this.cmdAnalize.Size = new System.Drawing.Size(157, 26);
            this.cmdAnalize.TabIndex = 79;
            this.cmdAnalize.Value = "Analyze";
            this.cmdAnalize.Click += new System.EventHandler(this.Event_Analize);
            // 
            // cmdPasteCosmicSifnatures
            // 
            this.cmdPasteCosmicSifnatures.BackColor = System.Drawing.Color.Black;
            this.cmdPasteCosmicSifnatures.ForeColor = System.Drawing.Color.LightGray;
            this.cmdPasteCosmicSifnatures.IsActive = true;
            this.cmdPasteCosmicSifnatures.IsTabControlButton = false;
            this.cmdPasteCosmicSifnatures.Location = new System.Drawing.Point(375, 30);
            this.cmdPasteCosmicSifnatures.Name = "cmdPasteCosmicSifnatures";
            this.cmdPasteCosmicSifnatures.Size = new System.Drawing.Size(157, 26);
            this.cmdPasteCosmicSifnatures.TabIndex = 76;
            this.cmdPasteCosmicSifnatures.Value = "Paste Cosmic Signatures";
            this.cmdPasteCosmicSifnatures.Click += new System.EventHandler(this.Event_PasteCosmicSignatures);
            // 
            // cmdTravelHistory
            // 
            this.cmdTravelHistory.BackColor = System.Drawing.Color.Black;
            this.cmdTravelHistory.ForeColor = System.Drawing.Color.LightGray;
            this.cmdTravelHistory.IsActive = true;
            this.cmdTravelHistory.IsTabControlButton = false;
            this.cmdTravelHistory.Location = new System.Drawing.Point(375, 187);
            this.cmdTravelHistory.Name = "cmdTravelHistory";
            this.cmdTravelHistory.Size = new System.Drawing.Size(157, 26);
            this.cmdTravelHistory.TabIndex = 74;
            this.cmdTravelHistory.Value = "Return to Location";
            this.cmdTravelHistory.Click += new System.EventHandler(this.Event_ReturnToSolarSystem);
            // 
            // whlTravelHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSolarSystemStaticIData);
            this.Controls.Add(this.cmdAnalize);
            this.Controls.Add(this.listHistorySignatures);
            this.Controls.Add(this.cmdPasteCosmicSifnatures);
            this.Controls.Add(this.listCosmicSifnatures);
            this.Controls.Add(this.cmdTravelHistory);
            this.Name = "whlTravelHistory";
            this.Size = new System.Drawing.Size(540, 222);
            this.ResumeLayout(false);

        }

        #endregion

        private whlButton cmdTravelHistory;
        private whlButton cmdPasteCosmicSifnatures;
        private System.Windows.Forms.ListBox listCosmicSifnatures;
        private System.Windows.Forms.ListBox listHistorySignatures;
        private whlButton cmdAnalize;
        private System.Windows.Forms.Label txtSolarSystemStaticIData;
        private System.Windows.Forms.Label label1;
    }
}
