using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public class StyleClassBusinessLogic
    {
        public string GetHtmlText(StyleClass style, string text)
        {
            return $"<p>{text}</p>";
        }
    }
}
