using Amazon;
using Amazon.Lambda.Core;
using Amazon.SQS.Model;
using Amazon.SQS;
using Amazon.Textract;
using Amazon.Textract.Model;
using System.Text.RegularExpressions;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace AwsStepFunctions
{
    public class LambdaFunctions
    {
        private readonly IStorageService _storageService = new AwsS3StorageService();
        private readonly IEmailService _emailService = new AwsSesEmailService();
        private string queueUrl = "";

        public async Task<StepFunctionsState> UploadNewResume(StepFunctionsState state, ILambdaContext context)
        {
            byte[] bytes = Convert.FromBase64String(state.FileBase64);
            
            using var memoryStream = new MemoryStream(bytes);
            state.StoredFileUrl = await _storageService.UploadAsync(memoryStream);
            state.FileBase64 = null;

            return state;
        }

        public async Task<StepFunctionsState> LookForGithubProfile(StepFunctionsState state, ILambdaContext context)
        {
            using var textractClient = new AmazonTextractClient(RegionEndpoint.USEast1);

            var s3ObjectKey = Regex.Match(state.StoredFileUrl, "amazonaws\\.com\\/(.+?(?=\\.pdf))").Groups[1].Value + ".pdf";
            var detectResponse = await textractClient.DetectDocumentTextAsync(
            new DetectDocumentTextRequest
            {
                Document = new Document
                {
                    S3Object = new S3Object
                    {
                        Bucket = AwsS3StorageService.BucketName,
                        Name = s3ObjectKey,
                    }
                }
            });

            state.GithubProfileUrl = detectResponse.Blocks.FirstOrDefault(x => x.BlockType == BlockType.WORD && x.Text.Contains("github.com"))?.Text;
            return state;
        }

        public async Task<StepFunctionsState> EmailRecruitment(StepFunctionsState state, ILambdaContext context)
        {
            await _emailService.SendAsync("recruitment@example.com",
            $"Somebody uploaded a resume! Read it here: {state.StoredFileUrl}\n\n" +
            $"...check out their GitHub profile: {state.GithubProfileUrl}");

            return state;
        }

        public async Task<string> BatchEmailRecruitment(object input, ILambdaContext c)
        {
            using var sqsClient = new AmazonSQSClient(RegionEndpoint.USEast1);
            var messageResponse = await sqsClient.ReceiveMessageAsync(
            new ReceiveMessageRequest()
            {
                QueueUrl = queueUrl,
                MaxNumberOfMessages = 10
            });
            var stateObjects = messageResponse.Messages.Select(msg => Deserialize(msg.Body));
            var listOfFiles = string.Join("\n\n", stateObjects.Select(x => x.StoredFileUrl));

            await _emailService.SendAsync("recruitment@example.com", $"You have {messageResponse.Messages.Count} new resumes to review!\n\n" + listOfFiles);
            await sqsClient.DeleteMessageBatchAsync(new DeleteMessageBatchRequest()
            {
                QueueUrl = queueUrl,
                Entries = messageResponse.Messages.Select(x =>
                new DeleteMessageBatchRequestEntry()
                {
                    Id = x.MessageId,
                    ReceiptHandle = x.ReceiptHandle
                }).ToList()
            });

            return "ok";
        }

        private MessageEx Deserialize(string body)
        {
            return null;
        }

        public partial class MessageEx : Message
        {
            public string StoredFileUrl { get; set; }
        }
    }
}
