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
        public virtual List<StyleClassDto> StyleClasses { get; set; }
        public FormatModel()
        {
            Id = Guid.NewGuid();
            Name = "";
            StyleClasses = new List<StyleClassDto>();
        }
        public FormatModel(Format aFormat)
        {
            Id = Guid.NewGuid();
            Name = aFormat.Name;
            foreach (var item in aFormat.StyleClasses)
            {
                StyleClassDto newDto = new StyleClassDto();
                newDto.Id = item.Id;
                newDto.Name = item.Name;
            }
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
            foreach (var item in StyleClasses)
            {
                StyleClass newStyleClass = new StyleClass();
                newStyleClass.Id = item.Id;
                newStyleClass.Name = item.Name;
                aFormat.StyleClasses.Add(newStyleClass);
            }
            return aFormat;
        }
    }
}