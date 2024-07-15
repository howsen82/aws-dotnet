using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace AwsStepFunctions
{
    public class AwsS3StorageService : IStorageService
    {
        public const string BucketName = "csharp-examples-bucket";

        public async Task<string> UploadAsync(Stream stream)
        {
            var fileName = Guid.NewGuid().ToString() + ".pdf";

            using var s3Client = new AmazonS3Client(RegionEndpoint.USEast1);

            await s3Client.PutObjectAsync(new PutObjectRequest()
            {
                InputStream = stream,
                BucketName = BucketName,
                Key = fileName,
            });
            var url = s3Client.GetPreSignedURL(new GetPreSignedUrlRequest()
            {
                BucketName = BucketName,
                Key = fileName,
                Expires = DateTime.UtcNow.AddMinutes(10)
            });

            return url;
        }
    }
}
