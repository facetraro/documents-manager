using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentsManager.WinApp.Controls
{
    public partial class ManageFormat : UserControl
    {
        private Panel MainPanel;
        public ManageFormat(Panel mainPanel)
        {
            InitializeComponent();
            MainPanel = mainPanel;
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl menuControl = new MainMenu(MainPanel);
            MainPanel.Controls.Add(menuControl);
        }

        private void buttonImportFormats_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl importMethodsControl = new ImportMethods(MainPanel);
            MainPanel.Controls.Add(importMethodsControl);
        }

        private void buttonADdFormat_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl createFormatControl = new FormatCreator(MainPanel);
            MainPanel.Controls.Add(createFormatControl);
        }

        private void buttonMaintainFormat_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl maintainFormatsControl = new MaintainFormats(MainPanel);
            MainPanel.Controls.Add(maintainFormatsControl);
        }

        private void labelTItle_Click(object sender, EventArgs e)
        {

        }
    }
}
