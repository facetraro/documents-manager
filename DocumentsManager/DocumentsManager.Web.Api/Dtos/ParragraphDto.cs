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
        public List<string> texts { get; set; }
        public ParragraphDto(Parragraph aParragraph) {
            this.Id = aParragraph.Id;
            this.texts = new List<string>();
            foreach (var ti in aParragraph.Texts)
            {
                texts.Add(ti.WrittenText);
            }
        }
    }
}