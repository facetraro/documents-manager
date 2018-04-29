using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerDataAccess
{
    public class EditorUserContext
    {
        public List<EditorUser> GetLazy()
        {
            List<EditorUser> allLazy = new List<EditorUser>();
            using (var context = new ContextDataAccess())
            {
                allLazy = context.Editors.ToList();
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
        public void Add(EditorUser newUser)
        {
            using (var context = new ContextDataAccess())
            {
                context.Editors.Add(newUser);
                context.SaveChanges();
            }
        }

        public void Remove(EditorUser newUser)
        {
            using (var context = new ContextDataAccess())
            {
                context.Editors.Remove(context.Editors.Find(newUser.Id));
                context.SaveChanges();
            }
        }

        public void Modify(EditorUser modifiedUser)
        {
            using (var context = new ContextDataAccess())
            {
                Remove(context.Editors.Find(modifiedUser.Id));
                Add(modifiedUser);
            }
        }
    }
}
