namespace CardService.Domain.Strategies
{
    public interface IActionStrategy
    {
        bool CanHandle(
            CardType cardType,
            CardStatus cardStatus);

        IReadOnlyCollection<string> GetAllowedActions(CardDetails card);
    }
}
