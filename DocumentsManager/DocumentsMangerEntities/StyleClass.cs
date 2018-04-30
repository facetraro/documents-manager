﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class StyleClass
    {
        public Guid Id { get; set; }
        public virtual List<StyleAttribute> Attributes { get; set; }
        public StyleClass Based { get; set; }
        public StyleClass()
        {
            Attributes = new List<StyleAttribute>();
        }
        public override bool Equals(object obj)
        {
            bool validation = false;
            StyleClass anotherStyleClass = obj as StyleClass;
            if ((System.Object)anotherStyleClass != null)
            {
                validation = Id.Equals(anotherStyleClass.Id); ;
            }
            return validation;
        }
        public StyleAttribute GetAttributeByName(string name)
        {
            StyleAttribute attribute = null;
            foreach (StyleAttribute item in Attributes)
            {
                if (item.Name == name)
                {
                    attribute = item;
                }
            }
            return attribute;
        }
        public StyleClass GetBasedOnStyleClass()
        {
            StyleClass basedStyleClass = new StyleClass();
            basedStyleClass.Id = this.Id;
            basedStyleClass.Attributes = Based.Attributes;
            foreach (StyleAttribute item in this.Attributes)
            {
                if (!basedStyleClass.IsAttributeSpecified(item))
                {
                    basedStyleClass.Attributes.Add(item);
                }
            }
            return basedStyleClass;
        }
        public bool IsAttributeSpecified(StyleAttribute attribute)
        {
            bool validation = false;
            foreach (StyleAttribute item in Attributes)
            {
                if (attribute.Name.Equals(item.Name))
                {
                    validation = true;
                }
            }
            return validation;
        }
    }
}
