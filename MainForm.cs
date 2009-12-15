using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PageReleaser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OutputTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString();
        }

        private void PageBrowseButton_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                PageTextBox.Text = OpenFileDialog.FileName;
        }

        private void OutputBrowseButton_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
                OutputTextBox.Text = FolderBrowserDialog.SelectedPath;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = false;

            // init proxymanager
            SettingManager sm = new SettingManager(PageTextBox.Text, OutputTextBox.Text);

            sm.IsHtmlCompress = HTMLCompressCheckBox.Checked;

            sm.IsJavaScriptCompress = JavaScriptCompressCheckBox.Checked;
            sm.IsJavaScriptCombine = JavaScriptCombineCheckBox.Checked;
            sm.IsJavaScriptEmbed = JavaScriptEmbedCheckBox.Checked;

            sm.IsCssCompress = CSSCompressCheckBox.Checked;
            sm.IsCssCombine = CSSCombineCheckBox.Checked;
            sm.IsCssEmbed = CSSEmbedCheckBox.Checked;

            sm.IgnoreRemoteFile = IgnoreRemoteFilesCheckBox.Checked;
            sm.IsCurrentFolderAndSubsOnly = CurrentFolderAndSubsOnlyCheckBox.Checked;

            //
            Releaser r = new Releaser();
            r.Release(sm);

            StartButton.Enabled = true;
        }

        private void PageTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None; 
        }

        private void PageTextBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] str = (string[])e.Data.GetData(DataFormats.FileDrop);
                PageTextBox.Text = str[0];
            }
        }
    }
}
