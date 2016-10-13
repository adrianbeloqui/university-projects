namespace P5
{
    partial class AddClientForm
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
            this.newClientNameTextBox = new System.Windows.Forms.TextBox();
            this.newClientLastNameTextBox = new System.Windows.Forms.TextBox();
            this.newClientSSNTextBox = new System.Windows.Forms.TextBox();
            this.newClientNationalityTextBox = new System.Windows.Forms.TextBox();
            this.newClientSexComboBox = new System.Windows.Forms.ComboBox();
            this.birthDateLabel = new System.Windows.Forms.Label();
            this.birthDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.sexLabel = new System.Windows.Forms.Label();
            this.nacionalityLabel = new System.Windows.Forms.Label();
            this.ssnLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.createNewClientButton = new System.Windows.Forms.Button();
            this.newClientGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // newClientGroupBox
            // 
            this.newClientGroupBox.Controls.Add(this.newClientNameTextBox);
            this.newClientGroupBox.Controls.Add(this.newClientLastNameTextBox);
            this.newClientGroupBox.Controls.Add(this.newClientSSNTextBox);
            this.newClientGroupBox.Controls.Add(this.newClientNationalityTextBox);
            this.newClientGroupBox.Controls.Add(this.newClientSexComboBox);
            this.newClientGroupBox.Controls.Add(this.birthDateLabel);
            this.newClientGroupBox.Controls.Add(this.birthDateDateTimePicker);
            this.newClientGroupBox.Controls.Add(this.sexLabel);
            this.newClientGroupBox.Controls.Add(this.nacionalityLabel);
            this.newClientGroupBox.Controls.Add(this.ssnLabel);
            this.newClientGroupBox.Controls.Add(this.lastNameLabel);
            this.newClientGroupBox.Controls.Add(this.nameLabel);
            this.newClientGroupBox.Location = new System.Drawing.Point(110, 77);
            this.newClientGroupBox.Name = "newClientGroupBox";
            this.newClientGroupBox.Size = new System.Drawing.Size(404, 264);
            this.newClientGroupBox.TabIndex = 0;
            this.newClientGroupBox.TabStop = false;
            this.newClientGroupBox.Text = "New Client";
            // 
            // newClientNameTextBox
            // 
            this.newClientNameTextBox.Location = new System.Drawing.Point(79, 38);
            this.newClientNameTextBox.Name = "newClientNameTextBox";
            this.newClientNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.newClientNameTextBox.TabIndex = 1;
            // 
            // newClientLastNameTextBox
            // 
            this.newClientLastNameTextBox.Location = new System.Drawing.Point(102, 71);
            this.newClientLastNameTextBox.Name = "newClientLastNameTextBox";
            this.newClientLastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.newClientLastNameTextBox.TabIndex = 2;
            // 
            // newClientSSNTextBox
            // 
            this.newClientSSNTextBox.Location = new System.Drawing.Point(73, 106);
            this.newClientSSNTextBox.Name = "newClientSSNTextBox";
            this.newClientSSNTextBox.Size = new System.Drawing.Size(100, 20);
            this.newClientSSNTextBox.TabIndex = 3;
            // 
            // newClientNationalityTextBox
            // 
            this.newClientNationalityTextBox.Location = new System.Drawing.Point(103, 143);
            this.newClientNationalityTextBox.Name = "newClientNationalityTextBox";
            this.newClientNationalityTextBox.Size = new System.Drawing.Size(100, 20);
            this.newClientNationalityTextBox.TabIndex = 4;
            // 
            // newClientSexComboBox
            // 
            this.newClientSexComboBox.FormattingEnabled = true;
            this.newClientSexComboBox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.newClientSexComboBox.Location = new System.Drawing.Point(69, 177);
            this.newClientSexComboBox.Name = "newClientSexComboBox";
            this.newClientSexComboBox.Size = new System.Drawing.Size(121, 21);
            this.newClientSexComboBox.TabIndex = 5;
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
            // birthDateDateTimePicker
            // 
            this.birthDateDateTimePicker.Location = new System.Drawing.Point(98, 214);
            this.birthDateDateTimePicker.Name = "birthDateDateTimePicker";
            this.birthDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.birthDateDateTimePicker.TabIndex = 6;
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
            // createNewClientButton
            // 
            this.createNewClientButton.Location = new System.Drawing.Point(439, 362);
            this.createNewClientButton.Name = "createNewClientButton";
            this.createNewClientButton.Size = new System.Drawing.Size(75, 23);
            this.createNewClientButton.TabIndex = 1;
            this.createNewClientButton.Text = "Create";
            this.createNewClientButton.UseVisualStyleBackColor = true;
            this.createNewClientButton.Click += new System.EventHandler(this.createNewClientButton_Click);
            // 
            // AddClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 496);
            this.Controls.Add(this.createNewClientButton);
            this.Controls.Add(this.newClientGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddClientForm";
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
        private System.Windows.Forms.DateTimePicker birthDateDateTimePicker;
        private System.Windows.Forms.Label sexLabel;
        private System.Windows.Forms.Label nacionalityLabel;
        private System.Windows.Forms.Label ssnLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox newClientNameTextBox;
        private System.Windows.Forms.TextBox newClientLastNameTextBox;
        private System.Windows.Forms.TextBox newClientSSNTextBox;
        private System.Windows.Forms.TextBox newClientNationalityTextBox;
        private System.Windows.Forms.ComboBox newClientSexComboBox;
        private System.Windows.Forms.Button createNewClientButton;
    }
}