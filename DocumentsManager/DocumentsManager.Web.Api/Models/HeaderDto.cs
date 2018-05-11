using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class HeaderDto
    {
        public Guid Id { get; set; }
        public HeaderDto(Header aHeader)
        {
            this.Id = aHeader.Id;
        }
    }
}