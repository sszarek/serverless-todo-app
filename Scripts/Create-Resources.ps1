$resourceGroupName = 'serverless-todo-app'

az group create --name $resourceGroupName --location eastus

az deployment group create --resource-group $resourceGroupName --template-file AzureDeploy/azuredeploy.json --parameters AzureDeploy/azuredeploy.parameters.json