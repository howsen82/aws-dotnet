### S3 Bucket

**Create S3 Bucket**

```sh
Import-Module AWSPowerShell.NetCore
New-S3Bucket -BucketName bucket-name
```

**Write S3 Bucket**

```sh
Import-Module AWSPowerShell.NetCore
echo "This is data" > data.txt
Write-S3Object -BucketName silly-name-1234 -File data.txt
Get-S3Object
```