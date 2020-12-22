using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.DataAccess.Extensions
{
    public static class ServiceRegisterExtension
    {
        public static void RegisterRepository(this IServiceCollection services)
        {

        }

        /// <summary>
        /// RegisterContext
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterContext<IDb>(this IServiceCollection services, string connectionString)
            where IDb : DbContext
        {
            services.AddDbContext<IDb>(
                options => options.UseSqlServer( connectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }));
        }
    }
}
