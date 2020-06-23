namespace WormholeNavigator
{
    partial class FormMainMenu
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
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.CommandWindowUnPin = new FontAwesome.Sharp.IconPictureBox();
            this.CommandWindowPin = new FontAwesome.Sharp.IconPictureBox();
            this.CommandPinUnpinPosition = new FontAwesome.Sharp.IconPictureBox();
            this.CommandMinMaxPosition = new FontAwesome.Sharp.IconPictureBox();
            this.CommandWindowMaximize = new FontAwesome.Sharp.IconPictureBox();
            this.CommandWindowMinimaze = new FontAwesome.Sharp.IconPictureBox();
            this.CommandCloseApplication = new FontAwesome.Sharp.IconPictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.CommandShowSettings = new FontAwesome.Sharp.IconButton();
            this.ShowWormholes = new FontAwesome.Sharp.IconButton();
            this.CommandShowBrowser = new FontAwesome.Sharp.IconButton();
            this.CommandShowLocation = new FontAwesome.Sharp.IconButton();
            this.CommandShowBookmarks = new FontAwesome.Sharp.IconButton();
            this.CommandSnowInfo = new FontAwesome.Sharp.IconButton();
            this.CommandShowPilots = new FontAwesome.Sharp.IconButton();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CommandWindowUnPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandWindowPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandPinUnpinPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandMinMaxPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandWindowMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandWindowMinimaze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandCloseApplication)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.Black;
            this.panelTitleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitleBar.Controls.Add(this.CommandWindowUnPin);
            this.panelTitleBar.Controls.Add(this.CommandWindowPin);
            this.panelTitleBar.Controls.Add(this.CommandPinUnpinPosition);
            this.panelTitleBar.Controls.Add(this.CommandMinMaxPosition);
            this.panelTitleBar.Controls.Add(this.CommandWindowMaximize);
            this.panelTitleBar.Controls.Add(this.CommandWindowMinimaze);
            this.panelTitleBar.Controls.Add(this.CommandCloseApplication);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(650, 25);
            this.panelTitleBar.TabIndex = 3;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Event_TitlebarMouseDown);
            // 
            // CommandWindowUnPin
            // 
            this.CommandWindowUnPin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CommandWindowUnPin.IconChar = FontAwesome.Sharp.IconChar.CaretSquareUp;
            this.CommandWindowUnPin.IconColor = System.Drawing.Color.White;
            this.CommandWindowUnPin.IconSize = 24;
            this.CommandWindowUnPin.Location = new System.Drawing.Point(266, 2);
            this.CommandWindowUnPin.Name = "CommandWindowUnPin";
            this.CommandWindowUnPin.Size = new System.Drawing.Size(24, 24);
            this.CommandWindowUnPin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CommandWindowUnPin.TabIndex = 6;
            this.CommandWindowUnPin.TabStop = false;
            this.CommandWindowUnPin.Click += new System.EventHandler(this.Event_WindowUnPin);
            // 
            // CommandWindowPin
            // 
            this.CommandWindowPin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CommandWindowPin.IconChar = FontAwesome.Sharp.IconChar.CaretSquareDown;
            this.CommandWindowPin.IconColor = System.Drawing.Color.White;
            this.CommandWindowPin.IconSize = 24;
            this.CommandWindowPin.Location = new System.Drawing.Point(311, 2);
            this.CommandWindowPin.Name = "CommandWindowPin";
            this.CommandWindowPin.Size = new System.Drawing.Size(24, 24);
            this.CommandWindowPin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CommandWindowPin.TabIndex = 5;
            this.CommandWindowPin.TabStop = false;
            this.CommandWindowPin.Click += new System.EventHandler(this.Event_WindowPin);
            // 
            // CommandPinUnpinPosition
            // 
            this.CommandPinUnpinPosition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CommandPinUnpinPosition.ForeColor = System.Drawing.Color.Black;
            this.CommandPinUnpinPosition.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.CommandPinUnpinPosition.IconColor = System.Drawing.Color.Black;
            this.CommandPinUnpinPosition.IconSize = 24;
            this.CommandPinUnpinPosition.Location = new System.Drawing.Point(3, 2);
            this.CommandPinUnpinPosition.Name = "CommandPinUnpinPosition";
            this.CommandPinUnpinPosition.Size = new System.Drawing.Size(24, 24);
            this.CommandPinUnpinPosition.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CommandPinUnpinPosition.TabIndex = 4;
            this.CommandPinUnpinPosition.TabStop = false;
            this.CommandPinUnpinPosition.Visible = false;
            // 
            // CommandMinMaxPosition
            // 
            this.CommandMinMaxPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandMinMaxPosition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CommandMinMaxPosition.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.CommandMinMaxPosition.IconColor = System.Drawing.Color.White;
            this.CommandMinMaxPosition.IconSize = 24;
            this.CommandMinMaxPosition.Location = new System.Drawing.Point(604, 2);
            this.CommandMinMaxPosition.Name = "CommandMinMaxPosition";
            this.CommandMinMaxPosition.Size = new System.Drawing.Size(24, 24);
            this.CommandMinMaxPosition.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CommandMinMaxPosition.TabIndex = 3;
            this.CommandMinMaxPosition.TabStop = false;
            this.CommandMinMaxPosition.Visible = false;
            // 
            // CommandWindowMaximize
            // 
            this.CommandWindowMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandWindowMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CommandWindowMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.CommandWindowMaximize.IconColor = System.Drawing.Color.White;
            this.CommandWindowMaximize.IconSize = 24;
            this.CommandWindowMaximize.Location = new System.Drawing.Point(485, 3);
            this.CommandWindowMaximize.Name = "CommandWindowMaximize";
            this.CommandWindowMaximize.Size = new System.Drawing.Size(24, 24);
            this.CommandWindowMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CommandWindowMaximize.TabIndex = 2;
            this.CommandWindowMaximize.TabStop = false;
            this.CommandWindowMaximize.Click += new System.EventHandler(this.Event_WindowMaximaze);
            // 
            // CommandWindowMinimaze
            // 
            this.CommandWindowMinimaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandWindowMinimaze.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CommandWindowMinimaze.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.CommandWindowMinimaze.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.CommandWindowMinimaze.IconColor = System.Drawing.Color.WhiteSmoke;
            this.CommandWindowMinimaze.IconSize = 24;
            this.CommandWindowMinimaze.Location = new System.Drawing.Point(455, 0);
            this.CommandWindowMinimaze.Name = "CommandWindowMinimaze";
            this.CommandWindowMinimaze.Size = new System.Drawing.Size(24, 24);
            this.CommandWindowMinimaze.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CommandWindowMinimaze.TabIndex = 1;
            this.CommandWindowMinimaze.TabStop = false;
            this.CommandWindowMinimaze.Click += new System.EventHandler(this.Event_WindowMinimize);
            // 
            // CommandCloseApplication
            // 
            this.CommandCloseApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandCloseApplication.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CommandCloseApplication.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.CommandCloseApplication.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.CommandCloseApplication.IconColor = System.Drawing.Color.WhiteSmoke;
            this.CommandCloseApplication.IconSize = 24;
            this.CommandCloseApplication.Location = new System.Drawing.Point(625, 2);
            this.CommandCloseApplication.Name = "CommandCloseApplication";
            this.CommandCloseApplication.Size = new System.Drawing.Size(24, 24);
            this.CommandCloseApplication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CommandCloseApplication.TabIndex = 0;
            this.CommandCloseApplication.TabStop = false;
            this.CommandCloseApplication.Click += new System.EventHandler(this.Command_ApplicationExit);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.CommandShowSettings);
            this.panelMenu.Controls.Add(this.ShowWormholes);
            this.panelMenu.Controls.Add(this.CommandShowBrowser);
            this.panelMenu.Controls.Add(this.CommandShowLocation);
            this.panelMenu.Controls.Add(this.CommandShowBookmarks);
            this.panelMenu.Controls.Add(this.CommandSnowInfo);
            this.panelMenu.Controls.Add(this.CommandShowPilots);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 25);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(166, 288);
            this.panelMenu.TabIndex = 4;
            // 
            // CommandShowSettings
            // 
            this.CommandShowSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.CommandShowSettings.FlatAppearance.BorderSize = 0;
            this.CommandShowSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CommandShowSettings.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.CommandShowSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandShowSettings.ForeColor = System.Drawing.Color.Gainsboro;
            this.CommandShowSettings.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            this.CommandShowSettings.IconColor = System.Drawing.Color.Gainsboro;
            this.CommandShowSettings.IconSize = 32;
            this.CommandShowSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CommandShowSettings.Location = new System.Drawing.Point(0, 240);
            this.CommandShowSettings.Name = "CommandShowSettings";
            this.CommandShowSettings.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.CommandShowSettings.Rotation = 0D;
            this.CommandShowSettings.Size = new System.Drawing.Size(164, 40);
            this.CommandShowSettings.TabIndex = 12;
            this.CommandShowSettings.Text = "Settings";
            this.CommandShowSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CommandShowSettings.UseVisualStyleBackColor = true;
            this.CommandShowSettings.Click += new System.EventHandler(this.Event_ShowSettings);
            // 
            // ShowWormholes
            // 
            this.ShowWormholes.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShowWormholes.FlatAppearance.BorderSize = 0;
            this.ShowWormholes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowWormholes.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.ShowWormholes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowWormholes.ForeColor = System.Drawing.Color.Gainsboro;
            this.ShowWormholes.IconChar = FontAwesome.Sharp.IconChar.Wifi;
            this.ShowWormholes.IconColor = System.Drawing.Color.Gainsboro;
            this.ShowWormholes.IconSize = 32;
            this.ShowWormholes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ShowWormholes.Location = new System.Drawing.Point(0, 200);
            this.ShowWormholes.Name = "ShowWormholes";
            this.ShowWormholes.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ShowWormholes.Rotation = 0D;
            this.ShowWormholes.Size = new System.Drawing.Size(164, 40);
            this.ShowWormholes.TabIndex = 13;
            this.ShowWormholes.Text = "Wormholes";
            this.ShowWormholes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ShowWormholes.UseVisualStyleBackColor = true;
            this.ShowWormholes.Click += new System.EventHandler(this.Event_ShowWormholes);
            // 
            // CommandShowBrowser
            // 
            this.CommandShowBrowser.Dock = System.Windows.Forms.DockStyle.Top;
            this.CommandShowBrowser.FlatAppearance.BorderSize = 0;
            this.CommandShowBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CommandShowBrowser.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.CommandShowBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandShowBrowser.ForeColor = System.Drawing.Color.Gainsboro;
            this.CommandShowBrowser.IconChar = FontAwesome.Sharp.IconChar.Chrome;
            this.CommandShowBrowser.IconColor = System.Drawing.Color.Gainsboro;
            this.CommandShowBrowser.IconSize = 32;
            this.CommandShowBrowser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CommandShowBrowser.Location = new System.Drawing.Point(0, 160);
            this.CommandShowBrowser.Name = "CommandShowBrowser";
            this.CommandShowBrowser.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.CommandShowBrowser.Rotation = 0D;
            this.CommandShowBrowser.Size = new System.Drawing.Size(164, 40);
            this.CommandShowBrowser.TabIndex = 11;
            this.CommandShowBrowser.Text = "Browser";
            this.CommandShowBrowser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CommandShowBrowser.UseVisualStyleBackColor = true;
            this.CommandShowBrowser.Click += new System.EventHandler(this.Event_ShowBrowser);
            // 
            // CommandShowLocation
            // 
            this.CommandShowLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.CommandShowLocation.FlatAppearance.BorderSize = 0;
            this.CommandShowLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CommandShowLocation.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.CommandShowLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandShowLocation.ForeColor = System.Drawing.Color.Gainsboro;
            this.CommandShowLocation.IconChar = FontAwesome.Sharp.IconChar.Compass;
            this.CommandShowLocation.IconColor = System.Drawing.Color.Gainsboro;
            this.CommandShowLocation.IconSize = 32;
            this.CommandShowLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CommandShowLocation.Location = new System.Drawing.Point(0, 120);
            this.CommandShowLocation.Name = "CommandShowLocation";
            this.CommandShowLocation.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.CommandShowLocation.Rotation = 0D;
            this.CommandShowLocation.Size = new System.Drawing.Size(164, 40);
            this.CommandShowLocation.TabIndex = 10;
            this.CommandShowLocation.Text = "Location";
            this.CommandShowLocation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CommandShowLocation.UseVisualStyleBackColor = true;
            this.CommandShowLocation.Click += new System.EventHandler(this.Event_ShowLocation);
            // 
            // CommandShowBookmarks
            // 
            this.CommandShowBookmarks.Dock = System.Windows.Forms.DockStyle.Top;
            this.CommandShowBookmarks.FlatAppearance.BorderSize = 0;
            this.CommandShowBookmarks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CommandShowBookmarks.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.CommandShowBookmarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandShowBookmarks.ForeColor = System.Drawing.Color.Gainsboro;
            this.CommandShowBookmarks.IconChar = FontAwesome.Sharp.IconChar.Bookmark;
            this.CommandShowBookmarks.IconColor = System.Drawing.Color.Gainsboro;
            this.CommandShowBookmarks.IconSize = 32;
            this.CommandShowBookmarks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CommandShowBookmarks.Location = new System.Drawing.Point(0, 80);
            this.CommandShowBookmarks.Name = "CommandShowBookmarks";
            this.CommandShowBookmarks.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.CommandShowBookmarks.Rotation = 0D;
            this.CommandShowBookmarks.Size = new System.Drawing.Size(164, 40);
            this.CommandShowBookmarks.TabIndex = 9;
            this.CommandShowBookmarks.Text = "Bookmarks";
            this.CommandShowBookmarks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CommandShowBookmarks.UseVisualStyleBackColor = true;
            this.CommandShowBookmarks.Click += new System.EventHandler(this.Event_ShowBookmarks);
            // 
            // CommandSnowInfo
            // 
            this.CommandSnowInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.CommandSnowInfo.FlatAppearance.BorderSize = 0;
            this.CommandSnowInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CommandSnowInfo.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.CommandSnowInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandSnowInfo.ForeColor = System.Drawing.Color.Gainsboro;
            this.CommandSnowInfo.IconChar = FontAwesome.Sharp.IconChar.InfoCircle;
            this.CommandSnowInfo.IconColor = System.Drawing.Color.Gainsboro;
            this.CommandSnowInfo.IconSize = 32;
            this.CommandSnowInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CommandSnowInfo.Location = new System.Drawing.Point(0, 40);
            this.CommandSnowInfo.Name = "CommandSnowInfo";
            this.CommandSnowInfo.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.CommandSnowInfo.Rotation = 0D;
            this.CommandSnowInfo.Size = new System.Drawing.Size(164, 40);
            this.CommandSnowInfo.TabIndex = 8;
            this.CommandSnowInfo.Text = "Information";
            this.CommandSnowInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CommandSnowInfo.UseVisualStyleBackColor = true;
            this.CommandSnowInfo.Click += new System.EventHandler(this.Event_ShowInformation);
            // 
            // CommandShowPilots
            // 
            this.CommandShowPilots.Dock = System.Windows.Forms.DockStyle.Top;
            this.CommandShowPilots.FlatAppearance.BorderSize = 0;
            this.CommandShowPilots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CommandShowPilots.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.CommandShowPilots.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandShowPilots.ForeColor = System.Drawing.Color.Gainsboro;
            this.CommandShowPilots.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            this.CommandShowPilots.IconColor = System.Drawing.Color.Gainsboro;
            this.CommandShowPilots.IconSize = 32;
            this.CommandShowPilots.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CommandShowPilots.Location = new System.Drawing.Point(0, 0);
            this.CommandShowPilots.Name = "CommandShowPilots";
            this.CommandShowPilots.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.CommandShowPilots.Rotation = 0D;
            this.CommandShowPilots.Size = new System.Drawing.Size(164, 40);
            this.CommandShowPilots.TabIndex = 7;
            this.CommandShowPilots.Text = "Pilots";
            this.CommandShowPilots.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CommandShowPilots.UseVisualStyleBackColor = true;
            this.CommandShowPilots.Click += new System.EventHandler(this.Event_ShowPilots);
            // 
            // panelDesktop
            // 
            this.panelDesktop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(166, 25);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(484, 288);
            this.panelDesktop.TabIndex = 5;
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 313);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTitleBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMainMenu";
            this.Text = "FormMainMenu";
            this.panelTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CommandWindowUnPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandWindowPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandPinUnpinPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandMinMaxPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandWindowMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandWindowMinimaze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandCloseApplication)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox CommandCloseApplication;
        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton CommandShowSettings;
        private FontAwesome.Sharp.IconButton CommandShowBrowser;
        private FontAwesome.Sharp.IconButton CommandShowLocation;
        private FontAwesome.Sharp.IconButton CommandShowBookmarks;
        private FontAwesome.Sharp.IconButton CommandSnowInfo;
        private FontAwesome.Sharp.IconButton CommandShowPilots;
        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconPictureBox CommandWindowMinimaze;
        private FontAwesome.Sharp.IconPictureBox CommandWindowMaximize;
        private FontAwesome.Sharp.IconPictureBox CommandMinMaxPosition;
        private FontAwesome.Sharp.IconPictureBox CommandWindowPin;
        private FontAwesome.Sharp.IconPictureBox CommandPinUnpinPosition;
        private FontAwesome.Sharp.IconPictureBox CommandWindowUnPin;
        private FontAwesome.Sharp.IconButton ShowWormholes;
    }
}