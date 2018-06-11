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
        private Panel mainPanel;
        private List<IFormatImportation> importers;
        public SelectImportMode(Panel panel, List<IFormatImportation> importations)
        {
            mainPanel = panel;
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
            mainPanel.Controls.Clear();
            UserControl importControl = new ImportControl(mainPanel, importation);
            mainPanel.Controls.Add(importControl);
        }
    }
}
