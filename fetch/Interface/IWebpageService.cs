public interface IWebpageService
{
    Task<Stream> GetWebpageAsync(string url);
}