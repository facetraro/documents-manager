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
using DocumentsMangerEntities;
using DocumentsManager.ImportedItemsParser;
using DocumentsManager.BusinessLogic;
using DocumentsManager.Data.Logger;

namespace DocumentsManager.WinApp.Controls
{
    public partial class ImportControl : UserControl
    {
        private Panel MainPanel;
        private static int distance = 40;
        private int position = 0;
        private IFormatImportation importer;
        private List<Tuple<string, string>> parametersObtained;
        private AdminBusinessLogic aBL;
        private FormatBusinessLogic fBL;
        private StyleClassBusinessLogic sBL;
        private LoggerMethod lm;
        public ImportControl(Panel panel, IFormatImportation importation)
        {
            importer = importation;
            MainPanel = panel;
            parametersObtained = new List<Tuple<string, string>>();
            InitializeComponent();
            LoadRequiredParamaters();
            aBL = new AdminBusinessLogic();
            sBL = new StyleClassBusinessLogic();
            fBL = new FormatBusinessLogic();
            lm = new LoggerMethod();
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
        private string AreAllParametersOk()
        {
            string errors = String.Empty;
            if (parametersObtained.Count != importer.GetParameters().Count)
            {
                foreach (var item in importer.GetParameters())
                {
                    if (!IsInTheList(item))
                    {
                        errors = errors + "-" + item.Item1 + "\n";
                    }
                }
                return errors;
            }
            return String.Empty;
        }

        private bool IsInTheList(Tuple<string, ParameterType> particularTuple)
        {
            foreach (var item in parametersObtained)
            {
                if (particularTuple.Item1 == item.Item1)
                {
                    return true;
                }
            }
            return false;
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            string errors = AreAllParametersOk();
            if (errors.Length != 0)
            {
                MessageBox.Show("Falta ingresar los siguientes parametros: \n" + errors);
                return;
            }
            try
            {
                List<ImportedFormat> importedFormats = importer.ImportFormats(parametersObtained);
                List<Format> formats = new List<Format>();
                foreach (ImportedFormat importedFormati in importedFormats)
                {
                    formats.Add(FormatParser.Parse(importedFormati));
                }
                foreach (Format formati in formats)
                {
                    foreach (StyleClass stylei in formati.StyleClasses)
                    {
                        sBL.AddStyle(stylei,Guid.NewGuid());
                    }
                    fBL.AddFormat(formati, Guid.NewGuid());
                }
                MessageBox.Show("Se importaron los formatos y estilos correctamente.");
                LoggerType log = new LoggerType
                {
                    Date = DateTime.Now,
                    Action = ActionType.Importation,
                    UserBy = UserLogged.Username,
                    Id = new Guid()
                };

                lm.AddLogger(log);
                MainPanel.Controls.Clear();
                UserControl menuControl = new MainMenu(MainPanel);
                MainPanel.Controls.Add(menuControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl importMethods = new ImportMethods(MainPanel);
            MainPanel.Controls.Add(importMethods);
        }
    }
}
