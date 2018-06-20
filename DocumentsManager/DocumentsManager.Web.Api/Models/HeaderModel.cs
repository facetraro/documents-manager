using DocumentsManager.BusinessLogic;
using DocumentsMangerEntities;
using DocumentsManager.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class HeaderModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public StyleClassDto Style { get; set; }
        public HeaderModel()
        {
            Id = Guid.NewGuid();
            Text = string.Empty;
            Style = new StyleClassDto();
        }
        public HeaderModel(Header aHeader)
        {
            Id = Guid.NewGuid();
            Text = aHeader.Text.WrittenText;
            Style.Id = aHeader.StyleClass.Id;
            Style.Name = aHeader.StyleClass.Name;
        }
        public Header GetEntityModel()
        {
            StyleClassBusinessLogic styleBL = new StyleClassBusinessLogic();
            Header header = new Header();
            if (!Id.Equals(Guid.Empty))
            {
                header.Id = Id;
            }
            header.Text = new DocumentsMangerEntities.Text();
            header.Text.Id = Guid.NewGuid();
            header.StyleClass = new StyleClass();
            header.Text.StyleClass = styleBL.GetStyleById(Style.Id, Guid.NewGuid());
            header.Text.WrittenText = Text;
            header.StyleClass = styleBL.GetStyleById(Style.Id, Guid.NewGuid());
            return header;
        }
    }
}