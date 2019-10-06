using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace hotelsweb.Services
{
    public class ReviewsService
    {
        private readonly IConfiguration _config;

        public ReviewsService(IConfiguration config) => _config = config;

        public async Task SubmitAsync(string reviewText)
        {
            var storageAccount = CloudStorageAccount.Parse(_config["Reviews:StorageConnectionString"]);
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("reviews");
            await queue.CreateIfNotExistsAsync().ConfigureAwait(false);

            var message = new CloudQueueMessage(reviewText);
            await queue.AddMessageAsync(message).ConfigureAwait(false);
        }
    }
}