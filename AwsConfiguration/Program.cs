using Amazon.Lambda;

var builder = WebApplication.CreateBuilder(args);

var awsOptions = builder.Configuration.GetAWSOptions();
builder.Services.AddDefaultAWSOptions(awsOptions);
builder.Services.AddAWSService<IAmazonLambda>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
