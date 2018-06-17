using DocumentsManager.Exceptions;
using DocumentsManager.FormatImportation;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.ImportedItemsParser
{
    public static class StyleClassParser
    {
        private static string Type = "TipoLetra";
        private static string FontSize = "TamanioLetra";
        private static string Italics = "Cursiva";
        private static string Aligment = "Alineacion";
        private static string Color = "Color";
        private static string Border = "Borde";
        private static string Bold = "Negrita";
        private static string Underlined = "Subrayado";
        private static string GetValueFromDoubleHeader(string actualValue)
        {
            string[] splitter = actualValue.Split(new[] { "###" }, StringSplitOptions.None);
            return splitter[1].ToLower();
        }
        private static string GetNodeName(string actualValue)
        {
            string[] splitter = actualValue.Split(new[] { "###" }, StringSplitOptions.None);
            return splitter[0];
        }
        private static void ParseFontSize(StyleClass newStyleClass, string actualValue)
        {
            if (GetNodeName(actualValue).Equals(FontSize))
            {
                FontSize attribute = new FontSize();
                try
                {
                    attribute.Size = Int32.Parse(GetValueFromDoubleHeader(actualValue));
                    newStyleClass.Attributes.Add(attribute);
                }
                catch
                {
                    throw new StyleAttributeNotRecognized(FontSize + ":" + GetValueFromDoubleHeader(actualValue));
                }

            }
        }
        private static void ParseFontType(StyleClass newStyleClass, string actualValue)
        {
            if (GetNodeName(actualValue).Equals(Type))
            {
                Font attribute = new Font();
                string value = GetValueFromDoubleHeader(actualValue);
                if (value.Equals("arial"))
                {
                    attribute.FontType = FontType.Arial;
                }
                else if (value.Equals("courier new") || value.Equals("couriernew") || value.Equals("courier-new"))
                {
                    attribute.FontType = FontType.CourierNew;
                }
                else if (value.Equals("times new roman") || value.Equals("timesnewroman") || value.Equals("times-new-roman"))
                {
                    attribute.FontType = FontType.TimesNewRoman;
                }
                else
                {
                    throw new StyleAttributeNotRecognized(Type + ":" + value);
                }
                newStyleClass.Attributes.Add(attribute);
            }
        }
        private static void ParseAlignment(StyleClass newStyleClass, string actualValue)
        {
            if (GetNodeName(actualValue).Equals(Aligment))
            {
                Alignment attribute = new Alignment();
                string value = GetValueFromDoubleHeader(actualValue);
                if (value.Equals("derecha"))
                {
                    attribute.TextAlignment = TextAlignment.Right;
                }
                else if (value.Equals("izquierda"))
                {
                    attribute.TextAlignment = TextAlignment.Left;
                }
                else if (value.Equals("centrado"))
                {
                    attribute.TextAlignment = TextAlignment.Center;
                }
                else if (value.Equals("justificado"))
                {
                    attribute.TextAlignment = TextAlignment.Justify;
                }
                else
                {
                    throw new StyleAttributeNotRecognized(Aligment + ":" + value);
                }
                newStyleClass.Attributes.Add(attribute);
            }
        }
        private static void ParseColor(StyleClass newStyleClass, string actualValue)
        {
            if (GetNodeName(actualValue).Equals(Color))
            {
                StyleColor attribute = new StyleColor();
                string value = GetValueFromDoubleHeader(actualValue);
                if (value.Equals("0,0,128"))
                {
                    attribute.TextColor = TextColor.Blue;
                }
                else if (value.Equals("128,0,0"))
                {
                    attribute.TextColor = TextColor.Red;
                }
                else if (value.Equals("0,0,0"))
                {
                    attribute.TextColor = TextColor.Black;
                }
                else
                {
                    throw new StyleAttributeNotRecognized(Color + ":" + value);
                }
                newStyleClass.Attributes.Add(attribute);
            }
        }
        private static void ParseBold(StyleClass newStyleClass, string actualValue)
        {
            if (GetNodeName(actualValue).Equals(Bold))
            {
                Bold attribute = new Bold();
                attribute.Applies = ApplyValue.Apply;
                newStyleClass.Attributes.Add(attribute);
            }
        }
        private static void ParseUnderlined(StyleClass newStyleClass, string actualValue)
        {
            if (GetNodeName(actualValue).Equals(Underlined))
            {
                Underline attribute = new Underline();
                attribute.Applies = ApplyValue.Apply;
                newStyleClass.Attributes.Add(attribute);
            }
        }
        private static void ParseBorder(StyleClass newStyleClass, string actualValue)
        {
            if (GetNodeName(actualValue).Equals(Border))
            {
                Border attribute = new Border();
                attribute.Applies = ApplyValue.Apply;
                newStyleClass.Attributes.Add(attribute);
            }
        }
        private static void ParseItalics(StyleClass newStyleClass, string actualValue)
        {
            if (GetNodeName(actualValue).Equals(Italics))
            {
                Italics attribute = new Italics();
                attribute.Applies = ApplyValue.Apply;
                newStyleClass.Attributes.Add(attribute);
            }
        }
        private static void ParseAttributes(StyleClass newStyleClass, ImportedStyleClass importedStyleClass)
        {
            foreach (string item in importedStyleClass.StyleAttributes)
            {
                ParseFontType(newStyleClass, item);
                ParseFontSize(newStyleClass, item);
                ParseAlignment(newStyleClass, item);
                ParseColor(newStyleClass, item);
                ParseBold(newStyleClass, item);
                ParseUnderlined(newStyleClass, item);
                ParseBorder(newStyleClass, item);
                ParseItalics(newStyleClass, item);
            }
        }
        public static StyleClass Parse(ImportedStyleClass importedStyleClass)
        {
            StyleClass newStyleClass = new StyleClass();
            newStyleClass.Name = importedStyleClass.Name;
            ParseAttributes(newStyleClass, importedStyleClass);
            return newStyleClass;
        }
    }
}
