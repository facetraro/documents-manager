using DocumentsManager.BusinessLogic;
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
        public List<HeaderDto> Texts { get; set; }
        public StyleClassDto Style { get; set; }
        public ParragraphModel()
        {
            Id = Guid.NewGuid();
            Style = new StyleClassDto();
            Texts = new List<HeaderDto>();
        }
        public ParragraphModel(Parragraph aParragraph) {
            Id = Guid.NewGuid();
            Style = new StyleClassDto(aParragraph.StyleClass);
            Texts = new List<HeaderDto>();
            foreach (Text ti in aParragraph.Texts)
            {
                HeaderDto text = new HeaderDto();
                text.text = ti.WrittenText;
                text.Id = ti.Id;
                text.Style = new StyleClassDto(ti.StyleClass);
                Texts.Add(text);
            }
        }
        public Parragraph GetEntityModel()
        {
            StyleClassBusinessLogic styleBL = new StyleClassBusinessLogic();
            Parragraph parragraph = new Parragraph {
                StyleClass = new StyleClass(),
                Texts = new List<Text>(),
                Id = Guid.NewGuid() 
            };
            if (!Id.Equals(Guid.Empty))
            {
                parragraph.Id = Id;
            }
            foreach (HeaderDto tmi in Texts)
            {
                Text newText = new Text();
                newText.StyleClass = styleBL.GetStyleById(tmi.Style.Id, Guid.NewGuid());
                newText.WrittenText = tmi.text;
                newText.Id = Guid.NewGuid();
                parragraph.Texts.Add(newText);
            }
            parragraph.StyleClass = styleBL.GetStyleById(Style.Id, Guid.NewGuid());
            return parragraph;
        }
    }
}