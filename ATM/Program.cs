using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ATM.Bll;
using Microsoft.Extensions.Configuration;
using ATM.View;

namespace ATM
{
    public class Program
    {
        private static readonly IConfiguration configuration;
        static void Main(string[] args)
        {
            // create hosting object and DI layer
            using IHost host = CreateHostBuilder(args).Build();
            // create a service scope
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            try
            {
                services.GetRequiredService<App>().Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] strings)
        {
            return Host.CreateDefaultBuilder()
                
                .ConfigureServices((_, services) =>
                {                   
                    services.AddSingleton<App>();
                    services.AddScoped<IGetWithdrawalApp, GetWithdrawalApp>();
                    services.AddScoped<IAccountUserInfoApp, AccountUserInfoApp>();
                    services.AddScoped<IGetDepositApp, GetDepositApp>();
                    services.AddScoped<ICurrencyDisplayApp, CurrencyDisplayApp>();
                    services.AddScoped<IGetInformationApp, GetInformationApp>();
                    services.AddScoped<ILoginUserInfoApp, LoginUserInfoApp>();
                    services.AddScoped<IShowRetryApp, ShowRetryApp>();
                    services.AddScoped<IShowUserInterfaceApp, ShowUserInterfaceApp>();
                    services.AddScoped<IUserInputHandlerApp, UserInputHandlerApp>();

                    services.RegisterBll(configuration);
                });
        }
    }
}
