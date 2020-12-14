variable "azure_region" {
  type = string
}

variable "environment" {
  type = string
  default = "development"
}

variable "app_name" {
  type = string
  default = "serverless-todo-app"

  validation {
    condition = length(var.app_name) >= 3
    error_message = "Name of the application should have at least 3 characters."
  }
}