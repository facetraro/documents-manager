using DocumentsManager.Data.DA.Handler;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;

namespace DocumentsManager.BusinessLogic
{
    public class FormatBusinessLogic
    {
        public Format GetById(Guid id)
        {
            FormatContext context = new FormatContext();
            StyleClassBusinessLogic styleLogic = new StyleClassBusinessLogic();
            Format format = context.GetById(id);
            List<StyleClass> styles = new List<StyleClass>();
            foreach (var item in format.StyleClasses)
            {
                styles.Add(styleLogic.GetById(item.Id));
            }
            format.StyleClasses = styles;
            return format;
        }
    }
}