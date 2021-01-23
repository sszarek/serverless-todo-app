resource "random_id" "fe_storage_account" {
  byte_length = 8
}

resource "azurerm_storage_account" "fe_sa" {
  name                     = "storage${lower(random_id.fe_storage_account.hex)}"
  resource_group_name      = azurerm_resource_group.rg.name
  location                 = azurerm_resource_group.rg.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
  tags = {
    "region" = var.environment
  }

  static_website {
    error_404_document = "notfound.html"
    index_document     = "index.html"
  }
}