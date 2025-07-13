namespace CardService.Domain.Strategies.Debit
{
    public class DebitRestrictedStrategy : IActionStrategy
    {
        public bool CanHandle(CardType cardType, CardStatus cardStatus)
            => cardType == CardType.Debit && cardStatus == CardStatus.Restricted;

        public IReadOnlyCollection<string> GetAllowedActions(CardDetails card)
            => ["ACTION4", "ACTION5", "ACTION8"];
    }
}
