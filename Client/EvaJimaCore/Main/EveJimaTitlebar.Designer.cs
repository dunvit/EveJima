namespace EveJimaCore.Main
{
    partial class EveJimaTitlebar
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
            this.cmdHide = new System.Windows.Forms.Button();
            this.cmdPin = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdMinimazeRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdHide
            // 
            this.cmdHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdHide.BackColor = System.Drawing.Color.Black;
            this.cmdHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdHide.Image = global::EveJimaCore.Properties.Resources.hide;
            this.cmdHide.Location = new System.Drawing.Point(735, 3);
            this.cmdHide.Name = "cmdHide";
            this.cmdHide.Size = new System.Drawing.Size(22, 22);
            this.cmdHide.TabIndex = 49;
            this.cmdHide.UseVisualStyleBackColor = false;
            this.cmdHide.Click += new System.EventHandler(this.Event_HideToTray);
            // 
            // cmdPin
            // 
            this.cmdPin.BackColor = System.Drawing.Color.Black;
            this.cmdPin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdPin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPin.Image = global::EveJimaCore.Properties.Resources.pin;
            this.cmdPin.Location = new System.Drawing.Point(3, 3);
            this.cmdPin.Name = "cmdPin";
            this.cmdPin.Size = new System.Drawing.Size(22, 22);
            this.cmdPin.TabIndex = 3;
            this.cmdPin.UseVisualStyleBackColor = false;
            this.cmdPin.Click += new System.EventHandler(this.Event_PinUnpinApplication);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.BackColor = System.Drawing.Color.Black;
            this.cmdClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Image = global::EveJimaCore.Properties.Resources.close;
            this.cmdClose.Location = new System.Drawing.Point(776, 3);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(22, 22);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.Event_CloseApplication);
            // 
            // cmdMinimazeRestore
            // 
            this.cmdMinimazeRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMinimazeRestore.BackColor = System.Drawing.Color.Black;
            this.cmdMinimazeRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdMinimazeRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMinimazeRestore.Image = global::EveJimaCore.Properties.Resources.minimize;
            this.cmdMinimazeRestore.Location = new System.Drawing.Point(756, 3);
            this.cmdMinimazeRestore.Name = "cmdMinimazeRestore";
            this.cmdMinimazeRestore.Size = new System.Drawing.Size(22, 22);
            this.cmdMinimazeRestore.TabIndex = 2;
            this.cmdMinimazeRestore.UseVisualStyleBackColor = false;
            this.cmdMinimazeRestore.Click += new System.EventHandler(this.Event_MinimizeApplication);
            // 
            // EveJimaTitlebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.cmdPin);
            this.Controls.Add(this.cmdHide);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdMinimazeRestore);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.DoubleBuffered = true;
            this.Name = "EveJimaTitlebar";
            this.Size = new System.Drawing.Size(801, 27);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Event_RedrawCurrentLocationInfo);
            this.DoubleClick += new System.EventHandler(this.Event_MinimizeApplication);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdHide;
        private System.Windows.Forms.Button cmdPin;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdMinimazeRestore;
    }
}
