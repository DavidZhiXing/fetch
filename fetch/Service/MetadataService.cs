using HtmlAgilityPack;

public class MetadataService : IMetadataService
{
    public Task<Metadata> GetMetadataAsync(string url, Stream data)
    {
        var document = new HtmlDocument();
        data.Seek(0, SeekOrigin.Begin);
        document.Load(data);

        var links = document.DocumentNode.SelectNodes("//a[@href]");
        var images = document.DocumentNode.SelectNodes("//img[@src]");
        var linksCount = links?.Count ?? 0;
        var imagesCount = images?.Count ?? 0;

        var metadata = new Metadata
        {
            Site = url,
            NumLinks = linksCount,
            Images = imagesCount,
            LastFetch = DateTime.Now
        };

        return Task.FromResult(metadata);
    }
}