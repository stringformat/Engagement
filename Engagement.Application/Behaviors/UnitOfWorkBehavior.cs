using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Engagement.Application.Behaviors;

public class UnitOfWorkBehavior<TRequest, TResponse>(DbContext dbContext) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();
        await dbContext.SaveChangesAsync(cancellationToken);
        return response;
    }
}

public static class UnitOfWorkBehaviorExtensions
{
    public static IServiceCollection AddUnitOfWorkBehavior(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));
    }
}