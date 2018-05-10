﻿using DocumentsManager.Data.DA.Handler;
using DocumentsMangerEntities;
using System;

namespace DocumentsManager.BusinessLogic
{
    public class TextBusinessLogic
    {
        public Text GetById(Guid id)
        {
            TextContext context = new TextContext();
            StyleClassBusinessLogic styleLogic = new StyleClassBusinessLogic();
            Text text = context.GetById(id);
            text.StyleClass = styleLogic.GetById(text.StyleClass.Id);
            return text;
        }
    }
}