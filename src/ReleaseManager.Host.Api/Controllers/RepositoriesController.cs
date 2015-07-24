using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReleaseManager.Host.Api.Controllers
{
    public class RepositoriesController : ApiController
    {
        // GET: api/Repositories
        public IEnumerable<Repository> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Repositories/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Repositories
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Repositories/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Repositories/5
        public void Delete(int id)
        {
        }
    }
}
