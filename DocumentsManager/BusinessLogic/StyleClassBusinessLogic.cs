using DocumentsManager.Data.DA.Handler;
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
        private static string LastTag ="</p>";
        private string GetAttributesInitialTag(StyleClass style)
        {
            string allHTMLStyles = String.Empty;
            foreach (var item in style.Attributes)
            {
                allHTMLStyles = allHTMLStyles + item.GetStyle();
            }
            return allHTMLStyles;
        }
        private string GetStylesInitialTag(StyleClass style)
        {
            string htmlResult = String.Empty;
            string allHTMLStyles = GetAttributesInitialTag(style);
            if (allHTMLStyles.Length != 0)
            {
                htmlResult = $"{htmlResult} style=\"{allHTMLStyles}\"";
            }
            return htmlResult;
        }
        private string GetInitialTag(StyleClass style)
        {
            string htmlResult = "<p";
            htmlResult = $"{htmlResult}{GetStylesInitialTag(style)}>";
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
        public string GetHtmlTextStyleFromDB(StyleClass style, string text)
        {
            string htmlResult = String.Empty;
            StyleClass styleFromDataBase = GetById(style.Id);
            htmlResult = GetInitialTag(style) + GetAllIncialAttributesTags(style) + text + GetAllEndAttributesTags(style) + LastTag;
            return htmlResult;
        }
        public string GetHtmlText(StyleClass style, string text)
        {
            style.Attributes.Sort();
            string htmlResult = String.Empty;
            htmlResult = GetInitialTag(style) + GetAllIncialAttributesTags(style) + text + GetAllEndAttributesTags(style) + LastTag;
            return htmlResult;
        }
        public StyleClass GetById(Guid id)
        {
            StyleClassContextHandler context = new StyleClassContextHandler();
            return context.GetById(id);
        }
    }
}
