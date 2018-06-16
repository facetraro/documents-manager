using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.ProxyInterfaces
{
    public interface IStyleClassBusinessLogic
    {
        IEnumerable<StyleClass> GetAllStyleClasses(Guid tokenId);
        StyleClass GetStyleById(Guid id, Guid tokenId);
        Guid AddStyle(StyleClass style, Guid tokenId);
        bool DeleteStyle(Guid id, Guid tokenId);
        bool UpdateStyle(Guid id, StyleClass newStyle, Guid tokenId);
    }
}
