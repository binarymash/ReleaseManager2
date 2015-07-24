using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.WindowsAzure.Storage.Table;
using ReleaseManager.Api.Host.Representations;
using ReleaseManager.Api.Host.TableStorage;
using ReleaseManager.Api.Host.VndError;

namespace ReleaseManager.Api.Host.Controllers
{
    [Route("api/repositories/{repositoryId}/branches")]
    public class BranchesController : Controller
    {
        private readonly Storage _storage;
        private readonly ErrorFactory _errorFactory;

        public BranchesController(Storage storage, ErrorFactory errorFactory)
        {
            _errorFactory = errorFactory;
            _storage = storage;
        }

        [HttpGet]
        public IActionResult Branches(string repositoryId)
        {
            var operation = TableOperation.Retrieve<TableStorage.Entities.Repository>("1", repositoryId);
            var result = _storage.Repositories.Execute(operation);

            var repositoryEntity = result.Result as TableStorage.Entities.Repository;
            if (repositoryEntity == null)
            {
                return new ObjectResult(_errorFactory.RepositoryNotFound());
            }

            var branches = new List<Branch>();
            using (var repo = new LibGit2Sharp.Repository(repositoryEntity.Path))
            {
                foreach (var branch in repo.Branches)
                {
                    branches.Add(new Branch
                    {
                        Name = branch.Name,
                        CanonicalName = branch.CanonicalName

                    });
                }

                return new ObjectResult(branches);
            }
        }
    }
}
