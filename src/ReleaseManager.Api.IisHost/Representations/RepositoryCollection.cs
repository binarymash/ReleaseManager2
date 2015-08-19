using System.Collections.Generic;
using WebApi.Hal;
using LinkTemplates = ReleaseManager.Api.Host.Hal.LinkTemplates;

namespace ReleaseManager.Api.Host.Representations
{
    public class RepositoryCollection : SimpleListRepresentation<Repository>
    {
        public RepositoryCollection(IList<Repository> repositories) : base(repositories)
        {
            //Rel = LinkTemplates.Repositories.Collection.Rel;
        }

        protected override void CreateHypermedia()
        {
            Href = LinkTemplates.Repositories.Collection.CreateLink().Href;
        }
    }
}
