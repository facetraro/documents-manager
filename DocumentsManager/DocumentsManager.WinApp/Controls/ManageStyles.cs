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
    public partial class ManageStyles : UserControl
    {
        Panel MainPanel;
        public ManageStyles(Panel MainPanel)
        {
            this.MainPanel = MainPanel;
            InitializeComponent();
        }

        private void buttonAddStyle_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl manageFormatControl = new StyleCreator(MainPanel);
            MainPanel.Controls.Add(manageFormatControl);
        }

        private void buttonMaintainStyle_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl manageFormatControl = new MaintainStyles(MainPanel);
            MainPanel.Controls.Add(manageFormatControl);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl menuControl = new MainMenu(MainPanel);
            MainPanel.Controls.Add(menuControl);
        }
    }
}
