namespace CodingChallenge.API.Services;

public interface IExchangeService
{
    public Task<decimal> GetExchangeRate(string inputCurrency, string outputCurrency);
}