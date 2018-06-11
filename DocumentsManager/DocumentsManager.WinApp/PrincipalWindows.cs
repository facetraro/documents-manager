﻿using DocumentsManager.WinApp.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentsManager.WinApp
{
    public partial class DocumentsManager : Form
    {
        public DocumentsManager()
        {
            InitializeComponent();
            mainPanel.Controls.Clear();
            UserControl imports  = new ImportMethods(mainPanel);
            mainPanel.Controls.Add(imports);
        }
    }
}
