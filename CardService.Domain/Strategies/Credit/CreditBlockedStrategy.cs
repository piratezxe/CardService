namespace CardService.Domain.Strategies.Credit
{
    public class CreditBlockedStrategy : IActionStrategy
    {
        public bool CanHandle(CardType cardType, CardStatus cardStatus)
            => cardType == CardType.Credit && cardStatus == CardStatus.Blocked;

        public IReadOnlyCollection<string> GetAllowedActions(CardDetails card)
        {
            var actions = new List<string> { "ACTION3", "ACTION4", "ACTION5", "ACTION8", "ACTION9" };

            if (card.IsPinSet)
            {
                actions.AddRange(["ACTION6", "ACTION7"]);
            }
            return actions;
        }
    }
}
