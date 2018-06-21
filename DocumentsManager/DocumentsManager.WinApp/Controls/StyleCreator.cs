using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentsMangerEntities;
using DocumentsManager.BusinessLogic;

namespace DocumentsManager.WinApp.Controls
{
    public partial class StyleCreator : UserControl
    {
        Panel MainPanel;
        public StyleCreator(Panel MainPanel)
        {
            this.MainPanel = MainPanel;
            InitializeComponent();
            ClearValuesComponents();
            LoadAllStyleAttributesToComboBox();
        }
        private void LoadAllStyleAttributesToComboBox()
        {
            comboBox.Items.Add(new FontSize());
            comboBox.Items.Add(new DocumentsMangerEntities.Font());
            comboBox.Items.Add(new Alignment());
            comboBox.Items.Add(new StyleColor());
            comboBox.Items.Add(new Border());
            comboBox.Items.Add(new Underline());
            comboBox.Items.Add(new Bold());
            comboBox.Items.Add(new Italics());
            StyleClassBusinessLogic scBL = new StyleClassBusinessLogic();
            IEnumerable<StyleClass> styles = scBL.GetAllStyleClasses(new Guid());
            foreach (var item in styles)
            {
                comboBoxBasedOn.Items.Add(item);
            }
        }
        private void LoadTextAlignment()
        {
            foreach (TextAlignment alignment in Enum.GetValues(typeof(TextAlignment)))
            {
                comboBoxAttributeValue.Items.Add(alignment);
            }
        }
        private void LoadFontType()
        {
            foreach (FontType font in Enum.GetValues(typeof(FontType)))
            {
                comboBoxAttributeValue.Items.Add(font);
            }
        }
        private void LoadStyleColor()
        {
            foreach (TextColor color in Enum.GetValues(typeof(TextColor)))
            {
                comboBoxAttributeValue.Items.Add(color);
            }
        }

        private void ClearValuesComponents()
        {
            comboBoxAttributeValue.Items.Clear();
            comboBoxAttributeValue.Visible = false;
            numericUpDown.Visible = false;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearValuesComponents();
            StyleAttribute attribute = comboBox.SelectedItem as StyleAttribute;
            if (attribute is Alignment)
            {
                comboBoxAttributeValue.Visible = true;
                LoadTextAlignment();
            }
            else if (attribute is DocumentsMangerEntities.Font)
            {
                comboBoxAttributeValue.Visible = true;
                LoadFontType();
            }
            else if (attribute is StyleColor)
            {
                comboBoxAttributeValue.Visible = true;
                LoadStyleColor();
            }
            else if (attribute is FontSize)
            {
                numericUpDown.Visible = true;
            }
        }

        private void buttonCreateFormat_Click(object sender, EventArgs e)
        {
            if (textBoxStyleName.Text.Length > 0)
            {
                StyleClassBusinessLogic scBL = new StyleClassBusinessLogic();
                StyleClass newStyle = new StyleClass();
                if (comboBoxBasedOn.SelectedIndex != -1)
                {
                    newStyle.Based = (StyleClass) comboBoxBasedOn.SelectedItem;
                }
                newStyle.Name = textBoxStyleName.Text;
                foreach (StyleAttribute item in listBoxAttributesToAdd.Items)
                {
                    newStyle.Attributes.Add(item);
                }
                try
                {
                    scBL.AddStyle(newStyle, new Guid());
                    MessageBox.Show("Estilo Añadido correctamente");
                    GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("El nombre no puede ser vacio.");
            }
        }
        private void AddToStyleList(StyleAttribute attribute)
        {
            RemoveFromStyleList(attribute);
            listBoxAttributesToAdd.Items.Add(attribute);
        }
        private void RemoveFromStyleList(StyleAttribute attribute)
        {
            for (int i = 0; i < listBoxAttributesToAdd.Items.Count; i++)
            {
                if (listBoxAttributesToAdd.Items[i].ToString().Equals(attribute.ToString()))
                {
                    listBoxAttributesToAdd.Items.RemoveAt(i);
                    return;
                }
            }
        }

        private void buttonAddAStyle_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("No se ha seleccionado ningun atributo.");
                return;
            }
            StyleAttribute attribute = comboBox.SelectedItem as StyleAttribute;
            if (attribute is Alignment || attribute is StyleColor || attribute is DocumentsMangerEntities.Font)
            {
                if (comboBoxAttributeValue.SelectedIndex == -1)
                {
                    MessageBox.Show("Se debe cargar el valor de este atributo.");
                    return;
                }
            }
            if (attribute is Alignment)
            {
                Alignment attributeToAdd = attribute as Alignment;
                attributeToAdd.TextAlignment = (TextAlignment)comboBoxAttributeValue.SelectedItem;
                AddToStyleList(attributeToAdd);

            }
            else if (attribute is StyleColor)
            {
                StyleColor attributeToAdd = attribute as StyleColor;
                attributeToAdd.TextColor = (TextColor)comboBoxAttributeValue.SelectedItem;
                AddToStyleList(attributeToAdd);
            }
            else if (attribute is DocumentsMangerEntities.Font)
            {
                DocumentsMangerEntities.Font attributeToAdd = attribute as DocumentsMangerEntities.Font;
                attributeToAdd.FontType = (FontType)comboBoxAttributeValue.SelectedItem;
                AddToStyleList(attributeToAdd);
            }
            else if (attribute is FontSize)
            {
                FontSize attributeToAdd = attribute as FontSize;
                attributeToAdd.Size = Convert.ToInt32(numericUpDown.Value);
                AddToStyleList(attributeToAdd); ;
            }
            else
            {
                AddToStyleList(attribute);
            }
        }

        private void buttonDeleteStyle_Click(object sender, EventArgs e)
        {
            int index = listBoxAttributesToAdd.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("No se ha seleccionado ningun atributo.");
                return;
            }
            listBoxAttributesToAdd.Items.RemoveAt(index);
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

        private void button1_Click(object sender, EventArgs e)
        {
            comboBoxBasedOn.SelectedIndex = -1;
        }
    }
}
