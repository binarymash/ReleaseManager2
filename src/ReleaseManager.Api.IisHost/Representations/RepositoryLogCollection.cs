using System.Collections.Generic;
using Newtonsoft.Json;
using WebApi.Hal;
using LinkTemplates = ReleaseManager.Api.Host.Hal.LinkTemplates;

namespace ReleaseManager.Api.Host.Representations
{
    public class RepositoryLogCollection : SimpleListRepresentation<RepositoryLog>
    {
        public RepositoryLogCollection(string repositoryId, IList<RepositoryLog> repositoryLogs) : base(repositoryLogs)
        {
            RepositoryId = repositoryId;
        }

        [JsonIgnore]
        public string RepositoryId { get; set; }

        protected override void CreateHypermedia()
        {
            Href = LinkTemplates.RepositoryLogs.Collection.CreateLink(new {repositoryId = RepositoryId}).Href;
        }


    }
}
