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
    public class PackingUnitExchangeService : IPackingUnitExchangesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PackingUnitExchangeService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }
        public int CreatePackingUnitExchange(PackingUnitExchange unitExchange)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _unitOfWork.PackingUnitExchangeRepository.Insert(unitExchange);
                    _unitOfWork.Save();
                    if (unitExchange.PackingUnitExchangeId == unitExchange.ParentPackingUnitId)
                    {
                        return -1;
                    }
                    scope.Complete();
                    return unitExchange.PackingUnitExchangeId;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public IEnumerable<PackingUnitExchange> GetAllPackingUnitExchanges()
        {
            return _unitOfWork.PackingUnitExchangeRepository.GetWithInclude(ux => true, new string[] {"PackingUnit"});
        }

        public PackingUnitExchange GetPackingUnitExchangeById(int id)
        {
            return _unitOfWork.PackingUnitExchangeRepository.GetById(id);
        }
    }
}
