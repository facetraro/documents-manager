using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManagerDataAccess;
using DocumentsManager.AuthenticationToken;
using DocumentsManager.Data.Logger;

namespace DocumentsManager.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ContextDataAccess context;
        private GenericRepository<User> userRepository;
        private GenericRepository<StyleClass> styleClassRepository;
        private GenericRepository<StyleAttribute> styleAttributeRepository;
        private GenericRepository<Text> textRepository;
        private GenericRepository<Header> headerRepository;
        private GenericRepository<Footer> footerRepository;
        private GenericRepository<Format> formatRepository;
        private GenericRepository<Parragraph> parragraphRepository;
        private GenericRepository<Document> documentRepository;
        private GenericRepository<ModifyDocumentHistory> historyRepository;
        private GenericRepository<Session> sessionRepository;
        private GenericRepository<Friendship> friendshipRepository;
        private GenericRepository<Review> reviewRepository;
        private GenericRepository<LoggerType> loggerRepository;


        public UnitOfWork(ContextDataAccess documentsManagerContext)
        {
            context = documentsManagerContext;
        }
        public IRepository<LoggerType> LoggerRepository
        {
            get
            {
                if (this.loggerRepository == null)
                {
                    this.loggerRepository = new GenericRepository<LoggerType>(context);
                }
                return loggerRepository;
            }
        }
        public IRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
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
        public IRepository<Parragraph> ParragraphRepository
        {
            get
            {
                if (this.parragraphRepository == null)
                {
                    this.parragraphRepository = new GenericRepository<Parragraph>(context);
                }
                return parragraphRepository;
            }
        }
        public IRepository<Document> DocumentRepository
        {
            get
            {
                if (this.documentRepository == null)
                {
                    this.documentRepository = new GenericRepository<Document>(context);
                }
                return documentRepository;
            }
        }

        public IRepository<ModifyDocumentHistory> HistoryRepository
        {
            get
            {
                if (this.historyRepository == null)
                {
                    this.historyRepository = new GenericRepository<ModifyDocumentHistory>(context);
                }
                return historyRepository;
            }
        }
        public IRepository<Session> SessionRepository
        {
            get
            {
                if (this.sessionRepository == null)
                {
                    this.sessionRepository = new GenericRepository<Session>(context);
                }
                return sessionRepository;
            }
        }
        public IRepository<Friendship> FriendshipRepository
        {
            get
            {
                if (this.friendshipRepository == null)
                {
                    this.friendshipRepository = new GenericRepository<Friendship>(context);
                }
                return friendshipRepository;
            }
        }
        public IRepository<Review> ReviewRepository
        {
            get
            {
                if (this.reviewRepository == null)
                {
                    this.reviewRepository = new GenericRepository<Review>(context);
                }
                return reviewRepository;
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
