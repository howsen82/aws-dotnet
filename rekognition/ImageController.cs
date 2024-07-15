using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Microsoft.AspNetCore.Mvc;

namespace rekognition.Controllers;

[Route("api/[controller]")]
public class ImageController
{
	private readonly IAmazonRekognition _rekognition;
	public ImageController(IAmazonRekognition rekognition)
	{
		_rekognition = rekognition;
	}

	[HttpGet]
	public async Task<string> GetFirstLabel()
	{
		var response = await _rekognition.DetectLabelsAsync(
		new DetectLabelsRequest
		{
			Image = new Image()
			{
				S3Object = new S3Object()
				{
					Name = "cat.jpg",
					Bucket = "photos-bucket",
				},
			},
			MaxLabels = 10,
			MinConfidence = 75F,
		});
		return response.Labels.FirstOrDefault()?.Name ?? "None";
	}
}