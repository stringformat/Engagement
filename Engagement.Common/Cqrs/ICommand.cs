using Engagement.Common.ResultPattern;

namespace Engagement.Common.Cqrs;

public interface ICommand<in TRequest> where TRequest : IRequest
{
    Task<Result> Handle(TRequest request, CancellationToken cancellationToken);
}

public interface ICommandWithResult<in TRequest> where TRequest : IRequest
{
    Task<Result<Guid>> Handle(TRequest request, CancellationToken cancellationToken);
}