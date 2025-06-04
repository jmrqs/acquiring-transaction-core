using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Accounts.Core.Extensions;
using Module.Accounts.Infrastructure.Extensions;

namespace Module.Accounts.Extensions
{
    public static class ModuleExtensionsCollector
    {
        public static IServiceCollection AddAccountsModule(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAccountsCore()
                .AddAccountsInfrastructure(configuration);
            return services;
        }
    }
}
