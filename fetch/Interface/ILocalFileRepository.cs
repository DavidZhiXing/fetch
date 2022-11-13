public interface ILocalFileRepository
{
    Task SaveWebpageAsync(string path, Stream data);
}