using Newtonsoft.Json;
using WebApi.Hal;
using LinkTemplates = ReleaseManager.Api.Host.Hal.LinkTemplates;

namespace ReleaseManager.Api.Host.Representations
{
    public class RepositoryLog : Representation
    {
        public string Sha { get; set; }

        public string Author { get; set; }

        public string ShortMessage { get; set; }

        [JsonIgnore]
        public string RepositoryId { get; set; } 

        protected override void CreateHypermedia()
        {
            Links.Add(LinkTemplates.RepositoryLogs.Collection.CreateLink(new {repositoryId = RepositoryId}));
            Links.Add(LinkTemplates.Repositories.Collection.CreateLink(new {repositoryId = RepositoryId}));
        }
    }
}
