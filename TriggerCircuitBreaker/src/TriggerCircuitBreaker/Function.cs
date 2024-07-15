using Amazon.ApiGatewayV2.Model;
using Amazon.ApiGatewayV2;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace TriggerCircuitBreaker;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
	public async Task FunctionHandler(object input, ILambdaContext context)
    {
		const string apiGatewayId = "abcabc";
		const string exchangeRateRouteId = "defdef";
		const string fallbackIntegrationId = "xyzxyz";

		var apiGatewayClient = new AmazonApiGatewayV2Client();
		await apiGatewayClient.UpdateRouteAsync(new UpdateRouteRequest
		{
			RouteId = exchangeRateRouteId,
			ApiId = apiGatewayId,
			Target = $"integrations/{fallbackIntegrationId}"
		});
	}
}
