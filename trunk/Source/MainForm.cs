using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jeebook.PageReleaser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            propertyGrid1.SelectedObject = new SettingManager();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UriResolver uiRes = new UriResolver(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, true);
            PageTextBox.Text = uiRes.ToAbsolute("Test\\Website\\index.html");
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

            SettingManager sm = (SettingManager)propertyGrid1.SelectedObject;
            sm.PageName = PageTextBox.Text;
            sm.OutputPath = OutputTextBox.Text;

            //
            try
            {
                Releaser r = new Releaser();
                r.Release(sm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        private void TrueAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SettingManager sm = (SettingManager)propertyGrid1.SelectedObject;
            sm.Configure(1);
            propertyGrid1.SelectedObject = sm;
        }

        private void FalseAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SettingManager sm = (SettingManager)propertyGrid1.SelectedObject;
            sm.Configure(-1);
            propertyGrid1.SelectedObject = sm;
        }
    }
}
