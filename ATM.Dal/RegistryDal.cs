using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ATM.Dal
{
    public static class RegistryDal
    {
        public static IServiceCollection RegisterDal(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILoadAllUsersDal, LoadAllUsersDal>();

            return services;
        }
    }
}
