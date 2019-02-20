namespace EveJimaCore.WhlControls
{
    partial class ControlAuthorization
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
            this.cmbPilots = new System.Windows.Forms.ComboBox();
            this.crlPilotPortrait = new System.Windows.Forms.PictureBox();
            this.lblAuthorizationInfo = new System.Windows.Forms.Label();
            this.btnLogInWithEveOnline = new System.Windows.Forms.PictureBox();
            this.cmdLoadPilotes = new EveJimaCore.whlButton();
            this.containerScreenUpdate = new System.Windows.Forms.Panel();
            this.lblUpdateLog = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditPilots = new EveJimaCore.whlButton();
            ((System.ComponentModel.ISupportInitialize)(this.crlPilotPortrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogInWithEveOnline)).BeginInit();
            this.containerScreenUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPilots
            // 
            this.cmbPilots.BackColor = System.Drawing.Color.Black;
            this.cmbPilots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPilots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPilots.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.cmbPilots.ForeColor = System.Drawing.Color.LightGray;
            this.cmbPilots.FormattingEnabled = true;
            this.cmbPilots.Location = new System.Drawing.Point(113, 21);
            this.cmbPilots.Name = "cmbPilots";
            this.cmbPilots.Size = new System.Drawing.Size(157, 21);
            this.cmbPilots.TabIndex = 14;
            this.cmbPilots.Visible = false;
            
            // 
            // crlPilotPortrait
            // 
            this.crlPilotPortrait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crlPilotPortrait.Location = new System.Drawing.Point(35, 21);
            this.crlPilotPortrait.Name = "crlPilotPortrait";
            this.crlPilotPortrait.Size = new System.Drawing.Size(64, 64);
            this.crlPilotPortrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.crlPilotPortrait.TabIndex = 13;
            this.crlPilotPortrait.TabStop = false;
            this.crlPilotPortrait.Visible = false;
            // 
            // lblAuthorizationInfo
            // 
            this.lblAuthorizationInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblAuthorizationInfo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorizationInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblAuthorizationInfo.Location = new System.Drawing.Point(111, 49);
            this.lblAuthorizationInfo.Name = "lblAuthorizationInfo";
            this.lblAuthorizationInfo.Size = new System.Drawing.Size(394, 97);
            this.lblAuthorizationInfo.TabIndex = 12;
            this.lblAuthorizationInfo.Text = "J230456";
            // 
            // btnLogInWithEveOnline
            // 
            this.btnLogInWithEveOnline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogInWithEveOnline.Image = global::EveJimaCore.Properties.Resources.EVE_SSO_Login_Buttons_Large_Black;
            this.btnLogInWithEveOnline.Location = new System.Drawing.Point(142, 156);
            this.btnLogInWithEveOnline.Name = "btnLogInWithEveOnline";
            this.btnLogInWithEveOnline.Size = new System.Drawing.Size(270, 45);
            this.btnLogInWithEveOnline.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnLogInWithEveOnline.TabIndex = 11;
            this.btnLogInWithEveOnline.TabStop = false;
            this.btnLogInWithEveOnline.Click += new System.EventHandler(this.Event_GoToCCPSSO);
            // 
            // cmdLoadPilotes
            // 
            this.cmdLoadPilotes.BackColor = System.Drawing.Color.Black;
            this.cmdLoadPilotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmdLoadPilotes.ForeColor = System.Drawing.Color.LightGray;
            this.cmdLoadPilotes.IsActive = true;
            this.cmdLoadPilotes.IsTabControlButton = false;
            this.cmdLoadPilotes.Location = new System.Drawing.Point(142, 112);
            this.cmdLoadPilotes.Name = "cmdLoadPilotes";
            this.cmdLoadPilotes.Size = new System.Drawing.Size(270, 25);
            this.cmdLoadPilotes.TabIndex = 78;
            this.cmdLoadPilotes.Value = "Load pilots";
            this.cmdLoadPilotes.Visible = false;
            this.cmdLoadPilotes.Click += new System.EventHandler(this.cmdLoadPilotes_Click);
            // 
            // containerScreenUpdate
            // 
            this.containerScreenUpdate.Controls.Add(this.lblUpdateLog);
            this.containerScreenUpdate.Controls.Add(this.label1);
            this.containerScreenUpdate.Location = new System.Drawing.Point(383, 259);
            this.containerScreenUpdate.Name = "containerScreenUpdate";
            this.containerScreenUpdate.Size = new System.Drawing.Size(351, 180);
            this.containerScreenUpdate.TabIndex = 79;
            // 
            // lblUpdateLog
            // 
            this.lblUpdateLog.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateLog.ForeColor = System.Drawing.Color.DarkGray;
            this.lblUpdateLog.Location = new System.Drawing.Point(12, 56);
            this.lblUpdateLog.Name = "lblUpdateLog";
            this.lblUpdateLog.Size = new System.Drawing.Size(327, 113);
            this.lblUpdateLog.TabIndex = 3;
            this.lblUpdateLog.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Update server. Please wait.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEditPilots
            // 
            this.btnEditPilots.BackColor = System.Drawing.Color.Black;
            this.btnEditPilots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnEditPilots.ForeColor = System.Drawing.Color.LightGray;
            this.btnEditPilots.IsActive = true;
            this.btnEditPilots.IsTabControlButton = false;
            this.btnEditPilots.Location = new System.Drawing.Point(283, 20);
            this.btnEditPilots.Name = "btnEditPilots";
            this.btnEditPilots.Size = new System.Drawing.Size(155, 25);
            this.btnEditPilots.TabIndex = 80;
            this.btnEditPilots.Value = "Edit";
            this.btnEditPilots.Visible = false;
            this.btnEditPilots.Click += new System.EventHandler(this.btnEditPilots_Click);
            // 
            // ControlAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.btnEditPilots);
            this.Controls.Add(this.containerScreenUpdate);
            this.Controls.Add(this.cmdLoadPilotes);
            this.Controls.Add(this.cmbPilots);
            this.Controls.Add(this.crlPilotPortrait);
            this.Controls.Add(this.lblAuthorizationInfo);
            this.Controls.Add(this.btnLogInWithEveOnline);
            this.Name = "ControlAuthorization";
            this.Size = new System.Drawing.Size(484, 258);
            ((System.ComponentModel.ISupportInitialize)(this.crlPilotPortrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogInWithEveOnline)).EndInit();
            this.containerScreenUpdate.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPilots;
        public System.Windows.Forms.PictureBox crlPilotPortrait;
        public System.Windows.Forms.Label lblAuthorizationInfo;
        private System.Windows.Forms.PictureBox btnLogInWithEveOnline;
        private whlButton cmdLoadPilotes;
        private System.Windows.Forms.Panel containerScreenUpdate;
        private System.Windows.Forms.Label lblUpdateLog;
        private System.Windows.Forms.Label label1;
        private whlButton btnEditPilots;
    }
}
