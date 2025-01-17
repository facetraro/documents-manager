﻿using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsManager.Dtos;

namespace DocumentsManager.ProxyInterfaces
{
    public interface IUserBusinessLogic
    {
        Guid CreateADocument(Document doc, Guid tokenId);
        bool UpdateADocument(Guid id, Document aDocument, Guid tokenId);
        bool DeleteADocument(Document aDocument, Guid tokenId);
        List<Document> GetDocumentsFromUser(User user, Guid tokenId);
        bool AddFriend(Guid userId, Guid tokenId);
        List<User> GetFriends(Guid tokenId);
        List<User> GetRequests(Guid tokenId);
        void RejectRequest(Guid userId, Guid tokenId);
        List<DocumentAverageDto> GetTopRankedDocuments(Guid tokenId);
        void AddReview(Review reviewToAdd, Guid tokenId);
    }
}
