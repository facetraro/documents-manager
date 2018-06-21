using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentsManager.BusinessLogic;
using DocumentsManager.Exceptions;

namespace DocumentsManager.WinApp
{
    public partial class LoginControl : UserControl
    {
        private Panel MainPanel;
        private AdminBusinessLogic aBL;
        public LoginControl(Panel panel)
        {
            aBL = new AdminBusinessLogic();
            MainPanel = panel;
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
        }
        private void InitializeSystem()
        {
            MessageBox.Show("OK");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AdminBusinessLogic logic = new AdminBusinessLogic();
            try
            {
                if (aBL.GetUserByUsername(textBoxUsername.Text) != null)
                {
                    logic.LogInWinApp(textBoxUsername.Text, textBoxPassword.Text);
                    InitializeSystem();
                    UserLogged.Username = textBoxUsername.Text;
                    MainPanel.Controls.Clear();
                    UserControl menuControl = new Controls.MainMenu(MainPanel);
                    MainPanel.Controls.Add(menuControl);
                }
                else {
                    throw new NotAdminOrDoesntExistsException();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
