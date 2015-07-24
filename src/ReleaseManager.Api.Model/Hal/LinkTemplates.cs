using WebApi.Hal;

namespace ReleaseManager.Api.Model.Hal
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
    }
}
