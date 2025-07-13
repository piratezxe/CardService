using CardService.Domain;
using CardService.Domain.Strategies.Debit;
using FluentAssertions;

namespace CardService.Tests.Unit.Domain.Strategies
{
    public class DebitStrategiesTests
    {
        [Theory]
        [InlineData(false, new[] { "ACTION1", "ACTION2", "ACTION3", "ACTION6" })]
        [InlineData(true, new[] { "ACTION1", "ACTION2", "ACTION3", "ACTION6", "ACTION7" })]
        public void DebitActiveStrategy_ReturnsCorrectActions(bool isPinSet, string[] expected)
        {
            var card = new CardDetails("1", CardType.Debit, CardStatus.Active, isPinSet);
            var strategy = new DebitActiveStrategy();

            var result = strategy.GetAllowedActions(card);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void DebitBlockedStrategy_ReturnsFixedActions(bool isPinSet)
        {
            var card = new CardDetails("1", CardType.Debit, CardStatus.Blocked, isPinSet);
            var strategy = new DebitBlockedStrategy();

            var result = strategy.GetAllowedActions(card);

            result.Should().BeEquivalentTo(["ACTION3", "ACTION4", "ACTION8"]);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void DebitExpiredStrategy_ReturnsFixedActions(bool isPinSet)
        {
            var card = new CardDetails("1", CardType.Debit, CardStatus.Expired, isPinSet);
            var strategy = new DebitExpiredStrategy();

            var result = strategy.GetAllowedActions(card);

            result.Should().BeEquivalentTo(["ACTION3", "ACTION8"]);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void DebitRestrictedStrategy_ReturnsFixedActions(bool isPinSet)
        {
            var card = new CardDetails("1", CardType.Debit, CardStatus.Restricted, isPinSet);
            var strategy = new DebitRestrictedStrategy();

            var result = strategy.GetAllowedActions(card);

            result.Should().BeEquivalentTo(["ACTION4", "ACTION5", "ACTION8"]);
        }
    }
}
