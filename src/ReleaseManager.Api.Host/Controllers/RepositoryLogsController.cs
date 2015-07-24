using System.Linq;
using LibGit2Sharp;
using Microsoft.AspNet.Mvc;
using Microsoft.WindowsAzure.Storage.Table;
using ReleaseManager.Api.Host.TableStorage;
using ReleaseManager.Api.Host.VndError;
using ReleaseManager.Api.Model;
using Repository = ReleaseManager.Api.Host.TableStorage.Entities.Repository;
using RepositoryLog = ReleaseManager.Api.Host.Representations.RepositoryLog;
using RepositoryLogCollection = ReleaseManager.Api.Host.Representations.RepositoryLogCollection;

namespace ReleaseManager.Api.Host.Controllers
{
    [Route("api/repositories/{repositoryId}/logs")]
    public class RepositoryLogsController : Controller
    {
        private readonly Storage _storage;
        private readonly ErrorFactory _errorFactory;

        public RepositoryLogsController(Storage storage, ErrorFactory errorFactory)
        {
            _storage = storage;
            _errorFactory = errorFactory;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get(string repositoryId)
        {
            var operation = TableOperation.Retrieve<Repository>("1", repositoryId);
            var result = _storage.Repositories.Execute(operation);

            var repositoryEntity = result.Result as Repository;
            if (repositoryEntity == null)
            {
                return new ObjectResult(_errorFactory.RepositoryNotFound());
            }

            using (var repo = new LibGit2Sharp.Repository(repositoryEntity.Path))
            {
                var filter = new CommitFilter {Since = repo.Branches["master"], Until = repo.Branches["development"]};

                var commits = repo.Commits.QueryBy(filter);

                var repositoryLogs = new RepositoryLogCollection(
                    repositoryId,
                    commits.Select(c => new RepositoryLog
                    {
                        RepositoryId = repositoryId,
                        Sha = c.Sha,
                        ShortMessage = c.MessageShort,
                        Author = c.Author.Name
                    }).ToList());


                return new ObjectResult(repositoryLogs);
            }
        }
    }
}
