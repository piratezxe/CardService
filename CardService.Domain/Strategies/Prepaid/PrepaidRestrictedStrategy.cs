namespace CardService.Domain.Strategies.Prepaid
{
    public class PrepaidRestrictedStrategy : IActionStrategy
    {
        public bool CanHandle(CardType cardType, CardStatus cardStatus)
            => cardType == CardType.Prepaid && cardStatus == CardStatus.Restricted;

        public IReadOnlyCollection<string> GetAllowedActions(CardDetails card)
            => ["ACTION4", "ACTION5", "ACTION9"];
    }
}
