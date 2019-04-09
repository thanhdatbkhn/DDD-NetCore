using ProductApp.DataLayer.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStorage.Business.Services
{
    public interface IPackingUnitsService
    {
        PackingUnit GetPackingUnitById(int id);
        IEnumerable<PackingUnit> GetAllPackingUnits();
        int CreatePackingUnit(PackingUnit packingUnit);
        bool UpdatePackingUnit(int id, PackingUnit packingUnit);
        bool DeletePackingUnit(int id);
    }
}
