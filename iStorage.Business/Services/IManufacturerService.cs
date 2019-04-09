using ProductApp.DataLayer.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Business.ServiceInterfaces
{
    public interface IManufacturersService
    {
        Manufacturer GetManufacturerById(string id);
        IEnumerable<Manufacturer> GetAllManufacturers();
        string CreateManufacturer(Manufacturer manufacturer);
        bool UpdateManufacturer(string id, Manufacturer manufacturer);
        bool DeleteManufacturer(string id);
    }
}
