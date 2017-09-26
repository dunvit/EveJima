namespace EveJimaCore.Logic.MapInformation
{
    partial class InformationSignaturesView
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdUpdateSignatures = new EveJimaCore.WhlControls.ejButton();
            this.ejButton2 = new EveJimaCore.WhlControls.ejButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ejButton4 = new EveJimaCore.WhlControls.ejButton();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Signatures";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.cmdUpdateSignatures);
            this.groupBox3.Controls.Add(this.ejButton2);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.ejButton4);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.FloralWhite;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 640);
            this.groupBox3.TabIndex = 149;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Signatures ";
            // 
            // cmdUpdateSignatures
            // 
            this.cmdUpdateSignatures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdUpdateSignatures.AutoSize = true;
            this.cmdUpdateSignatures.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdUpdateSignatures.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdUpdateSignatures.FlatAppearance.BorderSize = 0;
            this.cmdUpdateSignatures.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdUpdateSignatures.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.cmdUpdateSignatures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdUpdateSignatures.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdateSignatures.ForeColor = System.Drawing.Color.OliveDrab;
            this.cmdUpdateSignatures.Location = new System.Drawing.Point(125, 611);
            this.cmdUpdateSignatures.Name = "cmdUpdateSignatures";
            this.cmdUpdateSignatures.Size = new System.Drawing.Size(82, 23);
            this.cmdUpdateSignatures.TabIndex = 149;
            this.cmdUpdateSignatures.Tag = "MapSignatures";
            this.cmdUpdateSignatures.Text = "Update All";
            this.cmdUpdateSignatures.UseVisualStyleBackColor = true;
            this.cmdUpdateSignatures.Click += new System.EventHandler(this.cmdUpdateSignatures_Click);
            // 
            // ejButton2
            // 
            this.ejButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ejButton2.AutoSize = true;
            this.ejButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ejButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ejButton2.FlatAppearance.BorderSize = 0;
            this.ejButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ejButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ejButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ejButton2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ejButton2.ForeColor = System.Drawing.Color.Orange;
            this.ejButton2.Location = new System.Drawing.Point(6, 611);
            this.ejButton2.Name = "ejButton2";
            this.ejButton2.Size = new System.Drawing.Size(113, 23);
            this.ejButton2.TabIndex = 148;
            this.ejButton2.Tag = "MapSignatures";
            this.ejButton2.Text = "Paste Signatures";
            this.ejButton2.UseVisualStyleBackColor = true;
            this.ejButton2.Click += new System.EventHandler(this.ejButton2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.dataGridView1.Location = new System.Drawing.Point(5, 18);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DimGray;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.DarkRed;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(298, 579);
            this.dataGridView1.TabIndex = 147;
            // 
            // ejButton4
            // 
            this.ejButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ejButton4.AutoSize = true;
            this.ejButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ejButton4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ejButton4.FlatAppearance.BorderSize = 0;
            this.ejButton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ejButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ejButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ejButton4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ejButton4.ForeColor = System.Drawing.Color.OrangeRed;
            this.ejButton4.Location = new System.Drawing.Point(222, 611);
            this.ejButton4.Name = "ejButton4";
            this.ejButton4.Size = new System.Drawing.Size(82, 23);
            this.ejButton4.TabIndex = 146;
            this.ejButton4.Tag = "MapSignatures";
            this.ejButton4.Text = "Delete All";
            this.ejButton4.UseVisualStyleBackColor = true;
            this.ejButton4.Click += new System.EventHandler(this.ejButton4_Click);
            // 
            // InformationSignaturesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Name = "InformationSignaturesView";
            this.Size = new System.Drawing.Size(324, 646);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private WhlControls.ejButton cmdUpdateSignatures;
        private WhlControls.ejButton ejButton2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private WhlControls.ejButton ejButton4;
    }
}
