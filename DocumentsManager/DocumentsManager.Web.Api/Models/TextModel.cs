using DocumentsManager.BusinessLogic;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class TextModel
    {

        public Guid Id { get; set; }
        public Guid StyleClassId { get; set; }
        public string Text { get; set; }
        public TextModel(Text aText)
        {
            Id = aText.Id;
            Text = aText.WrittenText;
            StyleClassId = aText.StyleClass.Id;
        }
        public Text GetEntityModel()
        {
            StyleClassBusinessLogic styleBL = new StyleClassBusinessLogic();
            Text text = new Text();
            if (!Id.Equals(Guid.Empty))
            {
                text.Id = Id;
            }
            text.WrittenText = Text;
            text.StyleClass = styleBL.GetById(StyleClassId);
            return text;
        }
    }
}