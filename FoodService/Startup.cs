using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FoodService.Config;
using FoodService.Service;
using Food.EntityFramework;
using Food.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Food.EntityFramework.Configuration;
using FoodService.Domain.Services.Converters;
using Food.EntityFramework.Repository;
using FoodService.Domain.Services.Builders;
using FoodService.Domain.Services.Finders;

namespace FoodService
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            ApplicationConfig config = new ApplicationConfig(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped(provider => config.DbContextConfiguration);

            services.AddDbContext<FoodDbContext>((provider, builder) => { builder.UseSqlServer(provider.GetService<DbContextConfiguration>().ConnectionString); });
            services.AddEntityFrameworkSqlServer();

            services.AddScoped<IRepository<User>, GenericRepository<User>>();
            services.AddScoped<IUsersService, UserService>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IDailyOrderFinder, DailyOrderFinder>();

            services.AddScoped<IRepository<Menu>, GenericRepository<Menu>>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuService, MenuService>();

            services.AddScoped<IDailyOrderConverter, DailyOrderConverter>();
            services.AddScoped<IOrderBuilder, OrderBuilder>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler( "/Error" );
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc( routes =>
             {
                 routes.MapRoute(
                     name: "default",
                     template: "{controller}/{action=Index}/{id?}" );
             } );

            app.UseSpa( spa =>
             {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                 if ( env.IsDevelopment() )
                 {
                     spa.UseAngularCliServer( npmScript: "start" );
                 }
             } );
        }
    }
}
