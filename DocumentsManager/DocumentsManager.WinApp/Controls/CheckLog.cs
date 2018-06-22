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
using DocumentsManager.Data.Logger;

namespace DocumentsManager.WinApp.Controls
{
    public partial class CheckLog : UserControl
    {
        private LoggerMethod lm;
        private Panel MainPanel;
        public CheckLog(Panel mainPanel)
        {
            lm = new LoggerMethod();
            MainPanel = mainPanel;
            InitializeComponent();
            dateTimePickerSince.Value = DateTime.Today;
            dateTimePickerUntil.Value = DateTime.Today;
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            UserControl menuControl = new MainMenu(MainPanel);
            MainPanel.Controls.Add(menuControl);
        }
        private void buttonCheckLog_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxLogs.Items.Clear();
                if (dateTimePickerSince.Value < dateTimePickerUntil.Value)
                {
                    if (dateTimePickerSince.Value < DateTime.Now)
                    {
                        List<LoggerType> logs = lm.GetLoggers(dateTimePickerSince.Value, dateTimePickerUntil.Value);
                        logs.Sort(delegate (LoggerType x, LoggerType y)
                        {
                            return x.Date.CompareTo(y.Date);
                        });
                        foreach (LoggerType logi in logs)
                        {
                            listBoxLogs.Items.Add(logi);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La fecha desde no puede ser del futuro.");
                    }
                }
                else
                {
                    MessageBox.Show("La fecha desde debe ser menor a la fecha hasta.");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
