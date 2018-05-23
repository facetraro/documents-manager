using DocumentsManager.Data.Repository;
using DocumentsManagerDataAccess;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Data.DA.Handler
{
    public class FriendshipContext
    {
        public void Add(Friendship newFriendship)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                db.Users.Attach(newFriendship.Request);
                db.Users.Attach(newFriendship.Requested);
                unitOfWork.FriendshipRepository.Insert(newFriendship);
            }
        }
        public List<Friendship> GetLazy()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.FriendshipRepository.Get().ToList();
            }
        }
        public List<Friendship> GetAllFriendships()
        {
            List<Friendship> allFriendships = new List<Friendship>();
            foreach (var item in GetLazy())
            {
                allFriendships.Add(GetById(item.Id));
            }
            return allFriendships;
        }
        public void ClearAll()
        {
            foreach (var item in GetAllFriendships())
            {
                Remove(item);
            }
        }
        public void Remove(Friendship friendship)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.FriendshipRepository.Delete(friendship);
            }
        }
        public Friendship GetById(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                Friendship friendship = unitOfWork.FriendshipRepository.GetByID(id);
                db.Friendships.Include("Request").ToList();
                db.Friendships.Include("Requested").ToList();
                return friendship;
            }
        }
        public bool Modify(Friendship modifiedFriendship)
        {
            bool modified = false;
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.FriendshipRepository.Update(modifiedFriendship);
                modified = true;
            }
            return modified;
        }
    }
}
