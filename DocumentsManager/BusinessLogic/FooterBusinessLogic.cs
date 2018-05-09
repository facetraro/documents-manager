using DocumentsManager.Data.DA.Handler;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public class FooterBusinessLogic
    {
        public Footer GetById(Guid id)
        {
            FooterContext context = new FooterContext();
            StyleClassBusinessLogic styleLogic = new StyleClassBusinessLogic();
            Footer footer = context.GetById(id);
            TextBusinessLogic textLogic = new TextBusinessLogic();
            footer.Text = textLogic.GetById(footer.Text.Id);
            footer.StyleClass = styleLogic.GetById(footer.StyleClass.Id);
            return footer;
        }
    }
}
