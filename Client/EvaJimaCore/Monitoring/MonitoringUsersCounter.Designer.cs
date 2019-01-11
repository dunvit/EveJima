namespace EveJimaCore.WhlControls
{
    partial class MonitoringUsersCounter
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
            this.browserUsersCounterMetric = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // browserUsersCounterMetric
            // 
            this.browserUsersCounterMetric.Location = new System.Drawing.Point(3, 3);
            this.browserUsersCounterMetric.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserUsersCounterMetric.Name = "browserUsersCounterMetric";
            this.browserUsersCounterMetric.Size = new System.Drawing.Size(113, 105);
            this.browserUsersCounterMetric.TabIndex = 0;
            // 
            // MonitoringUsersCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.browserUsersCounterMetric);
            this.Name = "MonitoringUsersCounter";
            this.Size = new System.Drawing.Size(650, 205);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser browserUsersCounterMetric;
    }
}
