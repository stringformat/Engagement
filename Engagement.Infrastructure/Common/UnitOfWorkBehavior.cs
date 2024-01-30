using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Engagement.Infrastructure.Common;

public class UnitOfWorkMediatRBehavior<TRequest, TResponse>(EngagementContext dbContext) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();
        await dbContext.SaveChangesAsync(cancellationToken);
        return response;
    }
}

public static class UnitOfWorkMediatRBehaviorExtensions
{
    public static IServiceCollection AddUnitOfWorkMediatRBehavior(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkMediatRBehavior<,>));
    }
}