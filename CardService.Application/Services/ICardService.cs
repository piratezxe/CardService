using CardService.Domain;

namespace CardService.Application.Services
{
    public interface ICardService
    {
        public Task<CardDetails?> GetCardDetails(
            string userId,
            string cardNumber);
    }
}
