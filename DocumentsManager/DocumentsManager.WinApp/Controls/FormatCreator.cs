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
    public partial class FormatCreator : UserControl
    {
        private Panel MainPanel;
        private AdminBusinessLogic aBL;
        private FormatBusinessLogic fBL;
        private StyleClassBusinessLogic sBL;
        public FormatCreator(Panel panel)
        {
            MainPanel = panel;
            aBL = new AdminBusinessLogic();
            fBL = new FormatBusinessLogic();
            sBL = new StyleClassBusinessLogic();
            InitializeComponent();
            foreach (StyleClass stylei in sBL.GetAllStyleClasses(Guid.NewGuid()))
            {
                listBoxPossibleStyles.Items.Add(stylei);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl manageFormatControl = new ManageFormat(MainPanel);
            MainPanel.Controls.Add(manageFormatControl);
        }

        private void buttonCreateFormat_Click(object sender, EventArgs e)
        {
            try
            {
                Format newFormat = new Format();
                newFormat.Id = Guid.NewGuid();
                newFormat.Name = textBoxFormatName.Text;
                newFormat.StyleClasses = new List<StyleClass>();
                foreach (var item in listBoxStylesToAdd.Items)
                {
                    newFormat.StyleClasses.Add(sBL.GetStyleById((item as StyleClass).Id, Guid.NewGuid()));
                }
                ;
                if (newFormat.Name.Trim().Length < 3)
                {
                    throw new Exception("El nombre debe contener almenos 3 letras");
                }
                MessageBox.Show("Se creo el formato: " + newFormat.Name + " correctamente.");
                MainPanel.Controls.Clear();
                UserControl manageFormatControl = new ManageFormat(MainPanel);
                MainPanel.Controls.Add(manageFormatControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAddAStyle_Click(object sender, EventArgs e)
        {
            StyleClass selectedStyle = listBoxPossibleStyles.SelectedItem as StyleClass;
            listBoxPossibleStyles.Items.Remove(selectedStyle);
            listBoxStylesToAdd.Items.Add(selectedStyle);
        }

        private void buttonDeleteStyle_Click(object sender, EventArgs e)
        {
            StyleClass selectedStyle = listBoxStylesToAdd.SelectedItem as StyleClass;
            listBoxStylesToAdd.Items.Remove(selectedStyle);
            listBoxPossibleStyles.Items.Add(selectedStyle);
        }
    }
}
