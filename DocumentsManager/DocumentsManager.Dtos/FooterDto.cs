using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Dtos
{
    public class FooterDto
    {
        public Guid Id { get; set; }
        public string text { get; set; }
        public StyleClassDto Style { get; set; }
        public FooterDto(Footer aFooter)
        {
            this.Id = aFooter.Id;
            this.Style = new StyleClassDto(aFooter.StyleClass);
            this.text = aFooter.Text.WrittenText;
        }
    }
}
