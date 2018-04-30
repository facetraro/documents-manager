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
    }
}
