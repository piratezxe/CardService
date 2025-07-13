namespace CardService.Domain.Strategies.Debit
{
    public class DebitBlockedStrategy : IActionStrategy
    {
        public bool CanHandle(CardType cardType, CardStatus cardStatus)
            => cardType == CardType.Debit && cardStatus == CardStatus.Blocked;

        public IReadOnlyCollection<string> GetAllowedActions(CardDetails card)
            => ["ACTION3", "ACTION4", "ACTION8"];
    }
}
