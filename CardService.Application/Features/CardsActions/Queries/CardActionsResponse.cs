namespace CardService.Application.Features.CardsActions.Queries
{
    public class CardActionsResponse
    {
        public IReadOnlyCollection<string> Actions { get; init; }

        public CardActionsResponse(IReadOnlyCollection<string> actions)
        {
            Actions = actions;
        }
    }
}
