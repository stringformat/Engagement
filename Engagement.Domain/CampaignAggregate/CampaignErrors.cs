using System.Net;
using Engagement.Common;

namespace Engagement.Domain.CampaignAggregate;

public static class CampaignErrors
{
    public static Error DataRequiredWhenUpdateCampaignError
        => new(
            Message: "La mise à jour d'une campagne requière des données.", 
            Code: ErrorType.DataRequiredWhenUpdateCampaign,
            StatusCode: HttpStatusCode.BadRequest);
}