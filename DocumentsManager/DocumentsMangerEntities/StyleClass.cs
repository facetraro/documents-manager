using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class StyleClass
    {
        public TextAlignment Alignment { get; set; }
        public bool Bold { get; set; }
        public TextColor Color { get; set; }
        public FontType Font { get; set; }
        public int FontSize { get; set; }
        public bool Italics { get; set; }
        public bool Underline { get; set; }
    }
}
