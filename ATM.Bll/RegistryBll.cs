using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ATM.Dal;

namespace ATM.Bll
{
    public static class RegistryBll
    {
        public static IServiceCollection RegisterBll(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDepositBll, DepositBll>();
            services.AddScoped<IWithdrawalBll, WithdrawalBll>();
            services.AddScoped<ICurrencyConvertBll, CurrencyConvertBll>();
            services.AddScoped<IGetCurrencyFromCodeBll, GetCurrencyFromCodeBll>();
            services.AddScoped<ILoadAllUsersBll, LoadAllUsersBll>();

            services.RegisterDal(configuration);
            return services;
        }
    }
}
