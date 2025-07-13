using CardService.Domain;
using CardService.Domain.Strategies.Prepaid;
using FluentAssertions;

namespace CardService.Tests.Unit.Domain.Strategies
{
    public class PrepaidStrategiesTests
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void PrepaidClosedStrategy_ReturnsFixedActions(bool isPinSet)
        {
            var card = new CardDetails("1", CardType.Prepaid, CardStatus.Closed, isPinSet);
            var strategy = new PrepaidClosedStrategy();

            var result = strategy.GetAllowedActions(card);

            result.Should().BeEquivalentTo(["ACTION3", "ACTION4", "ACTION9"]);
        }

        [Theory]
        [InlineData(false, new[] { "ACTION1", "ACTION3", "ACTION9" })]
        [InlineData(true, new[] { "ACTION1", "ACTION3", "ACTION5", "ACTION9" })]
        public void PrepaidActiveStrategy_ReturnsCorrectActions(bool isPinSet, string[] expected)
        {
            var card = new CardDetails("1", CardType.Prepaid, CardStatus.Active, isPinSet);
            var strategy = new PrepaidActiveStrategy();

            var result = strategy.GetAllowedActions(card);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void PrepaidOrderedStrategy_ReturnsFixedActions()
        {
            var card = new CardDetails("1", CardType.Prepaid, CardStatus.Ordered, false);
            var strategy = new PrepaidOrderedStrategy();

            var result = strategy.GetAllowedActions(card);

            result.Should().BeEquivalentTo(["ACTION10", "ACTION11"]);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void PrepaidExpiredStrategy_ReturnsFixedActions(bool isPinSet)
        {
            var card = new CardDetails("1", CardType.Prepaid, CardStatus.Expired, isPinSet);
            var strategy = new PrepaidExpiredStrategy();

            var result = strategy.GetAllowedActions(card);

            result.Should().BeEquivalentTo(["ACTION3", "ACTION4", "ACTION9"]);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void PrepaidRestrictedStrategy_ReturnsFixedActions(bool isPinSet)
        {
            var card = new CardDetails("1", CardType.Prepaid, CardStatus.Restricted, isPinSet);
            var strategy = new PrepaidRestrictedStrategy();

            var result = strategy.GetAllowedActions(card);

            result.Should().BeEquivalentTo(["ACTION4", "ACTION5", "ACTION9"]);
        }
    }
}
