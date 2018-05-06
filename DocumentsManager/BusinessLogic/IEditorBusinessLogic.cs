using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public interface IEditorsBusinessLogic
    {
        IEnumerable<EditorUser> GetAllEditors();
        EditorUser GetByID(Guid id);
        Guid Add(EditorUser editor);
        bool Delete(Guid id);
        bool Update(EditorUser newEditor);
    }
}