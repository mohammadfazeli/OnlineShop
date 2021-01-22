using System;
using System.IO;
using OnlineShop.Common.PersianToolkit;
using OnlineShop.Common.WebToolkit;
using OnlineShop.DataLayer.Context;
using OnlineShop.ViewModels.Admin.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineShop.DataLayer.MSSQL
{
    public static class MsSqlServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguredMsSqlDbContext(this IServiceCollection services,SiteSettings siteSettings)
        {
            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());

            services.AddEntityFrameworkSqlServer(); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            services.AddEntityFrameworkProxies();
            services.AddDbContextPool<ApplicationDbContext,MsSqlDbContext>(
                (serviceProvider,optionsBuilder) => { optionsBuilder.UseConfiguredMsSql(siteSettings,serviceProvider); services.AddEntityFrameworkProxies().BuildServiceProvider(); });

            return services;
        }

        public static void UseConfiguredMsSql(
            this DbContextOptionsBuilder optionsBuilder,SiteSettings siteSettings,IServiceProvider serviceProvider)
        {
            var connectionString = siteSettings.GetMsSqlDbConnectionString();
            optionsBuilder.UseSqlServer(
                        connectionString,
                        sqlServerOptionsBuilder =>
                        {
                            sqlServerOptionsBuilder.CommandTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                            sqlServerOptionsBuilder.EnableRetryOnFailure();
                            sqlServerOptionsBuilder.MigrationsAssembly(typeof(MsSqlServiceCollectionExtensions).Assembly.FullName);
                        });
            optionsBuilder.UseLazyLoadingProxies(true).UseSqlServer(connectionString);
            optionsBuilder.UseInternalServiceProvider(serviceProvider); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            optionsBuilder.AddInterceptors(new PersianYeKeCommandInterceptor());
            optionsBuilder.ConfigureWarnings(warnings =>
            {
                // ...
            });
        }

        public static string GetMsSqlDbConnectionString(this SiteSettings siteSettingsValue)
        {
            if(siteSettingsValue == null)
            {
                throw new ArgumentNullException(nameof(siteSettingsValue));
            }

            switch(siteSettingsValue.ActiveDatabase)
            {
                case ActiveDatabase.LocalDb:
                    var attachDbFilename = siteSettingsValue.ConnectionStrings.LocalDb.AttachDbFilename;
                    var attachDbFilenamePath = Path.Combine(ServerInfo.GetAppDataFolderPath(),attachDbFilename);
                    var localDbInitialCatalog = siteSettingsValue.ConnectionStrings.LocalDb.InitialCatalog;
                    return $@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog={localDbInitialCatalog};AttachDbFilename={attachDbFilenamePath};Integrated Security=True;MultipleActiveResultSets=True;";

                case ActiveDatabase.SqlServer:
                    return siteSettingsValue.ConnectionStrings.SqlServer.ApplicationDbContextConnection;

                default:
                    throw new NotSupportedException("Please set the ActiveDatabase in appsettings.json file to `LocalDb` or `SqlServer`.");
            }
        }
    }
}