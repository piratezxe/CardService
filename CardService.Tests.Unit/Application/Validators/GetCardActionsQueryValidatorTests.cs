using CardService.Application.Features.CardsActions.Queries;
using CardService.Application.Features.CardsActions.Validators;
using FluentValidation.TestHelper;

namespace CardService.Tests.Unit.Application.Validators
{
    public class GetCardActionsQueryValidatorTests
    {
        private readonly GetCardActionsQueryValidator _validator = new();

        [Theory]
        [InlineData(" ", "4111111111111111", false, "User ID is required")]
        [InlineData("", "4111111111111111", false, "User ID is required")]
        [InlineData("user1", "", false, "Card number is required")]
        [InlineData("user1", " ", false, "Card number is required")]
        [InlineData("user1", "4111111111111111", true)]
        public void Validate_Query(
            string userId,
            string cardNumber,
            bool isValid,
            string? errorMessage = null)
        {
            var query = new GetCardActionsQuery(userId, cardNumber);

            var result = _validator.TestValidate(query);

            if (isValid)
            {
                result.ShouldNotHaveAnyValidationErrors();
            }
            else
            {
                if (userId == null || string.IsNullOrEmpty(userId))
                {
                    result.ShouldHaveValidationErrorFor(x => x.UserId)
                        .WithErrorMessage(errorMessage!);
                }
                else if (cardNumber == null)
                {
                    result.ShouldHaveValidationErrorFor(x => x.CardNumber)
                        .WithErrorMessage(errorMessage!);
                }
            }
        }
    }
}
