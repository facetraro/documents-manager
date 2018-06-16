﻿using DocumentsManager.BusinessLogic;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class FooterModel
    {

        public Guid Id { get; set; }
        public TextModel Text { get; set; }
        public Guid StyleClassId { get; set; }

        public FooterModel()
        {
            Id = Guid.NewGuid();
            Text = new TextModel();
            StyleClassId = Guid.NewGuid();
        }
        public FooterModel(Footer aFooter)
        {
            Id = Guid.NewGuid();
            Text = new TextModel(aFooter.Text);
            StyleClassId = aFooter.StyleClass.Id;
        }
        public Footer GetEntityModel()
        {
            StyleClassBusinessLogic styleBL = new StyleClassBusinessLogic();
            Footer footer = new Footer();
            if (!Id.Equals(Guid.Empty))
            {
                footer.Id = Id;
            }
            footer.Text = Text.GetEntityModel();
            footer.StyleClass = styleBL.GetStyleById(StyleClassId, Guid.NewGuid());
            return footer;
        }
    }
}