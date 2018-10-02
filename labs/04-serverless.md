# Azure Functions

## Create an Azure Function app

1. In the Azure portal, create a new function app.
1. Once the app is created, open its resource group and open the Storage account inside. Locate its connection string and copy it. We'll be using this storage account for local debugging and to create a queue for hotel review submissions.


## Configure the web application to save reviews to a queue

1. Open the web app from the previous module in the Azure portal. Add a new application setting:
    * Name - `Reviews__StorageConnectionString`
    * Value - the Storage connection string you just copied
1. Now the application will add reviews to a queue named `reviews` in the storage account when new reviews are submitted.


## Create a new function app

1. On your machine, in Visual Studio or VSCode, create a new Azure Function app (C#).
1. Create a queue triggered function and add the following code:
    ```csharp
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run(
            [QueueTrigger("reviews")]string myQueueItem, 
            [Table("reviews")] out Review review, 
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            review = new Review
            {
                PartitionKey = "review",
                RowKey = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(),
                Text = myQueueItem
            };
        }
    }
    ```
    Also add a new class named `Review`:
    ```csharp
    public class Review : TableEntity
    {
        public string Text { get; set; }
    }
    ```
1. Create a `local.settings.json` file with the following content:
    ```json
    {
      "IsEncrypted": false,
      "Values": {
        "AzureWebJobsStorage": "<function app storage connection string>",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet"
      },
      "Host": {
        "LocalHttpPort": 7071,
        "CORS": "*"
      }
    }
    ```
1. Create an HTTP triggered function named `GetReviews` and add the following code:
    ```csharp
    public static class GetReviews
    {
        [FunctionName("GetReviews")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, 
            [Table("reviews")] CloudTable reviews,
            ILogger log)
        {
            var items = await reviews.ExecuteQuerySegmentedAsync(new TableQuery<Review>(), null);
            return new OkObjectResult(items.Results.ToList());
        }
    }
    ```

