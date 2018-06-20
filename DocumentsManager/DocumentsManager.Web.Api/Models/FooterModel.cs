using DocumentsManager.BusinessLogic;
using DocumentsMangerEntities;
using DocumentsManager.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class FooterModel
    {

        public Guid Id { get; set; }
        public string Text { get; set; }
        public StyleClassDto Style { get; set; }

        public FooterModel()
        {
            Id = Guid.NewGuid();
            Text = "";
            Style = new StyleClassDto();
        }
        public FooterModel(Footer aFooter)
        {
            Id = Guid.NewGuid();
            Text = aFooter.Text.WrittenText;
            Style.Id = aFooter.StyleClass.Id;
            Style.Name = aFooter.StyleClass.Name;
        }
        public Footer GetEntityModel()
        {
            StyleClassBusinessLogic styleBL = new StyleClassBusinessLogic();
            Footer footer = new Footer();
            if (!Id.Equals(Guid.Empty))
            {
                footer.Id = Id;
            }
            footer.Text = new DocumentsMangerEntities.Text();
            footer.Text.Id = Guid.NewGuid();
            footer.StyleClass = new StyleClass();
            footer.Text.StyleClass = styleBL.GetStyleById(Style.Id, Guid.NewGuid());
            footer.Text.WrittenText = Text;
            footer.StyleClass = styleBL.GetStyleById(Style.Id, Guid.NewGuid());
            return footer;
        }
    }
}