using ReleaseManager.Api.Host.Hal;
using WebApi.Hal;

namespace ReleaseManager.Api.Host.Representations
{
    public class TrackerCollection : SimpleListRepresentation<Tracker>
    {
        public TrackerCollection()
        {
            
        }

        protected override void CreateHypermedia()
        {
            Href = LinkTemplates.Trackers.Collection.CreateLink(new Link()).Href;   
        }
    }
}
