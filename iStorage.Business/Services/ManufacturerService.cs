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
    public class ManufacturersService : IManufacturersService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ManufacturersService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }
        
        public string CreateManufacturer(Manufacturer manufacturer)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _unitOfWork.ManufacturerRepository.Insert(manufacturer);
                    _unitOfWork.Save();
                    scope.Complete();
                    return manufacturer.ManufactureId;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool DeleteManufacturer(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manufacturer> GetAllManufacturers()
        {
            throw new NotImplementedException();
        }

        public Manufacturer GetManufacturerById(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateManufacturer(string id, Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }
    }
}
