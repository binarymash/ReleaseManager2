using System;
using System.Net;
using Microsoft.WindowsAzure.Storage.Table;
using ReleaseManager.Api.Host.Representations;

namespace ReleaseManager.Api.Host.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNet.Mvc;
    using ReleaseManager.Api.Host.TableStorage;


    [System.Web.Http.Route("api/trackers")]
    public class TrackersController : Controller
    {
        private readonly Storage _storage;

        public TrackersController(Storage storage)
        {
            _storage = storage;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var trackers = new List<Tracker>();
            return new ObjectResult(trackers);
        }

        // POST api/repositories
        [HttpPost]
        public IActionResult Post([FromBody]Tracker tracker)
        {
            try
            {
                var trackerEntity = new TableStorage.Entities.Tracker("1", Guid.NewGuid().ToString())
                {
                    Timestamp = DateTime.UtcNow
                };

                var operation = TableOperation.Insert(trackerEntity);
                var result = _storage.Repositories.Execute(operation);
                trackerEntity = result.Result as TableStorage.Entities.Tracker;

                if (trackerEntity == null)
                {
                    return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
                }

                tracker.TrackerId = trackerEntity.RowKey;
                tracker.Url = trackerEntity.Url;

                return new ObjectResult(tracker);
            }
            catch (Exception)
            {
                //log
            }

            return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
        }

    }
}
