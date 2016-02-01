using System;        
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SplashCreator.Core.Helpers;
using SplashCreator.Core.Models;

namespace SplashCreator.UI.Forms
{
    public partial class MainForm : Form
    {
        private SplashTechniqueControlDatum _selectedTechniqueControlDatum;

        public MainForm()
        {
            InitializeComponent();
            HandleSplashTechniqueUI();
        }

        private void HandleSplashTechniqueUI()
        {
            var techniqueControlData = SplashTechniques.TechniqueData;

            foreach (var techniqueControlDatum in techniqueControlData)
            {        
                Controls.Add(techniqueControlDatum.Value.Control);
                techniqueControlDatum.Value.InvalidatePanelLocation(this, null);
            }

            var comboBoxItems = techniqueControlData.
                Select(techniqueControlDatum => techniqueControlDatum.Value).
                Cast<object>().
                ToArray();
            cbSplashTechniques.Items.AddRange(comboBoxItems);
            cbSplashTechniques.SelectedIndex = 0;
        }

        private string GetAvailableFilePath(string filePath, string extension = "exe")
        {
            extension = string.Concat(".", extension);

            var fileExistsCount = 0;
            string outputFilePath;
            do
            {
                fileExistsCount++;

                var beforeExtensionIndex = filePath.IndexOf(extension, StringComparison.Ordinal);
                outputFilePath = filePath.Insert(beforeExtensionIndex, fileExistsCount.ToString());
            } while (File.Exists(outputFilePath));

            return outputFilePath;
        }

        private void tbExecutablePath_DoubleClick(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    tbExecutablePath.Text = dialog.FileName;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var executablePath = tbExecutablePath.Text;
            if (string.IsNullOrWhiteSpace(executablePath))
                return;

            var creator = new Core.Helpers.SplashCreator();

            try
            {
                var technique = _selectedTechniqueControlDatum.Technique;
                var splashData = _selectedTechniqueControlDatum.Control.GetSplashData();
                var outputBytes = creator.CreateSplash(executablePath, technique, splashData);

                var outputExecutablePath = GetAvailableFilePath(executablePath);
                File.WriteAllBytes(outputExecutablePath, outputBytes);
            }
            catch (Exception exception)
            {
                MessageBox.Show($@"Error: {exception.Message}");
            }
        }

        private void chSplashTechniques_SelectedValueChanged(object sender, EventArgs e)
        {                     
            if (cbSplashTechniques.SelectedItem == null)
                return;

            foreach (var splashTechniqueControlDatum in SplashTechniques.TechniqueData)
            {
                if (splashTechniqueControlDatum.Value.Name == cbSplashTechniques.SelectedItem.ToString())
                {
                    splashTechniqueControlDatum.Value.Control.Visible = true;
                    _selectedTechniqueControlDatum = splashTechniqueControlDatum.Value;
                }
                else  
                    splashTechniqueControlDatum.Value.Control.Visible = false; 
            }                                                                                                       
        }
    }
}