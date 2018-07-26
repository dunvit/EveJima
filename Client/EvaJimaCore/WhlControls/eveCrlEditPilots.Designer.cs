namespace EveJimaCore.WhlControls
{
    partial class eveCrlEditPilots
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
            this.cmdReturn = new EveJimaCore.whlButton();
            this.crlPilotPortrait = new System.Windows.Forms.PictureBox();
            this.cmbPilots = new System.Windows.Forms.ComboBox();
            this.cmdSaveChanges = new EveJimaCore.whlButton();
            this.lblNeedRestart = new System.Windows.Forms.Label();
            this.lblAfterDeleteNotification = new System.Windows.Forms.Label();
            this.cmdDelete = new EveJimaCore.whlButton();
            ((System.ComponentModel.ISupportInitialize)(this.crlPilotPortrait)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdReturn
            // 
            this.cmdReturn.BackColor = System.Drawing.Color.Black;
            this.cmdReturn.ForeColor = System.Drawing.Color.LightGray;
            this.cmdReturn.IsActive = true;
            this.cmdReturn.IsTabControlButton = false;
            this.cmdReturn.Location = new System.Drawing.Point(54, 205);
            this.cmdReturn.Name = "cmdReturn";
            this.cmdReturn.Size = new System.Drawing.Size(211, 26);
            this.cmdReturn.TabIndex = 162;
            this.cmdReturn.Value = "Cancel";
            // 
            // crlPilotPortrait
            // 
            this.crlPilotPortrait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crlPilotPortrait.Location = new System.Drawing.Point(35, 21);
            this.crlPilotPortrait.Name = "crlPilotPortrait";
            this.crlPilotPortrait.Size = new System.Drawing.Size(64, 64);
            this.crlPilotPortrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.crlPilotPortrait.TabIndex = 163;
            this.crlPilotPortrait.TabStop = false;
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
            this.cmbPilots.TabIndex = 164;
            this.cmbPilots.TextChanged += new System.EventHandler(this.Event_SelectPilot);
            // 
            // cmdSaveChanges
            // 
            this.cmdSaveChanges.BackColor = System.Drawing.Color.Black;
            this.cmdSaveChanges.Enabled = false;
            this.cmdSaveChanges.ForeColor = System.Drawing.Color.LightGray;
            this.cmdSaveChanges.IsActive = true;
            this.cmdSaveChanges.IsTabControlButton = false;
            this.cmdSaveChanges.Location = new System.Drawing.Point(285, 205);
            this.cmdSaveChanges.Name = "cmdSaveChanges";
            this.cmdSaveChanges.Size = new System.Drawing.Size(211, 26);
            this.cmdSaveChanges.TabIndex = 165;
            this.cmdSaveChanges.Value = "Save";
            this.cmdSaveChanges.Click += new System.EventHandler(this.Event_DeletePilots);
            // 
            // lblNeedRestart
            // 
            this.lblNeedRestart.AutoSize = true;
            this.lblNeedRestart.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNeedRestart.ForeColor = System.Drawing.Color.Gray;
            this.lblNeedRestart.Location = new System.Drawing.Point(52, 144);
            this.lblNeedRestart.Name = "lblNeedRestart";
            this.lblNeedRestart.Size = new System.Drawing.Size(266, 12);
            this.lblNeedRestart.TabIndex = 168;
            this.lblNeedRestart.Text = "* Operation \"Save\" need restart EveJima client";
            // 
            // lblAfterDeleteNotification
            // 
            this.lblAfterDeleteNotification.AutoSize = true;
            this.lblAfterDeleteNotification.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAfterDeleteNotification.ForeColor = System.Drawing.Color.Gray;
            this.lblAfterDeleteNotification.Location = new System.Drawing.Point(52, 169);
            this.lblAfterDeleteNotification.Name = "lblAfterDeleteNotification";
            this.lblAfterDeleteNotification.Size = new System.Drawing.Size(371, 12);
            this.lblAfterDeleteNotification.TabIndex = 169;
            this.lblAfterDeleteNotification.Text = "* After \"Save\" you will lost all deleted pilots information and keys";
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.Color.Black;
            this.cmdDelete.ForeColor = System.Drawing.Color.LightGray;
            this.cmdDelete.IsActive = true;
            this.cmdDelete.IsTabControlButton = false;
            this.cmdDelete.Location = new System.Drawing.Point(284, 19);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(98, 26);
            this.cmdDelete.TabIndex = 170;
            this.cmdDelete.Value = "Delete";
            this.cmdDelete.Click += new System.EventHandler(this.Event_DeletePilot);
            // 
            // eveCrlEditPilots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.lblAfterDeleteNotification);
            this.Controls.Add(this.lblNeedRestart);
            this.Controls.Add(this.cmdSaveChanges);
            this.Controls.Add(this.cmbPilots);
            this.Controls.Add(this.crlPilotPortrait);
            this.Controls.Add(this.cmdReturn);
            this.DoubleBuffered = true;
            this.Name = "eveCrlEditPilots";
            this.Size = new System.Drawing.Size(550, 250);
            ((System.ComponentModel.ISupportInitialize)(this.crlPilotPortrait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private whlButton cmdReturn;
        public System.Windows.Forms.PictureBox crlPilotPortrait;
        private System.Windows.Forms.ComboBox cmbPilots;
        private whlButton cmdSaveChanges;
        private System.Windows.Forms.Label lblNeedRestart;
        private System.Windows.Forms.Label lblAfterDeleteNotification;
        private whlButton cmdDelete;
    }
}
