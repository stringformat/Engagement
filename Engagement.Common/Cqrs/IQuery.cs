namespace Engagement.Common.Cqrs;

public interface IQuery<in TRequest, TResponse> where TRequest : IRequest
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

public interface IQuery<TResponse>
{
    Task<TResponse> Handle(CancellationToken cancellationToken);
}