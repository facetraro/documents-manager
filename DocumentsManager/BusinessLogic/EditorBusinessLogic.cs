using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Exceptions;
using DocumentsManager.ProxyInterfaces;

namespace DocumentsManager.BusinessLogic
{
    public class EditorBusinessLogic : UserBusinessLogic, IEditorsBusinessLogic
    {
        public Guid AddEditor(EditorUser editor, Guid tokenId)
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

        public bool DeleteEditor(Guid id, Guid tokenId)
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

        public IEnumerable<EditorUser> GetAllEditors(Guid tokenId)
        {
            UserContext uContext = new UserContext();
            return uContext.GetEditors();
        }

        public EditorUser GetEditorByID(Guid id, Guid tokenId)
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

        public bool UpdateEditor(Guid id, EditorUser newEditor, Guid tokenId)
        {
            UserContext uContext = new UserContext();
            bool updated = false;
            updated = uContext.Modify(newEditor);
            User dbUser = GetEditorByID(id, tokenId);
            if (!dbUser.hasSameInformation(newEditor))
            {
                updated = false;
            }
            return updated;
        }
    }
}
