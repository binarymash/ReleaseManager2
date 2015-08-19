    using Microsoft.AspNet.Mvc;
    using ApiRoot = ReleaseManager.Api.Host.Representations.ApiRoot;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ReleaseManager.Api.Host.Controllers
{
    [Route("api/")]
    public class ApiRootController : Controller
    {
        // GET: api/
        [HttpGet]
        public ApiRoot Get()
        {
            var apiRoot = new ApiRoot();
            return apiRoot;
        }
    }
}
