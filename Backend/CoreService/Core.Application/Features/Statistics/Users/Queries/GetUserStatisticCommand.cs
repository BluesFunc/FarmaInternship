using Core.Application.Dtos.Statistics.Messages;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Statistics.Users.Queries;

public class GetUserStatisticCommand : IRequest<Result<UserStatisticMessage>>
{
    public Guid Id { get; set; }
}