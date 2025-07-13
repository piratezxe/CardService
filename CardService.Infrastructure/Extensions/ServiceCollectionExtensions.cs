using CardService.Application.Features.CardsActions.Queries;
using CardService.Application.Features.CardsActions.Validators;
using CardService.Application.Services;
using CardService.Domain.Strategies;
using CardService.Domain.Strategies.Credit;
using CardService.Domain.Strategies.Debit;
using CardService.Domain.Strategies.Prepaid;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyCardService = CardService.Application.Services.CardService;

namespace CardService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(GetCardActionsQuery).Assembly));

            services.AddScoped<IActionStrategy, PrepaidActiveStrategy>();
            services.AddScoped<IActionStrategy, PrepaidClosedStrategy>();
            services.AddScoped<IActionStrategy, PrepaidOrderedStrategy>();
            services.AddScoped<IActionStrategy, PrepaidExpiredStrategy>();
            services.AddScoped<IActionStrategy, PrepaidRestrictedStrategy>();

            services.AddScoped<IActionStrategy, DebitActiveStrategy>();
            services.AddScoped<IActionStrategy, DebitBlockedStrategy>();
            services.AddScoped<IActionStrategy, DebitExpiredStrategy>();
            services.AddScoped<IActionStrategy, DebitRestrictedStrategy>();

            services.AddScoped<IActionStrategy, CreditBlockedStrategy>();
            services.AddScoped<IActionStrategy, CreditExpiredStrategy>();
            services.AddScoped<IActionStrategy, CreditRestrictedStrategy>();

            services.AddScoped<IActionStrategyFactory, ActionStrategyFactory>();

            services.AddScoped<ICardService, MyCardService>();

            services.AddScoped<IValidator<GetCardActionsQuery>, GetCardActionsQueryValidator>();

            return services;
        }
    }
}
