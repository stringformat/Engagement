using Engagement.Application.Features.Campaigns.Create;
using Microsoft.Extensions.DependencyInjection;

namespace Engagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<CreateCampaignCommand>());

        return services;
    }
}