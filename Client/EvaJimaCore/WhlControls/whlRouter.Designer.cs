namespace EveJimaCore.WhlControls
{
    partial class whlRouter
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(whlRouter));
            this.containerShowAllRoutes = new System.Windows.Forms.Panel();
            this.txtPilotName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ejButton1 = new EveJimaCore.whlButton();
            this.cmdStartRoute = new EveJimaCore.whlButton();
            this.gridAllRoutes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openRouteFile = new System.Windows.Forms.OpenFileDialog();
            this.lblExample = new System.Windows.Forms.Label();
            this.containerShowAllRoutes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllRoutes)).BeginInit();
            this.SuspendLayout();
            // 
            // containerShowAllRoutes
            // 
            this.containerShowAllRoutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.containerShowAllRoutes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.containerShowAllRoutes.Controls.Add(this.lblExample);
            this.containerShowAllRoutes.Controls.Add(this.txtPilotName);
            this.containerShowAllRoutes.Controls.Add(this.label3);
            this.containerShowAllRoutes.Controls.Add(this.ejButton1);
            this.containerShowAllRoutes.Controls.Add(this.cmdStartRoute);
            this.containerShowAllRoutes.Controls.Add(this.gridAllRoutes);
            this.containerShowAllRoutes.Location = new System.Drawing.Point(5, 5);
            this.containerShowAllRoutes.Name = "containerShowAllRoutes";
            this.containerShowAllRoutes.Size = new System.Drawing.Size(534, 244);
            this.containerShowAllRoutes.TabIndex = 79;
            // 
            // txtPilotName
            // 
            this.txtPilotName.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPilotName.ForeColor = System.Drawing.Color.Tan;
            this.txtPilotName.Location = new System.Drawing.Point(259, 5);
            this.txtPilotName.Name = "txtPilotName";
            this.txtPilotName.Size = new System.Drawing.Size(136, 13);
            this.txtPilotName.TabIndex = 158;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 13);
            this.label3.TabIndex = 157;
            this.label3.Text = "Create route for pilot:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ejButton1
            // 
            this.ejButton1.BackColor = System.Drawing.Color.Black;
            this.ejButton1.ForeColor = System.Drawing.Color.LightGray;
            this.ejButton1.IsActive = true;
            this.ejButton1.IsTabControlButton = false;
            this.ejButton1.Location = new System.Drawing.Point(99, 201);
            this.ejButton1.Name = "ejButton1";
            this.ejButton1.Size = new System.Drawing.Size(164, 26);
            this.ejButton1.TabIndex = 156;
            this.ejButton1.Value = "Load route from file";
            this.ejButton1.Click += new System.EventHandler(this.ejButton1_Click);
            // 
            // cmdStartRoute
            // 
            this.cmdStartRoute.BackColor = System.Drawing.Color.Black;
            this.cmdStartRoute.Enabled = false;
            this.cmdStartRoute.ForeColor = System.Drawing.Color.LightGray;
            this.cmdStartRoute.IsActive = true;
            this.cmdStartRoute.IsTabControlButton = false;
            this.cmdStartRoute.Location = new System.Drawing.Point(269, 201);
            this.cmdStartRoute.Name = "cmdStartRoute";
            this.cmdStartRoute.Size = new System.Drawing.Size(164, 26);
            this.cmdStartRoute.TabIndex = 155;
            this.cmdStartRoute.Value = "Set route destination";
            this.cmdStartRoute.Click += new System.EventHandler(this.cmdStartRoute_Click_1);
            // 
            // gridAllRoutes
            // 
            this.gridAllRoutes.AllowUserToAddRows = false;
            this.gridAllRoutes.AllowUserToDeleteRows = false;
            this.gridAllRoutes.BackgroundColor = System.Drawing.Color.DimGray;
            this.gridAllRoutes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAllRoutes.ColumnHeadersVisible = false;
            this.gridAllRoutes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.gridAllRoutes.Location = new System.Drawing.Point(3, 30);
            this.gridAllRoutes.MultiSelect = false;
            this.gridAllRoutes.Name = "gridAllRoutes";
            this.gridAllRoutes.ReadOnly = true;
            this.gridAllRoutes.RowHeadersVisible = false;
            this.gridAllRoutes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.gridAllRoutes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridAllRoutes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAllRoutes.Size = new System.Drawing.Size(525, 151);
            this.gridAllRoutes.TabIndex = 85;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Solar System Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 480;
            // 
            // lblExample
            // 
            this.lblExample.BackColor = System.Drawing.Color.Transparent;
            this.lblExample.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExample.ForeColor = System.Drawing.Color.Gray;
            this.lblExample.Location = new System.Drawing.Point(4, 30);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(525, 151);
            this.lblExample.TabIndex = 159;
            this.lblExample.Text = resources.GetString("lblExample.Text");
            // 
            // whlRouter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.containerShowAllRoutes);
            this.Name = "whlRouter";
            this.Size = new System.Drawing.Size(546, 255);
            this.Enter += new System.EventHandler(this.whlRouter_Enter);
            this.containerShowAllRoutes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAllRoutes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel containerShowAllRoutes;
        private System.Windows.Forms.DataGridView gridAllRoutes;
        private System.Windows.Forms.OpenFileDialog openRouteFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private whlButton ejButton1;
        private whlButton cmdStartRoute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtPilotName;
        public System.Windows.Forms.Label lblExample;
    }
}
