namespace PageReleaser
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.PageTextBox = new System.Windows.Forms.TextBox();
            this.PageBrowseButton = new System.Windows.Forms.Button();
            this.OutputBrowseButton = new System.Windows.Forms.Button();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.StartButton = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Page";
            // 
            // PageTextBox
            // 
            this.PageTextBox.AllowDrop = true;
            this.PageTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.PageTextBox.Location = new System.Drawing.Point(57, 9);
            this.PageTextBox.Name = "PageTextBox";
            this.PageTextBox.ReadOnly = true;
            this.PageTextBox.Size = new System.Drawing.Size(180, 20);
            this.PageTextBox.TabIndex = 1;
            this.PageTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.PageTextBox_DragDrop);
            this.PageTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.PageTextBox_DragEnter);
            // 
            // PageBrowseButton
            // 
            this.PageBrowseButton.Location = new System.Drawing.Point(243, 9);
            this.PageBrowseButton.Name = "PageBrowseButton";
            this.PageBrowseButton.Size = new System.Drawing.Size(23, 23);
            this.PageBrowseButton.TabIndex = 2;
            this.PageBrowseButton.Text = "...";
            this.PageBrowseButton.UseVisualStyleBackColor = true;
            this.PageBrowseButton.Click += new System.EventHandler(this.PageBrowseButton_Click);
            // 
            // OutputBrowseButton
            // 
            this.OutputBrowseButton.Location = new System.Drawing.Point(243, 35);
            this.OutputBrowseButton.Name = "OutputBrowseButton";
            this.OutputBrowseButton.Size = new System.Drawing.Size(23, 23);
            this.OutputBrowseButton.TabIndex = 5;
            this.OutputBrowseButton.Text = "...";
            this.OutputBrowseButton.UseVisualStyleBackColor = true;
            this.OutputBrowseButton.Click += new System.EventHandler(this.OutputBrowseButton_Click);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point(57, 35);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size(180, 20);
            this.OutputTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output";
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "HTML(*.htm;*.html)|*.htm;*.html";
            // 
            // StartButton
            // 
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(86, 165);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(83, 37);
            this.StartButton.TabIndex = 9;
            this.StartButton.Text = "Release";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(272, 9);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(262, 312);
            this.propertyGrid1.TabIndex = 16;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 333);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.OutputBrowseButton);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PageBrowseButton);
            this.Controls.Add(this.PageTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Page Releaser - Jeebook.com";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.PageTextBox_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.PageTextBox_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PageTextBox;
        private System.Windows.Forms.Button PageBrowseButton;
        private System.Windows.Forms.Button OutputBrowseButton;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}

