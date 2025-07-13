using CardService.Domain;
using CardService.Domain.Strategies.Credit;
using FluentAssertions;

namespace CardService.Tests.Unit.Domain.Strategies
{
    public class CreditStrategiesTests
    {
        [Theory]
        [InlineData(false, new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION8", "ACTION9" })]
        [InlineData(true, new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION7", "ACTION8", "ACTION9" })]
        public void CreditBlockedStrategy_ReturnsCorrectActions(bool isPinSet, string[] expected)
        {
            var card = new CardDetails("1", CardType.Credit, CardStatus.Blocked, isPinSet);
            var strategy = new CreditBlockedStrategy();

            var result = strategy.GetAllowedActions(card);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void CreditExpiredStrategy_ReturnsFixedActions(bool isPinSet)
        {
            var card = new CardDetails("1", CardType.Credit, CardStatus.Expired, isPinSet);
            var strategy = new CreditExpiredStrategy();

            var result = strategy.GetAllowedActions(card);

            result.Should().BeEquivalentTo(["ACTION3", "ACTION8", "ACTION9"]);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void CreditRestrictedStrategy_ReturnsFixedActions(bool isPinSet)
        {
            var card = new CardDetails("1", CardType.Credit, CardStatus.Restricted, isPinSet);
            var strategy = new CreditRestrictedStrategy();

            var result = strategy.GetAllowedActions(card);

            result.Should().BeEquivalentTo(["ACTION4", "ACTION5", "ACTION8", "ACTION9"]);
        }
    }
}
