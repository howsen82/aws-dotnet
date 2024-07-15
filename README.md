## AWS CloudShell Installation

*Windows*

```
https://awscli.amazonaws.com/AWSCLIV2.msi

# Or
msiexec.exe /i https://awscli.amazonaws.com/AWSCLIV2.msi
```

Linux

```sh
sudo yum remove awscli
```

Or

```sh
curl "https://awscli.amazonaws.com/awscli-exe-linux-x86_64.zip" -o "awscliv2.zip"
unzip awscliv2.zip
sudo ./aws/install
```

---

## AWS PowerShell .NetCore

```sh
Install-Module -Name AWSPowerShell.NetCore
```

Authentication

```sh
aws configure
```

```sh
# Or
aws configure set aws_access_key_id <access_key_id>
aws configure set aws_secret_access_key <your-key-secret>
aws configure set default.region <home-region>
```