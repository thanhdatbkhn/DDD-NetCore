using ProductApp.DataLayer.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStorage.Business.Services
{
    public interface IPackingUnitExchangesService
    {
        PackingUnitExchange GetPackingUnitExchangeById(int id);
        IEnumerable<PackingUnitExchange> GetAllPackingUnitExchanges();
        int CreatePackingUnitExchange(PackingUnitExchange unitExchange);
    }
}
