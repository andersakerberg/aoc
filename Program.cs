using AoC;
using AoC.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = BuildHost(args);
RunProgram(host.Services);
host.Run();
static void RunProgram(IServiceProvider hostProvider)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    IMain? main = provider.GetService<IMain>();
    if (main != null)
    {
        main.Execute();
    }
}

IHost BuildHost(string[] strings)
{
    ConfigureLogging();
    HostApplicationBuilder builder = Host.CreateApplicationBuilder(strings);
    builder.Services.Configure();
    return builder.Build();
}

void ConfigureLogging()
{
    var builder = new ConfigurationBuilder();
    builder
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
}
