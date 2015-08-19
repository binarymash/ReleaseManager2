using WebApi.Hal;

namespace ReleaseManager.Api.Host.Hal
{
    public static class LinkTemplates
    {
        public static class Repositories
        {
            public static Link Collection => new Link("repositories", "/api/repositories");

            public static Link Repository => new Link("repository", "/api/repositories/{repositoryId}");
        }

        public static class Branches
        {
            public static Link Collection => new Link("branches","/api/repositories/{repositoryId}/branches");
        }

        public static class RepositoryLogs
        {
            public static Link Collection => new Link("logs", "/api/repositories/{repositoryId}/logs");
        }

        public static class Trackers
        {
            public static Link Collection => new Link("trackers", "/api/trackers");

            public static Link Tracker => new Link("tracker", "/api/trackers/{trackerId}");
        }
    }
}
