public interface IStorageService
{
    Task<string> Upload(Stream stream);
}
