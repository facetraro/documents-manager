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
            throw new NotImplementedException();
        }

        public IEnumerable<EditorUser> GetAllEditors()
        {
            UserContext uContext = new UserContext();
            return uContext.GetEditors();
        }

        public EditorUser GetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid id, EditorUser newEditor)
        {
            throw new NotImplementedException();
        }
    }
}
