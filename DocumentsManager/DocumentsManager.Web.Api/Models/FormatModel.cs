using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class FormatModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<StyleClass> StyleClasses { get; set; }
        public FormatModel()
        {
            Id = Guid.NewGuid()/*aFormat.Id*/;
            Name = "";
            StyleClasses = new List<StyleClass>();
        }
        public FormatModel(Format aFormat)
        {
            Id = Guid.NewGuid()/*aFormat.Id*/;
            Name = aFormat.Name;
            StyleClasses = aFormat.StyleClasses;
        }
        public Format GetEntityModel()
        {
            Format aFormat = new Format();
            if (!Id.Equals(Guid.Empty))
            {
                aFormat.Id = Id;
            }
            if (!String.IsNullOrEmpty(Name))
            {
                aFormat.Name = Name;
            }
            aFormat.StyleClasses = StyleClasses;
            return aFormat;
        }
    }
}