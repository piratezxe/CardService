using CardService.Application.Features.CardsActions.Queries;
using CardService.Application.Services;
using CardService.Domain.Strategies;
using FluentValidation;
using MediatR;

namespace CardService.Application.Features.CardsActions.Commands
{
    public class GetCardActionsHandler : IRequestHandler<GetCardActionsQuery, CardActionsResponse>
    {
        private readonly IActionStrategyFactory _actionStrategyFactory;

        private readonly ICardService _cardService;

        private readonly IValidator<GetCardActionsQuery> _validator;

        public GetCardActionsHandler(
            IActionStrategyFactory actionStrategyFactory,
            ICardService cardService,
            IValidator<GetCardActionsQuery> validator)
        {
            _actionStrategyFactory = actionStrategyFactory;

            _cardService = cardService;

            _validator = validator;
        }

        public async Task<CardActionsResponse> Handle(
            GetCardActionsQuery request,
            CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var card = await _cardService.GetCardDetails(
                request.UserId,
                request.CardNumber)
                ?? throw new ArgumentNullException($"Card with number {request.CardNumber} not found");

            var strategy = _actionStrategyFactory.GetStrategy(
                card.CardType,
                card.CardStatus);

            var actions = strategy.GetAllowedActions(card);

            return new CardActionsResponse(actions);
        }
    }
}
