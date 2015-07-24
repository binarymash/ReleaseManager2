namespace ReleaseManager.Application.Commands.CreateRepository
{
    public class Command : ICommand<Request, Response>
    {

        public Response Run(Request request)
        {
            //using (var repo = new LibGit2Sharp.Repository(request.Repository.Path))
            //{
            //    var filter = new LibGit2Sharp.CommitFilter
            //    {
            //        Since = repo.Branches["master"],
            //        Until = repo.Branches["development"]
            //    };

            //    var commits = repo.Commits.QueryBy(filter);
                
            //}


            //var repo2 = new ReleaseManager.Data.Model.Repository
            //{
            //    Path = request.Repository.Path
            //};

            return new Response();
        }
    }
}
