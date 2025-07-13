using MediatR;

namespace CardService.Application.Features.CardsActions.Queries
{
    public record GetCardActionsQuery(string UserId, string CardNumber) : IRequest<CardActionsResponse>;
}
