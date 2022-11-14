using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureLogging(logging =>
{
    logging.AddConsole();
});
builder.UseConsoleLifetime(consoleBuilder =>
{
    consoleBuilder.SuppressStatusMessages = true;
});
var host = builder.ConfigureServices(services =>
{
    services.AddLogging(logginBuilder => logginBuilder.AddConsole());
    services.AddLocalFileRepository();
    services.AddMetadataService();
    services.AddWebpageService();
    services.AddFetchService();
    services.AddHostedService<ConsoleService>();
}).Build();

await host.RunAsync();
                
