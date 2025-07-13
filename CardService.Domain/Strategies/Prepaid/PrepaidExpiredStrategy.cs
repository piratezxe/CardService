namespace CardService.Domain.Strategies.Prepaid
{

    public class PrepaidExpiredStrategy : IActionStrategy
    {
        public bool CanHandle(CardType cardType, CardStatus cardStatus)
            => cardType == CardType.Prepaid && cardStatus == CardStatus.Expired;

        public IReadOnlyCollection<string> GetAllowedActions(CardDetails card)
            => ["ACTION3", "ACTION4", "ACTION9"];
    }
}
