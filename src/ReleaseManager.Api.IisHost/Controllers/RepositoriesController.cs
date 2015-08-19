using FluentValidation;
using ReleaseManager.Api.Host.Validators;
using ReleaseManager.Api.Host.VndError;

namespace ReleaseManager.Api.Host.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using Microsoft.AspNet.Mvc;
    using Microsoft.WindowsAzure.Storage.Table;
    using ReleaseManager.Api.Host.TableStorage;

    [Route("api/[controller]")]
    public class RepositoriesController : Controller
    {
        private readonly Storage _storage;
        private readonly ErrorFactory _errorFactory;
        private RepositoryValidator _repositoryValidator;

        public RepositoriesController(Storage storage, RepositoryValidator repositoryValidator, ErrorFactory errorFactory)
        {
            _repositoryValidator = repositoryValidator;
            _errorFactory = errorFactory;
            _storage = storage;
        }

        // GET: api/repositories
        [HttpGet]
        public Representations.RepositoryCollection Get()
        {
            var query = new TableQuery<TableStorage.Entities.Repository>()
                .Where(AccountIdIs("1"));

            var repositoryEntities = _storage.Repositories.ExecuteQuery(query);

            var repositories = new Representations.RepositoryCollection(
                repositoryEntities.Select(r => new Representations.Repository
                {
                    RepositoryId = r.RowKey,
                    Path = r.Path
                }).ToList());

            return repositories;
        }

        // GET api/repositories/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var operation = TableOperation.Retrieve<TableStorage.Entities.Repository>("1", id);
            var result = _storage.Repositories.Execute(operation);

            var repositoryEntity = result.Result as TableStorage.Entities.Repository;
            if (repositoryEntity == null)
            {
                return new ObjectResult(_errorFactory.RepositoryNotFound());
            }

            var repository = new Representations.Repository
            {
                RepositoryId = repositoryEntity.RowKey,
                Path = repositoryEntity.Path
            };

            return new ObjectResult(repository);
        }

        // POST api/repositories
        [HttpPost]
        public IActionResult Post([FromBody]Representations.Repository repository)
        {
            var validationResult = _repositoryValidator.Validate(repository, ruleSet:"default,create");
            if (!validationResult.IsValid)
            {
                throw new Exception();
                //    var errors = new VndError.ErrorCollection();
                //    foreach (var error in validationResult.Errors)
                //    {
                //        error.
                //    }
                //    this.Context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //    return new ObjectResult(errors);
            }

            var repositoryEntity = new TableStorage.Entities.Repository("1", Guid.NewGuid().ToString())
            {
                Path = repository.Path,
                Timestamp = DateTime.UtcNow
            };

            var operation = TableOperation.Insert(repositoryEntity);
            var result = _storage.Repositories.Execute(operation);
            repositoryEntity = result.Result as TableStorage.Entities.Repository;

            if (repositoryEntity == null)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }

            repository.RepositoryId = repositoryEntity.RowKey;
            repository.Path = repositoryEntity.Path;

            return new ObjectResult(repository);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Representations.Repository repository)
        {
            var operation = TableOperation.Retrieve<TableStorage.Entities.Repository>("1", id);
            var result = _storage.Repositories.Execute(operation);

            var repositoryEntity = result.Result as TableStorage.Entities.Repository;
            if (repositoryEntity == null)
            {
                return new ObjectResult(_errorFactory.RepositoryNotFound());
            }

            repositoryEntity.Path = repository.Path;
            repositoryEntity.Timestamp = DateTime.UtcNow;

            operation = TableOperation.Replace(repositoryEntity);
            result = _storage.Repositories.Execute(operation);
            repositoryEntity = result.Result as TableStorage.Entities.Repository;

            if (repositoryEntity == null)
            {
                return new HttpStatusCodeResult((int) HttpStatusCode.InternalServerError);
            }

            repository.RepositoryId = repositoryEntity.RowKey;
            repository.Path = repositoryEntity.Path;

            return new ObjectResult(repository);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
                //var operation = TableOperation.repositoryEntity);
                //var options=  new TableRequestOptions() { }
                //var result = _storage.Repositories.DeleteIfExists(operation);
                //repositoryEntity = result.Result as TableStorage.Entities.Repository;

                //if (repositoryEntity == null)
                //{
                //    Response.StatusCode = result.HttpStatusCode;
                //    return null;
                //}

                //repository.RepositoryId = repositoryEntity.RowKey;
                //repository.Path = repositoryEntity.Path;

                //return repository;
        }

        private static string AccountIdIs(string accountId)
        {
            return TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "1");
        }
    }
}
