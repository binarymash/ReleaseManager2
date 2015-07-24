using System.Threading;
using Microsoft.WindowsAzure.Storage.Table;

namespace ReleaseManager.Api.Host.TableStorage.Entities
{
    public class Tracker : TableEntity
    {
        public Tracker()
        {
        }

        public Tracker(string accountId, string trackerId)
        {
            this.PartitionKey = accountId;
            this.RowKey = trackerId;
        }

        public string Url { get; set; }
    }
}
