namespace AwsStepFunctions
{
    public interface IEmailService
    {
        Task SendAsync(string emailAddress, string body);
    }
}
