using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Exceptions;
using DocumentsManager.ProxyInterfaces;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;

namespace DocumentsManager.BusinessLogic
{
    public class FormatBusinessLogic : IFormatsBusinessLogic
    {
        public Format GetFormatByID(Guid id, Guid tokenId)
        {
            FormatContext context = new FormatContext();
            StyleClassBusinessLogic styleLogic = new StyleClassBusinessLogic();
            Format format = context.GetById(id);
            List<StyleClass> styles = new List<StyleClass>();
            foreach (var item in format.StyleClasses)
            {
                styles.Add(styleLogic.GetStyleById(item.Id, tokenId));
            }
            format.StyleClasses = styles;
            return format;
        }

        public bool Exists(Guid id)
        {
            FormatContext context = new FormatContext();
            return context.Exists(id);
        }

        public Guid AddFormat(Format format, Guid tokenId)
        {
            FormatContext context = new FormatContext();
            if ((context.Exists(format.Id)))
            {
                throw new ObjectAlreadyExistsException("format name");
            }
            context.Add(format);
            return format.Id;
        }

        public IEnumerable<Format> GetAllFormats(Guid tokenId)
        {
            FormatContext context = new FormatContext();
            List<Format> allFormatEager = context.GetEagerFormats();
            foreach (var item in allFormatEager)
            {
                List<StyleClass> allStylesFromFormat = new List<StyleClass>();
                foreach (var style in item.StyleClasses)
                {
                    StyleClassBusinessLogic styleLogic = new StyleClassBusinessLogic();
                    allStylesFromFormat.Add(styleLogic.GetStyleById(style.Id, tokenId));

                }
                item.StyleClasses = allStylesFromFormat;
            }
            return allFormatEager;
        }


        public bool DeleteFormat(Guid id, Guid tokenId)
        {
            FormatContext context = new FormatContext();
            if ((!context.Exists(id)))
            {
                return false;
                throw new ObjectDoesNotExists("username");
            }
            Format formatToDelete = GetFormatByID(id, tokenId);
            context.Remove(formatToDelete);
            return true;
        }

        public bool UpdateFormat(Guid id, Format newFormat, Guid tokenId)
        {
            FormatContext context = new FormatContext();
            if ((!context.Exists(id)))
            {
                return false;
                throw new ObjectDoesNotExists("username");
            }
            newFormat.Id = id;
            context.Modify(GetFormatByID(newFormat.Id, tokenId));
            return true;
        }
    }
}