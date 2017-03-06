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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdReturn = new EveJimaCore.whlButton();
            this.containerShowAllRoutes = new System.Windows.Forms.Panel();
            this.gridAllRoutes = new System.Windows.Forms.DataGridView();
            this.cmdShowRoute = new EveJimaCore.whlButton();
            this.cmdDeleteRoute = new EveJimaCore.whlButton();
            this.cmdSetDesination = new EveJimaCore.whlButton();
            this.cmdShowAllRoutes = new EveJimaCore.whlButton();
            this.cmdCreateNewRoute = new EveJimaCore.whlButton();
            this.containerCreateRoute = new System.Windows.Forms.Panel();
            this.gridWaypoints = new System.Windows.Forms.DataGridView();
            this.clmSolarSystemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRemoveWormholeName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdCreate = new EveJimaCore.whlButton();
            this.containerRoute = new System.Windows.Forms.Panel();
            this.gridSelectedRoute = new System.Windows.Forms.DataGridView();
            this.txtRouteName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.whlButton1 = new EveJimaCore.whlButton();
            this.containerShowAllRoutes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllRoutes)).BeginInit();
            this.containerCreateRoute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWaypoints)).BeginInit();
            this.containerRoute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSelectedRoute)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdReturn
            // 
            this.cmdReturn.BackColor = System.Drawing.Color.Black;
            this.cmdReturn.ForeColor = System.Drawing.Color.LightGray;
            this.cmdReturn.IsActive = true;
            this.cmdReturn.IsTabControlButton = false;
            this.cmdReturn.Location = new System.Drawing.Point(6, 195);
            this.cmdReturn.Name = "cmdReturn";
            this.cmdReturn.Size = new System.Drawing.Size(111, 26);
            this.cmdReturn.TabIndex = 78;
            this.cmdReturn.Value = "Return";
            this.cmdReturn.Click += new System.EventHandler(this.Event_Return);
            // 
            // containerShowAllRoutes
            // 
            this.containerShowAllRoutes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.containerShowAllRoutes.Controls.Add(this.gridAllRoutes);
            this.containerShowAllRoutes.Controls.Add(this.cmdShowRoute);
            this.containerShowAllRoutes.Controls.Add(this.cmdDeleteRoute);
            this.containerShowAllRoutes.Controls.Add(this.cmdSetDesination);
            this.containerShowAllRoutes.Location = new System.Drawing.Point(417, 133);
            this.containerShowAllRoutes.Name = "containerShowAllRoutes";
            this.containerShowAllRoutes.Size = new System.Drawing.Size(407, 215);
            this.containerShowAllRoutes.TabIndex = 79;
            // 
            // gridAllRoutes
            // 
            this.gridAllRoutes.AllowUserToAddRows = false;
            this.gridAllRoutes.AllowUserToDeleteRows = false;
            this.gridAllRoutes.BackgroundColor = System.Drawing.Color.DimGray;
            this.gridAllRoutes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAllRoutes.ColumnHeadersVisible = false;
            this.gridAllRoutes.Location = new System.Drawing.Point(9, 9);
            this.gridAllRoutes.MultiSelect = false;
            this.gridAllRoutes.Name = "gridAllRoutes";
            this.gridAllRoutes.ReadOnly = true;
            this.gridAllRoutes.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.gridAllRoutes.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridAllRoutes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAllRoutes.Size = new System.Drawing.Size(384, 154);
            this.gridAllRoutes.TabIndex = 85;
            this.gridAllRoutes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Event_SelectCell);
            // 
            // cmdShowRoute
            // 
            this.cmdShowRoute.BackColor = System.Drawing.Color.Black;
            this.cmdShowRoute.ForeColor = System.Drawing.Color.LightGray;
            this.cmdShowRoute.IsActive = true;
            this.cmdShowRoute.IsTabControlButton = false;
            this.cmdShowRoute.Location = new System.Drawing.Point(146, 175);
            this.cmdShowRoute.Name = "cmdShowRoute";
            this.cmdShowRoute.Size = new System.Drawing.Size(111, 26);
            this.cmdShowRoute.TabIndex = 84;
            this.cmdShowRoute.Value = "Show";
            this.cmdShowRoute.Click += new System.EventHandler(this.Event_ShowRoute);
            // 
            // cmdDeleteRoute
            // 
            this.cmdDeleteRoute.BackColor = System.Drawing.Color.Black;
            this.cmdDeleteRoute.ForeColor = System.Drawing.Color.LightGray;
            this.cmdDeleteRoute.IsActive = true;
            this.cmdDeleteRoute.IsTabControlButton = false;
            this.cmdDeleteRoute.Location = new System.Drawing.Point(9, 175);
            this.cmdDeleteRoute.Name = "cmdDeleteRoute";
            this.cmdDeleteRoute.Size = new System.Drawing.Size(111, 26);
            this.cmdDeleteRoute.TabIndex = 83;
            this.cmdDeleteRoute.Value = "Delete Route";
            this.cmdDeleteRoute.Click += new System.EventHandler(this.Event_DeleteRoute);
            // 
            // cmdSetDesination
            // 
            this.cmdSetDesination.BackColor = System.Drawing.Color.Black;
            this.cmdSetDesination.ForeColor = System.Drawing.Color.LightGray;
            this.cmdSetDesination.IsActive = true;
            this.cmdSetDesination.IsTabControlButton = false;
            this.cmdSetDesination.Location = new System.Drawing.Point(282, 175);
            this.cmdSetDesination.Name = "cmdSetDesination";
            this.cmdSetDesination.Size = new System.Drawing.Size(111, 26);
            this.cmdSetDesination.TabIndex = 82;
            this.cmdSetDesination.Value = "Set Destination";
            this.cmdSetDesination.Click += new System.EventHandler(this.EventSetDesination);
            // 
            // cmdShowAllRoutes
            // 
            this.cmdShowAllRoutes.BackColor = System.Drawing.Color.Black;
            this.cmdShowAllRoutes.ForeColor = System.Drawing.Color.LightGray;
            this.cmdShowAllRoutes.IsActive = true;
            this.cmdShowAllRoutes.IsTabControlButton = false;
            this.cmdShowAllRoutes.Location = new System.Drawing.Point(6, 6);
            this.cmdShowAllRoutes.Name = "cmdShowAllRoutes";
            this.cmdShowAllRoutes.Size = new System.Drawing.Size(111, 26);
            this.cmdShowAllRoutes.TabIndex = 80;
            this.cmdShowAllRoutes.Value = "Show Routes";
            this.cmdShowAllRoutes.Click += new System.EventHandler(this.Event_ShowAllRoutes);
            // 
            // cmdCreateNewRoute
            // 
            this.cmdCreateNewRoute.BackColor = System.Drawing.Color.Black;
            this.cmdCreateNewRoute.ForeColor = System.Drawing.Color.LightGray;
            this.cmdCreateNewRoute.IsActive = true;
            this.cmdCreateNewRoute.IsTabControlButton = false;
            this.cmdCreateNewRoute.Location = new System.Drawing.Point(6, 38);
            this.cmdCreateNewRoute.Name = "cmdCreateNewRoute";
            this.cmdCreateNewRoute.Size = new System.Drawing.Size(111, 26);
            this.cmdCreateNewRoute.TabIndex = 81;
            this.cmdCreateNewRoute.Value = "Create New";
            this.cmdCreateNewRoute.Click += new System.EventHandler(this.Event_ContainerShowCreateRoute);
            // 
            // containerCreateRoute
            // 
            this.containerCreateRoute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.containerCreateRoute.Controls.Add(this.gridWaypoints);
            this.containerCreateRoute.Controls.Add(this.txtRemoveWormholeName);
            this.containerCreateRoute.Controls.Add(this.label13);
            this.containerCreateRoute.Controls.Add(this.cmdCreate);
            this.containerCreateRoute.Location = new System.Drawing.Point(300, 15);
            this.containerCreateRoute.Name = "containerCreateRoute";
            this.containerCreateRoute.Size = new System.Drawing.Size(407, 215);
            this.containerCreateRoute.TabIndex = 82;
            // 
            // gridWaypoints
            // 
            this.gridWaypoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridWaypoints.ColumnHeadersVisible = false;
            this.gridWaypoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSolarSystemName});
            this.gridWaypoints.Location = new System.Drawing.Point(17, 30);
            this.gridWaypoints.Name = "gridWaypoints";
            this.gridWaypoints.RowHeadersVisible = false;
            this.gridWaypoints.Size = new System.Drawing.Size(359, 139);
            this.gridWaypoints.TabIndex = 87;
            this.gridWaypoints.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Event_CellEndEdit);
            this.gridWaypoints.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Event_CellValidating);
            // 
            // clmSolarSystemName
            // 
            this.clmSolarSystemName.HeaderText = "Solar System Name";
            this.clmSolarSystemName.Name = "clmSolarSystemName";
            this.clmSolarSystemName.Width = 270;
            // 
            // txtRemoveWormholeName
            // 
            this.txtRemoveWormholeName.Location = new System.Drawing.Point(115, 4);
            this.txtRemoveWormholeName.MaxLength = 200;
            this.txtRemoveWormholeName.Name = "txtRemoveWormholeName";
            this.txtRemoveWormholeName.Size = new System.Drawing.Size(252, 20);
            this.txtRemoveWormholeName.TabIndex = 86;
            this.txtRemoveWormholeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(17, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 23);
            this.label13.TabIndex = 85;
            this.label13.Text = "Route Name:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdCreate
            // 
            this.cmdCreate.BackColor = System.Drawing.Color.Black;
            this.cmdCreate.ForeColor = System.Drawing.Color.LightGray;
            this.cmdCreate.IsActive = true;
            this.cmdCreate.IsTabControlButton = false;
            this.cmdCreate.Location = new System.Drawing.Point(146, 175);
            this.cmdCreate.Name = "cmdCreate";
            this.cmdCreate.Size = new System.Drawing.Size(111, 26);
            this.cmdCreate.TabIndex = 84;
            this.cmdCreate.Value = "Create";
            this.cmdCreate.Click += new System.EventHandler(this.Event_Create);
            // 
            // containerRoute
            // 
            this.containerRoute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.containerRoute.Controls.Add(this.gridSelectedRoute);
            this.containerRoute.Controls.Add(this.txtRouteName);
            this.containerRoute.Controls.Add(this.label1);
            this.containerRoute.Controls.Add(this.whlButton1);
            this.containerRoute.Location = new System.Drawing.Point(126, 6);
            this.containerRoute.Name = "containerRoute";
            this.containerRoute.Size = new System.Drawing.Size(407, 215);
            this.containerRoute.TabIndex = 83;
            // 
            // gridSelectedRoute
            // 
            this.gridSelectedRoute.AllowUserToAddRows = false;
            this.gridSelectedRoute.AllowUserToDeleteRows = false;
            this.gridSelectedRoute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSelectedRoute.ColumnHeadersVisible = false;
            this.gridSelectedRoute.Location = new System.Drawing.Point(17, 30);
            this.gridSelectedRoute.Name = "gridSelectedRoute";
            this.gridSelectedRoute.ReadOnly = true;
            this.gridSelectedRoute.RowHeadersVisible = false;
            this.gridSelectedRoute.Size = new System.Drawing.Size(359, 139);
            this.gridSelectedRoute.TabIndex = 87;
            // 
            // txtRouteName
            // 
            this.txtRouteName.BackColor = System.Drawing.Color.DarkGray;
            this.txtRouteName.Location = new System.Drawing.Point(115, 4);
            this.txtRouteName.MaxLength = 200;
            this.txtRouteName.Name = "txtRouteName";
            this.txtRouteName.ReadOnly = true;
            this.txtRouteName.Size = new System.Drawing.Size(252, 20);
            this.txtRouteName.TabIndex = 86;
            this.txtRouteName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(17, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 85;
            this.label1.Text = "Route Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // whlButton1
            // 
            this.whlButton1.BackColor = System.Drawing.Color.Black;
            this.whlButton1.ForeColor = System.Drawing.Color.LightGray;
            this.whlButton1.IsActive = true;
            this.whlButton1.IsTabControlButton = false;
            this.whlButton1.Location = new System.Drawing.Point(49, 179);
            this.whlButton1.Name = "whlButton1";
            this.whlButton1.Size = new System.Drawing.Size(261, 26);
            this.whlButton1.TabIndex = 84;
            this.whlButton1.Value = "Set destination";
            this.whlButton1.Click += new System.EventHandler(this.Event_SetDesinationForCurrentRoute);
            // 
            // whlRouter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.cmdCreateNewRoute);
            this.Controls.Add(this.cmdShowAllRoutes);
            this.Controls.Add(this.containerShowAllRoutes);
            this.Controls.Add(this.cmdReturn);
            this.Controls.Add(this.containerCreateRoute);
            this.Controls.Add(this.containerRoute);
            this.Name = "whlRouter";
            this.Size = new System.Drawing.Size(536, 228);
            this.containerShowAllRoutes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAllRoutes)).EndInit();
            this.containerCreateRoute.ResumeLayout(false);
            this.containerCreateRoute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWaypoints)).EndInit();
            this.containerRoute.ResumeLayout(false);
            this.containerRoute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSelectedRoute)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private whlButton cmdReturn;
        private System.Windows.Forms.Panel containerShowAllRoutes;
        private whlButton cmdShowAllRoutes;
        private whlButton cmdCreateNewRoute;
        private whlButton cmdSetDesination;
        private whlButton cmdDeleteRoute;
        private whlButton cmdShowRoute;
        private System.Windows.Forms.DataGridView gridAllRoutes;
        private System.Windows.Forms.Panel containerCreateRoute;
        private whlButton cmdCreate;
        private System.Windows.Forms.TextBox txtRemoveWormholeName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView gridWaypoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSolarSystemName;
        private System.Windows.Forms.Panel containerRoute;
        private System.Windows.Forms.DataGridView gridSelectedRoute;
        private System.Windows.Forms.TextBox txtRouteName;
        private System.Windows.Forms.Label label1;
        private whlButton whlButton1;
    }
}
