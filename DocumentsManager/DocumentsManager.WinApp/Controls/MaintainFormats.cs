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
    public partial class MaintainFormats : UserControl
    {
        private Panel MainPanel;
        private AdminBusinessLogic aBL;
        private FormatBusinessLogic fBL;
        private StyleClassBusinessLogic sBL;
        public MaintainFormats(Panel mainPanel)
        {
            fBL = new FormatBusinessLogic();
            aBL = new AdminBusinessLogic();
            sBL = new StyleClassBusinessLogic();
            InitializeComponent();
            MainPanel = mainPanel;
            foreach (Format formati in fBL.GetAllFormats(Guid.NewGuid()))
            {
                listBoxFormats.Items.Add(formati);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl menuControl = new ManageFormat(MainPanel);
            MainPanel.Controls.Add(menuControl);
        }

        private void buttonDeleteFormat_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxFormats.SelectedIndex != -1)
                {
                    Format formatToDelete = new Format();
                    formatToDelete = listBoxFormats.SelectedItem as Format;
                    if (aBL.CanDeleteFormat(formatToDelete.Id))
                    {
                        fBL.DeleteFormat(formatToDelete.Id, Guid.NewGuid());
                        MessageBox.Show("El formato " + formatToDelete.Name + " fue borrado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pueden borrar formatos que esten aplicados a documentos.");
                    }
                }
                else
                {
                    MessageBox.Show("Debes seleccionar un formato para realizar esta acción.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MainPanel.Controls.Clear();
            UserControl menuControl = new MaintainFormats(MainPanel);
            MainPanel.Controls.Add(menuControl);
        }

        private void buttonModifyFormat_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxFormats.SelectedIndex != -1)
                {
                    Format formatToModify = new Format();
                    formatToModify = listBoxFormats.SelectedItem as Format;
                    MainPanel.Controls.Clear();
                    UserControl modifyFormatControl = new ModifyFormat(MainPanel, formatToModify);
                    MainPanel.Controls.Add(modifyFormatControl);
                }
                else
                {
                    MessageBox.Show("Debes seleccionar un formato para realizar esta acción.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
