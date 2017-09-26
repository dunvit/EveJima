namespace EveJimaCore.Logic.MapInformation
{
    partial class MapControl
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
            this.containerToolbar = new TestPlatform.Logic.ToolbarView();
            this.containerInformation = new TestPlatform.Logic.Views.MapInformationControl();
            this.containerMap = new EveJimaCore.Logic.MapInformation.MapView();
            this.SuspendLayout();
            // 
            // containerToolbar
            // 
            this.containerToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.containerToolbar.Location = new System.Drawing.Point(3, 3);
            this.containerToolbar.Name = "containerToolbar";
            this.containerToolbar.SelectedTab = "SolarSystem";
            this.containerToolbar.Size = new System.Drawing.Size(700, 29);
            this.containerToolbar.TabIndex = 0;
            // 
            // containerInformation
            // 
            this.containerInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.containerInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.containerInformation.Location = new System.Drawing.Point(3, 35);
            this.containerInformation.Name = "containerInformation";
            this.containerInformation.SelectedTab = "SolarSystem";
            this.containerInformation.Size = new System.Drawing.Size(326, 480);
            this.containerInformation.TabIndex = 1;
            // 
            // containerMap
            // 
            this.containerMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.containerMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.containerMap.Location = new System.Drawing.Point(335, 35);
            this.containerMap.Name = "containerMap";
            this.containerMap.Size = new System.Drawing.Size(699, 480);
            this.containerMap.TabIndex = 2;
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.containerMap);
            this.Controls.Add(this.containerInformation);
            this.Controls.Add(this.containerToolbar);
            this.DoubleBuffered = true;
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(1037, 518);
            this.Load += new System.EventHandler(this.MapControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TestPlatform.Logic.ToolbarView containerToolbar;
        private TestPlatform.Logic.Views.MapInformationControl containerInformation;
        private EveJimaCore.Logic.MapInformation.MapView containerMap;
    }
}
