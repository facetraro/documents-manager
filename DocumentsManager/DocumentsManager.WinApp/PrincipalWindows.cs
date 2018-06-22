using DocumentsManager.WinApp.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentsManager.WinApp
{
    public partial class DocumentsManager : Form
    {
        public DocumentsManager()
        {
            InitializeComponent();
            mainPanel.Controls.Clear();
            UserControl mainMenu  = new LoginControl(mainPanel);
            mainPanel.Controls.Add(mainMenu);
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void jkjikbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
