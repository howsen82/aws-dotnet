using Amazon.Lambda;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class ExampleController : ControllerBase
{
	private readonly IAmazonLambda _lambdaClient;

	public ExampleController(IAmazonLambda lambdaClient)
	{
		_lambdaClient = lambdaClient;
	}

	public async Task DoSomething()
	{
		await _lambdaClient.InvokeAsync(new Amazon.Lambda.Model.InvokeRequest
		{
			FunctionName = "MyLambdaFunction",
			InvocationType = InvocationType.Event
		});
	}
}
