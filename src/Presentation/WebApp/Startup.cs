using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using System.Data;
using System.Data.SqlClient;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using ApplicationCore.Entities;
using ApplicationCore.Services;
using MicroOrm.Dapper.Repositories;

namespace WebApp
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
            //数据库相关
            services.AddSingleton<IDbConnection > (new SqlConnection(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<ISqlGenerator<Car>>(new SqlGenerator<Car>(ESqlConnector.MSSQL));
            services.AddSingleton<ISqlGenerator<CarBrand>>(new SqlGenerator<CarBrand>(ESqlConnector.MSSQL));


            //注册仓储
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarBrandRepository, CarBrandRepository>();
            services.AddSingleton<IDapperRepository<Car>, DapperRepository<Car>>();

            //注册服务
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICarBrandService,CarBrandService>();

            services.AddMvc();
             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
