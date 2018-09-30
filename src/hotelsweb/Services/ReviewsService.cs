using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace hotelsweb.Services
{
    public class ReviewsService
    {
        private readonly IConfiguration config;

        public ReviewsService(IConfiguration config)
        {
            this.config = config;
        }

        public async Task SubmitAsync(string reviewText)
        {
            var storageAccount = CloudStorageAccount.Parse(config["Reviews:StorageConnectionString"]);
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("reviews");
            await queue.CreateIfNotExistsAsync();

            var message = new CloudQueueMessage(reviewText);
            await queue.AddMessageAsync(message);
        }
    }
}