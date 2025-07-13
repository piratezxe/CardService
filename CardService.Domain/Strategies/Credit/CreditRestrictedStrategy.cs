namespace CardService.Domain.Strategies.Credit
{
    public class CreditRestrictedStrategy : IActionStrategy
    {
        public bool CanHandle(CardType cardType, CardStatus cardStatus)
            => cardType == CardType.Credit && cardStatus == CardStatus.Restricted;

        public IReadOnlyCollection<string> GetAllowedActions(CardDetails card)
            => ["ACTION4", "ACTION5", "ACTION8", "ACTION9"];
    }
}
