using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class FontSize
    {
        public FontSize()
        {
            Size = 10;
            Specified = SpecifiedValue.NotSpecified;
        }

        public int Size { get; set; }
        public SpecifiedValue Specified { get; set; }
        public override bool Equals(object obj)
        {
            return true;
        }
    }
}
