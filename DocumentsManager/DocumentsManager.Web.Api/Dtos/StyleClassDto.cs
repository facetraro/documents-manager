using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class StyleClassDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public StyleClassDto()
        {

        }
        public StyleClassDto(StyleClass style)
        {
            Id = style.Id;
            Name = style.Name;
        }
        public StyleClass GetEntityModel()
        {
            StyleClass style = new StyleClass();
            if (!Id.Equals(Guid.Empty))
            {
                style.Id = Id;
            }
            if (!String.IsNullOrEmpty(Name))
            {
                style.Name = Name;
            }
            
            return style;
        }
    }
}