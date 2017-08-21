namespace EveJimaCore.WhlControls
{
    partial class windowMapSettings
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbIsMemberCanDropSystems = new System.Windows.Forms.ComboBox();
            this.cmdCancel = new EveJimaCore.whlButton();
            this.cmdSave = new EveJimaCore.whlButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIsSaveLowSecSystems = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMapKey = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbIsMemberCanDropSystems);
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.cmdSave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbIsSaveLowSecSystems);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtMapKey);
            this.panel1.Controls.Add(this.cmdClose);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 180);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(21, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "Member can delete system:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbIsMemberCanDropSystems
            // 
            this.cmbIsMemberCanDropSystems.BackColor = System.Drawing.Color.Black;
            this.cmbIsMemberCanDropSystems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsMemberCanDropSystems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIsMemberCanDropSystems.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.cmbIsMemberCanDropSystems.ForeColor = System.Drawing.Color.LightGray;
            this.cmbIsMemberCanDropSystems.FormattingEnabled = true;
            this.cmbIsMemberCanDropSystems.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbIsMemberCanDropSystems.Location = new System.Drawing.Point(206, 80);
            this.cmbIsMemberCanDropSystems.Name = "cmbIsMemberCanDropSystems";
            this.cmbIsMemberCanDropSystems.Size = new System.Drawing.Size(85, 21);
            this.cmbIsMemberCanDropSystems.TabIndex = 79;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Black;
            this.cmdCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmdCancel.ForeColor = System.Drawing.Color.LightGray;
            this.cmdCancel.IsActive = true;
            this.cmdCancel.IsTabControlButton = false;
            this.cmdCancel.Location = new System.Drawing.Point(281, 132);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(146, 25);
            this.cmdCancel.TabIndex = 78;
            this.cmdCancel.Value = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.Black;
            this.cmdSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmdSave.ForeColor = System.Drawing.Color.LightGray;
            this.cmdSave.IsActive = true;
            this.cmdSave.IsTabControlButton = false;
            this.cmdSave.Location = new System.Drawing.Point(116, 132);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(146, 25);
            this.cmdSave.TabIndex = 77;
            this.cmdSave.Value = "Create Map";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(37, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "Save lowsector systems:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbIsSaveLowSecSystems
            // 
            this.cmbIsSaveLowSecSystems.BackColor = System.Drawing.Color.Black;
            this.cmbIsSaveLowSecSystems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsSaveLowSecSystems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIsSaveLowSecSystems.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.cmbIsSaveLowSecSystems.ForeColor = System.Drawing.Color.LightGray;
            this.cmbIsSaveLowSecSystems.FormattingEnabled = true;
            this.cmbIsSaveLowSecSystems.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbIsSaveLowSecSystems.Location = new System.Drawing.Point(206, 47);
            this.cmbIsSaveLowSecSystems.Name = "cmbIsSaveLowSecSystems";
            this.cmbIsSaveLowSecSystems.Size = new System.Drawing.Size(85, 21);
            this.cmbIsSaveLowSecSystems.TabIndex = 75;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkGray;
            this.label14.Location = new System.Drawing.Point(90, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 13);
            this.label14.TabIndex = 73;
            this.label14.Text = "Map public key:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMapKey
            // 
            this.txtMapKey.BackColor = System.Drawing.Color.Black;
            this.txtMapKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMapKey.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtMapKey.ForeColor = System.Drawing.Color.LightGray;
            this.txtMapKey.Location = new System.Drawing.Point(206, 20);
            this.txtMapKey.Name = "txtMapKey";
            this.txtMapKey.Size = new System.Drawing.Size(250, 21);
            this.txtMapKey.TabIndex = 74;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmdClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Image = global::EveJimaCore.Properties.Resources.close;
            this.cmdClose.Location = new System.Drawing.Point(511, 0);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(22, 22);
            this.cmdClose.TabIndex = 72;
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // windowMapSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(542, 182);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "windowMapSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "windowMapSettings";
            this.Load += new System.EventHandler(this.windowMapSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbIsMemberCanDropSystems;
        private whlButton cmdCancel;
        private whlButton cmdSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbIsSaveLowSecSystems;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMapKey;
        private System.Windows.Forms.Button cmdClose;
    }
}