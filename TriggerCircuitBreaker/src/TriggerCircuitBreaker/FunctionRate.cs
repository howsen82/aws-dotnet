using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using Amazon.Lambda.Core;
using System.Diagnostics;

namespace ProbeExchangeRateEndpoint;

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
		var watch = Stopwatch.StartNew();
		var response = await new HttpClient().GetAsync("https://external-api.com/latest-rate");

		response.EnsureSuccessStatusCode();

		watch.Stop();

		var cloudWatch = new AmazonCloudWatchClient();
		await cloudWatch.PutMetricDataAsync(new PutMetricDataRequest
		{
			Namespace = "CircuitBreakerExample",
			MetricData = new List<MetricDatum>
			{
				new MetricDatum
				{
					MetricName = "ExchangeRateProbeLatency",
					Value = watch.ElapsedMilliseconds
				}
			}
		});
	}
}
