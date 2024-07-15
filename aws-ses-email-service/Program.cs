var email = new AwsSesEmailService();
await email.SendAsync("example@email.com", "Place content here");
