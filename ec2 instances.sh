#!/bin/bash
aws ec2 run-instances --image-id ami-033594f8862b03bb2
aws ec2 describe-instances --filters "Name=instance-type,Values=t2.micro"
aws ec2 terminate-instances --instance-ids i-00cbf30e33063f1a4