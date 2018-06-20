using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Dtos
{
    public class FormatDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<StyleClassDto> StyleClasses { get; set; }
        public FormatDto(Format aFormat)
        {
            Id = aFormat.Id;
            Name = aFormat.Name;
            StyleClasses = new List<StyleClassDto>();
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
            return aFormat;
        }
    }
}
