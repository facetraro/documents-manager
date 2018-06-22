using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManager.Data.DA.Handler;

namespace DocumentsManager.BusinessLogic
{
    public class ParragraphBusinessLogic
    {
        public Parragraph GetById(Guid id)
        {
            ParragraphContext context = new ParragraphContext();
            StyleClassBusinessLogic styleLogic = new StyleClassBusinessLogic();
            Parragraph parragraph = context.GetById(id);
            TextBusinessLogic textLogic = new TextBusinessLogic();
            List<Text> allTexts = new List<Text>();
            foreach (var item in parragraph.Texts)
            {
                allTexts.Add(textLogic.GetById(item.Id));
            }
            parragraph.Texts = allTexts;
            parragraph.StyleClass = styleLogic.GetStyleById(parragraph.StyleClass.Id, Guid.NewGuid());
            return parragraph;
        }
    }
}
