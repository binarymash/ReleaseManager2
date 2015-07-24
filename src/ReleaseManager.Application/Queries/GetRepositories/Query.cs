using System.Collections.Generic;

namespace ReleaseManager.Application.Queries.GetRepositories
{
    public class Query : Query<Request, Response>
    {
        public override Response Run(Request request)
        {
            var repositories = new List<ReleaseManager.Api.Model.Repository>
            {
                new Api.Model.Repository
                {

                }
            };
            return new Response();
        }
    }
}
