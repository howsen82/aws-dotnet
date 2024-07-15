## EC2 Instances

**Get EC2 Zone**

```ps1
Import-Module AWSPowerShell.NetCore
Get-EC2AvailabilityZone
```

```ps1
$zones = Get-EC2AvailabilityZone -Filter @{ Name="state";Values="available" }
$zones.count
```