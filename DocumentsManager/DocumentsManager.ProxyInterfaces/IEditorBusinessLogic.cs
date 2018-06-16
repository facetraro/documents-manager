using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.ProxyInterfaces
{
    public interface IEditorsBusinessLogic
    {
        IEnumerable<EditorUser> GetAllEditors(Guid tokenId);
        EditorUser GetEditorByID(Guid id, Guid tokenId);
        Guid AddEditor(EditorUser editor, Guid tokenId);
        bool DeleteEditor(Guid id, Guid tokenId);
        bool UpdateEditor(Guid id, EditorUser newEditor, Guid tokenId);
    }
}
