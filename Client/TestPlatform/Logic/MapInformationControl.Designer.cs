namespace EveJimaCore.Logic
{
    partial class MapInformationControl
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
            this.button1 = new System.Windows.Forms.Button();
            this.crlInformationContainer = new TestPlatform.Logic.Views.InformationView();
            this.crlToolbarView = new TestPlatform.Logic.ToolbarView();
            this.mapView1 = new TestPlatform.Logic.Views.MapView();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(667, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // crlInformationContainer
            // 
            this.crlInformationContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.crlInformationContainer.Location = new System.Drawing.Point(12, 53);
            this.crlInformationContainer.Name = "crlInformationContainer";
            this.crlInformationContainer.Size = new System.Drawing.Size(304, 312);
            this.crlInformationContainer.TabIndex = 2;
            // 
            // crlToolbarView
            // 
            this.crlToolbarView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.crlToolbarView.Location = new System.Drawing.Point(12, 12);
            this.crlToolbarView.Name = "crlToolbarView";
            this.crlToolbarView.SelectedTab = "SolarSystem";
            this.crlToolbarView.Size = new System.Drawing.Size(358, 35);
            this.crlToolbarView.TabIndex = 1;
            // 
            // mapView1
            // 
            this.mapView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.mapView1.Location = new System.Drawing.Point(323, 54);
            this.mapView1.Name = "mapView1";
            this.mapView1.Size = new System.Drawing.Size(419, 311);
            this.mapView1.TabIndex = 3;
            // 
            // MapInformationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(754, 377);
            this.Controls.Add(this.mapView1);
            this.Controls.Add(this.crlInformationContainer);
            this.Controls.Add(this.crlToolbarView);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MapInformationControl";
            this.Text = "MapInformationControl";
            this.Load += new System.EventHandler(this.MapInformationControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private TestPlatform.Logic.ToolbarView cnrToolbar;
        private TestPlatform.Logic.ToolbarView crlToolbarView;
        private TestPlatform.Logic.Views.InformationView crlInformationContainer;
        private TestPlatform.Logic.Views.MapView mapView1;
    }
}