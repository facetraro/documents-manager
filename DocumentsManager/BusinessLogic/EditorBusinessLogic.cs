using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Exceptions;

namespace DocumentsManager.BusinessLogic
{
    public class EditorBusinessLogic : UserBusinessLogic, IEditorsBusinessLogic
    {
        public Guid Add(EditorUser editor)
        {
            editor.Id = Guid.NewGuid();
            UserContext uContext = new UserContext();
            if (IdRegistered(editor))
            {
                throw new ObjectAlreadyExistsException("Id");
            }
            if (EmailRegistered(editor))
            {
                throw new ObjectAlreadyExistsException("email");
            }
            if (UserNameRegistered(editor))
            {
                throw new ObjectAlreadyExistsException("username");
            }
            uContext.Add(editor);
            return editor.Id;
        }

        public bool Delete(Guid id)
        {
            UserContext uContext = new UserContext();
            EditorUser idUser = new EditorUser();
            idUser.Id = id;
            if (uContext.Exists(idUser))
            {
                return uContext.Remove(id);
            }
            throw new ObjectDoesNotExists(idUser);
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
            User userToVerify = uContext.GetById(id);
            if (userToVerify is AdminUser)
            {
                throw new WrongUserType(userToReturn);
            }
            userToReturn = userToVerify as EditorUser;
            if (userToReturn == null)
            {
                throw new ObjectDoesNotExists(new EditorUser());
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
                updated = false;
            }
            User dbUser = GetByID(id);
            if (!dbUser.hasSameInformation(newEditor))
            {
                updated = false;
            }
            return updated;
        }
    }
}
