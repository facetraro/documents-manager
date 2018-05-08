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
        private string GetInitialTag(StyleClass style)
        {
            string htmlResult = "<p";
            string allHTMLStyles = String.Empty;
            foreach (var item in style.Attributes)
            {
                allHTMLStyles = allHTMLStyles + item.GetStyle();
            }
            if (allHTMLStyles.Length != 0)
            {
                htmlResult = $"{htmlResult} style=\"{allHTMLStyles}\"";
            }
            htmlResult = $"{htmlResult}>";
            return htmlResult;
        }

        private string GetAllEndAttributesTags(StyleClass style)
        {
            string htmlResult = String.Empty;
            foreach (var item in style.Attributes)
            {
                htmlResult = htmlResult + item.GetEndTag();
            }
            return htmlResult;
        }

        private string GetAllIncialAttributesTags(StyleClass style)
        {
            string htmlResult = String.Empty;
            foreach (var item in style.Attributes)
            {
                htmlResult = htmlResult + item.GetInitialTag();
            }
            return htmlResult;
        }
        public string GetHtmlText(StyleClass style, string text)
        {
            string htmlResult = String.Empty;
            htmlResult = GetInitialTag(style) + GetAllIncialAttributesTags(style) + text + GetAllEndAttributesTags(style) + "</p>";
            return htmlResult;
        }

    }
}
