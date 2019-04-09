using iStorage.Business.DataTransferObjects;
using iStorage.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStorage.Business.Services
{
    public interface IProductsService
    {
        ProductDTO GetProductById(string productId);
        IEnumerable<ProductDTO> GetAllProducts();
        string CreateProduct(CreateProductModel product);
        bool UpdateProduct(string productId, UpdateProductModel product);
        bool DeleteProduct(string productId);
    }
}
