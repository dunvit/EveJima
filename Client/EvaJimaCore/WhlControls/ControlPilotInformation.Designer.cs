using System.Windows.Forms;

namespace EveJimaCore.WhlControls
{
    partial class ControlPilotInformation : BaseContainer
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
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.crlPilotsHistory = new System.Windows.Forms.ListBox();
            this.txtSelectedPilotName = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cmdCopyPilotsFromClipboard = new EveJimaCore.whlButton();
            this.cmdClearHistory = new EveJimaCore.whlButton();
            this.cmdShowZkillboard = new EveJimaCore.whlButton();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkGray;
            this.label17.Location = new System.Drawing.Point(290, 47);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 61;
            this.label17.Text = "History";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DarkGray;
            this.label16.Location = new System.Drawing.Point(10, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(162, 13);
            this.label16.TabIndex = 60;
            this.label16.Text = "Pilots (copy from Eve chat)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkGray;
            this.label14.Location = new System.Drawing.Point(10, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 13);
            this.label14.TabIndex = 54;
            this.label14.Text = "Selected pilot";
            // 
            // crlPilotsHistory
            // 
            this.crlPilotsHistory.BackColor = System.Drawing.Color.Black;
            this.crlPilotsHistory.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.crlPilotsHistory.ForeColor = System.Drawing.Color.LightGray;
            this.crlPilotsHistory.FormattingEnabled = true;
            this.crlPilotsHistory.Location = new System.Drawing.Point(287, 63);
            this.crlPilotsHistory.Name = "crlPilotsHistory";
            this.crlPilotsHistory.Size = new System.Drawing.Size(242, 134);
            this.crlPilotsHistory.TabIndex = 59;
            this.crlPilotsHistory.Click += new System.EventHandler(this.Event_PilotsHistoryClick);
            // 
            // txtSelectedPilotName
            // 
            this.txtSelectedPilotName.BackColor = System.Drawing.Color.Black;
            this.txtSelectedPilotName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSelectedPilotName.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtSelectedPilotName.ForeColor = System.Drawing.Color.LightGray;
            this.txtSelectedPilotName.Location = new System.Drawing.Point(12, 19);
            this.txtSelectedPilotName.Name = "txtSelectedPilotName";
            this.txtSelectedPilotName.Size = new System.Drawing.Size(250, 21);
            this.txtSelectedPilotName.TabIndex = 58;
            this.txtSelectedPilotName.TextChanged += new System.EventHandler(this.txtSelectedPilotName_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.listBox1.ForeColor = System.Drawing.Color.LightGray;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 63);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(250, 134);
            this.listBox1.TabIndex = 57;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // cmdCopyPilotsFromClipboard
            // 
            this.cmdCopyPilotsFromClipboard.BackColor = System.Drawing.Color.Black;
            this.cmdCopyPilotsFromClipboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmdCopyPilotsFromClipboard.ForeColor = System.Drawing.Color.LightGray;
            this.cmdCopyPilotsFromClipboard.IsActive = true;
            this.cmdCopyPilotsFromClipboard.IsTabControlButton = false;
            this.cmdCopyPilotsFromClipboard.Location = new System.Drawing.Point(60, 220);
            this.cmdCopyPilotsFromClipboard.Name = "cmdCopyPilotsFromClipboard";
            this.cmdCopyPilotsFromClipboard.Size = new System.Drawing.Size(146, 25);
            this.cmdCopyPilotsFromClipboard.TabIndex = 67;
            this.cmdCopyPilotsFromClipboard.Value = "Copy from clipboard";
            this.cmdCopyPilotsFromClipboard.Click += new System.EventHandler(this.cmdCopyPilotsFromClipboard_Click);
            // 
            // cmdClearHistory
            // 
            this.cmdClearHistory.BackColor = System.Drawing.Color.Black;
            this.cmdClearHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmdClearHistory.ForeColor = System.Drawing.Color.LightGray;
            this.cmdClearHistory.IsActive = true;
            this.cmdClearHistory.IsTabControlButton = false;
            this.cmdClearHistory.Location = new System.Drawing.Point(332, 220);
            this.cmdClearHistory.Name = "cmdClearHistory";
            this.cmdClearHistory.Size = new System.Drawing.Size(146, 25);
            this.cmdClearHistory.TabIndex = 66;
            this.cmdClearHistory.Value = "Clear history";
            this.cmdClearHistory.Click += new System.EventHandler(this.cmdClearHistory_Click);
            // 
            // cmdShowZkillboard
            // 
            this.cmdShowZkillboard.BackColor = System.Drawing.Color.Black;
            this.cmdShowZkillboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmdShowZkillboard.ForeColor = System.Drawing.Color.LightGray;
            this.cmdShowZkillboard.IsActive = false;
            this.cmdShowZkillboard.IsTabControlButton = false;
            this.cmdShowZkillboard.Location = new System.Drawing.Point(284, 17);
            this.cmdShowZkillboard.Name = "cmdShowZkillboard";
            this.cmdShowZkillboard.Size = new System.Drawing.Size(245, 25);
            this.cmdShowZkillboard.TabIndex = 64;
            this.cmdShowZkillboard.Value = "Zkillboard";
            this.cmdShowZkillboard.Click += new System.EventHandler(this.cmdShowZkillboard_Click);
            this.cmdShowZkillboard.Load += new System.EventHandler(this.cmdShowZkillboard_Load);
            // 
            // whlPilotInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.cmdCopyPilotsFromClipboard);
            this.Controls.Add(this.cmdClearHistory);
            this.Controls.Add(this.cmdShowZkillboard);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.crlPilotsHistory);
            this.Controls.Add(this.txtSelectedPilotName);
            this.Controls.Add(this.listBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlPilotInformation";
            this.Size = new System.Drawing.Size(544, 256);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox crlPilotsHistory;
        private System.Windows.Forms.TextBox txtSelectedPilotName;
        private System.Windows.Forms.ListBox listBox1;
        private whlButton cmdShowZkillboard;
        private whlButton cmdClearHistory;
        private whlButton cmdCopyPilotsFromClipboard;
    }
}
