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
    public class VendorsService : IVendorsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VendorsService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public string CreateVendor(Vendor vendor)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _unitOfWork.VendorRepository.Insert(vendor);
                    _unitOfWork.Save();
                    scope.Complete();
                    return vendor.VendorId;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool DeleteVendor(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vendor> GetAllVendors()
        {
            return _unitOfWork.VendorRepository.Get();
        }

        public Vendor GetVendorById(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateVendor(string id, Vendor vendor)
        {
            throw new NotImplementedException();
        }
    }
}
