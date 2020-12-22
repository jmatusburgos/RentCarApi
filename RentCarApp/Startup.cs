using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RentCarApp.BusinessLogic.Contracts;
using RentCarApp.BusinessLogic.Contracts.Base;
using RentCarApp.BusinessLogic.Services;
using RentCarApp.Common.ErrorHandling;
using RentCarApp.DataAccess.Context;
using RentCarApp.DataAccess.Contracts;
using RentCarApp.DataAccess.Extensions;
using RentCarApp.DataAccess.Repositories;
using RentCarApp.DataAccess.Repositories.Base;
using RentCarApp.DataAccess.Uow;
using RentCarApp.Domain.Models.Auth;
using RentCarApp.Domain.Models.Order;
using RentCarApp.Domain.Models.Product;
using System;


namespace RentCarApp
{
    public class Startup
    {
        private string mainConnectionString;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            mainConnectionString = Configuration.GetConnectionString("RentCarDb");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            AddMainContext(services);
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rent Car Api", Version = "v1", });
            });


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });

            });

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<MainDbContext>();

            //Common Services
            services.AddScoped<IValidationError, ValidationError>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGenericRepository<Brand>, GenericRepository<Brand>>();
            services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
            services.AddScoped<IGenericRepository<Model>, GenericRepository<Model>>();
            services.AddScoped<IGenericRepository<Car>, GenericRepository<Car>>();
            services.AddScoped<IGenericRepository<Order>, GenericRepository<Order>>();


            //Services
            services.AddScoped<IUnitOfWork, UnitOfWork<MainDbContext>>();
            services.AddScoped<IGenericService<Brand, Guid>, GenericService<Brand, Guid>>();
            services.AddScoped<IGenericService<Category, Guid>, GenericService<Category, Guid>>();
            services.AddScoped<IGenericService<Model, Guid>, GenericService<Model, Guid>>();
            services.AddScoped<IGenericService<Car, Guid>, GenericService<Car, Guid>>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();

        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rent Car API");
                c.RoutePrefix = string.Empty;
            });

            InitializeDatabase(app);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseDeveloperExceptionPage();
            

            
            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private void AddMainContext(IServiceCollection services)
        => services.RegisterContext<MainDbContext>(mainConnectionString);

        /// <summary>
        /// Initialize Database
        /// </summary>
        /// <param name="app"></param>
        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<MainDbContext>().Database.Migrate();
            }
        }
    }
}
