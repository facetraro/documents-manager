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
                RemoveAttributes(styleClass);
                context.Styles.Attach(styleClass);
                context.Styles.Remove(styleClass);
                context.SaveChanges();
            }
        }
        public void RemoveAttributes(StyleClass styleClass)
        {
            int lenghtAttributes = styleClass.Attributes.Count;
            for (int i = 0; i < lenghtAttributes; i++)
            {
                RemoveAttribute(styleClass.Attributes[0]);
            }
        }
        public void RemoveAttribute(StyleAttribute attribute)
        {
            using (var context = new ContextDataAccess())
            {
                context.Attributes.Attach(attribute);
                context.Attributes.Remove(attribute);
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

        public List<StyleAttribute> GetAllAttributes()
        {
            using (var context = new ContextDataAccess())
            {
                return context.Attributes.ToList();
            }
        }

        public void Modify(StyleClass newStyle)
        {
            Remove(newStyle);
            Add(newStyle);
        }
    }
}
