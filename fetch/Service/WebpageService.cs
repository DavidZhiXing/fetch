using Microsoft.Extensions.Logging;

public class WebpageService : IWebpageService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<WebpageService> _logger;

    public WebpageService(HttpClient httpClient, ILogger<WebpageService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Stream> GetWebpageAsync(string url)
    {
        try
        {
            var response =await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStreamAsync();
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error occurred while fetching webpage.");
            throw;
        }
    }
}