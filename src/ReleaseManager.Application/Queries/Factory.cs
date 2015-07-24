using System;

namespace ReleaseManager.Application.Queries
{
    public class Factory
    {
        private readonly IServiceProvider _serviceProvider;

        public Factory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Queries.GetRepositories.Query GetRepositories()
        {
            return _serviceProvider.GetService(typeof (Queries.GetRepositories.Query)) as Queries.GetRepositories.Query;
        }
    }
}
