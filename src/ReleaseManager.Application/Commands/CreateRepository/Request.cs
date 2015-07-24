using ReleaseManager.Api.Model;

namespace ReleaseManager.Application.Commands.CreateRepository
{
    public class Request : Null.Request
    {
        public Repository Repository { get; private set; }

        public Request(Repository repository)
        {
            Repository = repository;
        }
    }
}
