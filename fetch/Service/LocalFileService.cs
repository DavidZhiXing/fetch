public class LocalFileService : ILocalFileRepository
{
    public async Task SaveWebpageAsync(string path, Stream data)
    {
        using var fileStream = new FileStream(path, FileMode.OpenOrCreate);
        data.Seek(0, SeekOrigin.Begin);
        await data.CopyToAsync(fileStream);
    }
}