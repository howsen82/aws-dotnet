## AWS Lambda Installation

**Install AWS Functions**

```sh
dotnet new -i Amazon.Lambda.Templates
dotnet new lambda.EmptyFunction --name SingleCSharpLambda
```

**Deployment**

```sh
dotnet tool install -g Amazon.Lambda.Tools
dotnet lambda deploy-function SingleCSharpLambda
```

*Output*

```
Creating new Lambda function SingleCSharpLambda
Select IAM Role that to provide AWS credentials to your code:
    1) AmazonSageMakerServiceCatalogProductsLambdaRole
    2) AmazonSageMakerServiceCatalogProductsUseRole
    3) demo-lambda-role-xd4iitmw
    4) helloworld-role-7lfkppd9
    5) LamdaS3FullAccess
    6) stopper-role-mfz5npcb
    7) *** Create new IAM Role ***
5
New Lambda function created
```

Deploy Lambda to ASP.NET Application

```sh
dotnet add package Amazon.Lambda.AspNetCoreServer
```

```C#
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Add AWS Lambda support.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

app.MapRazorPages();

var app = builder.Build();
```

```sh
dotnet lambda deploy-function UploadNewResume
```