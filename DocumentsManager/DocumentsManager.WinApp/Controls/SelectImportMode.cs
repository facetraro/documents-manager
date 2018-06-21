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
    public partial class SelectImportMode : UserControl
    {
        private Panel MainPanel;
        private List<IFormatImportation> importers;
        public SelectImportMode(Panel panel, List<IFormatImportation> importations)
        {
            MainPanel = panel;
            importers = importations;
            InitializeComponent();
            LoadComboBox();
        }
        private void LoadComboBox()
        {
            foreach (var item in importers)
            {
                comboBox.Items.Add(item);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            IFormatImportation importation = comboBox.SelectedItem as IFormatImportation;
            if (comboBox.SelectedItem == null)
            {
                MessageBox.Show("No se selecciono ningun tipo de importacion.");
                return;
            }
            MainPanel.Controls.Clear();
            UserControl importControl = new ImportControl(MainPanel, importation);
            MainPanel.Controls.Add(importControl);
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl importMethods = new ImportMethods(MainPanel);
            MainPanel.Controls.Add(importMethods);
        }
    }
}
