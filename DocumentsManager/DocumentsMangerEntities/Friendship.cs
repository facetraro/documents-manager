using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class Friendship
    {
        public Guid Id { get; set; }
        public User Request { get; set; }
        public User Requested { get; set; }
        public FriendshipState State { get; set; }
        public override bool Equals(object obj)
        {
            Friendship anotherFriendship = obj as Friendship;
            if ((System.Object)anotherFriendship == null)
            {
                return false;
            }
            return Id.Equals(anotherFriendship.Id);    
        }

        public bool IsFriendship()
        {
            return true;
        }

        public bool IsRequest()
        {
            return true;
        }
    }
}
