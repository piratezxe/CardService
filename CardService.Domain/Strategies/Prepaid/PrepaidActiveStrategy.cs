namespace CardService.Domain.Strategies.Prepaid
{
    public class PrepaidActiveStrategy : IActionStrategy
    {
        public bool CanHandle(CardType cardType, CardStatus cardStatus)
            => cardType == CardType.Prepaid && cardStatus == CardStatus.Active;

        public IReadOnlyCollection<string> GetAllowedActions(CardDetails card)
        {
            var actions = new List<string> { "ACTION1", "ACTION3", "ACTION9" };
            if (card.IsPinSet)
            {
                actions.Add("ACTION5");
            }
            return actions;
        }
    }
}
