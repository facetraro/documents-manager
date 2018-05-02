using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<AdminUser> AdminRepository { get; }
        IRepository<EditorUser> EditorRepository { get; }
        IRepository<StyleClass> StyleClassRepository { get; }
        IRepository<StyleAttribute> StyleAttributeRepository { get; }
        IRepository<Text> TextRepository { get; }
        void Save();
    }
}
