﻿using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Dtos
{
    public class HeaderDto
    {
        public Guid Id { get; set; }
        public string text { get; set; }
        public StyleClassDto Style { get; set; }
        public HeaderDto(Header aHeader)
        {
            this.Style = new StyleClassDto(aHeader.StyleClass);
            this.Id = aHeader.Id;
            this.text = aHeader.Text.WrittenText;
        }

        public HeaderDto()
        {
        }
    }
}
