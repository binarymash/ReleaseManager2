using WebApi.Hal;
using LinkTemplates = ReleaseManager.Api.Host.Hal.LinkTemplates;

namespace ReleaseManager.Api.Host.Representations
{
    public class ApiRoot : Representation
    {
        protected override void CreateHypermedia()
        {
            Links.Add(LinkTemplates.Repositories.Collection);
        }
    }
}
