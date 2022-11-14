using CommandLine;
using Microsoft.Extensions.Hosting;

public class ConsoleService : BackgroundService
{
    private IHostApplicationLifetime _hostApplicationLifetime;
    private FetchPageService _fetchPageService;

    public ConsoleService(IHostApplicationLifetime hostApplicationLifetime, FetchPageService fetchPageService)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _fetchPageService = fetchPageService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await ParseCommandLineArgumentsAndRun();
        _hostApplicationLifetime.StopApplication();
    }

    private async Task ParseCommandLineArgumentsAndRun()
    {
        await Parser.Default.ParseArguments<CommandLineOption>(Environment.GetCommandLineArgs())
                            .WithParsedAsync(RunAsync);
    }

    private async Task RunAsync(CommandLineOption options)
    {
        try
        {
            await _fetchPageService.FetchAndSaveAsync(options.Urls, options.Metadata);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}
