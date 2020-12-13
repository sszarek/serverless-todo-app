terraform {
  required_providers {
      azurerm = {
          source = "hashicorp/azurerm"
          version = ">= 2.26"
      }
  }
}

provider "azurerm" {
  features {}
}

module "naming" {
  source = "Azure/naming/azurerm"
  suffix = ["todoapp"]
}

resource "azurerm_resource_group" "rg" {
  name = "serverless-todo-app"
  location = "centralus"
}

resource "azurerm_storage_account" "sa" {
  name = module.naming.storage_account.name
  resource_group_name = azurerm_resource_group.rg.name
  location = azurerm_resource_group.rg.location
  account_tier = "Standard"
  account_replication_type = "LRS"
  tags = {
    environment = "development"
  }
}

resource "azurerm_app_service_plan" "sp" {
  name = "serverless-todo-app-plan"
  location = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  kind = "FunctionApp"
  sku {
    tier = "Dynamic"
    size = "Y1"
  }
  tags = {
    environment = "development"
  }
}

resource "azurerm_function_app" "afa" {
  name = "serverless-todo-app"
  location = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_app_service_plan.sp.id
  storage_account_name = azurerm_storage_account.sa.name
  storage_account_access_key = azurerm_storage_account.sa.primary_access_key
  os_type = "linux"
  version = "~2"
  tags = {
    environment = "development"
  }
}