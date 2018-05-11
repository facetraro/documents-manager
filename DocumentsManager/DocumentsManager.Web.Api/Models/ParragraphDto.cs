using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class ParragraphDto
    {
        public Guid Id { get; set; }
        public ParragraphDto(Parragraph aParragraph) {
            this.Id = aParragraph.Id;
        }
    }
}