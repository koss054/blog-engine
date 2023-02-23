using BlogEngine.API.Common;
using BlogEngine.API.Services;
using BlogEngine.API.Services.Common.User;

namespace BlogEngine.API.Infrastructure
{
    public static class AppServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserServices>();

            return services;
        }
    }
}