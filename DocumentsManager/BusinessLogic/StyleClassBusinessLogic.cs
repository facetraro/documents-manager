using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Exceptions;
using DocumentsManager.ProxyInterfaces;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public class StyleClassBusinessLogic : IStyleClassBusinessLogic
    {
        private static string LastTag = "</p>";
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
            StyleClass styleFromDataBase = GetStyleById(style.Id, Guid.NewGuid());
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
        public StyleClass GetStyleById(Guid id, Guid tokenId)
        {
            StyleClassContextHandler context = new StyleClassContextHandler();
            return context.GetById(id);
        }
        public Guid AddStyle(StyleClass newStyle, Guid tokenId)
        {
            newStyle.Id = Guid.NewGuid();
            StyleClassContextHandler context = new StyleClassContextHandler();
            context.Add(newStyle);
            return newStyle.Id;
        }
        public bool Exists(Guid id)
        {
            StyleClassContextHandler context = new StyleClassContextHandler();
            return context.Exists(id);
        }

        public IEnumerable<StyleClass> GetAllStyleClasses(Guid tokenId)
        {
            StyleClassContextHandler context = new StyleClassContextHandler();
            List<StyleClass> styles = new List<StyleClass>();
            foreach (var item in context.GetLazy())
            {
                styles.Add(context.GetById(item.Id));
            }
            return styles;
        }



        public bool DeleteStyle(Guid id, Guid tokenId)
        {
            StyleClassContextHandler context = new StyleClassContextHandler();
            StyleClass toDelete = GetStyleById(id, tokenId);
            context.Remove(toDelete);
            return true;
        }

        public bool UpdateStyle(Guid id, StyleClass newStyle, Guid tokenId)
        {
            StyleClassContextHandler context = new StyleClassContextHandler();
            foreach (var item in newStyle.Attributes)
            {
                item.Style = newStyle;
            }
            context.Modify(newStyle);
            return true;
        }
    }
}
