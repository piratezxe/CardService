namespace CardService.Domain.Strategies.Credit
{
    public class CreditExpiredStrategy : IActionStrategy
    {
        public bool CanHandle(CardType cardType, CardStatus cardStatus)
            => cardType == CardType.Credit && cardStatus == CardStatus.Expired;

        public IReadOnlyCollection<string> GetAllowedActions(CardDetails card)
            => ["ACTION3", "ACTION8", "ACTION9"];
    }
}
