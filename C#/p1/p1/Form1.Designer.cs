namespace p1
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
            this.numberSetpsLabel = new System.Windows.Forms.Label();
            this.strideLengthLabel = new System.Windows.Forms.Label();
            this.milesWalkedLabel = new System.Windows.Forms.Label();
            this.stepsTextBox = new System.Windows.Forms.TextBox();
            this.inchesTextBox = new System.Windows.Forms.TextBox();
            this.milesTextBox = new System.Windows.Forms.TextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.calculateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numberSetpsLabel
            // 
            this.numberSetpsLabel.AutoSize = true;
            this.numberSetpsLabel.Location = new System.Drawing.Point(63, 34);
            this.numberSetpsLabel.Name = "numberSetpsLabel";
            this.numberSetpsLabel.Size = new System.Drawing.Size(89, 13);
            this.numberSetpsLabel.TabIndex = 0;
            this.numberSetpsLabel.Text = "Number of Steps:";
            // 
            // strideLengthLabel
            // 
            this.strideLengthLabel.AutoSize = true;
            this.strideLengthLabel.Location = new System.Drawing.Point(38, 75);
            this.strideLengthLabel.Name = "strideLengthLabel";
            this.strideLengthLabel.Size = new System.Drawing.Size(114, 13);
            this.strideLengthLabel.TabIndex = 1;
            this.strideLengthLabel.Text = "Stride Length (Inches):";
            // 
            // milesWalkedLabel
            // 
            this.milesWalkedLabel.AutoSize = true;
            this.milesWalkedLabel.Location = new System.Drawing.Point(78, 118);
            this.milesWalkedLabel.Name = "milesWalkedLabel";
            this.milesWalkedLabel.Size = new System.Drawing.Size(74, 13);
            this.milesWalkedLabel.TabIndex = 2;
            this.milesWalkedLabel.Text = "Miles Walked:";
            // 
            // stepsTextBox
            // 
            this.stepsTextBox.Location = new System.Drawing.Point(158, 31);
            this.stepsTextBox.Name = "stepsTextBox";
            this.stepsTextBox.Size = new System.Drawing.Size(100, 20);
            this.stepsTextBox.TabIndex = 3;
            // 
            // inchesTextBox
            // 
            this.inchesTextBox.Location = new System.Drawing.Point(158, 72);
            this.inchesTextBox.Name = "inchesTextBox";
            this.inchesTextBox.Size = new System.Drawing.Size(100, 20);
            this.inchesTextBox.TabIndex = 4;
            // 
            // milesTextBox
            // 
            this.milesTextBox.Enabled = false;
            this.milesTextBox.Location = new System.Drawing.Point(158, 115);
            this.milesTextBox.Name = "milesTextBox";
            this.milesTextBox.Size = new System.Drawing.Size(100, 20);
            this.milesTextBox.TabIndex = 5;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Enabled = false;
            this.messageTextBox.Location = new System.Drawing.Point(26, 163);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(232, 20);
            this.messageTextBox.TabIndex = 6;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(285, 118);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(94, 28);
            this.resetButton.TabIndex = 7;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(285, 158);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(94, 28);
            this.calculateButton.TabIndex = 8;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 208);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.milesTextBox);
            this.Controls.Add(this.inchesTextBox);
            this.Controls.Add(this.stepsTextBox);
            this.Controls.Add(this.milesWalkedLabel);
            this.Controls.Add(this.strideLengthLabel);
            this.Controls.Add(this.numberSetpsLabel);
            this.Name = "mainForm";
            this.Text = "P1 Step Calculator - Adrian Beloqui";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberSetpsLabel;
        private System.Windows.Forms.Label strideLengthLabel;
        private System.Windows.Forms.Label milesWalkedLabel;
        private System.Windows.Forms.TextBox stepsTextBox;
        private System.Windows.Forms.TextBox inchesTextBox;
        private System.Windows.Forms.TextBox milesTextBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button calculateButton;
    }
}

