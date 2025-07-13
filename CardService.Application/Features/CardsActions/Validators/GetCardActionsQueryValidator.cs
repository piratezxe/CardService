using CardService.Application.Features.CardsActions.Queries;
using FluentValidation;

namespace CardService.Application.Features.CardsActions.Validators
{
    public class GetCardActionsQueryValidator : AbstractValidator<GetCardActionsQuery>
    {
        public GetCardActionsQueryValidator()
        {
            RuleFor(query => query.UserId)
                .NotEmpty()
                .WithMessage("User ID is required");

            RuleFor(query => query.CardNumber)
                .NotEmpty()
                .WithMessage("Card number is required");
        }
    }
}
