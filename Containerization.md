## Containerization

```sh
app2container init
app2container inventory
app2container analyze --application-id iis-example-d87652a0
```

```sh
# Create a Dockerfile
app2container containerize --application-id iis-example-d87652a0

# Generate a deployment
app2container generate app-deployment --application-id iis-example-d87652a0
```
