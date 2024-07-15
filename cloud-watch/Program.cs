using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using System.Diagnostics;

var client = new AmazonCloudWatchClient();
await client.PutMetricDataAsync(new Amazon.CloudWatch.Model.PutMetricDataRequest
{
    Namespace = "MyApplication",
    MetricData = new List<MetricDatum>
    {
        new MetricDatum
        {
            MetricName = "ProcessCount",
            Value = Process.GetProcesses().Length
        }
    }
});