namespace EveJimaCore.WhlControls
{
    partial class windowMessage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMessage = new System.Windows.Forms.Label();
            this.cmdClose = new EveJimaCore.whlButton();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Honeydew;
            this.lblMessage.Location = new System.Drawing.Point(12, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(184, 85);
            this.lblMessage.TabIndex = 88;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Black;
            this.cmdClose.ForeColor = System.Drawing.Color.LightGray;
            this.cmdClose.IsActive = true;
            this.cmdClose.IsTabControlButton = false;
            this.cmdClose.Location = new System.Drawing.Point(48, 109);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(117, 26);
            this.cmdClose.TabIndex = 81;
            this.cmdClose.Value = "Close";
            this.cmdClose.Click += new System.EventHandler(this.Event_CloseWindow);
            // 
            // windowMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(221, 148);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cmdClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "windowMessage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "windowMessage";
            this.Load += new System.EventHandler(this.windowMessage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private whlButton cmdClose;
        private System.Windows.Forms.Label lblMessage;
    }
}