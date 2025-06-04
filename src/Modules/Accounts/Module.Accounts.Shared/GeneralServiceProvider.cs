using Microsoft.Extensions.DependencyInjection;

namespace Module.Accounts.Shared
{
    public static class GeneralServiceProvider
    {
        public static IServiceProvider? ServiceProvider { get; set; }
        public static List<IServiceProvider> ServiceProviders { get; } = [];
    }
}
