﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.FormatImportation
{
    public class ImportedStyleClass
    {
        public Guid Id = new Guid();
        public string Name { get; set; }
        public List<string> StyleAttributes { get; set; }

        public ImportedStyleClass()
        {
            this.Name = "";
            this.StyleAttributes = new List<string>();
        }
    }
}
