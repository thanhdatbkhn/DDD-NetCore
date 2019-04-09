using System;
using Microsoft.Extensions.DependencyInjection;
using iStorage.Business.Services;
using AutoMapper;

namespace IStorage.IoC
{
    public static class BusinessLayerInjectorExtensions
    {
        public static void RegisterBusinessServices(this IServiceCollection services)
        {
            //services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ITokensService, TokensService>();
        }
    }
}
