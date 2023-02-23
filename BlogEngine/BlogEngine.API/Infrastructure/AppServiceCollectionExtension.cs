
namespace BlogEngine.API.Infrastructure
{
    using Microsoft.EntityFrameworkCore;

    using Common;
    using Data;
    using Services;
    using Services.Common.User;

    public static class AppServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            // Initial
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Db context
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            // Additional
            services.AddCors();
            services.AddRouting(options => options.LowercaseUrls = true);

            // Custom services
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserServices>();

            return services;
        }
    }
}