using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Accounts.Core.Abstractions;
using Module.Accounts.Infrastructure.Persistence;
using Module.Accounts.Shared;
using Shared.Infrastructure.Extensions;

namespace Module.Accounts.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAccountsInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDatabaseContext<AccountsDbContext>(config)
                .AddScoped<IAccountDbContext>(provider => provider?.GetService<AccountsDbContext>() ??
                    throw new InvalidOperationException($"Failed to get service: {typeof(IAccountDbContext).Name}."));

            GeneralServiceProvider.ServiceProviders.Add(services.BuildServiceProvider());

            return services;
        }
    }
}
