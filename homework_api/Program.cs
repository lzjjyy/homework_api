using mdland_dotnet_template_lib.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;

namespace homework_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                    {
#if  DEBUG
                        config.AddJsonFile("config/appsettings.Development.json");                     
                        config.AddJsonFile("config/libConfig.Development.json");                     
#else
                        config.AddJsonFile("config/appsettings.json");
                        config.AddJsonFile("config/libConfig.json");
#endif
                    });
                    webBuilder = WebBuilder.CreateHostBuilder(webBuilder);
                    webBuilder.UseStartup<Startup>();

                });
    }
}