﻿using DocumentsManager.Data.Repository;
using DocumentsManagerDataAccess;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Data.DA.Handler
{
    public class StyleClassContextHandler
    {
        public void Add(StyleClass newStyleClass)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                if (newStyleClass.Based != null)
                {
                    db.Styles.Attach(newStyleClass.Based);
                }
                unitOfWork.StyleClassRepository.Insert(newStyleClass);
            }
        }
        public List<StyleClass> GetLazy()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.StyleClassRepository.Get().ToList();
            }
        }
        public void ClearAll()
        {
            int totalStyles = GetLazy().Count;
            while (totalStyles != 0)
            {
                foreach (var item in GetLazy())
                {
                    if (!AreStyleBasedOnHim(item))
                        Remove(item);
                }
                totalStyles = GetLazy().Count;
            }
        }
        public bool AreStyleBasedOnHim(StyleClass style)
        {
            foreach (var item in GetLazy())
            {
                if (IsStyleBasedInStyle(item, style))
                {
                    return true;
                }
            }
            return false;
        }
        public void Remove(StyleClass style)
        {
            RemoveAttributes(style);
            style.Attributes = null;
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.StyleClassRepository.Delete(style);
            }
        }
        private bool IsStyleBasedInStyle(StyleClass child, StyleClass father)
        {
            return child.IsBasedOnOtherStyle() && child.Based.Equals(father);
        }
        private void RemoveAttributes(StyleClass style)
        {
            StyleClass styleClass = GetById(style.Id);
            int lenghtAttributes = styleClass.Attributes.Count;
            for (int i = 0; i < lenghtAttributes; i++)
            {
                RemoveAttribute(styleClass.Attributes[0]);
            }
        }
        private void AddAttributes(StyleClass styleClass)
        {
            int lenghtAttributes = styleClass.Attributes.Count;
            for (int i = 0; i < lenghtAttributes; i++)
            {
                AddAttribute(styleClass.Attributes[i]);
            }
        }
        private void AddAttribute(StyleAttribute attribute)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                db.Styles.Attach(attribute.Style);
                unitOfWork.StyleAttributeRepository.Insert(attribute);
            }
        }
        private void RemoveAttribute(StyleAttribute attribute)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.StyleAttributeRepository.Delete(attribute);
            }
        }
        public StyleClass GetById(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                StyleClass style = unitOfWork.StyleClassRepository.GetByID(id);
                db.Styles.Include("Attributes").ToList();
                db.Styles.Include("Formats").ToList();
                return style;
            }
        }
        public List<StyleAttribute> GetAttributes(StyleClass newStyle)
        {
            return GetById(newStyle.Id).Attributes;
        }
        public List<StyleAttribute> GetAllAttributes()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.StyleAttributeRepository.Get().ToList();
            }
        }
        private void UpdateAttributes(StyleClass modifiedStyle)
        {
            RemoveAttributes(modifiedStyle);
            AddAttributes(modifiedStyle);
        }
        private StyleClass GetBasedStyleClass(ContextDataAccess db, StyleClass style)
        {
            db.Styles.Include("Attributes").ToList();
            StyleClass basedOnStyle = null;
            if (style.Based != null)
            {
                basedOnStyle = db.Styles.Find(style.Based.Id);
                db.Styles.Include("Attributes").ToList();
            }
            return basedOnStyle;
        }
        private void UpdateData(StyleClass modifiedStyle)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                StyleClass styleClassEntity = db.Styles.Find(modifiedStyle.Id);
                styleClassEntity.Based = GetBasedStyleClass(db, modifiedStyle);
                styleClassEntity.Name = modifiedStyle.Name;
                unitOfWork.StyleClassRepository.Update(styleClassEntity);
                unitOfWork.Save();
            }
        }
        public void Modify(StyleClass modifiedStyle)
        {
            UpdateAttributes(modifiedStyle);
            UpdateData(modifiedStyle);
        }
        public bool Exists(Guid styleId)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.StyleClassRepository.Exists(styleId);
            }
        }
    }
}
