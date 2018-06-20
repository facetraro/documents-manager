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

        public StyleClassDto Style{ get; set; }
        public List<HeaderDto> texts { get; set; }
        public ParragraphDto(Parragraph aParragraph) {
            this.Id = aParragraph.Id;
            this.Style = new StyleClassDto(aParragraph.StyleClass);
            this.texts = new List<HeaderDto>();
            foreach (var ti in aParragraph.Texts)
            {
                HeaderDto newParragraph = new HeaderDto();
                newParragraph.Id = ti.Id;
                newParragraph.Style = new StyleClassDto(ti.StyleClass);
                newParragraph.text = ti.WrittenText;
                texts.Add(newParragraph);
            }
        }
    }
}