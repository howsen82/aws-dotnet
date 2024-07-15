var upload = new AwsS3StorageService();
var stream = File.OpenRead("sample.pdf");

await upload.Upload(stream);