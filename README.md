# serverless-todo-app

## Prepare Azure infrastructure
### Login to Azure
```
az login
```

### Set subscription
All the resources required for the application will need to be created under specific subscription.

You can list subscriptions available for you by running:
```
az account list --output table
```
The above command will return table formatted list ouf sbuscriptions available for your account.

### Create resources
Start from creating resource group.
```
az group create --name serverless-todo-app --location eastus
```

Deploy ARM template
```
az deployment group create --resource-group serverless-todo-app --template-file AzureDeploy/azuredeploy.json --parameters AzureDeploy/azuredeploy.parameters.json
```

### Deploy function to Azure


### Cleanup resources
```
az group delete --name serverless-todo-app
```

## Links
[Microsoft Documentation on Azure CLI](https://docs.microsoft.com/en-us/cli/azure/?view=azure-cli-latest)