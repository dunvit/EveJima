﻿namespace EveJimaCore.Logic.ToolBar
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
            this.cmdBrowser = new System.Windows.Forms.Button();
            this.cmdLocation = new System.Windows.Forms.Button();
            this.cmdAuthorization = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdBrowser
            // 
            this.cmdBrowser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdBrowser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdBrowser.FlatAppearance.BorderSize = 0;
            this.cmdBrowser.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdBrowser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdBrowser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowser.ForeColor = System.Drawing.Color.White;
            this.cmdBrowser.Location = new System.Drawing.Point(185, 5);
            this.cmdBrowser.Name = "cmdBrowser";
            this.cmdBrowser.Size = new System.Drawing.Size(94, 23);
            this.cmdBrowser.TabIndex = 5;
            this.cmdBrowser.Tag = "Browser";
            this.cmdBrowser.Text = "Browser";
            this.cmdBrowser.UseVisualStyleBackColor = true;
            // 
            // cmdLocation
            // 
            this.cmdLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdLocation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdLocation.FlatAppearance.BorderSize = 0;
            this.cmdLocation.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdLocation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdLocation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLocation.ForeColor = System.Drawing.Color.White;
            this.cmdLocation.Location = new System.Drawing.Point(105, 5);
            this.cmdLocation.Name = "cmdLocation";
            this.cmdLocation.Size = new System.Drawing.Size(75, 23);
            this.cmdLocation.TabIndex = 4;
            this.cmdLocation.Tag = "Location";
            this.cmdLocation.Text = "Location";
            this.cmdLocation.UseVisualStyleBackColor = true;
            // 
            // cmdAuthorization
            // 
            this.cmdAuthorization.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdAuthorization.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdAuthorization.FlatAppearance.BorderSize = 0;
            this.cmdAuthorization.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdAuthorization.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdAuthorization.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdAuthorization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAuthorization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAuthorization.ForeColor = System.Drawing.Color.White;
            this.cmdAuthorization.Location = new System.Drawing.Point(6, 5);
            this.cmdAuthorization.Name = "cmdAuthorization";
            this.cmdAuthorization.Size = new System.Drawing.Size(99, 23);
            this.cmdAuthorization.TabIndex = 3;
            this.cmdAuthorization.Tag = "Authorization";
            this.cmdAuthorization.Text = "Authorization";
            this.cmdAuthorization.UseVisualStyleBackColor = true;
            // 
            // ToolbarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.Controls.Add(this.cmdBrowser);
            this.Controls.Add(this.cmdLocation);
            this.Controls.Add(this.cmdAuthorization);
            this.DoubleBuffered = true;
            this.Name = "MapToolbarControl";
            this.Size = new System.Drawing.Size(448, 32);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdBrowser;
        private System.Windows.Forms.Button cmdLocation;
        private System.Windows.Forms.Button cmdAuthorization;
    }
}
