using DocumentsManager.BusinessLogic;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class HeaderModel
    {
        public Guid Id { get; set; }
        public TextModel Text { get; set; }
        public Guid StyleClassId { get; set; }
        public HeaderModel(Header aHeader)
        {
            Id = aHeader.Id;
            Text = new TextModel (aHeader.Text);
            StyleClassId = aHeader.StyleClass.Id;
        }
        public Header GetEntityModel()
        {
            StyleClassBusinessLogic styleBL = new StyleClassBusinessLogic();
            Header header = new Header();
            if (!Id.Equals(Guid.Empty))
            {
                header.Id = Id;
            }
            header.Text = Text.GetEntityModel();
            header.StyleClass = styleBL.GetById(StyleClassId);
            return header;
        }
    }
}