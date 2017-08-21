namespace EveJimaCore.Logic.MapInformation
{
    partial class MapView
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
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.cmdReload = new EveJimaCore.WhlControls.ejButton();
            this.SuspendLayout();
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.ForeColor = System.Drawing.Color.Gray;
            this.lblUpdateTime.Location = new System.Drawing.Point(3, 0);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(141, 18);
            this.lblUpdateTime.TabIndex = 1;
            this.lblUpdateTime.Text = "label1";
            // 
            // cmdReload
            // 
            this.cmdReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReload.AutoSize = true;
            this.cmdReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdReload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdReload.FlatAppearance.BorderSize = 0;
            this.cmdReload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdReload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdReload.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReload.ForeColor = System.Drawing.Color.OliveDrab;
            this.cmdReload.Location = new System.Drawing.Point(437, 3);
            this.cmdReload.Name = "cmdReload";
            this.cmdReload.Size = new System.Drawing.Size(83, 23);
            this.cmdReload.TabIndex = 153;
            this.cmdReload.Tag = "MapSignatures";
            this.cmdReload.Text = "Reload Map";
            this.cmdReload.UseVisualStyleBackColor = true;
            this.cmdReload.Click += new System.EventHandler(this.cmdReload_Click);
            // 
            // MapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.Controls.Add(this.cmdReload);
            this.Controls.Add(this.lblUpdateTime);
            this.DoubleBuffered = true;
            this.Name = "MapView";
            this.Size = new System.Drawing.Size(523, 411);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Event_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Event_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUpdateTime;
        private WhlControls.ejButton cmdReload;
    }
}
