using MediatR;

namespace Engagement.Application.Features.Users.List;

public record ListUserQuery : IRequest<List<ListUserResponse>>;