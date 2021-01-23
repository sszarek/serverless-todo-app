terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = ">= 2.26"
    }
  }
}

provider "azurerm" {
  features {}
}

provider "random" {
  
}

resource "azurerm_resource_group" "rg" {
  name     = var.app_name
  location = var.azure_region
}
