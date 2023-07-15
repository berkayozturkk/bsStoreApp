using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracs;

namespace WebApplication1.Extentions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration cofiguration) => services.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer(cofiguration.GetConnectionString("sqlConnection")));
        
        public static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();
    
        public static void ConfigureServiceManager(this IServiceCollection services)
            => services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureLoggerService(this IServiceCollection services)
            => services.AddSingleton<ILoggerService,LoggerManager>();
    }
}
