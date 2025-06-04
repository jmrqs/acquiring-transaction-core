using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Interfaces;
using Shared.Infrastructure.Interceptors;
using Shared.Infrastructure.Services;
using Shared.Models.DockerEnviroments;
using Shared.Models.Models;
using System.Reflection;

namespace Shared.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddDistributedMemoryCache();

            services.AddScoped<BackgroundDomainEventSaveChangesInterceptor>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }

        public static IServiceCollection AddDatabaseContext<T>(this IServiceCollection services, IConfiguration configuration)
            where T : DbContext
        {
            var envirmonmentVariables = new List<KeyValuePair<string, string>>()
            {
                new("{dbHost}" ,DockerEnvironments.SqlServerDB_HOST),
                new("{dbName}" , DockerEnvironments.SqlServerDB_NAME),
                new("{dbPassword}" , DockerEnvironments.SqlServerDB_SA_PASSWORD)
            };
            string defaultConnectionString = configuration.GetConnectionString("DefaultConnection")!;
            string dockerConnectionString = configuration.GetConnectionString("DockerComposeConnection")!;

            _ = bool.TryParse(configuration.GetSection("IsContainerized")?.Value, out bool isContainerized);

            var databseConfig = new DatabaseConfig(isContainerized,
                defaultConnectionString, dockerConnectionString, envirmonmentVariables);
            services.AddMsSql<T>(databseConfig.ConnectionString);
            return services;
        }
        public static IServiceCollection AddMsSql<T>(this IServiceCollection services, string connectionString)
            where T : DbContext
        {
            services.AddDbContext<T>(options =>
            options.UseSqlServer(connectionString, e => e.MigrationsAssembly(typeof(T).Assembly.FullName)));

            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<T>();
            dbContext.Database.Migrate();
            return services;
        }
    }
}