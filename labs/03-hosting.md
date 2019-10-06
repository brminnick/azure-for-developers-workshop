# Hosting an app on Azure App Service

In this lab you will learn to:

* Azure SQL Database
    * Create an instance of Azure SQL Database
    * Load data in to the database
* Azure App Service
    * Create an instance of Azure Web Apps
    * Deploy an ASP.NET Core 2.2 app to Azure Web Apps
    * Configure the web app to access the database
* Application Insights
    * Create an instance of Application Insights
    * Activate Application Insights in the web app
    * Explore Application insights features
* Azure DevOps
    * Configure continuous delivery

## Azure SQL Database

1. In the Azure portal, create a new Azure SQL Database instance.
    * Set up firewall rules to allow Azure resources and your IP
1. **Fork** our app from https://github.com/brminnick/azure-for-developers-workshop.
1. Clone the fork onto your machine.
1. Run the script at `src/hotelsweb/database/sql/create-tables-data.sql` using one of the following:
    * Azure portal
    * SQL Management Studio
    * SQL Operations Studio
    * Visual Studio or VS Code with SQL Server extension
1. Open `src/hotelsweb.sln` in Visual Studio or VSCode.
1. Configure the application with the SQL Database connection string.
    * Visual Studio - Right-click on the project, select **Manage User Secrets**. Enter this snippet:
        ```json
        {
          "ConnectionStrings": {
            "LocalConnection": "<connection string>"
          }
        }
        ```
    * Other editors (.NET CLI) - Open a terminal to the folder containing hotelsweb.csproj. Enter this command:
        ```
        dotnet user-secrets set 'ConnectionStrings:LocalConnection' '<connection string>'
        ```
1. Run the application. Clicking on the Hotels link in the navigation bar should display a list of hotels.


## Azure App Service

1. In the Azure portal, create a new Web App.
    * Place it in the same resource group as the SQL Database
    * Select Windows
    * Do not turn on Application Insights for now
1. Once the app is created, go to its **Deployment options** view and configure GitHub deployment from your fork. Wait for the app to be deployed.
1. Open the web app's application settings. Add a new connection string:
    * Name: `HotelsConnection`
    * Value: Your SQL Database connection string
1. Open the application in your browser. It should appear and the Hotels links should work.


## Application Insights

1. In the Azure portal, open the **Application Insights** view. Select **Setup Application Insights** and follow instructions to configure Application Insights.


## Azure DevOps

1. In the Azure portal, create a new DevOps project. Select "Bring your own code".
1. Connect your GitHub account and select your fork.
1. Follow the rest of the instructions.

