using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

public class CloudWatchLogger : IAsyncDisposable
{
	const string LogGroup = "/aws/codebuild/demoproject";

	private readonly AmazonCloudWatchLogsClient _client;
	private readonly string _logStreamName;
	private readonly List<InputLogEvent> _logs = new List<InputLogEvent>();

	public CloudWatchLogger(AmazonCloudWatchLogsClient client, string name)
	{
		_client = client;
		_logStreamName = name;
	}

	public async static Task<CloudWatchLogger> CreateNew()
	{
		var client = new AmazonCloudWatchLogsClient();
		var logStreamName = DateTime.UtcNow.ToString("yyyy/MM/dd/") + Guid.NewGuid().ToString();

		await client.CreateLogStreamAsync(new CreateLogStreamRequest
		{
			LogGroupName = LogGroup,
			LogStreamName = logStreamName
		});
		return new CloudWatchLogger(client, logStreamName);
	}
	public void WriteLine(string message)
	{
		_logs.Add(new InputLogEvent
		{
			Message = message,
			Timestamp = DateTime.Now
		});
	}

	public async ValueTask DisposeAsync()
	{
		await _client.PutLogEventsAsync(new PutLogEventsRequest
		{
			LogEvents = _logs,
			LogGroupName = LogGroup,
			LogStreamName = _logStreamName
		});
	}
}
