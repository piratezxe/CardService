namespace CardService.Domain.Strategies
{
    public interface IActionStrategyFactory
    {
        IActionStrategy GetStrategy(
            CardType cardType,
            CardStatus cardStatus);
    }
}
