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
using DocumentsMangerEntities;

namespace DocumentsManager.WinApp.Controls
{
    public partial class MaintainStyles : UserControl
    {
        StyleClassBusinessLogic scBL;
        Panel MainPanel;
        public MaintainStyles(Panel mainPanel)
        {
            this.MainPanel = mainPanel;
            scBL = new StyleClassBusinessLogic();
            InitializeComponent();
            LoadStyles();
        }

        private void LoadStyles()
        {
            foreach (var item in scBL.GetAllStyleClasses(new Guid()))
            {
                listBoxStyles.Items.Add(item);
            }
        }

        private bool IsListSelected()
        {
            if (listBoxStyles.SelectedIndex == -1)
            {
                MessageBox.Show("No se selecciono ningun Estilo.");
                return false;
            }
            return true;
        }
        private void buttonModifyStyle_Click(object sender, EventArgs e)
        {
            if (IsListSelected())
            {
                try
                {
                    StyleClass style = (StyleClass)listBoxStyles.SelectedItem;
                    MainPanel.Controls.Clear();
                    UserControl manageFormatControl = new ModifyStyle(MainPanel,style);
                    MainPanel.Controls.Add(manageFormatControl);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonDeleteStyle_Click(object sender, EventArgs e)
        {
            if (IsListSelected())
            {
                try
                {
                    StyleClass style = (StyleClass)listBoxStyles.SelectedItem;
                    scBL.DeleteStyle(style.Id, new Guid());
                    MessageBox.Show("Estilo eliminado correctamente");
                    GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void GoBack()
        {
            MainPanel.Controls.Clear();
            UserControl manageFormatControl = new ManageStyles(MainPanel);
            MainPanel.Controls.Add(manageFormatControl);
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}
