using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManager.Data.DA.Handler;

namespace DocumentsManager.BusinessLogic
{
    public class EditorBusinessLogic : IEditorsBusinessLogic
    {
        public Guid Add(EditorUser editor)
        {
            UserContext uContext = new UserContext();
            try
            {
                uContext.Add(editor);
            }
            catch (Exception e)
            {

            }
            return editor.Id;
        }

        public bool Delete(Guid id)
        {
            bool deleted = false;
            UserContext uContext = new UserContext();
            int quantity = GetAllEditors().Count();
            try
            {
                uContext.Remove(id);
            }
            catch (Exception e)
            {
                deleted= false;
            }
            int newQuantity= GetAllEditors().Count();
            if (quantity>newQuantity)
            {
                deleted = true;
            }
            return deleted;
        }

        public IEnumerable<EditorUser> GetAllEditors()
        {
            UserContext uContext = new UserContext();
            return uContext.GetEditors();
        }

        public EditorUser GetByID(Guid id)
        {
            EditorUser userToReturn = new EditorUser();
            UserContext uContext = new UserContext();
            try
            {
                userToReturn= uContext.GetById(id) as EditorUser;
            }
            catch (Exception e)
            {
                return null; 
            }
            return userToReturn;
        }

        public bool Update(Guid id, EditorUser newEditor)
        {
            UserContext uContext = new UserContext();
            bool updated = true;
            try
            {
                uContext.Modify(newEditor);
            }
            catch (Exception e)
            {
                updated=false;
            }
            return updated;
        }
    }
}
