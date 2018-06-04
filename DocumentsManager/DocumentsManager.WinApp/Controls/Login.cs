using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentsManager.WinApp
{
    public partial class LoginControl : UserControl
    {
        private Panel mainPanel;
        public LoginControl(Panel panel)
        {
            mainPanel = panel;
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
