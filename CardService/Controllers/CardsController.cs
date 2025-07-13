using CardService.Application.Features.CardsActions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CardService.Web.Controllers
{
    [ApiController]
    [Route("api/cards")]
    public class CardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Pobiera listę dozwolonych akcji dla karty
        /// </summary>
        /// <remarks>
        /// Przykładowe żądanie:
        /// ```
        /// GET /api/cards/actions?userId=usr_123&cardNumber=4111111111111111
        /// </remarks>
        /// <param name="request">Parametry żądania</param>
        /// <response code="200">Zwraca listę dozwolonych akcji</response>
        /// <response code="400">Błędne dane wejściowe (np. nieprawidłowy numer karty)</response>
        /// <response code="404">Karta nie znaleziona</response>
        /// <response code="401">Brak autoryzacji</response>
        [HttpGet("actions")]
        [ProducesResponseType(typeof(CardActionsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCardActions([FromQuery] GetCardActionsQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
