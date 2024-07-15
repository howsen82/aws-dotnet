## Application Migration Service (MGN)

```sh
mkdir MGNAgent
cd MGNAgent
Invoke-WebRequest https://aws-application-migration-service-us-east-1.s3.us-east-1.amazonaws.com/latest/windows/AwsReplicationWindowsInstaller.exe -OutFile C:\MGNAgent\AwsReplicationWindowsInstaller.exe

$AWS_REGION="<region>"
$KEY_ID="<your-key-id>"
$KEY_SECRET="<your-key-secret>"

.\AwsReplicationWindowsInstaller.exe --region $AWS_REGION --aws-access-key-id $KEY_ID --aws-secret-access-key $KEY_SECRET
```