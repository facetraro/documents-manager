using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerDataAccess
{
    public class StyleClassContext
    {
        public void Add(StyleClass newStyleClass)
        {
            using (var context = new ContextDataAccess())
            {
                context.Styles.Add(newStyleClass);
                context.SaveChanges();
            }
        }
        public List<StyleClass> GetLazy()
        {
            List<StyleClass> allLazy = new List<StyleClass>();
            using (var context = new ContextDataAccess())
            {
                allLazy = context.Styles.ToList();
            }
            return allLazy;
        }
        public void ClearAll()
        {
            foreach (var item in GetLazy())
            {
                Remove(item);
            }
        }
        public void Remove(StyleClass style)
        {
            using (var context = new ContextDataAccess())
            {
                StyleClass styleClass = GetById(style.Id);
                context.Styles.Attach(styleClass);
                context.Styles.Remove(styleClass);
                context.SaveChanges();
            }
        }
        public StyleClass GetById(Guid id)
        {
            using (var context = new ContextDataAccess())
            {
                StyleClass style = context.Styles.Find(id);
                context.Styles.Include("Attributes").ToList();
                return style;
            }
        }

        public List<StyleAttribute> GetAttributes(StyleClass newStyle)
        {
            return GetById(newStyle.Id).Attributes;
        }
    }
}
