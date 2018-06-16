using DocumentsManager.BusinessLogic.Charts;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.ProxyInterfaces
{
    public interface IChartsBusinessLogic
    {
        ChartIntDate GetChartModificationsByUser(User user, DateTime since, DateTime until, Guid tokenId);


        ChartIntDate GetChartCreationByUser(User user, DateTime since, DateTime until, Guid tokenId);

    }
}
