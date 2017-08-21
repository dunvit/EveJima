namespace EveJimaCore.WhlControls
{
    partial class mapSolarSystemKSpace
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
            this.lnlSystemText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSolarSystemRegion = new System.Windows.Forms.Label();
            this.txtSolarSystemName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lnlSystemText
            // 
            this.lnlSystemText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnlSystemText.ForeColor = System.Drawing.Color.White;
            this.lnlSystemText.Location = new System.Drawing.Point(3, 5);
            this.lnlSystemText.Name = "lnlSystemText";
            this.lnlSystemText.Size = new System.Drawing.Size(100, 23);
            this.lnlSystemText.TabIndex = 105;
            this.lnlSystemText.Text = "Solar System";
            this.lnlSystemText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 106;
            this.label4.Text = "Region";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSolarSystemRegion
            // 
            this.txtSolarSystemRegion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolarSystemRegion.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSolarSystemRegion.Location = new System.Drawing.Point(109, 22);
            this.txtSolarSystemRegion.Name = "txtSolarSystemRegion";
            this.txtSolarSystemRegion.Size = new System.Drawing.Size(110, 23);
            this.txtSolarSystemRegion.TabIndex = 108;
            this.txtSolarSystemRegion.Text = "111111";
            this.txtSolarSystemRegion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSolarSystemName
            // 
            this.txtSolarSystemName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolarSystemName.ForeColor = System.Drawing.Color.DarkOrange;
            this.txtSolarSystemName.Location = new System.Drawing.Point(109, 2);
            this.txtSolarSystemName.Name = "txtSolarSystemName";
            this.txtSolarSystemName.Size = new System.Drawing.Size(110, 23);
            this.txtSolarSystemName.TabIndex = 107;
            this.txtSolarSystemName.Text = "111111";
            this.txtSolarSystemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mapSolarSystemKSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lnlSystemText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSolarSystemRegion);
            this.Controls.Add(this.txtSolarSystemName);
            this.Name = "mapSolarSystemKSpace";
            this.Size = new System.Drawing.Size(222, 127);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lnlSystemText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtSolarSystemRegion;
        private System.Windows.Forms.Label txtSolarSystemName;
    }
}
