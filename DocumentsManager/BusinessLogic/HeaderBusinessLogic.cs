using DocumentsManager.Data.DA.Handler;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public class HeaderBusinessLogic
    {
        public Header GetById(Guid id)
        {
            HeaderContext context = new HeaderContext();
            StyleClassBusinessLogic styleLogic = new StyleClassBusinessLogic();
            Header header = context.GetById(id);
            TextBusinessLogic textLogic = new TextBusinessLogic();
            header.Text = textLogic.GetById(header.Text.Id);
            header.StyleClass = styleLogic.GetStyleById(header.StyleClass.Id, Guid.NewGuid());
            return header;
        }
    }
}
