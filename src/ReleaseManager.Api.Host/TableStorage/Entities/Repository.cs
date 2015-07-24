namespace ReleaseManager.Api.Host.TableStorage.Entities
{
    using Microsoft.WindowsAzure.Storage.Table;

    public class Repository : TableEntity
    {
        public Repository()
        {
        }

        public Repository(string accountId, string repositoryId)
        {
            PartitionKey = accountId;
            this.RowKey = repositoryId;
        }

        public string Path { get; set; }
    }
}
