using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

Parser.Default.ParseArguments<CommandLineOption>(args)
              .WithParsed(o =>
              {
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
                  }).Build();

                  try
                  {
                      var fetchPageService = host.Services.GetRequiredService<FetchPageService>();
                      fetchPageService.FetchAndSaveAsync(o.Urls, o.Metadata).GetAwaiter().GetResult();
                  }
                  catch (Exception ex)
                  {
                      Console.WriteLine(ex.Message);
                      throw;
                  }

              });
