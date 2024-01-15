using Engagement.Application.Behaviors;
using Engagement.Application.Features.Campaign.Create;
using Microsoft.Extensions.DependencyInjection;

namespace Engagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<CreateCampaignCommand>())
            .AddUnitOfWorkBehavior();

        return services;
    }
}