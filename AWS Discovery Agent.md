## AWS Discovery Agent Installation

Windows

```sh
mkdir ADSAgent
cd ADSAgent
Invoke-WebRequest https://s3.us-west-2.amazonaws.com/aws-discovery-agent.us-west-2/windows/latest/AWSDiscoveryAgentInstaller.exe -OutFile ADSAgentInstaller.exe
.\ADSAgentInstaller.exe REGION="us-east-1" KEY_ID="aws-access-key-id" KEY_SECRET="aws-secret-access-key" INSTALLLOCATION="C:\ADSAgent" /quiet
```

Linux

```sh
mkdir ADSAgent
cd ADSAgent
curl -o ./aws-discovery-agent.tar.gz https://s3-us-west-2.amazonaws.com/aws-discovery-agent.us-west-2/linux/latest/aws-discovery-agent.tar.gz
tar -xzf aws-discovery-agent.tar.gz
sudo bash install -r us-east-1 -k aws-access-key-id -s aws-secret-access-key

# Start Agent
sudo systemctl start aws-discovery-daemon.service
# Stop Agent
sudo systemctl stop aws-discovery-daemon.service
# Restart Agent
sudo systemctl restart aws-discovery-daemon.service
```