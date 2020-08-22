using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Identity;
using OnlineShop.Services.Contracts;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.Services.Contracts.Identity;
using OnlineShop.Services.Identity;
using OnlineShop.Services.Identity.Logger;
using OnlineShop.Services.Services;
using System.Security.Claims;
using System.Security.Principal;

namespace OnlineShop.IocConfig
{
    public static class AddCustomServicesExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPrincipal>(provider =>
                provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.User ?? ClaimsPrincipal.Current);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            #region Service

            services.AddScoped<IPartService, PartService>();
            services.AddScoped<IProductGroupService, ProductGroupService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IAttachmentService, AttachmentService>();

            #endregion Service

            #region Identity

            services.AddScoped<ILookupNormalizer, CustomNormalizer>();

            services.AddScoped<ISecurityStampValidator, CustomSecurityStampValidator>();
            services.AddScoped<SecurityStampValidator<User>, CustomSecurityStampValidator>();

            services.AddScoped<IPasswordValidator<User>, CustomPasswordValidator>();
            services.AddScoped<PasswordValidator<User>, CustomPasswordValidator>();

            services.AddScoped<IUserValidator<User>, CustomUserValidator>();
            services.AddScoped<UserValidator<User>, CustomUserValidator>();

            services.AddScoped<IUserClaimsPrincipalFactory<User>, ApplicationClaimsPrincipalFactory>();
            services.AddScoped<UserClaimsPrincipalFactory<User, Role>, ApplicationClaimsPrincipalFactory>();

            services.AddScoped<IdentityErrorDescriber, CustomIdentityErrorDescriber>();

            services.AddScoped<IApplicationUserStore, ApplicationUserStore>();
            services.AddScoped<UserStore<User, Role, ApplicationDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>, ApplicationUserStore>();

            services.AddScoped<IApplicationUserManager, ApplicationUserManager>();
            services.AddScoped<UserManager<User>, ApplicationUserManager>();

            services.AddScoped<IApplicationRoleManager, ApplicationRoleManager>();
            services.AddScoped<RoleManager<Role>, ApplicationRoleManager>();

            services.AddScoped<IApplicationSignInManager, ApplicationSignInManager>();
            services.AddScoped<SignInManager<User>, ApplicationSignInManager>();

            services.AddScoped<IApplicationRoleStore, ApplicationRoleStore>();
            services.AddScoped<RoleStore<Role, ApplicationDbContext, int, UserRole, RoleClaim>, ApplicationRoleStore>();

            services.AddScoped<IEmailSender, AuthMessageSender>();
            services.AddScoped<ISmsSender, AuthMessageSender>();

            services.AddScoped<IIdentityDbInitializer, IdentityDbInitializer>();
            services.AddScoped<IUsedPasswordsService, UsedPasswordsService>();
            services.AddScoped<ISiteStatService, SiteStatService>();
            services.AddScoped<IUsersPhotoService, UsersPhotoService>();
            services.AddScoped<ISecurityTrimmingService, SecurityTrimmingService>();
            services.AddScoped<IAppLogItemsService, AppLogItemsService>();

            #endregion Identity

            return services;
        }
    }
}