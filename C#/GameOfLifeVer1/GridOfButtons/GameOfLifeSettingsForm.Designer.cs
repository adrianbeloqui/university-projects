namespace GridOfButtons
{
    partial class GameOfLifeSettingsForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.rowTextBox = new System.Windows.Forms.TextBox();
            this.rowLabel = new System.Windows.Forms.Label();
            this.colLabel = new System.Windows.Forms.Label();
            this.colTextBox = new System.Windows.Forms.TextBox();
            this.timerTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(129, 245);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(123, 54);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // rowTextBox
            // 
            this.rowTextBox.Location = new System.Drawing.Point(129, 102);
            this.rowTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rowTextBox.Name = "rowTextBox";
            this.rowTextBox.Size = new System.Drawing.Size(140, 26);
            this.rowTextBox.TabIndex = 2;
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Location = new System.Drawing.Point(50, 102);
            this.rowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(49, 20);
            this.rowLabel.TabIndex = 3;
            this.rowLabel.Text = "Rows";
            // 
            // colLabel
            // 
            this.colLabel.AutoSize = true;
            this.colLabel.Location = new System.Drawing.Point(50, 166);
            this.colLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.colLabel.Name = "colLabel";
            this.colLabel.Size = new System.Drawing.Size(71, 20);
            this.colLabel.TabIndex = 5;
            this.colLabel.Text = "Columns";
            // 
            // colTextBox
            // 
            this.colTextBox.Location = new System.Drawing.Point(129, 162);
            this.colTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.colTextBox.Name = "colTextBox";
            this.colTextBox.Size = new System.Drawing.Size(140, 26);
            this.colTextBox.TabIndex = 4;
            // 
            // timerTextBox
            // 
            this.timerTextBox.Location = new System.Drawing.Point(130, 212);
            this.timerTextBox.Name = "timerTextBox";
            this.timerTextBox.Size = new System.Drawing.Size(138, 26);
            this.timerTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // GameOfLifeSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 362);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timerTextBox);
            this.Controls.Add(this.colLabel);
            this.Controls.Add(this.colTextBox);
            this.Controls.Add(this.rowLabel);
            this.Controls.Add(this.rowTextBox);
            this.Controls.Add(this.okButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GameOfLifeSettingsForm";
            this.Text = "GameOfLifeSettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox rowTextBox;
        private System.Windows.Forms.Label rowLabel;
        private System.Windows.Forms.Label colLabel;
        private System.Windows.Forms.TextBox colTextBox;
        private System.Windows.Forms.TextBox timerTextBox;
        private System.Windows.Forms.Label label1;
    }
}