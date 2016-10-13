namespace P6
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button imageMinesButton;
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.x20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusButton = new System.Windows.Forms.Button();
            this.totalMinesLabel = new System.Windows.Forms.Label();
            this.imageClockButton = new System.Windows.Forms.Button();
            this.timerLabel = new System.Windows.Forms.Label();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            imageMinesButton = new System.Windows.Forms.Button();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(352, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.x20ToolStripMenuItem,
            this.x50ToolStripMenuItem,
            this.x100ToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.newGameToolStripMenuItem.Text = "N&ew game";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem1.Text = "9x9";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // x20ToolStripMenuItem
            // 
            this.x20ToolStripMenuItem.Name = "x20ToolStripMenuItem";
            this.x20ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.x20ToolStripMenuItem.Text = "12x12";
            this.x20ToolStripMenuItem.Click += new System.EventHandler(this.x20ToolStripMenuItem_Click);
            // 
            // x50ToolStripMenuItem
            // 
            this.x50ToolStripMenuItem.Name = "x50ToolStripMenuItem";
            this.x50ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.x50ToolStripMenuItem.Text = "18x18";
            this.x50ToolStripMenuItem.Click += new System.EventHandler(this.x50ToolStripMenuItem_Click);
            // 
            // x100ToolStripMenuItem
            // 
            this.x100ToolStripMenuItem.Name = "x100ToolStripMenuItem";
            this.x100ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.x100ToolStripMenuItem.Text = "22x22";
            this.x100ToolStripMenuItem.Click += new System.EventHandler(this.x100ToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusButton
            // 
            this.statusButton.Location = new System.Drawing.Point(144, 31);
            this.statusButton.Name = "statusButton";
            this.statusButton.Size = new System.Drawing.Size(45, 43);
            this.statusButton.TabIndex = 1;
            this.statusButton.UseVisualStyleBackColor = true;
            this.statusButton.Click += new System.EventHandler(this.statusButton_Click);
            // 
            // totalMinesLabel
            // 
            this.totalMinesLabel.AutoSize = true;
            this.totalMinesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalMinesLabel.Location = new System.Drawing.Point(60, 40);
            this.totalMinesLabel.Name = "totalMinesLabel";
            this.totalMinesLabel.Size = new System.Drawing.Size(24, 25);
            this.totalMinesLabel.TabIndex = 2;
            this.totalMinesLabel.Text = "  ";
            // 
            // imageClockButton
            // 
            this.imageClockButton.BackgroundImage = global::P6.Properties.Resources.clock;
            this.imageClockButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageClockButton.Enabled = false;
            this.imageClockButton.Location = new System.Drawing.Point(299, 34);
            this.imageClockButton.Name = "imageClockButton";
            this.imageClockButton.Size = new System.Drawing.Size(41, 36);
            this.imageClockButton.TabIndex = 4;
            this.imageClockButton.UseVisualStyleBackColor = true;
            // 
            // imageMinesButton
            // 
            imageMinesButton.BackgroundImage = global::P6.Properties.Resources.bomb;
            imageMinesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            imageMinesButton.Enabled = false;
            imageMinesButton.Location = new System.Drawing.Point(13, 34);
            imageMinesButton.Name = "imageMinesButton";
            imageMinesButton.Size = new System.Drawing.Size(41, 36);
            imageMinesButton.TabIndex = 3;
            imageMinesButton.UseVisualStyleBackColor = true;
            // 
            // timerLabel
            // 
            this.timerLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.timerLabel.AutoEllipsis = true;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(195, 40);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timerLabel.Size = new System.Drawing.Size(98, 25);
            this.timerLabel.TabIndex = 5;
            this.timerLabel.Text = "  ";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 1000;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(352, 356);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.imageClockButton);
            this.Controls.Add(imageMinesButton);
            this.Controls.Add(this.totalMinesLabel);
            this.Controls.Add(this.statusButton);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "mainForm";
            this.Text = "Minesweeper GUI - Adrian Beloqui";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x20ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x50ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button statusButton;
        private System.Windows.Forms.Label totalMinesLabel;
        private System.Windows.Forms.Button imageClockButton;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Timer mainTimer;
    }
}

