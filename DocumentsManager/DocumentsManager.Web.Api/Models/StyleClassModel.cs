using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class StyleClassModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<StyleAttribute> Attributes { get; set; }
        public StyleClass Based { get; set; }
        public virtual List<Format> Formats { get; set; }
        public StyleClassModel()
        {

        }
        public StyleClassModel(StyleClass style)
        {
            Id = style.Id;
            Name = style.Name;
            Attributes = style.Attributes;
            Formats = style.Formats;
            Based = style.Based;
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
            style.Attributes = Attributes;
            style.Formats = Formats;
            style.Based = Based;
            return style;
        }
    }
}