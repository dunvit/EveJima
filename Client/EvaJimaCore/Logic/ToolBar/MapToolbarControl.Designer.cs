namespace EveJimaCore.Logic.ToolBar
{
    partial class MapToolbarControl
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
            this.cmdSolarSystem = new System.Windows.Forms.Label();
            this.cmdLocation = new System.Windows.Forms.Label();
            this.cmdBookmarks = new System.Windows.Forms.Label();
            this.cmdAuthorization = new System.Windows.Forms.Label();
            this.cmdPathfinder = new System.Windows.Forms.Label();
            this.cmdBrowser = new System.Windows.Forms.Label();
            this.cmdSettings = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdSolarSystem
            // 
            this.cmdSolarSystem.AutoSize = true;
            this.cmdSolarSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSolarSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSolarSystem.ForeColor = System.Drawing.Color.White;
            this.cmdSolarSystem.Location = new System.Drawing.Point(105, -1);
            this.cmdSolarSystem.Name = "cmdSolarSystem";
            this.cmdSolarSystem.Size = new System.Drawing.Size(70, 13);
            this.cmdSolarSystem.TabIndex = 10;
            this.cmdSolarSystem.Text = "Information";
            // 
            // cmdLocation
            // 
            this.cmdLocation.AutoSize = true;
            this.cmdLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdLocation.ForeColor = System.Drawing.Color.White;
            this.cmdLocation.Location = new System.Drawing.Point(43, -1);
            this.cmdLocation.Name = "cmdLocation";
            this.cmdLocation.Size = new System.Drawing.Size(56, 13);
            this.cmdLocation.TabIndex = 11;
            this.cmdLocation.Text = "Location";
            // 
            // cmdBookmarks
            // 
            this.cmdBookmarks.AutoSize = true;
            this.cmdBookmarks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdBookmarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdBookmarks.ForeColor = System.Drawing.Color.White;
            this.cmdBookmarks.Location = new System.Drawing.Point(181, -1);
            this.cmdBookmarks.Name = "cmdBookmarks";
            this.cmdBookmarks.Size = new System.Drawing.Size(69, 13);
            this.cmdBookmarks.TabIndex = 12;
            this.cmdBookmarks.Text = "Bookmarks";
            // 
            // cmdAuthorization
            // 
            this.cmdAuthorization.AutoSize = true;
            this.cmdAuthorization.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdAuthorization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdAuthorization.ForeColor = System.Drawing.Color.White;
            this.cmdAuthorization.Location = new System.Drawing.Point(-1, -1);
            this.cmdAuthorization.Name = "cmdAuthorization";
            this.cmdAuthorization.Size = new System.Drawing.Size(38, 13);
            this.cmdAuthorization.TabIndex = 13;
            this.cmdAuthorization.Text = "Pilots";
            // 
            // cmdPathfinder
            // 
            this.cmdPathfinder.AutoSize = true;
            this.cmdPathfinder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdPathfinder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdPathfinder.ForeColor = System.Drawing.Color.White;
            this.cmdPathfinder.Location = new System.Drawing.Point(256, -1);
            this.cmdPathfinder.Name = "cmdPathfinder";
            this.cmdPathfinder.Size = new System.Drawing.Size(65, 13);
            this.cmdPathfinder.TabIndex = 14;
            this.cmdPathfinder.Text = "Pathfinder";
            // 
            // cmdBrowser
            // 
            this.cmdBrowser.AutoSize = true;
            this.cmdBrowser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdBrowser.ForeColor = System.Drawing.Color.White;
            this.cmdBrowser.Location = new System.Drawing.Point(327, 0);
            this.cmdBrowser.Name = "cmdBrowser";
            this.cmdBrowser.Size = new System.Drawing.Size(52, 13);
            this.cmdBrowser.TabIndex = 15;
            this.cmdBrowser.Text = "Browser";
            // 
            // cmdSettings
            // 
            this.cmdSettings.AutoSize = true;
            this.cmdSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSettings.ForeColor = System.Drawing.Color.White;
            this.cmdSettings.Location = new System.Drawing.Point(516, 0);
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Size = new System.Drawing.Size(53, 13);
            this.cmdSettings.TabIndex = 16;
            this.cmdSettings.Text = "Settings";
            // 
            // MapToolbarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.cmdSettings);
            this.Controls.Add(this.cmdBrowser);
            this.Controls.Add(this.cmdPathfinder);
            this.Controls.Add(this.cmdAuthorization);
            this.Controls.Add(this.cmdBookmarks);
            this.Controls.Add(this.cmdLocation);
            this.Controls.Add(this.cmdSolarSystem);
            this.DoubleBuffered = true;
            this.Name = "MapToolbarControl";
            this.Size = new System.Drawing.Size(568, 333);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label cmdSolarSystem;
        private System.Windows.Forms.Label cmdLocation;
        private System.Windows.Forms.Label cmdBookmarks;
        private System.Windows.Forms.Label cmdAuthorization;
        private System.Windows.Forms.Label cmdPathfinder;
        private System.Windows.Forms.Label cmdBrowser;
        private System.Windows.Forms.Label cmdSettings;
    }
}
