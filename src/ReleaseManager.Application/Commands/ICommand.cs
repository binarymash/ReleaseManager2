using ReleaseManager.Application.Commands.Null;

namespace ReleaseManager.Application.Commands
{
    public interface ICommand<TRequest, TResponse>
        where TRequest : Request
        where TResponse : Response
    {
        TResponse Run(TRequest request);
    }

}
