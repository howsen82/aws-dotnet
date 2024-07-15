namespace AwsStepFunctions
{
    public interface IStorageService
    {
        Task<string> UploadAsync(Stream stream);
    }
}
