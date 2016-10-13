namespace P5
{
    partial class AddVehicleForm
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
            this.newVehicleGroupBox = new System.Windows.Forms.GroupBox();
            this.newVehicleBrandLabel = new System.Windows.Forms.Label();
            this.newVehicleModelLabel = new System.Windows.Forms.Label();
            this.newVehiclePlateLable = new System.Windows.Forms.Label();
            this.newVehicleTypeLabel = new System.Windows.Forms.Label();
            this.newVehicleBrandTextBox = new System.Windows.Forms.TextBox();
            this.newVehicleModelTextBox = new System.Windows.Forms.TextBox();
            this.newVehiclePlateNumberTextBox = new System.Windows.Forms.TextBox();
            this.newVehicleTypeComboBox = new System.Windows.Forms.ComboBox();
            this.newVehicleCreateButton = new System.Windows.Forms.Button();
            this.newVehicleGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // newVehicleGroupBox
            // 
            this.newVehicleGroupBox.Controls.Add(this.newVehicleTypeComboBox);
            this.newVehicleGroupBox.Controls.Add(this.newVehiclePlateNumberTextBox);
            this.newVehicleGroupBox.Controls.Add(this.newVehicleModelTextBox);
            this.newVehicleGroupBox.Controls.Add(this.newVehicleBrandTextBox);
            this.newVehicleGroupBox.Controls.Add(this.newVehicleTypeLabel);
            this.newVehicleGroupBox.Controls.Add(this.newVehiclePlateLable);
            this.newVehicleGroupBox.Controls.Add(this.newVehicleModelLabel);
            this.newVehicleGroupBox.Controls.Add(this.newVehicleBrandLabel);
            this.newVehicleGroupBox.Location = new System.Drawing.Point(165, 71);
            this.newVehicleGroupBox.Name = "newVehicleGroupBox";
            this.newVehicleGroupBox.Size = new System.Drawing.Size(283, 182);
            this.newVehicleGroupBox.TabIndex = 0;
            this.newVehicleGroupBox.TabStop = false;
            this.newVehicleGroupBox.Text = "New Vehicle";
            // 
            // newVehicleBrandLabel
            // 
            this.newVehicleBrandLabel.AutoSize = true;
            this.newVehicleBrandLabel.Location = new System.Drawing.Point(44, 39);
            this.newVehicleBrandLabel.Name = "newVehicleBrandLabel";
            this.newVehicleBrandLabel.Size = new System.Drawing.Size(38, 13);
            this.newVehicleBrandLabel.TabIndex = 0;
            this.newVehicleBrandLabel.Text = "Brand:";
            // 
            // newVehicleModelLabel
            // 
            this.newVehicleModelLabel.AutoSize = true;
            this.newVehicleModelLabel.Location = new System.Drawing.Point(44, 72);
            this.newVehicleModelLabel.Name = "newVehicleModelLabel";
            this.newVehicleModelLabel.Size = new System.Drawing.Size(36, 13);
            this.newVehicleModelLabel.TabIndex = 1;
            this.newVehicleModelLabel.Text = "Model";
            // 
            // newVehiclePlateLable
            // 
            this.newVehiclePlateLable.AutoSize = true;
            this.newVehiclePlateLable.Location = new System.Drawing.Point(44, 103);
            this.newVehiclePlateLable.Name = "newVehiclePlateLable";
            this.newVehiclePlateLable.Size = new System.Drawing.Size(72, 13);
            this.newVehiclePlateLable.TabIndex = 2;
            this.newVehiclePlateLable.Text = "Plate number:";
            // 
            // newVehicleTypeLabel
            // 
            this.newVehicleTypeLabel.AutoSize = true;
            this.newVehicleTypeLabel.Location = new System.Drawing.Point(44, 132);
            this.newVehicleTypeLabel.Name = "newVehicleTypeLabel";
            this.newVehicleTypeLabel.Size = new System.Drawing.Size(31, 13);
            this.newVehicleTypeLabel.TabIndex = 3;
            this.newVehicleTypeLabel.Text = "Type";
            // 
            // newVehicleBrandTextBox
            // 
            this.newVehicleBrandTextBox.Location = new System.Drawing.Point(88, 36);
            this.newVehicleBrandTextBox.Name = "newVehicleBrandTextBox";
            this.newVehicleBrandTextBox.Size = new System.Drawing.Size(100, 20);
            this.newVehicleBrandTextBox.TabIndex = 4;
            // 
            // newVehicleModelTextBox
            // 
            this.newVehicleModelTextBox.Location = new System.Drawing.Point(88, 69);
            this.newVehicleModelTextBox.Name = "newVehicleModelTextBox";
            this.newVehicleModelTextBox.Size = new System.Drawing.Size(100, 20);
            this.newVehicleModelTextBox.TabIndex = 5;
            // 
            // newVehiclePlateNumberTextBox
            // 
            this.newVehiclePlateNumberTextBox.Location = new System.Drawing.Point(122, 100);
            this.newVehiclePlateNumberTextBox.Name = "newVehiclePlateNumberTextBox";
            this.newVehiclePlateNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.newVehiclePlateNumberTextBox.TabIndex = 6;
            // 
            // newVehicleTypeComboBox
            // 
            this.newVehicleTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.newVehicleTypeComboBox.FormattingEnabled = true;
            this.newVehicleTypeComboBox.Items.AddRange(new object[] {
            "Car"});
            this.newVehicleTypeComboBox.Location = new System.Drawing.Point(81, 129);
            this.newVehicleTypeComboBox.Name = "newVehicleTypeComboBox";
            this.newVehicleTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.newVehicleTypeComboBox.TabIndex = 7;
            // 
            // newVehicleCreateButton
            // 
            this.newVehicleCreateButton.Location = new System.Drawing.Point(373, 269);
            this.newVehicleCreateButton.Name = "newVehicleCreateButton";
            this.newVehicleCreateButton.Size = new System.Drawing.Size(75, 23);
            this.newVehicleCreateButton.TabIndex = 1;
            this.newVehicleCreateButton.Text = "Create";
            this.newVehicleCreateButton.UseVisualStyleBackColor = true;
            this.newVehicleCreateButton.Click += new System.EventHandler(this.newVehicleCreateButton_Click);
            // 
            // AddVehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(595, 496);
            this.Controls.Add(this.newVehicleCreateButton);
            this.Controls.Add(this.newVehicleGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddVehicleForm";
            this.Text = "AddVehicleForm";
            this.newVehicleGroupBox.ResumeLayout(false);
            this.newVehicleGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox newVehicleGroupBox;
        private System.Windows.Forms.ComboBox newVehicleTypeComboBox;
        private System.Windows.Forms.TextBox newVehiclePlateNumberTextBox;
        private System.Windows.Forms.TextBox newVehicleModelTextBox;
        private System.Windows.Forms.TextBox newVehicleBrandTextBox;
        private System.Windows.Forms.Label newVehicleTypeLabel;
        private System.Windows.Forms.Label newVehiclePlateLable;
        private System.Windows.Forms.Label newVehicleModelLabel;
        private System.Windows.Forms.Label newVehicleBrandLabel;
        private System.Windows.Forms.Button newVehicleCreateButton;
    }
}