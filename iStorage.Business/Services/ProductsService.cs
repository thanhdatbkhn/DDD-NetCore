
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.DataLayer.Models.Data;
using System.Transactions;
using iStorage.Data.UnitOfWork;
using iStorage.Business.Models;
using iStorage.Data.Repository;
using AutoMapper;
using iStorage.Domain.AggregatesModels.Products;
using iStorage.Business.DataTransferObjects;

namespace iStorage.Business.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsService(IMapper mapper, IUnitOfWork uow, IProductRepository productRepository)
        {
            _unitOfWork = uow;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public string CreateProduct(CreateProductModel product)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var newProduct = _mapper.Map<Product>(product);
                    _productRepository.Insert(newProduct);
                    _unitOfWork.Save();
                    scope.Complete();
                    return newProduct.Id;
                }
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public bool DeleteProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return null;
        }

        public ProductDTO GetProductById(string productId)
        {
            return null;
        }

        public bool UpdateProduct(string productId, UpdateProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
