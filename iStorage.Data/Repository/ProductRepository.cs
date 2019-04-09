using System;
using iStorage.DomainCore.Repository;
using iStorage.Domain.AggregatesModels.Products;
using iStorage.Data.DataContext;

namespace iStorage.Data.Repository
{
    public interface IProductRepository : IRepository<Product>
    {

    }

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(iStorageContext context) : base(context)
        {
        }
    }
}
