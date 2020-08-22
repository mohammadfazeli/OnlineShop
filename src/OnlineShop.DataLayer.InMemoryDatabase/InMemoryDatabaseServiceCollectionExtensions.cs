using System;
using OnlineShop.Common.PersianToolkit;
using OnlineShop.DataLayer.Context;
using OnlineShop.ViewModels.Identity.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineShop.DataLayer.InMemoryDatabase
{
    public static class InMemoryDatabaseServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguredInMemoryDbContext(this IServiceCollection services, SiteSettings siteSettings)
        {
            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());
            services.AddEntityFrameworkInMemoryDatabase(); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            services.AddEntityFrameworkProxies();
            services.AddDbContextPool<ApplicationDbContext, InMemoryDatabaseContext>(
                (serviceProvider, optionsBuilder) => optionsBuilder.UseConfiguredInMemoryDatabase(siteSettings, serviceProvider));
            return services;
        }

        public static void UseConfiguredInMemoryDatabase(
            this DbContextOptionsBuilder optionsBuilder, SiteSettings siteSettings, IServiceProvider serviceProvider)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(siteSettings.ConnectionStrings.LocalDb.InitialCatalog);
            optionsBuilder.UseInMemoryDatabase(siteSettings.ConnectionStrings.LocalDb.InitialCatalog);
            optionsBuilder.UseInternalServiceProvider(serviceProvider); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            optionsBuilder.AddInterceptors(new PersianYeKeCommandInterceptor());
            optionsBuilder.ConfigureWarnings(warnings =>
            {
                // ...
            });
        }
    }
}