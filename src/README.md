LabManagementSystem- Capstone project details

This is the repo for .Net Core 6 Web API with all CRUD operations for Author, Category and Lab.

DataBase:
resource group: socgen-sqlserver-rg
Database Name: socgensqlserver/spandan-capstone-db

Tables
- Authers
- Categories
- Labs

Asuze App:
resource group: spandan-capstone-rg
App service Name: spandan-capstone-app
Web site url: https://spandan-capstone-app.azurewebsites.net
Swagger URL: https://spandan-capstone-app.azurewebsites.net/swagger/index.html

Control
- AutherController
- CategoryController
- LabController

Asuze App:
resource group: spandan-capstone-rg
Key vault Name: spandan-capstone-kv
Vault url: https://spandan-capstone-kv.vault.azure.net/
Secret Name: sqlConnectionString

Api retrives the connection string data from vaults, those details are mention in the 'Appsetting.json'
I have taken a Code first approach'

To connect with database, i have used 'Microsoft.EntityFrameworkCore.Sqlite'.
