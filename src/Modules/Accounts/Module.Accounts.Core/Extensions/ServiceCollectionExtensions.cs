using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Module.Accounts.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAccountsCore(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
