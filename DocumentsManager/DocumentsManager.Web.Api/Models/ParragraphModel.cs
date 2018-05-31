﻿using DocumentsManager.BusinessLogic;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class ParragraphModel
    {
        public Guid Id { get; set; }
        public List<TextModel> Texts { get; set; }
        public Guid StyleClassId { get; set; }
        public ParragraphModel(Parragraph aParragraph) {
            Id = aParragraph.Id;
            StyleClassId = aParragraph.StyleClass.Id;
            Texts = new List<TextModel>();
            foreach (Text ti in aParragraph.Texts)
            {
                Texts.Add(new TextModel(ti));
            }
        }
        public Parragraph GetEntityModel()
        {
            StyleClassBusinessLogic styleBL = new StyleClassBusinessLogic();
            Parragraph parragraph = new Parragraph();
            if (!Id.Equals(Guid.Empty))
            {
                parragraph.Id = Id;
            }
            foreach (TextModel tmi in Texts)
            {
                parragraph.Texts.Add(tmi.GetEntityModel());
            }
            parragraph.StyleClass = styleBL.GetById(StyleClassId);
            return parragraph;
        }
    }
}