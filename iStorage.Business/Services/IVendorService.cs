using ProductApp.DataLayer.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStorage.Business.Services
{
    public interface IVendorsService
    {
        Vendor GetVendorById(string id);
        IEnumerable<Vendor> GetAllVendors();
        string CreateVendor(Vendor vendor);
        bool UpdateVendor(string id, Vendor vendor);
        bool DeleteVendor(string id);
    }
}
