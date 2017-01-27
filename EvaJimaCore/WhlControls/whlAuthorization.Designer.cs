namespace EveJimaCore.WhlControls
{
    partial class whlAuthorization
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
            ((System.ComponentModel.ISupportInitialize)(this.crlPilotPortrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogInWithEveOnline)).BeginInit();
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
            this.cmbPilots.TextChanged += new System.EventHandler(this.cmbPilots_TextChanged);
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
            // whlAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmbPilots);
            this.Controls.Add(this.crlPilotPortrait);
            this.Controls.Add(this.lblAuthorizationInfo);
            this.Controls.Add(this.btnLogInWithEveOnline);
            this.Name = "whlAuthorization";
            this.Size = new System.Drawing.Size(540, 222);
            this.Load += new System.EventHandler(this.Event_FormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.crlPilotPortrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogInWithEveOnline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPilots;
        public System.Windows.Forms.PictureBox crlPilotPortrait;
        public System.Windows.Forms.Label lblAuthorizationInfo;
        private System.Windows.Forms.PictureBox btnLogInWithEveOnline;
    }
}
