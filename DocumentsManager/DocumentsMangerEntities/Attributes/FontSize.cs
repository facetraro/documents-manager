using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class FontSize : StyleAttribute
    {
        public FontSize()
        {
            Name = "Tamaño";
            Size = 10;
        }

        public int Size { get; set; }
        public override bool Equals(object obj)
        {
            FontSize anotherFontSize = obj as FontSize;
            return base.Equals(anotherFontSize) && IsTheSameSize(anotherFontSize);
        }
        private bool IsTheSameSize(FontSize anotherFontSize)
        {
            return Size == anotherFontSize.Size;
        }
    }
}
