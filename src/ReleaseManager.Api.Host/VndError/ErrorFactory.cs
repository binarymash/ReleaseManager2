using ReleaseManager.Api.Host.Representations;

namespace ReleaseManager.Api.Host.VndError
{
    public class ErrorFactory
    {
        private readonly RequestIdStore _requestIdStore;

        public ErrorFactory(RequestIdStore requestIdStore)
        {
            _requestIdStore = requestIdStore;
        }

        public Error RepositoryNotFound()
        {
            return new Error
            {
                LogRef = _requestIdStore.Value,
                Message = "Repository not found"
            };
        }

        public Error RepositoryStorageWriteError()
        {
            return new Error
            {
                LogRef = _requestIdStore.Value,
                Message = "Something went wrong when trying to store the repository"
            };
        }
    }
}
