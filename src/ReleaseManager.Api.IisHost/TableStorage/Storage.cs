using System.Threading.Tasks;
using Microsoft.Framework.OptionsModel;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace ReleaseManager.Api.Host.TableStorage
{
    public class Storage
    {
        private readonly CloudTableClient _tableClient;

        public Storage(IOptions<AppSettings> appSettings)
        {
            var storageAccount = CloudStorageAccount.Parse(appSettings.Options.CloudStorageConnection);
            _tableClient = storageAccount.CreateCloudTableClient();
        }

        public async Task Initialise()
        {
            await Task.WhenAll(new Task[]
            {
                Repositories.CreateIfNotExistsAsync(),
                Trackers.CreateIfNotExistsAsync()
            });
        }

        public CloudTable Repositories => _tableClient.GetTableReference("repositories");

        public CloudTable Trackers => _tableClient.GetTableReference("trackers");
    }
}
