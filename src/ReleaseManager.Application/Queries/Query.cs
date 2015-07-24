namespace ReleaseManager.Application.Queries
{
    public class Query<TRequest, TResponse> 
        where TRequest : Request 
        where TResponse : Response
{
    public virtual TResponse Run(TRequest request)
    {
        return new Response() as TResponse;
    }
}
}
