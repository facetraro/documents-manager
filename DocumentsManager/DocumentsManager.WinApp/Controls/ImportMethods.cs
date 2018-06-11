using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentsManager.FormatImportation;

namespace DocumentsManager.WinApp.Controls
{
    public partial class ImportMethods : UserControl
    {
        private string FileNamePath;
        private Panel mainPanel;
        public ImportMethods(Panel panel)
        {
            mainPanel = panel;
            InitializeComponent();
        }

        private void buttonDll_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileNamePath = dialog.SelectedPath;
                GoToSelectImportMode();
            }
        }
        private List<IFormatImportation> LoadImportationModes()
        {
            FormatImportationService service = new FormatImportationService();
            return service.GetImportationsMethods(FileNamePath);
        }
        private void GoToSelectImportMode()
        {
            List<IFormatImportation> importations = LoadImportationModes();
            if (importations.Count < 0)
            {
                MessageBox.Show("No se encontraron Importadores en ese Path");
                return;
            }
            mainPanel.Controls.Clear();
            UserControl importControl = new SelectImportMode(mainPanel, importations);
            mainPanel.Controls.Add(importControl);
        }
    }
}
