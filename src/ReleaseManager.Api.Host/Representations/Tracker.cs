using ReleaseManager.Api.Host.Hal;
using WebApi.Hal;

namespace ReleaseManager.Api.Host.Representations
{
    public class Tracker : Representation
    {

        public Tracker()
        {
            Rel = LinkTemplates.Trackers.Tracker.Rel;
        }

        public string TrackerId { get; set; }

        public string Url { get; set; }

        protected override void CreateHypermedia()
        {
            Href = LinkTemplates.Trackers.Tracker.CreateLink(TrackerId = TrackerId).Href;
        }
    }
}
