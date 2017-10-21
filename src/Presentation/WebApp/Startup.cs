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
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Logging;

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
			// Add identity types
			services.AddIdentity<ApplicationUser, ApplicationRole>()
				.AddDefaultTokenProviders();

			// Identity Services
			services.AddTransient<IUserStore<ApplicationUser>, IdentityUserStore>();
			services.AddTransient<IRoleStore<ApplicationRole>, IdentityRoleStore>(); 


			//数据库相关  
			services.AddSingleton(typeof(IDbConnection), new SqlConnection(Configuration.GetConnectionString("DefaultConnection")));
			services.AddSingleton(typeof(IIdentityDbConnection),new SqlConnection(Configuration.GetConnectionString("IdentityConnection")));
			services.AddSingleton(typeof(ISqlGenerator<>), typeof(SqlGenerator<>));
			 
			//注册仓储
			services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
			services.AddSingleton(typeof(IDapperRepository<>), typeof(DapperRepository<>));
			services.AddSingleton<ICarBrandRepository, CarBrandRepository>();
			services.AddSingleton<ICarRepository, CarRepository>();

			//注册服务
			services.AddSingleton(typeof(IBaseService<>), typeof(BaseService<>));
			services.AddSingleton<ICarBrandService, CachedCarBrandService>();//实现缓存功能
			services.AddSingleton<ICarService, CachedCarService>();//实现缓存功能

			services.AddSingleton(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

			// Add memory cache services
			services.AddMemoryCache();
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
