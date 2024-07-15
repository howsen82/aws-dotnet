## Blazor Server App

```sh
cd BlazorApp
dotnet run --urls=http://localhost:8080
```

Now build this container with the following command:

```sh
docker build . -t blazor-app-dotnet:latest
```

To run it, do the following:

```sh
docker run -p 8080:8080 blazor-app-dotnet:latest
```

Push to Amazon Elastic Container Registry (ECR)

```sh
aws ecr get-login-password --region us-east-1 | docker login --username AWS --password-stdin 059075291393.dkr.ecr.us-east-1.amazonaws.com
docker build -t blazor-app-dotnet .
docker tag blazor-app-dotnet:latest 059075291393.dkr.ecr.us-east-1.amazonaws.com/blazor-app-dotnet:latest
docker push 059075291393.dkr.ecr.us-east-1.amazonaws.com/blazor-app-dotnet:latest
```

With ECR hosting our container, let's discuss using a service that can deploy it automatically.

---

## Deploy to AWS App Runner

*Source*

Repository type: `Container registry`
Provider: `Amazon ECR`
Container image URI: `059075291393.dkr.ecr.us-east-1.amazonaws.com/blazor-app-dotnet:latest`
Deployment trigger: `Automatic`
ECR access role: `Use existing service role`

Press `Next` button

Service name: `dotnet-blazor-app`
Virtual CPU: `1 vCPU`
Virtual memory: `2 GB`
Port: `8080`

Press `Next` button

Press `Create & deploy` button