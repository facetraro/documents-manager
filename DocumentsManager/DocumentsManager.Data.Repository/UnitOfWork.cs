using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManagerDataAccess;

namespace DocumentsManager.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ContextDataAccess context;
        private GenericRepository<AdminUser> adminUserRepository;
        private GenericRepository<EditorUser> editorUserRepository;
        private GenericRepository<StyleClass> styleClassRepository;
        private GenericRepository<StyleAttribute> styleAttributeRepository;
        private GenericRepository<Text> textRepository;
        private GenericRepository<Header> headerRepository;
        private GenericRepository<Footer> footerRepository;
        private GenericRepository<Format> formatRepository;

        public UnitOfWork(ContextDataAccess documentsManagerContext)
        {
            context = documentsManagerContext;
        }

        public IRepository<AdminUser> AdminRepository
        {
            get
            {
                if (this.adminUserRepository == null)
                {
                    this.adminUserRepository = new GenericRepository<AdminUser>(context);
                }
                return adminUserRepository;
            }
        }

        public IRepository<EditorUser> EditorRepository
        {
            get
            {
                if (this.editorUserRepository == null)
                {
                    this.editorUserRepository = new GenericRepository<EditorUser>(context);
                }
                return editorUserRepository;
            }
        }

        public IRepository<StyleClass> StyleClassRepository
        {
            get
            {
                if (this.styleClassRepository == null)
                {
                    this.styleClassRepository = new GenericRepository<StyleClass>(context);
                }
                return styleClassRepository;
            }
        }

        public IRepository<StyleAttribute> StyleAttributeRepository
        {
            get
            {
                if (this.styleAttributeRepository == null)
                {
                    this.styleAttributeRepository = new GenericRepository<StyleAttribute>(context);
                }
                return styleAttributeRepository;
            }
        }
        public IRepository<Text> TextRepository
        {
            get
            {
                if (this.textRepository == null)
                {
                    this.textRepository = new GenericRepository<Text>(context);
                }
                return textRepository;
            }
        }
        public IRepository<Header> HeaderRepository
        {
            get
            {
                if (this.headerRepository == null)
                {
                    this.headerRepository = new GenericRepository<Header>(context);
                }
                return headerRepository;
            }
        }
        public IRepository<Footer> FooterRepository
        {
            get
            {
                if (this.footerRepository == null)
                {
                    this.footerRepository = new GenericRepository<Footer>(context);
                }
                return footerRepository;
            }
        }
        public IRepository<Format> FormatRepository
        {
            get
            {
                if (this.formatRepository == null)
                {
                    this.formatRepository = new GenericRepository<Format>(context);
                }
                return formatRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
