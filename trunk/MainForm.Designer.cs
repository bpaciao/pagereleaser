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
            this.label1 = new System.Windows.Forms.Label();
            this.PageTextBox = new System.Windows.Forms.TextBox();
            this.PageBrowseButton = new System.Windows.Forms.Button();
            this.OutputBrowseButton = new System.Windows.Forms.Button();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HTMLCompressCheckBox = new System.Windows.Forms.CheckBox();
            this.JavaScriptCompressCheckBox = new System.Windows.Forms.CheckBox();
            this.CSSCompressCheckBox = new System.Windows.Forms.CheckBox();
            this.JavaScriptEmbedCheckBox = new System.Windows.Forms.CheckBox();
            this.CSSEmbedCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ImageCombineCheckBox8 = new System.Windows.Forms.CheckBox();
            this.CSSCombineCheckBox = new System.Windows.Forms.CheckBox();
            this.JavaScriptCombineCheckBox = new System.Windows.Forms.CheckBox();
            this.IgnoreRemoteFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.UseGZipCheckBox = new System.Windows.Forms.CheckBox();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.StartButton = new System.Windows.Forms.Button();
            this.CurrentFolderAndSubsOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Page";
            // 
            // PageTextBox
            // 
            this.PageTextBox.AllowDrop = true;
            this.PageTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.PageTextBox.Location = new System.Drawing.Point(57, 8);
            this.PageTextBox.Name = "PageTextBox";
            this.PageTextBox.ReadOnly = true;
            this.PageTextBox.Size = new System.Drawing.Size(180, 21);
            this.PageTextBox.TabIndex = 1;
            this.PageTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.PageTextBox_DragDrop);
            this.PageTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.PageTextBox_DragEnter);
            // 
            // PageBrowseButton
            // 
            this.PageBrowseButton.Location = new System.Drawing.Point(243, 8);
            this.PageBrowseButton.Name = "PageBrowseButton";
            this.PageBrowseButton.Size = new System.Drawing.Size(23, 21);
            this.PageBrowseButton.TabIndex = 2;
            this.PageBrowseButton.Text = "...";
            this.PageBrowseButton.UseVisualStyleBackColor = true;
            this.PageBrowseButton.Click += new System.EventHandler(this.PageBrowseButton_Click);
            // 
            // OutputBrowseButton
            // 
            this.OutputBrowseButton.Location = new System.Drawing.Point(243, 32);
            this.OutputBrowseButton.Name = "OutputBrowseButton";
            this.OutputBrowseButton.Size = new System.Drawing.Size(23, 21);
            this.OutputBrowseButton.TabIndex = 5;
            this.OutputBrowseButton.Text = "...";
            this.OutputBrowseButton.UseVisualStyleBackColor = true;
            this.OutputBrowseButton.Click += new System.EventHandler(this.OutputBrowseButton_Click);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point(57, 32);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size(180, 21);
            this.OutputTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output";
            // 
            // HTMLCompressCheckBox
            // 
            this.HTMLCompressCheckBox.AutoSize = true;
            this.HTMLCompressCheckBox.Enabled = false;
            this.HTMLCompressCheckBox.Location = new System.Drawing.Point(6, 18);
            this.HTMLCompressCheckBox.Name = "HTMLCompressCheckBox";
            this.HTMLCompressCheckBox.Size = new System.Drawing.Size(48, 16);
            this.HTMLCompressCheckBox.TabIndex = 6;
            this.HTMLCompressCheckBox.Text = "HTML";
            this.HTMLCompressCheckBox.UseVisualStyleBackColor = true;
            // 
            // JavaScriptCompressCheckBox
            // 
            this.JavaScriptCompressCheckBox.AutoSize = true;
            this.JavaScriptCompressCheckBox.Checked = true;
            this.JavaScriptCompressCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.JavaScriptCompressCheckBox.Location = new System.Drawing.Point(68, 17);
            this.JavaScriptCompressCheckBox.Name = "JavaScriptCompressCheckBox";
            this.JavaScriptCompressCheckBox.Size = new System.Drawing.Size(84, 16);
            this.JavaScriptCompressCheckBox.TabIndex = 7;
            this.JavaScriptCompressCheckBox.Text = "JavaScript";
            this.JavaScriptCompressCheckBox.UseVisualStyleBackColor = true;
            // 
            // CSSCompressCheckBox
            // 
            this.CSSCompressCheckBox.AutoSize = true;
            this.CSSCompressCheckBox.Enabled = false;
            this.CSSCompressCheckBox.Location = new System.Drawing.Point(150, 18);
            this.CSSCompressCheckBox.Name = "CSSCompressCheckBox";
            this.CSSCompressCheckBox.Size = new System.Drawing.Size(42, 16);
            this.CSSCompressCheckBox.TabIndex = 8;
            this.CSSCompressCheckBox.Text = "CSS";
            this.CSSCompressCheckBox.UseVisualStyleBackColor = true;
            // 
            // JavaScriptEmbedCheckBox
            // 
            this.JavaScriptEmbedCheckBox.AutoSize = true;
            this.JavaScriptEmbedCheckBox.Location = new System.Drawing.Point(6, 17);
            this.JavaScriptEmbedCheckBox.Name = "JavaScriptEmbedCheckBox";
            this.JavaScriptEmbedCheckBox.Size = new System.Drawing.Size(84, 16);
            this.JavaScriptEmbedCheckBox.TabIndex = 9;
            this.JavaScriptEmbedCheckBox.Text = "JavaScript";
            this.JavaScriptEmbedCheckBox.UseVisualStyleBackColor = true;
            // 
            // CSSEmbedCheckBox
            // 
            this.CSSEmbedCheckBox.AutoSize = true;
            this.CSSEmbedCheckBox.Location = new System.Drawing.Point(88, 18);
            this.CSSEmbedCheckBox.Name = "CSSEmbedCheckBox";
            this.CSSEmbedCheckBox.Size = new System.Drawing.Size(42, 16);
            this.CSSEmbedCheckBox.TabIndex = 10;
            this.CSSEmbedCheckBox.Text = "CSS";
            this.CSSEmbedCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HTMLCompressCheckBox);
            this.groupBox1.Controls.Add(this.JavaScriptCompressCheckBox);
            this.groupBox1.Controls.Add(this.CSSCompressCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 38);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compress";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CSSEmbedCheckBox);
            this.groupBox2.Controls.Add(this.JavaScriptEmbedCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(9, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 38);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Embed in page";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ImageCombineCheckBox8);
            this.groupBox3.Controls.Add(this.CSSCombineCheckBox);
            this.groupBox3.Controls.Add(this.JavaScriptCombineCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(9, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 38);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Combine";
            // 
            // ImageCombineCheckBox8
            // 
            this.ImageCombineCheckBox8.AutoSize = true;
            this.ImageCombineCheckBox8.Enabled = false;
            this.ImageCombineCheckBox8.Location = new System.Drawing.Point(141, 18);
            this.ImageCombineCheckBox8.Name = "ImageCombineCheckBox8";
            this.ImageCombineCheckBox8.Size = new System.Drawing.Size(54, 16);
            this.ImageCombineCheckBox8.TabIndex = 13;
            this.ImageCombineCheckBox8.Text = "Image";
            this.ImageCombineCheckBox8.UseVisualStyleBackColor = true;
            // 
            // CSSCombineCheckBox
            // 
            this.CSSCombineCheckBox.AutoSize = true;
            this.CSSCombineCheckBox.Checked = true;
            this.CSSCombineCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CSSCombineCheckBox.Enabled = false;
            this.CSSCombineCheckBox.Location = new System.Drawing.Point(88, 18);
            this.CSSCombineCheckBox.Name = "CSSCombineCheckBox";
            this.CSSCombineCheckBox.Size = new System.Drawing.Size(42, 16);
            this.CSSCombineCheckBox.TabIndex = 12;
            this.CSSCombineCheckBox.Text = "CSS";
            this.CSSCombineCheckBox.UseVisualStyleBackColor = true;
            // 
            // JavaScriptCombineCheckBox
            // 
            this.JavaScriptCombineCheckBox.AutoSize = true;
            this.JavaScriptCombineCheckBox.Checked = true;
            this.JavaScriptCombineCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.JavaScriptCombineCheckBox.Enabled = false;
            this.JavaScriptCombineCheckBox.Location = new System.Drawing.Point(6, 19);
            this.JavaScriptCombineCheckBox.Name = "JavaScriptCombineCheckBox";
            this.JavaScriptCombineCheckBox.Size = new System.Drawing.Size(84, 16);
            this.JavaScriptCombineCheckBox.TabIndex = 11;
            this.JavaScriptCombineCheckBox.Text = "JavaScript";
            this.JavaScriptCombineCheckBox.UseVisualStyleBackColor = true;
            // 
            // IgnoreRemoteFilesCheckBox
            // 
            this.IgnoreRemoteFilesCheckBox.AutoSize = true;
            this.IgnoreRemoteFilesCheckBox.Checked = true;
            this.IgnoreRemoteFilesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IgnoreRemoteFilesCheckBox.Location = new System.Drawing.Point(6, 17);
            this.IgnoreRemoteFilesCheckBox.Name = "IgnoreRemoteFilesCheckBox";
            this.IgnoreRemoteFilesCheckBox.Size = new System.Drawing.Size(138, 16);
            this.IgnoreRemoteFilesCheckBox.TabIndex = 14;
            this.IgnoreRemoteFilesCheckBox.Text = "Ignore remote files";
            this.IgnoreRemoteFilesCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CurrentFolderAndSubsOnlyCheckBox);
            this.groupBox4.Controls.Add(this.UseGZipCheckBox);
            this.groupBox4.Controls.Add(this.IgnoreRemoteFilesCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(9, 184);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(257, 60);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Other";
            // 
            // UseGZipCheckBox
            // 
            this.UseGZipCheckBox.AutoSize = true;
            this.UseGZipCheckBox.Enabled = false;
            this.UseGZipCheckBox.Location = new System.Drawing.Point(125, 17);
            this.UseGZipCheckBox.Name = "UseGZipCheckBox";
            this.UseGZipCheckBox.Size = new System.Drawing.Size(78, 16);
            this.UseGZipCheckBox.TabIndex = 15;
            this.UseGZipCheckBox.Text = "User gzip";
            this.UseGZipCheckBox.UseVisualStyleBackColor = true;
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "HTML(*.htm;*.html)|*.htm;*.html";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(97, 250);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 21);
            this.StartButton.TabIndex = 9;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // CurrentFolderAndSubsOnlyCheckBox
            // 
            this.CurrentFolderAndSubsOnlyCheckBox.AutoSize = true;
            this.CurrentFolderAndSubsOnlyCheckBox.Enabled = false;
            this.CurrentFolderAndSubsOnlyCheckBox.Location = new System.Drawing.Point(6, 38);
            this.CurrentFolderAndSubsOnlyCheckBox.Name = "CurrentFolderAndSubsOnlyCheckBox";
            this.CurrentFolderAndSubsOnlyCheckBox.Size = new System.Drawing.Size(192, 16);
            this.CurrentFolderAndSubsOnlyCheckBox.TabIndex = 16;
            this.CurrentFolderAndSubsOnlyCheckBox.Text = "Current folder and subs only";
            this.CurrentFolderAndSubsOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 279);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OutputBrowseButton);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PageBrowseButton);
            this.Controls.Add(this.PageTextBox);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "PageReleaser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.CheckBox HTMLCompressCheckBox;
        private System.Windows.Forms.CheckBox JavaScriptCompressCheckBox;
        private System.Windows.Forms.CheckBox CSSCompressCheckBox;
        private System.Windows.Forms.CheckBox JavaScriptEmbedCheckBox;
        private System.Windows.Forms.CheckBox CSSEmbedCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ImageCombineCheckBox8;
        private System.Windows.Forms.CheckBox CSSCombineCheckBox;
        private System.Windows.Forms.CheckBox JavaScriptCombineCheckBox;
        private System.Windows.Forms.CheckBox IgnoreRemoteFilesCheckBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox UseGZipCheckBox;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.CheckBox CurrentFolderAndSubsOnlyCheckBox;
    }
}

