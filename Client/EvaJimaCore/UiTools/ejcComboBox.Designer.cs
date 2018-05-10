namespace EveJimaCore.WhlControls
{
    partial class ejcComboBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ejcComboBox));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdPathfinder = new System.Windows.Forms.Label();
            this.lblSizeOwner = new System.Windows.Forms.Label();
            this.comboBox1 = new FlattenCombo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cmdPathfinder
            // 
            this.cmdPathfinder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPathfinder.BackColor = System.Drawing.Color.Black;
            this.cmdPathfinder.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdPathfinder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdPathfinder.ForeColor = System.Drawing.Color.White;
            this.cmdPathfinder.Location = new System.Drawing.Point(24, 5);
            this.cmdPathfinder.Name = "cmdPathfinder";
            this.cmdPathfinder.Size = new System.Drawing.Size(163, 13);
            this.cmdPathfinder.TabIndex = 15;
            this.cmdPathfinder.Text = "Pathfinder";
            this.cmdPathfinder.Click += new System.EventHandler(this.cmdPathfinder_Click);
            // 
            // lblSizeOwner
            // 
            this.lblSizeOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSizeOwner.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSizeOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSizeOwner.ForeColor = System.Drawing.Color.White;
            this.lblSizeOwner.Location = new System.Drawing.Point(71, 51);
            this.lblSizeOwner.Name = "lblSizeOwner";
            this.lblSizeOwner.Size = new System.Drawing.Size(163, 13);
            this.lblSizeOwner.TabIndex = 17;
            this.lblSizeOwner.Text = "Pathfinder";
            this.lblSizeOwner.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.BackColor = System.Drawing.Color.Black;
            this.comboBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.comboBox1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.comboBox1.ButtonColor = System.Drawing.SystemColors.Control;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 15;
            this.comboBox1.Location = new System.Drawing.Point(27, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(162, 23);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.Visible = false;
            this.comboBox1.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged_1);
            // 
            // ejcComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.cmdPathfinder);
            this.Controls.Add(this.lblSizeOwner);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox1);
            this.DoubleBuffered = true;
            this.Name = "ejcComboBox";
            this.Size = new System.Drawing.Size(192, 26);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label cmdPathfinder;
        private FlattenCombo comboBox1;
        private System.Windows.Forms.Label lblSizeOwner;
    }
}
