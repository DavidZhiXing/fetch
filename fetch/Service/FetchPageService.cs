using Microsoft.Extensions.Logging;

public class FetchPageService
{
    private readonly IMetadataService _metadataService;
    private readonly ILocalFileRepository _localFileRepository;
    private readonly IWebpageService _webpageService;
    private readonly ILogger<FetchPageService> _logger;
    private readonly string HtmlExtention = ".html";

    public FetchPageService(IMetadataService metadataService, ILocalFileRepository localFileRepository, IWebpageService webpageService, ILogger<FetchPageService> logger)
    {
        _metadataService = metadataService;
        _localFileRepository = localFileRepository;
        _webpageService = webpageService;
        _logger = logger;
    }

    public async Task FetchAndSaveAsync(IEnumerable<string> urls, bool printMetadata = false)
    {
        foreach (var url in urls)
        {
            try
            {
                var uri = new Uri(url);
                using (var data = await _webpageService.GetWebpageAsync(url))
                {
                    var metadata = await _metadataService.GetMetadataAsync(url, data).ConfigureAwait(false);
                    if (printMetadata)
                    {
                        Console.WriteLine(metadata.ToString());
                    }

                    var directory = Environment.CurrentDirectory;
                    var fileName = uri.Host + HtmlExtention;

                    var path = Path.Combine(directory, fileName);
                    await _localFileRepository.SaveWebpageAsync(path, data).ConfigureAwait(false);

                    Console.WriteLine($"Webpage saved to {path}");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching {url}: {ex.Message}");
            }
        }
    }
}