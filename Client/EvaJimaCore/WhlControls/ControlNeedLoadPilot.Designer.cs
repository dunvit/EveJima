namespace EveJimaCore.WhlControls
{
    partial class ControlNeedLoadPilot
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
            this.lblAuthorizationInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAuthorizationInfo
            // 
            this.lblAuthorizationInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblAuthorizationInfo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorizationInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblAuthorizationInfo.Location = new System.Drawing.Point(71, 48);
            this.lblAuthorizationInfo.Name = "lblAuthorizationInfo";
            this.lblAuthorizationInfo.Size = new System.Drawing.Size(394, 97);
            this.lblAuthorizationInfo.TabIndex = 13;
            this.lblAuthorizationInfo.Text = "J230456";
            // 
            // ControlNeedLoadPilot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.lblAuthorizationInfo);
            this.Name = "ControlNeedLoadPilot";
            this.Size = new System.Drawing.Size(540, 233);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblAuthorizationInfo;
    }
}
