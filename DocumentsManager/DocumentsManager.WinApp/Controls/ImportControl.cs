using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentsManager.FormatImportation;

namespace DocumentsManager.WinApp.Controls
{
    public partial class ImportControl : UserControl
    {
        private Panel mainPanel;
        private static int distance = 40;
        private int position = 0;
        private IFormatImportation importer;
        private List<Tuple<string, string>> parametersObtained;
        public ImportControl(Panel panel, IFormatImportation importation)
        {
            importer = importation;
            mainPanel = panel;
            parametersObtained = new List<Tuple<string, string>>();
            InitializeComponent();
            LoadRequiredParamaters();
        }
        private void LoadRequiredParamaters()
        {
            List<Tuple<string, ParameterType>> paramater = importer.GetParameters();
            foreach (var item in paramater)
            {
                AddParameterToTheControl(item);
            }
        }
        private Button AddPathParameter(string name)
        {
            Button newButton = new Button();
            newButton.Text = "Buscar";
            newButton.Click += (s, e) => { GetPathEvent(name); };
            SetSecondBounds(newButton);
            this.Controls.Add(newButton);
            return newButton;
        }
        private void AddParamater(Tuple<string, string> newTuple)
        {
            foreach (var item in parametersObtained)
            {
                if (item.Item1 == newTuple.Item1)
                {
                    parametersObtained.Remove(item);
                }
            }
            parametersObtained.Add(newTuple);
        }
        private void GetPathEvent(string name)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Tuple<string, string> newTuple = new Tuple<string, string>(name, dialog.FileName);
                parametersObtained.Add(newTuple);
            }
        }
        private void SetDefaultBounds(Control aControl)
        {
            aControl.SetBounds(distance, position, distance * 2, distance / 2);
        }
        private void SetSecondBounds(Control aControl)
        {
            aControl.SetBounds(distance * 3, position, distance * 2, distance / 2);
        }
        private Control AddParameterToTheControl(Tuple<string, ParameterType> item)
        {
            Label newLabel = new Label();
            newLabel.Text = item.Item1;
            position = position + distance;
            SetDefaultBounds(newLabel);
            this.Controls.Add(newLabel);
            if (item.Item2 == ParameterType.Path)
            {
                return AddPathParameter(item.Item1);
            }
            return null;
        }
        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (parametersObtained.Count != importer.GetParameters().Count)
            {
                MessageBox.Show("Para poder Imporatr los formatos debes brindarnos todos los datos solicitados en pantalla. Gracias");
                return;
            }
            List<ImportedFormat> formats = importer.ImportFormats(parametersObtained);
        }
    }
}
