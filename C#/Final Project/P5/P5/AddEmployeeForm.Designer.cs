namespace P5
{
    partial class AddEmployeeForm
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
            this.newClientGroupBox = new System.Windows.Forms.GroupBox();
            this.newEmployeePositionComboBox = new System.Windows.Forms.ComboBox();
            this.positionLabel = new System.Windows.Forms.Label();
            this.newEmployeeNameTextBox = new System.Windows.Forms.TextBox();
            this.newEmployeeLastNameTextBox = new System.Windows.Forms.TextBox();
            this.newEmployeeSSNTextBox = new System.Windows.Forms.TextBox();
            this.newEmployeeNationalityTextBox = new System.Windows.Forms.TextBox();
            this.newEmployeeSexComboBox = new System.Windows.Forms.ComboBox();
            this.birthDateLabel = new System.Windows.Forms.Label();
            this.newEmployeeBirthDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.sexLabel = new System.Windows.Forms.Label();
            this.nacionalityLabel = new System.Windows.Forms.Label();
            this.ssnLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.createNewEmployeeButton = new System.Windows.Forms.Button();
            this.newClientGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // newClientGroupBox
            // 
            this.newClientGroupBox.Controls.Add(this.newEmployeePositionComboBox);
            this.newClientGroupBox.Controls.Add(this.positionLabel);
            this.newClientGroupBox.Controls.Add(this.newEmployeeNameTextBox);
            this.newClientGroupBox.Controls.Add(this.newEmployeeLastNameTextBox);
            this.newClientGroupBox.Controls.Add(this.newEmployeeSSNTextBox);
            this.newClientGroupBox.Controls.Add(this.newEmployeeNationalityTextBox);
            this.newClientGroupBox.Controls.Add(this.newEmployeeSexComboBox);
            this.newClientGroupBox.Controls.Add(this.birthDateLabel);
            this.newClientGroupBox.Controls.Add(this.newEmployeeBirthDateDateTimePicker);
            this.newClientGroupBox.Controls.Add(this.sexLabel);
            this.newClientGroupBox.Controls.Add(this.nacionalityLabel);
            this.newClientGroupBox.Controls.Add(this.ssnLabel);
            this.newClientGroupBox.Controls.Add(this.lastNameLabel);
            this.newClientGroupBox.Controls.Add(this.nameLabel);
            this.newClientGroupBox.Location = new System.Drawing.Point(108, 74);
            this.newClientGroupBox.Name = "newClientGroupBox";
            this.newClientGroupBox.Size = new System.Drawing.Size(404, 301);
            this.newClientGroupBox.TabIndex = 0;
            this.newClientGroupBox.TabStop = false;
            this.newClientGroupBox.Text = "New Employee";
            // 
            // newEmployeePositionComboBox
            // 
            this.newEmployeePositionComboBox.FormattingEnabled = true;
            this.newEmployeePositionComboBox.Items.AddRange(new object[] {
            "Administrator",
            "Driver"});
            this.newEmployeePositionComboBox.Location = new System.Drawing.Point(88, 252);
            this.newEmployeePositionComboBox.Name = "newEmployeePositionComboBox";
            this.newEmployeePositionComboBox.Size = new System.Drawing.Size(121, 21);
            this.newEmployeePositionComboBox.TabIndex = 7;
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(35, 255);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(47, 13);
            this.positionLabel.TabIndex = 7;
            this.positionLabel.Text = "Position:";
            // 
            // newEmployeeNameTextBox
            // 
            this.newEmployeeNameTextBox.Location = new System.Drawing.Point(79, 38);
            this.newEmployeeNameTextBox.Name = "newEmployeeNameTextBox";
            this.newEmployeeNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.newEmployeeNameTextBox.TabIndex = 1;
            // 
            // newEmployeeLastNameTextBox
            // 
            this.newEmployeeLastNameTextBox.Location = new System.Drawing.Point(102, 71);
            this.newEmployeeLastNameTextBox.Name = "newEmployeeLastNameTextBox";
            this.newEmployeeLastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.newEmployeeLastNameTextBox.TabIndex = 2;
            // 
            // newEmployeeSSNTextBox
            // 
            this.newEmployeeSSNTextBox.Location = new System.Drawing.Point(73, 106);
            this.newEmployeeSSNTextBox.Name = "newEmployeeSSNTextBox";
            this.newEmployeeSSNTextBox.Size = new System.Drawing.Size(100, 20);
            this.newEmployeeSSNTextBox.TabIndex = 3;
            // 
            // newEmployeeNationalityTextBox
            // 
            this.newEmployeeNationalityTextBox.Location = new System.Drawing.Point(103, 143);
            this.newEmployeeNationalityTextBox.Name = "newEmployeeNationalityTextBox";
            this.newEmployeeNationalityTextBox.Size = new System.Drawing.Size(100, 20);
            this.newEmployeeNationalityTextBox.TabIndex = 4;
            // 
            // newEmployeeSexComboBox
            // 
            this.newEmployeeSexComboBox.FormattingEnabled = true;
            this.newEmployeeSexComboBox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.newEmployeeSexComboBox.Location = new System.Drawing.Point(69, 177);
            this.newEmployeeSexComboBox.Name = "newEmployeeSexComboBox";
            this.newEmployeeSexComboBox.Size = new System.Drawing.Size(121, 21);
            this.newEmployeeSexComboBox.TabIndex = 5;
            // 
            // birthDateLabel
            // 
            this.birthDateLabel.AutoSize = true;
            this.birthDateLabel.Location = new System.Drawing.Point(35, 216);
            this.birthDateLabel.Name = "birthDateLabel";
            this.birthDateLabel.Size = new System.Drawing.Size(57, 13);
            this.birthDateLabel.TabIndex = 6;
            this.birthDateLabel.Text = "Birth Date:";
            // 
            // newEmployeeBirthDateDateTimePicker
            // 
            this.newEmployeeBirthDateDateTimePicker.Location = new System.Drawing.Point(98, 214);
            this.newEmployeeBirthDateDateTimePicker.Name = "newEmployeeBirthDateDateTimePicker";
            this.newEmployeeBirthDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.newEmployeeBirthDateDateTimePicker.TabIndex = 6;
            // 
            // sexLabel
            // 
            this.sexLabel.AutoSize = true;
            this.sexLabel.Location = new System.Drawing.Point(35, 180);
            this.sexLabel.Name = "sexLabel";
            this.sexLabel.Size = new System.Drawing.Size(28, 13);
            this.sexLabel.TabIndex = 4;
            this.sexLabel.Text = "Sex:";
            // 
            // nacionalityLabel
            // 
            this.nacionalityLabel.AutoSize = true;
            this.nacionalityLabel.Location = new System.Drawing.Point(35, 146);
            this.nacionalityLabel.Name = "nacionalityLabel";
            this.nacionalityLabel.Size = new System.Drawing.Size(65, 13);
            this.nacionalityLabel.TabIndex = 3;
            this.nacionalityLabel.Text = "Nactionality:";
            // 
            // ssnLabel
            // 
            this.ssnLabel.AutoSize = true;
            this.ssnLabel.Location = new System.Drawing.Point(35, 109);
            this.ssnLabel.Name = "ssnLabel";
            this.ssnLabel.Size = new System.Drawing.Size(32, 13);
            this.ssnLabel.TabIndex = 2;
            this.ssnLabel.Text = "SSN:";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(35, 74);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(61, 13);
            this.lastNameLabel.TabIndex = 1;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(35, 41);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // createNewEmployeeButton
            // 
            this.createNewEmployeeButton.Location = new System.Drawing.Point(437, 381);
            this.createNewEmployeeButton.Name = "createNewEmployeeButton";
            this.createNewEmployeeButton.Size = new System.Drawing.Size(75, 23);
            this.createNewEmployeeButton.TabIndex = 1;
            this.createNewEmployeeButton.Text = "Create";
            this.createNewEmployeeButton.UseVisualStyleBackColor = true;
            this.createNewEmployeeButton.Click += new System.EventHandler(this.createNewEmployeeButton_Click);
            // 
            // AddEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(595, 496);
            this.Controls.Add(this.createNewEmployeeButton);
            this.Controls.Add(this.newClientGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddEmployeeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add new client";
            this.newClientGroupBox.ResumeLayout(false);
            this.newClientGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox newClientGroupBox;
        private System.Windows.Forms.Label birthDateLabel;
        private System.Windows.Forms.DateTimePicker newEmployeeBirthDateDateTimePicker;
        private System.Windows.Forms.Label sexLabel;
        private System.Windows.Forms.Label nacionalityLabel;
        private System.Windows.Forms.Label ssnLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox newEmployeeNameTextBox;
        private System.Windows.Forms.TextBox newEmployeeLastNameTextBox;
        private System.Windows.Forms.TextBox newEmployeeSSNTextBox;
        private System.Windows.Forms.TextBox newEmployeeNationalityTextBox;
        private System.Windows.Forms.ComboBox newEmployeeSexComboBox;
        private System.Windows.Forms.Button createNewEmployeeButton;
        private System.Windows.Forms.ComboBox newEmployeePositionComboBox;
        private System.Windows.Forms.Label positionLabel;
    }
}