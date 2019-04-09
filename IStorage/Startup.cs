using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IStorage.IoC;
using AutoMapper;
using IStorage.Filters;
using iStorage.DomainCore.Configurations;
using iStorage.Business.MappingConfigurations;
using iStorage.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace IStorage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppConfigs>(Configuration);
            AutoMapping.RegisterMappings();
            services.AddAutoMapper();
            services.AddDbContext<iStorageContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString"]);
            });
            services.RegisterBusinessServices();
            services.RegisterDomainService();
            services.RegisterRepositories();
            services.AddMvc(options => options.Filters.Add(typeof(AuthorizeFilter))).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.UseMvc();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=users}/{action=Index}/{id?}");
            });
        }
    }
}
