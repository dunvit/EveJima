namespace EveJimaCore.WhlControls
{
    partial class whlLostAndFoundOffice
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
            this.cmdReturn = new EveJimaCore.whlButton();
            this.cmdShow = new EveJimaCore.whlButton();
            this.cmdPublish = new EveJimaCore.whlButton();
            this.cmdRemove = new EveJimaCore.whlButton();
            this.containerGrid = new System.Windows.Forms.Panel();
            this.containerMessage = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.whlButton1 = new EveJimaCore.whlButton();
            this.containerPublish = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPublishWormholeReward = new System.Windows.Forms.TextBox();
            this.txtPublishWormholeName = new System.Windows.Forms.TextBox();
            this.txtPublisherName = new System.Windows.Forms.TextBox();
            this.cmdPublishSearchCoordinates = new EveJimaCore.whlButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.containerRemove = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRemoveWormholeName = new System.Windows.Forms.TextBox();
            this.txtRemoveWormholePublisher = new System.Windows.Forms.TextBox();
            this.cmdRemoveOperation = new EveJimaCore.whlButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.containerGrid.SuspendLayout();
            this.containerMessage.SuspendLayout();
            this.containerPublish.SuspendLayout();
            this.containerRemove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdReturn
            // 
            this.cmdReturn.BackColor = System.Drawing.Color.Black;
            this.cmdReturn.ForeColor = System.Drawing.Color.LightGray;
            this.cmdReturn.IsActive = true;
            this.cmdReturn.IsTabControlButton = false;
            this.cmdReturn.Location = new System.Drawing.Point(6, 185);
            this.cmdReturn.Name = "cmdReturn";
            this.cmdReturn.Size = new System.Drawing.Size(72, 26);
            this.cmdReturn.TabIndex = 77;
            this.cmdReturn.Value = "Return";
            this.cmdReturn.Click += new System.EventHandler(this.Event_Return);
            // 
            // cmdShow
            // 
            this.cmdShow.BackColor = System.Drawing.Color.Black;
            this.cmdShow.ForeColor = System.Drawing.Color.LightGray;
            this.cmdShow.IsActive = true;
            this.cmdShow.IsTabControlButton = false;
            this.cmdShow.Location = new System.Drawing.Point(6, 69);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(72, 26);
            this.cmdShow.TabIndex = 78;
            this.cmdShow.Value = "Show";
            this.cmdShow.Click += new System.EventHandler(this.Event_Show);
            // 
            // cmdPublish
            // 
            this.cmdPublish.BackColor = System.Drawing.Color.Black;
            this.cmdPublish.ForeColor = System.Drawing.Color.LightGray;
            this.cmdPublish.IsActive = true;
            this.cmdPublish.IsTabControlButton = false;
            this.cmdPublish.Location = new System.Drawing.Point(6, 5);
            this.cmdPublish.Name = "cmdPublish";
            this.cmdPublish.Size = new System.Drawing.Size(72, 26);
            this.cmdPublish.TabIndex = 79;
            this.cmdPublish.Value = "Publish";
            this.cmdPublish.Click += new System.EventHandler(this.Event_ShowPublishContainer);
            // 
            // cmdRemove
            // 
            this.cmdRemove.BackColor = System.Drawing.Color.Black;
            this.cmdRemove.ForeColor = System.Drawing.Color.LightGray;
            this.cmdRemove.IsActive = true;
            this.cmdRemove.IsTabControlButton = false;
            this.cmdRemove.Location = new System.Drawing.Point(6, 37);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(72, 26);
            this.cmdRemove.TabIndex = 80;
            this.cmdRemove.Value = "Remove";
            this.cmdRemove.Click += new System.EventHandler(this.Event_ShowRemoveContainer);
            // 
            // containerGrid
            // 
            this.containerGrid.Controls.Add(this.containerMessage);
            this.containerGrid.Controls.Add(this.containerPublish);
            this.containerGrid.Controls.Add(this.containerRemove);
            this.containerGrid.Controls.Add(this.dataGridView1);
            this.containerGrid.Location = new System.Drawing.Point(80, 1);
            this.containerGrid.Name = "containerGrid";
            this.containerGrid.Size = new System.Drawing.Size(453, 210);
            this.containerGrid.TabIndex = 81;
            // 
            // containerMessage
            // 
            this.containerMessage.Controls.Add(this.lblMessage);
            this.containerMessage.Controls.Add(this.whlButton1);
            this.containerMessage.Location = new System.Drawing.Point(354, 63);
            this.containerMessage.Name = "containerMessage";
            this.containerMessage.Size = new System.Drawing.Size(446, 203);
            this.containerMessage.TabIndex = 3;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lblMessage.Location = new System.Drawing.Point(9, 22);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(425, 114);
            this.lblMessage.TabIndex = 87;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // whlButton1
            // 
            this.whlButton1.BackColor = System.Drawing.Color.Black;
            this.whlButton1.ForeColor = System.Drawing.Color.LightGray;
            this.whlButton1.IsActive = true;
            this.whlButton1.IsTabControlButton = false;
            this.whlButton1.Location = new System.Drawing.Point(116, 164);
            this.whlButton1.Name = "whlButton1";
            this.whlButton1.Size = new System.Drawing.Size(165, 26);
            this.whlButton1.TabIndex = 80;
            this.whlButton1.Value = "Exit";
            this.whlButton1.Click += new System.EventHandler(this.Event_CloseMessageContainer);
            // 
            // containerPublish
            // 
            this.containerPublish.Controls.Add(this.label7);
            this.containerPublish.Controls.Add(this.label6);
            this.containerPublish.Controls.Add(this.label5);
            this.containerPublish.Controls.Add(this.label4);
            this.containerPublish.Controls.Add(this.txtPublishWormholeReward);
            this.containerPublish.Controls.Add(this.txtPublishWormholeName);
            this.containerPublish.Controls.Add(this.txtPublisherName);
            this.containerPublish.Controls.Add(this.cmdPublishSearchCoordinates);
            this.containerPublish.Controls.Add(this.label3);
            this.containerPublish.Controls.Add(this.label2);
            this.containerPublish.Controls.Add(this.label1);
            this.containerPublish.Location = new System.Drawing.Point(395, 18);
            this.containerPublish.Name = "containerPublish";
            this.containerPublish.Size = new System.Drawing.Size(446, 203);
            this.containerPublish.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label7.Location = new System.Drawing.Point(9, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(425, 23);
            this.label7.TabIndex = 87;
            this.label7.Text = "Search Wormhole request";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(258, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 23);
            this.label6.TabIndex = 86;
            this.label6.Text = "Example: 1kkk";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(258, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 23);
            this.label5.TabIndex = 85;
            this.label5.Text = "Example: J213734";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(258, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 23);
            this.label4.TabIndex = 84;
            this.label4.Text = "Example: Dunkan Su-Shiloff";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPublishWormholeReward
            // 
            this.txtPublishWormholeReward.Location = new System.Drawing.Point(135, 129);
            this.txtPublishWormholeReward.MaxLength = 200;
            this.txtPublishWormholeReward.Name = "txtPublishWormholeReward";
            this.txtPublishWormholeReward.Size = new System.Drawing.Size(114, 20);
            this.txtPublishWormholeReward.TabIndex = 83;
            // 
            // txtPublishWormholeName
            // 
            this.txtPublishWormholeName.Location = new System.Drawing.Point(135, 94);
            this.txtPublishWormholeName.MaxLength = 200;
            this.txtPublishWormholeName.Name = "txtPublishWormholeName";
            this.txtPublishWormholeName.Size = new System.Drawing.Size(114, 20);
            this.txtPublishWormholeName.TabIndex = 82;
            this.txtPublishWormholeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPublisherName
            // 
            this.txtPublisherName.BackColor = System.Drawing.Color.Silver;
            this.txtPublisherName.Location = new System.Drawing.Point(135, 60);
            this.txtPublisherName.MaxLength = 200;
            this.txtPublisherName.Name = "txtPublisherName";
            this.txtPublisherName.ReadOnly = true;
            this.txtPublisherName.Size = new System.Drawing.Size(114, 20);
            this.txtPublisherName.TabIndex = 81;
            // 
            // cmdPublishSearchCoordinates
            // 
            this.cmdPublishSearchCoordinates.BackColor = System.Drawing.Color.Black;
            this.cmdPublishSearchCoordinates.ForeColor = System.Drawing.Color.LightGray;
            this.cmdPublishSearchCoordinates.IsActive = true;
            this.cmdPublishSearchCoordinates.IsTabControlButton = false;
            this.cmdPublishSearchCoordinates.Location = new System.Drawing.Point(116, 164);
            this.cmdPublishSearchCoordinates.Name = "cmdPublishSearchCoordinates";
            this.cmdPublishSearchCoordinates.Size = new System.Drawing.Size(165, 26);
            this.cmdPublishSearchCoordinates.TabIndex = 80;
            this.cmdPublishSearchCoordinates.Value = "Publish";
            this.cmdPublishSearchCoordinates.Click += new System.EventHandler(this.Event_Publish);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(9, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Reward:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(9, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wormhole Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(9, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Publisher:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // containerRemove
            // 
            this.containerRemove.Controls.Add(this.label8);
            this.containerRemove.Controls.Add(this.label10);
            this.containerRemove.Controls.Add(this.label11);
            this.containerRemove.Controls.Add(this.txtRemoveWormholeName);
            this.containerRemove.Controls.Add(this.txtRemoveWormholePublisher);
            this.containerRemove.Controls.Add(this.cmdRemoveOperation);
            this.containerRemove.Controls.Add(this.label13);
            this.containerRemove.Controls.Add(this.label14);
            this.containerRemove.Location = new System.Drawing.Point(18, 85);
            this.containerRemove.Name = "containerRemove";
            this.containerRemove.Size = new System.Drawing.Size(446, 203);
            this.containerRemove.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.OrangeRed;
            this.label8.Location = new System.Drawing.Point(9, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(425, 23);
            this.label8.TabIndex = 87;
            this.label8.Text = "Remove Wormhole request";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(258, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 23);
            this.label10.TabIndex = 85;
            this.label10.Text = "Example: J213734";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(258, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(176, 23);
            this.label11.TabIndex = 84;
            this.label11.Text = "Example: Dunkan Su-Shiloff";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemoveWormholeName
            // 
            this.txtRemoveWormholeName.Location = new System.Drawing.Point(135, 94);
            this.txtRemoveWormholeName.MaxLength = 200;
            this.txtRemoveWormholeName.Name = "txtRemoveWormholeName";
            this.txtRemoveWormholeName.Size = new System.Drawing.Size(114, 20);
            this.txtRemoveWormholeName.TabIndex = 82;
            this.txtRemoveWormholeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRemoveWormholePublisher
            // 
            this.txtRemoveWormholePublisher.BackColor = System.Drawing.Color.Silver;
            this.txtRemoveWormholePublisher.Location = new System.Drawing.Point(135, 60);
            this.txtRemoveWormholePublisher.MaxLength = 200;
            this.txtRemoveWormholePublisher.Name = "txtRemoveWormholePublisher";
            this.txtRemoveWormholePublisher.ReadOnly = true;
            this.txtRemoveWormholePublisher.Size = new System.Drawing.Size(114, 20);
            this.txtRemoveWormholePublisher.TabIndex = 81;
            // 
            // cmdRemoveOperation
            // 
            this.cmdRemoveOperation.BackColor = System.Drawing.Color.Black;
            this.cmdRemoveOperation.ForeColor = System.Drawing.Color.LightGray;
            this.cmdRemoveOperation.IsActive = true;
            this.cmdRemoveOperation.IsTabControlButton = false;
            this.cmdRemoveOperation.Location = new System.Drawing.Point(116, 164);
            this.cmdRemoveOperation.Name = "cmdRemoveOperation";
            this.cmdRemoveOperation.Size = new System.Drawing.Size(165, 26);
            this.cmdRemoveOperation.TabIndex = 80;
            this.cmdRemoveOperation.Value = "Remove";
            this.cmdRemoveOperation.Click += new System.EventHandler(this.Event_RemoveOperation);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(9, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 23);
            this.label13.TabIndex = 1;
            this.label13.Text = "Wormhole Name:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(9, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 23);
            this.label14.TabIndex = 0;
            this.label14.Text = "Publisher:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(404, 184);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(447, 203);
            this.dataGridView1.TabIndex = 0;
            // 
            // whlLostAndFoundOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.containerGrid);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdPublish);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.cmdReturn);
            this.Name = "whlLostAndFoundOffice";
            this.Size = new System.Drawing.Size(536, 218);
            this.containerGrid.ResumeLayout(false);
            this.containerMessage.ResumeLayout(false);
            this.containerPublish.ResumeLayout(false);
            this.containerPublish.PerformLayout();
            this.containerRemove.ResumeLayout(false);
            this.containerRemove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private whlButton cmdReturn;
        private whlButton cmdShow;
        private whlButton cmdPublish;
        private whlButton cmdRemove;
        private System.Windows.Forms.Panel containerGrid;
        private System.Windows.Forms.Panel containerRemove;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRemoveWormholeName;
        private System.Windows.Forms.TextBox txtRemoveWormholePublisher;
        private whlButton cmdRemoveOperation;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel containerPublish;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPublishWormholeReward;
        private System.Windows.Forms.TextBox txtPublishWormholeName;
        private System.Windows.Forms.TextBox txtPublisherName;
        private whlButton cmdPublishSearchCoordinates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel containerMessage;
        private System.Windows.Forms.Label lblMessage;
        private whlButton whlButton1;
    }
}
