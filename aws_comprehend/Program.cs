using Amazon;
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

// Display title
Console.WriteLine("AWS AI API Sentiment Detector" + Environment.NewLine);

// Ask for phrase
Console.WriteLine("Type in phrase for analysis" + Environment.NewLine);
var phrase = Console.ReadLine();

// Detect Sentiment
var comprehendClient = new AmazonComprehendClient(RegionEndpoint.EUWest1);
Console.WriteLine("Calling DetectSentiment");

var detectSentimentResponse = await comprehendClient.DetectSentimentAsync(
    new DetectSentimentRequest()
    {
        Text = phrase,
        LanguageCode = "en"
    });

Console.WriteLine(detectSentimentResponse.Sentiment);
Console.WriteLine("Done");