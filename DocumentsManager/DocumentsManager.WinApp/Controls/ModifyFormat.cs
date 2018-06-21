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
    public partial class ModifyFormat : UserControl
    {
        private Panel MainPanel;
        private Format FormatToModify;
        private AdminBusinessLogic aBL;
        private FormatBusinessLogic fBL;
        private StyleClassBusinessLogic sBL;
        public ModifyFormat(Panel mainPanel, Format aFormat)
        {
            FormatToModify = aFormat;
            fBL = new FormatBusinessLogic();
            aBL = new AdminBusinessLogic();
            sBL = new StyleClassBusinessLogic();
            MainPanel = mainPanel;
            InitializeComponent();
            textBoxFN.Text = aFormat.Name;
            foreach (StyleClass stylei in sBL.GetAllStyleClasses(Guid.NewGuid()))
            {
                if (aFormat.StyleClasses.Contains(stylei))
                {
                    listBoxStylesKeep.Items.Add(stylei);
                }
                else
                {
                    listBoxStylesToLeave.Items.Add(stylei);
                }
            }
        }

        private void buttonCreateFormat_Click(object sender, EventArgs e)
        {
            try
            {
                FormatToModify.StyleClasses = new List<StyleClass>();
                FormatToModify.Name = textBoxFN.Text;
                if (FormatToModify.Name.Trim().Length < 3)
                {
                    throw new Exception("El nombre debe contener almenos 3 letras");
                }
                foreach (var item in listBoxStylesKeep.Items)
                {
                    FormatToModify.StyleClasses.Add(sBL.GetStyleById((item as StyleClass).Id, Guid.NewGuid()));
                }
                fBL.UpdateFormat(FormatToModify.Id, FormatToModify, Guid.NewGuid());
                MessageBox.Show("El formato fue modificado exitosamente.");
                MainPanel.Controls.Clear();
                UserControl maintainFormats = new MaintainFormats(MainPanel);
                MainPanel.Controls.Add(maintainFormats);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl maintainFormats = new MaintainFormats(MainPanel);
            MainPanel.Controls.Add(maintainFormats);
        }

        private void buttonDeleteStyle_Click(object sender, EventArgs e)
        {
            if (listBoxStylesKeep.SelectedIndex != -1)
            {
                StyleClass selectedStyle = listBoxStylesKeep.SelectedItem as StyleClass;
                listBoxStylesKeep.Items.Remove(selectedStyle);
                listBoxStylesToLeave.Items.Add(selectedStyle);
            }
            else
            {
                MessageBox.Show("Debes seleccionar un Estilo para realizar esta acción");
            }
        }

        private void buttonAddAStyle_Click(object sender, EventArgs e)
        {
            if (listBoxStylesToLeave.SelectedIndex != -1)
            {
                StyleClass selectedStyle = listBoxStylesToLeave.SelectedItem as StyleClass;
                listBoxStylesToLeave.Items.Remove(selectedStyle);
                listBoxStylesKeep.Items.Add(selectedStyle);
            }
            else
            {
                MessageBox.Show("Debes seleccionar un Estilo para realizar esta acción");
            }
        }
    }
}
