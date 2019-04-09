using ProductApp.Business.ServiceInterfaces;
using ProductApp.DataLayer.Models.Data;
using ProductApp.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace iStorage.Business.Services
{
    public class PackingUnitsService : IPackingUnitsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PackingUnitsService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public int CreatePackingUnit(PackingUnit packingUnit)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    // Insert to PackingUnit table
                    _unitOfWork.PackingUnitRepository.Insert(packingUnit);
                    _unitOfWork.Save();

                    // Insert to PackingUnitExchange table
                    var unitExchange = new PackingUnitExchange
                    {
                        PackingUnitId = packingUnit.PackingUnitId,
                        ParentPackingUnitId = null
                    };
                    _unitOfWork.PackingUnitExchangeRepository.Insert(unitExchange);
                    _unitOfWork.Save();

                    scope.Complete();
                    return packingUnit.PackingUnitId;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return -1;
            }
        }

        public bool DeletePackingUnit(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PackingUnit> GetAllPackingUnits()
        {
            return _unitOfWork.PackingUnitRepository.Get();
        }

        public PackingUnit GetPackingUnitById(int id)
        {
            return _unitOfWork.PackingUnitRepository.GetById(id);
        }

        public bool UpdatePackingUnit(int id, PackingUnit packingUnit)
        {
            throw new NotImplementedException();
        }
    }
}
