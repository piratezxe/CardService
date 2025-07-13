namespace CardService.Domain.Strategies
{
    public class ActionStrategyFactory : IActionStrategyFactory
    {
        private readonly IEnumerable<IActionStrategy> _strategies;

        public ActionStrategyFactory(IEnumerable<IActionStrategy> strategies)
        {
            _strategies = strategies;
        }

        public IActionStrategy GetStrategy(
            CardType cardType,
            CardStatus cardStatus)
        {
            var strategy = _strategies
                .FirstOrDefault(strategy => strategy.CanHandle(
                    cardType,
                    cardStatus));

            return strategy ?? throw new NotSupportedException($"No strategy for {cardType}/{cardStatus}");
        }
    }
}
