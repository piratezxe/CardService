namespace CardService.Domain.Strategies.Debit
{
    public class DebitActiveStrategy : IActionStrategy
    {
        public bool CanHandle(CardType cardType, CardStatus cardStatus)
            => cardType == CardType.Debit && cardStatus == CardStatus.Active;

        public IReadOnlyCollection<string> GetAllowedActions(CardDetails card)
        {
            var actions = new List<string> { "ACTION1", "ACTION2", "ACTION3", "ACTION6" };
            if (card.IsPinSet)
            {
                actions.Add("ACTION7");
            }
            return actions;
        }
    }
}
