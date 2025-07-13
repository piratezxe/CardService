namespace CardService.Domain.Strategies.Prepaid
{
    public class PrepaidOrderedStrategy : IActionStrategy
    {
        public bool CanHandle(CardType cardType, CardStatus cardStatus)
            => cardType == CardType.Prepaid && cardStatus == CardStatus.Ordered;

        public IReadOnlyCollection<string> GetAllowedActions(CardDetails card)
            => ["ACTION10", "ACTION11"];
    }
}
