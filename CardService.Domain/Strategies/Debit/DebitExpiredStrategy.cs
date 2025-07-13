namespace CardService.Domain.Strategies.Debit
{
    public class DebitExpiredStrategy : IActionStrategy
    {
        public bool CanHandle(CardType cardType, CardStatus cardStatus)
            => cardType == CardType.Debit && cardStatus == CardStatus.Expired;

        public IReadOnlyCollection<string> GetAllowedActions(CardDetails card)
            => ["ACTION3", "ACTION8"];
    }
}
