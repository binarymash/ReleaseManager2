using LinkTemplates = ReleaseManager.Api.Host.Hal.LinkTemplates;

namespace ReleaseManager.Api.Host.Representations
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Repository : WebApi.Hal.Representation
    {
        public Repository()
        {
            Rel = LinkTemplates.Repositories.Repository.Rel;
        }

        public string RepositoryId { get; set; }

        public string Path { get; set; }

        protected override void CreateHypermedia()
        {
            Href = LinkTemplates.Repositories.Repository.CreateLink(new { repositoryId = RepositoryId }).Href;

            Links.Add(LinkTemplates.RepositoryLogs.Collection.CreateLink(new {repositoryId = RepositoryId}));
            Links.Add(LinkTemplates.Branches.Collection.CreateLink(new {repositoryId = RepositoryId}));
        }
    }
}
