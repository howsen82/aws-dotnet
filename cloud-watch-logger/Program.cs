await using (var logger = await CloudWatchLogger.CreateNew())
{
    logger.WriteLine("Developing");
    logger.WriteLine("on AWS");
    logger.WriteLine("With C#!");
}