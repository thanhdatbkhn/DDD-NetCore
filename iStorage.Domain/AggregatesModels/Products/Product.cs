using System;
using iStorage.DomainCore.Entities;
namespace iStorage.Domain.AggregatesModels.Products
{
    public class Product : Entity<string>
    {
        public string ProductName { get; set; }
        public int PackingId { get; set; }
        public int ProductTypeId { get; set; }
    }
}
