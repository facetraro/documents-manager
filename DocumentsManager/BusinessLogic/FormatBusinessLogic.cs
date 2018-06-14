using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Exceptions;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;

namespace DocumentsManager.BusinessLogic
{
    public class FormatBusinessLogic : IFormatsBusinessLogic
    {
        public Format GetByID(Guid id)
        {
           // LoggedToken.GetToken();

            FormatContext context = new FormatContext();
            StyleClassBusinessLogic styleLogic = new StyleClassBusinessLogic();
            Format format = context.GetById(id);
            List<StyleClass> styles = new List<StyleClass>();
            foreach (var item in format.StyleClasses)
            {
                styles.Add(styleLogic.GetById(item.Id));
            }
            format.StyleClasses = styles;
            return format;
        }

        public bool Exists(Guid id)
        {
            LoggedToken.GetToken();

            FormatContext context = new FormatContext();
            return context.Exists(id);
        }

        public Guid Add(Format format)
        {
            LoggedToken.GetToken();
            FormatContext context = new FormatContext();
            if ((context.Exists(format.Id)))
            {
                throw new ObjectAlreadyExistsException("username");
            }
            context.Add(format);
            return format.Id;
        }

        public IEnumerable<Format> GetAllFormats()
        {
            LoggedToken.GetToken();

            FormatContext context = new FormatContext();
            List<Format> allFormatEager = context.GetEagerFormats();
            foreach (var item in allFormatEager)
            {
                List<StyleClass> allStylesFromFormat = new List<StyleClass> ();
                foreach (var style in item.StyleClasses)
                {
                    StyleClassBusinessLogic styleLogic = new StyleClassBusinessLogic();
                    allStylesFromFormat.Add(styleLogic.GetById(style.Id));
                    
                }
                item.StyleClasses = allStylesFromFormat;
            }
            return allFormatEager;
        }


        public bool Delete(Guid id)
        {
            LoggedToken.GetToken();

            FormatContext context = new FormatContext();
            if ((!context.Exists(id)))
            {
                return false;
                throw new ObjectDoesNotExists("username");
            }
            Format formatToDelete = GetByID(id);
            context.Remove(formatToDelete);
            return true;
        }

        public bool Update(Guid id, Format newFormat)
        {
            LoggedToken.GetToken();

            FormatContext context = new FormatContext();
            if ((!context.Exists(id)))
            {
                return false;
                throw new ObjectDoesNotExists("username");
            }
            newFormat.Id = id;
            context.Modify(GetByID(newFormat.Id));
            return true;
        }
    }
}