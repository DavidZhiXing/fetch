public interface IMetadataService
{
    Task<Metadata> GetMetadataAsync(string url, Stream data);
}