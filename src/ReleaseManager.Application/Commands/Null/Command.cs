namespace ReleaseManager.Application.Commands.Null
{
    public class Command : ICommand<Request, Response>
    {
        public virtual Response Run(Request request)
        {
            return new Response();
        }
    }
}
