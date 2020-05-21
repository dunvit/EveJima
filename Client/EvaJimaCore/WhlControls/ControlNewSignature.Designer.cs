namespace EveJimaCore.WhlControls
{
    partial class ControlNewSignature
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
            this.cmdZkillboard = new EveJimaCore.whlButton();
            this.label1 = new System.Windows.Forms.Label();
            this.whlButton1 = new EveJimaCore.whlButton();
            this.SuspendLayout();
            // 
            // cmdZkillboard
            // 
            this.cmdZkillboard.BackColor = System.Drawing.Color.Black;
            this.cmdZkillboard.ForeColor = System.Drawing.Color.LightGray;
            this.cmdZkillboard.IsActive = true;
            this.cmdZkillboard.IsTabControlButton = false;
            this.cmdZkillboard.Location = new System.Drawing.Point(245, 186);
            this.cmdZkillboard.Name = "cmdZkillboard";
            this.cmdZkillboard.Size = new System.Drawing.Size(237, 26);
            this.cmdZkillboard.TabIndex = 92;
            this.cmdZkillboard.Value = "Start monitoring";
            this.cmdZkillboard.Click += new System.EventHandler(this.cmdZkillboard_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(216, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 23);
            this.label1.TabIndex = 93;
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // whlButton1
            // 
            this.whlButton1.BackColor = System.Drawing.Color.Black;
            this.whlButton1.ForeColor = System.Drawing.Color.LightGray;
            this.whlButton1.IsActive = true;
            this.whlButton1.IsTabControlButton = false;
            this.whlButton1.Location = new System.Drawing.Point(245, 218);
            this.whlButton1.Name = "whlButton1";
            this.whlButton1.Size = new System.Drawing.Size(237, 26);
            this.whlButton1.TabIndex = 94;
            this.whlButton1.Value = "Desable alarm";
            this.whlButton1.Click += new System.EventHandler(this.whlButton1_Click);
            // 
            // ControlNewSignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.whlButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdZkillboard);
            this.Name = "ControlNewSignature";
            this.Size = new System.Drawing.Size(773, 356);
            this.ResumeLayout(false);

        }

        #endregion

        private whlButton cmdZkillboard;
        private System.Windows.Forms.Label label1;
        private whlButton whlButton1;
    }
}
