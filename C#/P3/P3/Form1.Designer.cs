namespace P3
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
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.signButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.valuesSignedDataGridView = new System.Windows.Forms.DataGridView();
            this.amountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signatureColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.valuesSignedDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(29, 47);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(46, 13);
            this.amountLabel.TabIndex = 0;
            this.amountLabel.Text = "Amount:";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(81, 44);
            this.amountTextBox.MaxLength = 7;
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(100, 20);
            this.amountTextBox.TabIndex = 1;
            // 
            // signButton
            // 
            this.signButton.Location = new System.Drawing.Point(691, 42);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(75, 23);
            this.signButton.TabIndex = 2;
            this.signButton.Text = "Sign";
            this.signButton.UseVisualStyleBackColor = true;
            this.signButton.Click += new System.EventHandler(this.signButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(772, 42);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // valuesSignedDataGridView
            // 
            this.valuesSignedDataGridView.AllowUserToAddRows = false;
            this.valuesSignedDataGridView.AllowUserToDeleteRows = false;
            this.valuesSignedDataGridView.AllowUserToResizeColumns = false;
            this.valuesSignedDataGridView.AllowUserToResizeRows = false;
            this.valuesSignedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.valuesSignedDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.amountColumn,
            this.signatureColumn});
            this.valuesSignedDataGridView.Location = new System.Drawing.Point(12, 84);
            this.valuesSignedDataGridView.Name = "valuesSignedDataGridView";
            this.valuesSignedDataGridView.ReadOnly = true;
            this.valuesSignedDataGridView.RowHeadersVisible = false;
            this.valuesSignedDataGridView.ShowEditingIcon = false;
            this.valuesSignedDataGridView.Size = new System.Drawing.Size(835, 235);
            this.valuesSignedDataGridView.TabIndex = 4;
            // 
            // amountColumn
            // 
            this.amountColumn.HeaderText = "Amount";
            this.amountColumn.Name = "amountColumn";
            this.amountColumn.ReadOnly = true;
            // 
            // signatureColumn
            // 
            this.signatureColumn.HeaderText = "Signature";
            this.signatureColumn.Name = "signatureColumn";
            this.signatureColumn.ReadOnly = true;
            this.signatureColumn.Width = 732;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 331);
            this.Controls.Add(this.valuesSignedDataGridView);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.signButton);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.amountLabel);
            this.Name = "mainForm";
            this.Text = "P3 If\'s, Switch - Adrian Beloqui";
            ((System.ComponentModel.ISupportInitialize)(this.valuesSignedDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Button signButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.DataGridView valuesSignedDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn signatureColumn;
    }
}

