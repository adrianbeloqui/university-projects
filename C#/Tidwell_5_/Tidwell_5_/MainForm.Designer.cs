namespace Tidwell_5_
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sortLabel = new System.Windows.Forms.Label();
            this.featuresLabel = new System.Windows.Forms.Label();
            this.mainLabel = new System.Windows.Forms.Label();
            this.mainListBox = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.descButton = new System.Windows.Forms.Button();
            this.ascButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.descButton);
            this.splitContainer1.Panel1.Controls.Add(this.ascButton);
            this.splitContainer1.Panel1.Controls.Add(this.addButton);
            this.splitContainer1.Panel1.Controls.Add(this.sortLabel);
            this.splitContainer1.Panel1.Controls.Add(this.featuresLabel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mainLabel);
            this.splitContainer1.Panel2.Controls.Add(this.mainListBox);
            this.splitContainer1.Size = new System.Drawing.Size(463, 262);
            this.splitContainer1.SplitterDistance = 154;
            this.splitContainer1.TabIndex = 0;
            // 
            // sortLabel
            // 
            this.sortLabel.AutoSize = true;
            this.sortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.sortLabel.Location = new System.Drawing.Point(12, 135);
            this.sortLabel.Name = "sortLabel";
            this.sortLabel.Size = new System.Drawing.Size(74, 24);
            this.sortLabel.TabIndex = 1;
            this.sortLabel.Text = "Sorting:";
            // 
            // featuresLabel
            // 
            this.featuresLabel.AutoSize = true;
            this.featuresLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.featuresLabel.Location = new System.Drawing.Point(12, 27);
            this.featuresLabel.Name = "featuresLabel";
            this.featuresLabel.Size = new System.Drawing.Size(89, 24);
            this.featuresLabel.TabIndex = 0;
            this.featuresLabel.Text = "Features:";
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.mainLabel.Location = new System.Drawing.Point(8, 27);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(120, 24);
            this.mainLabel.TabIndex = 1;
            this.mainLabel.Text = "Vehicles List:";
            // 
            // mainListBox
            // 
            this.mainListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.mainListBox.FormattingEnabled = true;
            this.mainListBox.ItemHeight = 20;
            this.mainListBox.Location = new System.Drawing.Point(12, 77);
            this.mainListBox.Name = "mainListBox";
            this.mainListBox.Size = new System.Drawing.Size(281, 164);
            this.mainListBox.TabIndex = 0;
            this.mainListBox.SelectedValueChanged += new System.EventHandler(this.mainListBox_SelectedIndexChanged);
            // 
            // descButton
            // 
            this.descButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.descButton.BackgroundImage = global::Tidwell_5_.Properties.Resources.Circle_arrow_descending;
            this.descButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.descButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.descButton.Location = new System.Drawing.Point(87, 175);
            this.descButton.Name = "descButton";
            this.descButton.Size = new System.Drawing.Size(43, 40);
            this.descButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.descButton, "Sort the list of vehicles with the descending style");
            this.descButton.UseVisualStyleBackColor = false;
            this.descButton.Click += new System.EventHandler(this.descButton_Click);
            // 
            // ascButton
            // 
            this.ascButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ascButton.BackgroundImage = global::Tidwell_5_.Properties.Resources.Circle_arrow_ascending;
            this.ascButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ascButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ascButton.Location = new System.Drawing.Point(27, 175);
            this.ascButton.Name = "ascButton";
            this.ascButton.Size = new System.Drawing.Size(43, 40);
            this.ascButton.TabIndex = 4;
            this.toolTip1.SetToolTip(this.ascButton, "Sort the list of vehicles with the ascending style");
            this.ascButton.UseVisualStyleBackColor = false;
            this.ascButton.Click += new System.EventHandler(this.ascButton_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.addButton.BackgroundImage = global::Tidwell_5_.Properties.Resources.plus_sign_simple;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.addButton.Location = new System.Drawing.Point(58, 66);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(43, 40);
            this.addButton.TabIndex = 2;
            this.toolTip1.SetToolTip(this.addButton, "Add a new vehicle");
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 262);
            this.Controls.Add(this.splitContainer1);
            this.Name = "mainForm";
            this.Text = "Tidwell #5 Lists - Adrian Beloqui";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label sortLabel;
        private System.Windows.Forms.Label featuresLabel;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.ListBox mainListBox;
        private System.Windows.Forms.Button descButton;
        private System.Windows.Forms.Button ascButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

