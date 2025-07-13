namespace CardService.Domain.Strategies.Prepaid
{
    public class PrepaidClosedStrategy : IActionStrategy
    {
        public bool CanHandle(CardType cardType, CardStatus cardStatus)
            => cardType == CardType.Prepaid && cardStatus == CardStatus.Closed;

        public IReadOnlyCollection<string> GetAllowedActions(CardDetails card)
            => ["ACTION3", "ACTION4", "ACTION9"];
    }
}
