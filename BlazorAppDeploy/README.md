## AWS CodeDeploy

**Pre-requisite**

To install the deployment tool, use the dotnet tool install command:

```sh
dotnet tool install -g aws.deploy.tools
```

To update to the latest version of the deployment tool, use the dotnet tool update command.

```sh
dotnet tool update -g aws.deploy.tools
```

To uninstall it, simply type:

```sh
dotnet tool uninstall -g aws.deploy.tools
```

```sh
dotnet new blazor -o BlazorAppDeploy --no-https -f net8.0 && cd BlazorAppDeploy
```

To deploy your application and type:

```sh
dotnet aws deploy
```