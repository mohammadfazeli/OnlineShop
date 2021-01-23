using AspNetCore.Unobtrusive.Ajax;
using AutoMapper;
using DNTCaptcha.Core;
using DNTCommon.Web.Core;
using KhabarTech.UI.Classes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NToastNotify;
using OnlineShop.Common.WebToolkit;
using OnlineShop.IocConfig;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Admin.Settings;
using OnlineShop.Web.Classes;
using OnlineShop.Web.Hubs;
using System.Threading;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace OnlineShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SiteSettings>(options => Configuration.Bind(options));

            // Adds all of the ASP.NET Core Identity related services and configurations at once.
            services.AddEntityFrameworkProxies();
            services.AddCustomIdentityServices();
            services.AddAutoMapper(config => { config.AddCustomMappingProfile(); });

            services.AddMvc(options =>
            {
                options.UseYeKeModelBinder(); options.Filters.Add(typeof(TitleAndIconFilter));
            }).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
                    options => { options.ResourcesPath = "Resources"; })

                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type,factory) =>
                        factory.Create(typeof(Resource.Resource));
                })
            .AddNToastNotifyToastr(new ToastrOptions()
            {
                Rtl = true,
                CloseButton = true,
                ShowDuration = 5,
            });
            services.AddUnobtrusiveAjax();
            //services.AddUnobtrusiveAjax(useCdn: true, injectScriptIfNeeded: false);
            services.AddDNTCommonWeb();
            services.AddDNTCaptcha();
            services.AddCloudscribePagination();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if(!env.IsDevelopment())
            {
                app.UseExceptionHandler("/error/index/500");
                app.UseStatusCodePagesWithReExecute("/error/index/{0}");
            }
            if(!env.IsDevelopment())
            {
                app.UseHsts();
            }
            //app.UseHttpsRedirection();

            Thread.CurrentThread.CurrentUICulture = PersianDateExtensionMethods.GetPersianCulture();
            Thread.CurrentThread.CurrentCulture = PersianDateExtensionMethods.GetPersianCulture();

            // var supportedCultures = new List<CultureInfo>()
            // {
            //     new CustomPersianCulture(),
            //     new CultureInfo("en-US")
            // };
            // var options = new RequestLocalizationOptions()
            // {
            //     DefaultRequestCulture = new RequestCulture("fa-IR"),
            //     SupportedCultures = supportedCultures,
            //     SupportedUICultures = supportedCultures,
            //     RequestCultureProviders = new List<IRequestCultureProvider>()
            //     {
            //         new QueryStringRequestCultureProvider(),
            //         new CookieRequestCultureProvider()
            //     }
            // };
            app.UseNToastNotify();
            // app.UseRequestLocalization(options);

            app.UseContentSecurityPolicy();

            app.UseStaticFiles();

            //It is required for serving 'jquery-unobtrusive-ajax.min.js' embedded script file.
            app.UseUnobtrusiveAjax(); //It is suggested to place it after UseStaticFiles()

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Account}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "normal",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
                endpoints.MapHub<Notification>("/Notification");
            });
        }
    }
}