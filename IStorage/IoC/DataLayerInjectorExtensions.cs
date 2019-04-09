using System;
using Microsoft.Extensions.DependencyInjection;
using iStorage.Data.DataContext;
using iStorage.Data.Repository;
using iStorage.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IStorage.IoC
{
    public static class DataLayerInjectorExtensions
    {
        public static void RegisterRepositories(this IServiceCollection service)
        {
           
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
