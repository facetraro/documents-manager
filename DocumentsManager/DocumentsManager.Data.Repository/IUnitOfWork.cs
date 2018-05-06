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
        IRepository<User> UserRepository { get; }
        IRepository<StyleClass> StyleClassRepository { get; }
        IRepository<StyleAttribute> StyleAttributeRepository { get; }
        IRepository<Text> TextRepository { get; }
        IRepository<Header> HeaderRepository { get; }
        IRepository<Footer> FooterRepository { get; }
        IRepository<Format> FormatRepository { get; }
        IRepository<Parragraph> ParragraphRepository { get; }
        IRepository<Document> DocumentRepository { get; }
        void Save();
    }
}
