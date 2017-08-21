namespace EveJimaCore.WhlControls
{
    partial class mapSolarSystem
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
            this.lblSolarSystemName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSolarSystemName
            // 
            this.lblSolarSystemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolarSystemName.ForeColor = System.Drawing.Color.White;
            this.lblSolarSystemName.Location = new System.Drawing.Point(0, 2);
            this.lblSolarSystemName.Name = "lblSolarSystemName";
            this.lblSolarSystemName.Size = new System.Drawing.Size(60, 19);
            this.lblSolarSystemName.TabIndex = 0;
            this.lblSolarSystemName.Text = "Murethand";
            this.lblSolarSystemName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mapSolarSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblSolarSystemName);
            this.Name = "mapSolarSystem";
            this.Size = new System.Drawing.Size(62, 62);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Event_OnPaint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSolarSystemName;
    }
}
