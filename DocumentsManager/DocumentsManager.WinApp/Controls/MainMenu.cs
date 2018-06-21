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
    public partial class MainMenu : UserControl
    {
        private Panel MainPanel;
        public MainMenu(Panel mainPanel)
        {
            MainPanel = mainPanel;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl loginControl = new LoginControl(MainPanel);
            MainPanel.Controls.Add(loginControl);
        }

        private void buttonManageFormats_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl manageFormatControl = new ManageFormat(MainPanel);
            MainPanel.Controls.Add(manageFormatControl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl seeLogControl = new CheckLog(MainPanel);
            MainPanel.Controls.Add(seeLogControl);
        }
    }
}
