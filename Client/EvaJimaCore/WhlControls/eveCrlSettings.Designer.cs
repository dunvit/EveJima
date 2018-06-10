namespace EveJimaCore.WhlControls
{
    partial class EveCrlSettings
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
            this.crlIsUseBrowser = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.crlIsUseMap = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSaveSettings = new EveJimaCore.whlButton();
            this.cmdIsSignatureRebuild = new System.Windows.Forms.Label();
            this.crlIsSignatureRebuild = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmdLanguage = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.crlIsInterceptLinksFromEVE = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkIsOpenNewTabForZkillboard = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.crlIsUseWhiteColorForSystems = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // crlIsUseBrowser
            // 
            this.crlIsUseBrowser.AutoSize = true;
            this.crlIsUseBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crlIsUseBrowser.Location = new System.Drawing.Point(210, 57);
            this.crlIsUseBrowser.Name = "crlIsUseBrowser";
            this.crlIsUseBrowser.Size = new System.Drawing.Size(12, 11);
            this.crlIsUseBrowser.TabIndex = 149;
            this.crlIsUseBrowser.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 13);
            this.label5.TabIndex = 148;
            this.label5.Text = "Use Browser:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(221, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 150;
            this.label1.Text = "(need restart)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(221, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 153;
            this.label2.Text = "(need restart)";
            // 
            // crlIsUseMap
            // 
            this.crlIsUseMap.AutoSize = true;
            this.crlIsUseMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crlIsUseMap.Location = new System.Drawing.Point(210, 82);
            this.crlIsUseMap.Name = "crlIsUseMap";
            this.crlIsUseMap.Size = new System.Drawing.Size(12, 11);
            this.crlIsUseMap.TabIndex = 152;
            this.crlIsUseMap.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 26);
            this.label3.TabIndex = 151;
            this.label3.Text = "Use Wormholes Map:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmdSaveSettings
            // 
            this.cmdSaveSettings.BackColor = System.Drawing.Color.Black;
            this.cmdSaveSettings.ForeColor = System.Drawing.Color.LightGray;
            this.cmdSaveSettings.IsActive = true;
            this.cmdSaveSettings.IsTabControlButton = false;
            this.cmdSaveSettings.Location = new System.Drawing.Point(199, 212);
            this.cmdSaveSettings.Name = "cmdSaveSettings";
            this.cmdSaveSettings.Size = new System.Drawing.Size(257, 26);
            this.cmdSaveSettings.TabIndex = 154;
            this.cmdSaveSettings.Value = "Save settings";
            this.cmdSaveSettings.Click += new System.EventHandler(this.cmdSaveSettings_Click);
            this.cmdSaveSettings.Load += new System.EventHandler(this.cmdSaveSettings_Load);
            // 
            // cmdIsSignatureRebuild
            // 
            this.cmdIsSignatureRebuild.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIsSignatureRebuild.ForeColor = System.Drawing.Color.White;
            this.cmdIsSignatureRebuild.Location = new System.Drawing.Point(3, 106);
            this.cmdIsSignatureRebuild.Name = "cmdIsSignatureRebuild";
            this.cmdIsSignatureRebuild.Size = new System.Drawing.Size(201, 13);
            this.cmdIsSignatureRebuild.TabIndex = 155;
            this.cmdIsSignatureRebuild.Text = "Short signature rebuild:";
            this.cmdIsSignatureRebuild.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // crlIsSignatureRebuild
            // 
            this.crlIsSignatureRebuild.AutoSize = true;
            this.crlIsSignatureRebuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crlIsSignatureRebuild.Location = new System.Drawing.Point(210, 108);
            this.crlIsSignatureRebuild.Name = "crlIsSignatureRebuild";
            this.crlIsSignatureRebuild.Size = new System.Drawing.Size(12, 11);
            this.crlIsSignatureRebuild.TabIndex = 156;
            this.crlIsSignatureRebuild.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Tan;
            this.label4.Location = new System.Drawing.Point(-13, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 157;
            this.label4.Text = "Eve Jima version:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Tan;
            this.label6.Location = new System.Drawing.Point(462, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 158;
            this.label6.Text = "Author:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(129, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 12);
            this.label7.TabIndex = 159;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(528, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 160;
            this.label8.Text = "Dunkan Su-Sushiloff";
            // 
            // lblLanguage
            // 
            this.lblLanguage.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.ForeColor = System.Drawing.Color.White;
            this.lblLanguage.Location = new System.Drawing.Point(13, 10);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(120, 13);
            this.lblLanguage.TabIndex = 161;
            this.lblLanguage.Text = "Language:";
            this.lblLanguage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmdLanguage
            // 
            this.cmdLanguage.BackColor = System.Drawing.Color.Gray;
            this.cmdLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdLanguage.FormattingEnabled = true;
            this.cmdLanguage.Location = new System.Drawing.Point(142, 7);
            this.cmdLanguage.Name = "cmdLanguage";
            this.cmdLanguage.Size = new System.Drawing.Size(121, 21);
            this.cmdLanguage.TabIndex = 162;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(302, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(248, 13);
            this.label9.TabIndex = 163;
            this.label9.Text = "Intercept links from EVE:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // crlIsInterceptLinksFromEVE
            // 
            this.crlIsInterceptLinksFromEVE.AutoSize = true;
            this.crlIsInterceptLinksFromEVE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crlIsInterceptLinksFromEVE.Location = new System.Drawing.Point(556, 59);
            this.crlIsInterceptLinksFromEVE.Name = "crlIsInterceptLinksFromEVE";
            this.crlIsInterceptLinksFromEVE.Size = new System.Drawing.Size(12, 11);
            this.crlIsInterceptLinksFromEVE.TabIndex = 164;
            this.crlIsInterceptLinksFromEVE.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(302, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(248, 14);
            this.label12.TabIndex = 166;
            this.label12.Text = "Open zkillboard in new tab:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkIsOpenNewTabForZkillboard
            // 
            this.chkIsOpenNewTabForZkillboard.AutoSize = true;
            this.chkIsOpenNewTabForZkillboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsOpenNewTabForZkillboard.Location = new System.Drawing.Point(556, 86);
            this.chkIsOpenNewTabForZkillboard.Name = "chkIsOpenNewTabForZkillboard";
            this.chkIsOpenNewTabForZkillboard.Size = new System.Drawing.Size(12, 11);
            this.chkIsOpenNewTabForZkillboard.TabIndex = 168;
            this.chkIsOpenNewTabForZkillboard.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(566, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 12);
            this.label11.TabIndex = 167;
            this.label11.Text = "(need restart)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(566, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 12);
            this.label10.TabIndex = 165;
            this.label10.Text = "(need restart)";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(302, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(248, 14);
            this.label13.TabIndex = 169;
            this.label13.Text = "Use white color for systems:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // crlIsUseWhiteColorForSystems
            // 
            this.crlIsUseWhiteColorForSystems.AutoSize = true;
            this.crlIsUseWhiteColorForSystems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crlIsUseWhiteColorForSystems.Location = new System.Drawing.Point(556, 108);
            this.crlIsUseWhiteColorForSystems.Name = "crlIsUseWhiteColorForSystems";
            this.crlIsUseWhiteColorForSystems.Size = new System.Drawing.Size(12, 11);
            this.crlIsUseWhiteColorForSystems.TabIndex = 170;
            this.crlIsUseWhiteColorForSystems.UseVisualStyleBackColor = true;
            // 
            // EveCrlSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.label13);
            this.Controls.Add(this.crlIsUseWhiteColorForSystems);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkIsOpenNewTabForZkillboard);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.crlIsInterceptLinksFromEVE);
            this.Controls.Add(this.cmdLanguage);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdIsSignatureRebuild);
            this.Controls.Add(this.crlIsSignatureRebuild);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.crlIsUseBrowser);
            this.Controls.Add(this.cmdSaveSettings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crlIsUseMap);
            this.DoubleBuffered = true;
            this.Name = "EveCrlSettings";
            this.Size = new System.Drawing.Size(654, 250);
            this.Load += new System.EventHandler(this.EveCrlSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox crlIsUseBrowser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox crlIsUseMap;
        private System.Windows.Forms.Label label3;
        private whlButton cmdSaveSettings;
        private System.Windows.Forms.Label cmdIsSignatureRebuild;
        private System.Windows.Forms.CheckBox crlIsSignatureRebuild;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cmdLanguage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox crlIsInterceptLinksFromEVE;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkIsOpenNewTabForZkillboard;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox crlIsUseWhiteColorForSystems;
    }
}
