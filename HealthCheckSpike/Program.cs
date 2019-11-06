using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HealthCheckSpike
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Example uses the ASP.NET Core generic host, which is available from .NET Core 2.1 onwards
            // This allows us to easily host an API and messaging in the same process and get stuff like SIGINT/SIGTERM support

            // The generic host is the recommended way to host APIs & messaging endpoints moving forward
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // This is what sets up our health checcks
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices((HostBuilderContext, services) => {
                    // This is what sets up the messaging endpoint
                    services.AddHostedService<MessagePump>();
                });
    }
}
