using Amazon.Lambda;
using Amazon.XRay.Recorder.Core;
using Microsoft.AspNetCore.Mvc;

namespace x_ray.Controllers
{
	[Route("api/[controller]")]
	public class ApplicationController : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> InvokedMyTracedLambda()
		{
			AWSXRayRecorder.Instance.BeginSubsegment("Executing Controller Action");

			var lambdaClient = new AmazonLambdaClient(Amazon.RegionEndpoint.USEast1);
			await lambdaClient.InvokeAsync(new Amazon.Lambda.Model.InvokeRequest
			{
				FunctionName = "TracedLambdaFunction"
			});

			AWSXRayRecorder.Instance.EndSubsegment();
			
			return Ok();
		}
	}
}
