namespace TestPlatform.Logic
{
    partial class ToolbarView
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
            this.cmdSystemInformation = new System.Windows.Forms.Button();
            this.cmdMapSignatures = new System.Windows.Forms.Button();
            this.cmdMapSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdSystemInformation
            // 
            this.cmdSystemInformation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSystemInformation.FlatAppearance.BorderSize = 0;
            this.cmdSystemInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSystemInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSystemInformation.ForeColor = System.Drawing.Color.White;
            this.cmdSystemInformation.Location = new System.Drawing.Point(17, 4);
            this.cmdSystemInformation.Name = "cmdSystemInformation";
            this.cmdSystemInformation.Size = new System.Drawing.Size(75, 23);
            this.cmdSystemInformation.TabIndex = 0;
            this.cmdSystemInformation.Text = "button1";
            this.cmdSystemInformation.UseVisualStyleBackColor = true;
            this.cmdSystemInformation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Event_SelectToolBarElement);
            // 
            // cmdMapSignatures
            // 
            this.cmdMapSignatures.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdMapSignatures.FlatAppearance.BorderSize = 0;
            this.cmdMapSignatures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMapSignatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMapSignatures.ForeColor = System.Drawing.Color.White;
            this.cmdMapSignatures.Location = new System.Drawing.Point(98, 4);
            this.cmdMapSignatures.Name = "cmdMapSignatures";
            this.cmdMapSignatures.Size = new System.Drawing.Size(75, 23);
            this.cmdMapSignatures.TabIndex = 1;
            this.cmdMapSignatures.Text = "button2";
            this.cmdMapSignatures.UseVisualStyleBackColor = true;
            this.cmdMapSignatures.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Event_SelectToolBarElement);
            // 
            // cmdMapSettings
            // 
            this.cmdMapSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdMapSettings.FlatAppearance.BorderSize = 0;
            this.cmdMapSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMapSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMapSettings.ForeColor = System.Drawing.Color.White;
            this.cmdMapSettings.Location = new System.Drawing.Point(179, 4);
            this.cmdMapSettings.Name = "cmdMapSettings";
            this.cmdMapSettings.Size = new System.Drawing.Size(75, 23);
            this.cmdMapSettings.TabIndex = 2;
            this.cmdMapSettings.Text = "button3";
            this.cmdMapSettings.UseVisualStyleBackColor = true;
            this.cmdMapSettings.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Event_SelectToolBarElement);
            // 
            // Toolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.Controls.Add(this.cmdMapSettings);
            this.Controls.Add(this.cmdMapSignatures);
            this.Controls.Add(this.cmdSystemInformation);
            this.Name = "Toolbar";
            this.Size = new System.Drawing.Size(358, 35);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSystemInformation;
        private System.Windows.Forms.Button cmdMapSignatures;
        private System.Windows.Forms.Button cmdMapSettings;
    }
}
