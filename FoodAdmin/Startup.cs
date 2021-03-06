using Food.EntityFramework;
using Food.EntityFramework.Configuration;
using Food.EntityFramework.Entities;
using Food.EntityFramework.Repository;
using FoodAdmin.Config;
using FoodAdmin.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodAdmin
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
            ApplicationConfig config = new ApplicationConfig(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped(provider => config.DbContextConfiguration);

            services.AddDbContext<FoodDbContext>((provider, builder) => { builder.UseSqlServer(provider.GetService<DbContextConfiguration>().ConnectionString); });
            services.AddEntityFrameworkSqlServer();

            services.AddScoped<IRepository<Sample>, GenericRepository<Sample>>();
            services.AddScoped<ISampleService, SampleService>();

            services.AddScoped<IRepository<Dish>, GenericRepository<Dish>>();

            services.AddScoped<IRepository<User>, GenericRepository<User>>();
            services.AddScoped<IUsersService, UserService>();

            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuService, MenuService>();

            services.AddScoped<IRepository<MenuDish>, GenericRepository<MenuDish>>();

            services.AddScoped<IRepository<Command>, GenericRepository<Command>>();
            services.AddScoped<ICommandsService, CommandsService>();

            services.AddScoped<IRepository<Dish>, GenericRepository<Dish>>();
            services.AddScoped<IDishService, DishService>();

            services.AddScoped<IRepository<Container>, GenericRepository<Container>>();
            services.AddScoped<IContainerService, ContainerService>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(builder => builder.WithOrigins("http://localhost:4200/")
                   .AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod());
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                // TODO add Cors support if need it
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
