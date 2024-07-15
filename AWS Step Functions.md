## Developing with AWS Step Functions

```sh
dotnet tool update -g Amazon.Lambda.Tools
dotnet new install Amazon.Lambda.Templates
```

```sh
dotnet new serverless.EmptyServerless --region us-east-1 --name AwsStepFunctions
dotnet add package Amazon.Lambda.AspNetCoreServer.Hosting
dotnet add package AWSSDK.S3
dotnet add package AWSSDK.SimpleEmail
dotnet add package AWSSDK.Textract
dotnet add package AWSSDK.SQS
```

```C#
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Add AWS Lambda support.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

app.MapRazorPages();

var app = builder.Build();
```

```c#
[HttpPost]
public async Task<IActionResult> SaveUploadedResume()
{
    Request.EnableBuffering();
    using var fileStream = new MemoryStream();
    using var reader = new StreamReader(fileStream);
    await Request.Body.CopyToAsync(fileStream);
    
    var storedFileUrl = await _storageService.Upload(fileStream);
    await _emailService.Send("recruitment@example.com", $"Somebody has uploaded a resume! Read it here: {storedFileUrl}");

    return Ok();
}
```

```sh
dotnet lambda deploy-function UploadNewResume
dotnet lambda deploy-function UploadNewResume --function-handler  ServerlessResumeUploader::AwsStepFunctions.LambdaFunctions::UploadNewResume
dotnet lambda deploy-function LookForGithubProfile --function-handler  ServerlessResumeUploader::AwsStepFunctions.LambdaFunctions::LookForGithubProfile
dotnet lambda deploy-function EmailRecruitment --function-handler  ServerlessResumeUploader::AwsStepFunctions.LambdaFunctions::EmailRecruitment
```