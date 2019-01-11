namespace EveJimaCore.WhlControls
{
    partial class ControlCurrentLocation
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
            this.cmdPasta = new EveJimaCore.whlButton();
            this.cmdTripwire = new EveJimaCore.whlButton();
            this.cmdDotlan = new EveJimaCore.whlButton();
            this.cmdEllatha = new EveJimaCore.whlButton();
            this.cmdSuperpute = new EveJimaCore.whlButton();
            this.cmdZkillboard = new EveJimaCore.whlButton();
            this.txtSolarSystemConstellation = new System.Windows.Forms.Label();
            this.txtSolarSystemRegion = new System.Windows.Forms.Label();
            this.txtSolarSystemStaticIIData = new System.Windows.Forms.Label();
            this.txtSolarSystemStaticIData = new System.Windows.Forms.Label();
            this.txtSolarSystemStaticII = new System.Windows.Forms.Label();
            this.txtSolarSystemStaticI = new System.Windows.Forms.Label();
            this.txtSolarSystemEffect = new System.Windows.Forms.Label();
            this.lbl_StaticII = new System.Windows.Forms.Label();
            this.lbl_Constellation = new System.Windows.Forms.Label();
            this.lbl_Region = new System.Windows.Forms.Label();
            this.lbl_StaticI = new System.Windows.Forms.Label();
            this.lbl_Effect = new System.Windows.Forms.Label();
            this.lbl_Class = new System.Windows.Forms.Label();
            this.txtSolarSystemName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdPasta
            // 
            this.cmdPasta.BackColor = System.Drawing.Color.Black;
            this.cmdPasta.ForeColor = System.Drawing.Color.LightGray;
            this.cmdPasta.IsActive = true;
            this.cmdPasta.IsTabControlButton = false;
            this.cmdPasta.Location = new System.Drawing.Point(377, 160);
            this.cmdPasta.Name = "cmdPasta";
            this.cmdPasta.Size = new System.Drawing.Size(148, 26);
            this.cmdPasta.TabIndex = 99;
            this.cmdPasta.Value = "Pasta.gg";
            this.cmdPasta.Click += new System.EventHandler(this.Event_PastaShow);
            // 
            // cmdTripwire
            // 
            this.cmdTripwire.BackColor = System.Drawing.Color.Black;
            this.cmdTripwire.ForeColor = System.Drawing.Color.LightGray;
            this.cmdTripwire.IsActive = true;
            this.cmdTripwire.IsTabControlButton = false;
            this.cmdTripwire.Location = new System.Drawing.Point(377, 128);
            this.cmdTripwire.Name = "cmdTripwire";
            this.cmdTripwire.Size = new System.Drawing.Size(148, 26);
            this.cmdTripwire.TabIndex = 95;
            this.cmdTripwire.Value = "Tripwire";
            this.cmdTripwire.Click += new System.EventHandler(this.Event_TripwireShow);
            // 
            // cmdDotlan
            // 
            this.cmdDotlan.BackColor = System.Drawing.Color.Black;
            this.cmdDotlan.ForeColor = System.Drawing.Color.LightGray;
            this.cmdDotlan.IsActive = true;
            this.cmdDotlan.IsTabControlButton = false;
            this.cmdDotlan.Location = new System.Drawing.Point(377, 99);
            this.cmdDotlan.Name = "cmdDotlan";
            this.cmdDotlan.Size = new System.Drawing.Size(148, 26);
            this.cmdDotlan.TabIndex = 94;
            this.cmdDotlan.Value = "Dotlan";
            this.cmdDotlan.Click += new System.EventHandler(this.Event_ShowDotlan);
            // 
            // cmdEllatha
            // 
            this.cmdEllatha.BackColor = System.Drawing.Color.Black;
            this.cmdEllatha.ForeColor = System.Drawing.Color.LightGray;
            this.cmdEllatha.IsActive = true;
            this.cmdEllatha.IsTabControlButton = false;
            this.cmdEllatha.Location = new System.Drawing.Point(377, 70);
            this.cmdEllatha.Name = "cmdEllatha";
            this.cmdEllatha.Size = new System.Drawing.Size(148, 26);
            this.cmdEllatha.TabIndex = 93;
            this.cmdEllatha.Value = "Ellatha";
            this.cmdEllatha.Click += new System.EventHandler(this.Event_ShowEllatha);
            // 
            // cmdSuperpute
            // 
            this.cmdSuperpute.BackColor = System.Drawing.Color.Black;
            this.cmdSuperpute.ForeColor = System.Drawing.Color.LightGray;
            this.cmdSuperpute.IsActive = true;
            this.cmdSuperpute.IsTabControlButton = false;
            this.cmdSuperpute.Location = new System.Drawing.Point(377, 41);
            this.cmdSuperpute.Name = "cmdSuperpute";
            this.cmdSuperpute.Size = new System.Drawing.Size(148, 26);
            this.cmdSuperpute.TabIndex = 92;
            this.cmdSuperpute.Value = "eve-wh.space";
            this.cmdSuperpute.Click += new System.EventHandler(this.Event_ShowSuperpute);
            // 
            // cmdZkillboard
            // 
            this.cmdZkillboard.BackColor = System.Drawing.Color.Black;
            this.cmdZkillboard.ForeColor = System.Drawing.Color.LightGray;
            this.cmdZkillboard.IsActive = true;
            this.cmdZkillboard.IsTabControlButton = false;
            this.cmdZkillboard.Location = new System.Drawing.Point(377, 12);
            this.cmdZkillboard.Name = "cmdZkillboard";
            this.cmdZkillboard.Size = new System.Drawing.Size(148, 26);
            this.cmdZkillboard.TabIndex = 91;
            this.cmdZkillboard.Value = "Zkillboard";
            this.cmdZkillboard.Click += new System.EventHandler(this.Event_ShowZkillboard);
            // 
            // txtSolarSystemConstellation
            // 
            this.txtSolarSystemConstellation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolarSystemConstellation.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSolarSystemConstellation.Location = new System.Drawing.Point(154, 62);
            this.txtSolarSystemConstellation.Name = "txtSolarSystemConstellation";
            this.txtSolarSystemConstellation.Size = new System.Drawing.Size(100, 23);
            this.txtSolarSystemConstellation.TabIndex = 90;
            this.txtSolarSystemConstellation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSolarSystemRegion
            // 
            this.txtSolarSystemRegion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolarSystemRegion.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSolarSystemRegion.Location = new System.Drawing.Point(154, 39);
            this.txtSolarSystemRegion.Name = "txtSolarSystemRegion";
            this.txtSolarSystemRegion.Size = new System.Drawing.Size(100, 23);
            this.txtSolarSystemRegion.TabIndex = 89;
            this.txtSolarSystemRegion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSolarSystemStaticIIData
            // 
            this.txtSolarSystemStaticIIData.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolarSystemStaticIIData.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSolarSystemStaticIIData.Location = new System.Drawing.Point(224, 135);
            this.txtSolarSystemStaticIIData.Name = "txtSolarSystemStaticIIData";
            this.txtSolarSystemStaticIIData.Size = new System.Drawing.Size(130, 23);
            this.txtSolarSystemStaticIIData.TabIndex = 88;
            this.txtSolarSystemStaticIIData.Text = "111111";
            this.txtSolarSystemStaticIIData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSolarSystemStaticIIData.Visible = false;
            // 
            // txtSolarSystemStaticIData
            // 
            this.txtSolarSystemStaticIData.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolarSystemStaticIData.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSolarSystemStaticIData.Location = new System.Drawing.Point(224, 112);
            this.txtSolarSystemStaticIData.Name = "txtSolarSystemStaticIData";
            this.txtSolarSystemStaticIData.Size = new System.Drawing.Size(130, 23);
            this.txtSolarSystemStaticIData.TabIndex = 87;
            this.txtSolarSystemStaticIData.Text = "111111";
            this.txtSolarSystemStaticIData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSolarSystemStaticIData.Visible = false;
            // 
            // txtSolarSystemStaticII
            // 
            this.txtSolarSystemStaticII.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolarSystemStaticII.ForeColor = System.Drawing.Color.Goldenrod;
            this.txtSolarSystemStaticII.Location = new System.Drawing.Point(154, 136);
            this.txtSolarSystemStaticII.Name = "txtSolarSystemStaticII";
            this.txtSolarSystemStaticII.Size = new System.Drawing.Size(64, 23);
            this.txtSolarSystemStaticII.TabIndex = 86;
            this.txtSolarSystemStaticII.Text = "222";
            this.txtSolarSystemStaticII.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSolarSystemStaticII.Visible = false;
            // 
            // txtSolarSystemStaticI
            // 
            this.txtSolarSystemStaticI.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolarSystemStaticI.ForeColor = System.Drawing.Color.Goldenrod;
            this.txtSolarSystemStaticI.Location = new System.Drawing.Point(154, 113);
            this.txtSolarSystemStaticI.Name = "txtSolarSystemStaticI";
            this.txtSolarSystemStaticI.Size = new System.Drawing.Size(64, 23);
            this.txtSolarSystemStaticI.TabIndex = 85;
            this.txtSolarSystemStaticI.Text = "222";
            this.txtSolarSystemStaticI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSolarSystemStaticI.Visible = false;
            // 
            // txtSolarSystemEffect
            // 
            this.txtSolarSystemEffect.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolarSystemEffect.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSolarSystemEffect.Location = new System.Drawing.Point(154, 89);
            this.txtSolarSystemEffect.Name = "txtSolarSystemEffect";
            this.txtSolarSystemEffect.Size = new System.Drawing.Size(100, 23);
            this.txtSolarSystemEffect.TabIndex = 84;
            this.txtSolarSystemEffect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.lbl_StaticII.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_StaticII.ForeColor = System.Drawing.Color.White;
            this.lbl_StaticII.Location = new System.Drawing.Point(24, 134);
            this.lbl_StaticII.Name = "lbl_StaticII";
            this.lbl_StaticII.Size = new System.Drawing.Size(100, 23);
            this.lbl_StaticII.TabIndex = 82;
            this.lbl_StaticII.Text = "WH Static II";
            this.lbl_StaticII.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.lbl_Constellation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Constellation.ForeColor = System.Drawing.Color.White;
            this.lbl_Constellation.Location = new System.Drawing.Point(24, 65);
            this.lbl_Constellation.Name = "lbl_Constellation";
            this.lbl_Constellation.Size = new System.Drawing.Size(109, 23);
            this.lbl_Constellation.TabIndex = 81;
            this.lbl_Constellation.Text = "Constellation";
            this.lbl_Constellation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.lbl_Region.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Region.ForeColor = System.Drawing.Color.White;
            this.lbl_Region.Location = new System.Drawing.Point(24, 42);
            this.lbl_Region.Name = "lbl_Region";
            this.lbl_Region.Size = new System.Drawing.Size(100, 23);
            this.lbl_Region.TabIndex = 80;
            this.lbl_Region.Text = "Region";
            this.lbl_Region.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.lbl_StaticI.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_StaticI.ForeColor = System.Drawing.Color.White;
            this.lbl_StaticI.Location = new System.Drawing.Point(24, 111);
            this.lbl_StaticI.Name = "lbl_StaticI";
            this.lbl_StaticI.Size = new System.Drawing.Size(100, 23);
            this.lbl_StaticI.TabIndex = 79;
            this.lbl_StaticI.Text = "WH Static I";
            this.lbl_StaticI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.lbl_Effect.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Effect.ForeColor = System.Drawing.Color.White;
            this.lbl_Effect.Location = new System.Drawing.Point(24, 88);
            this.lbl_Effect.Name = "lbl_Effect";
            this.lbl_Effect.Size = new System.Drawing.Size(100, 23);
            this.lbl_Effect.TabIndex = 78;
            this.lbl_Effect.Text = "WH Effect";
            this.lbl_Effect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblClass
            // 
            this.lbl_Class.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_Class.ForeColor = System.Drawing.Color.White;
            this.lbl_Class.Location = new System.Drawing.Point(116, 6);
            this.lbl_Class.Name = "lbl_Class";
            this.lbl_Class.Size = new System.Drawing.Size(112, 23);
            this.lbl_Class.TabIndex = 77;
            this.lbl_Class.Text = "Class";
            this.lbl_Class.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSolarSystemName
            // 
            this.txtSolarSystemName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolarSystemName.ForeColor = System.Drawing.Color.DarkOrange;
            this.txtSolarSystemName.Location = new System.Drawing.Point(10, 9);
            this.txtSolarSystemName.Name = "txtSolarSystemName";
            this.txtSolarSystemName.Size = new System.Drawing.Size(100, 23);
            this.txtSolarSystemName.TabIndex = 100;
            this.txtSolarSystemName.Text = "J100200300";
            this.txtSolarSystemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EveCrlLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.txtSolarSystemName);
            this.Controls.Add(this.cmdPasta);
            this.Controls.Add(this.cmdTripwire);
            this.Controls.Add(this.cmdDotlan);
            this.Controls.Add(this.cmdEllatha);
            this.Controls.Add(this.cmdSuperpute);
            this.Controls.Add(this.cmdZkillboard);
            this.Controls.Add(this.txtSolarSystemConstellation);
            this.Controls.Add(this.txtSolarSystemRegion);
            this.Controls.Add(this.txtSolarSystemStaticIIData);
            this.Controls.Add(this.txtSolarSystemStaticIData);
            this.Controls.Add(this.txtSolarSystemStaticII);
            this.Controls.Add(this.txtSolarSystemStaticI);
            this.Controls.Add(this.txtSolarSystemEffect);
            this.Controls.Add(this.lbl_StaticII);
            this.Controls.Add(this.lbl_Constellation);
            this.Controls.Add(this.lbl_Region);
            this.Controls.Add(this.lbl_StaticI);
            this.Controls.Add(this.lbl_Effect);
            this.Controls.Add(this.lbl_Class);
            this.DoubleBuffered = true;
            this.Name = "ControlCurrentLocation";
            this.Size = new System.Drawing.Size(550, 250);
            this.ResumeLayout(false);

        }

        #endregion

        private whlButton cmdPasta;
        private whlButton cmdTripwire;
        private whlButton cmdDotlan;
        private whlButton cmdEllatha;
        private whlButton cmdSuperpute;
        private whlButton cmdZkillboard;
        private System.Windows.Forms.Label txtSolarSystemConstellation;
        private System.Windows.Forms.Label txtSolarSystemRegion;
        private System.Windows.Forms.Label txtSolarSystemStaticIIData;
        private System.Windows.Forms.Label txtSolarSystemStaticIData;
        private System.Windows.Forms.Label txtSolarSystemStaticII;
        private System.Windows.Forms.Label txtSolarSystemStaticI;
        private System.Windows.Forms.Label txtSolarSystemEffect;
        private System.Windows.Forms.Label lbl_StaticII;
        private System.Windows.Forms.Label lbl_Constellation;
        private System.Windows.Forms.Label lbl_Region;
        private System.Windows.Forms.Label lbl_StaticI;
        private System.Windows.Forms.Label lbl_Effect;
        private System.Windows.Forms.Label lbl_Class;
        private System.Windows.Forms.Label txtSolarSystemName;
    }
}
