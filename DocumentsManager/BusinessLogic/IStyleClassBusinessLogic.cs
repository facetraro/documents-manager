using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public interface IStyleClassBusinessLogic
    {
        IEnumerable<StyleClass> GetAllStyleClasses();
        StyleClass GetByID(Guid id);
        Guid Add(StyleClass style);
        bool Delete(Guid id);
        bool Update(Guid id, StyleClass newStyle);
    }
}