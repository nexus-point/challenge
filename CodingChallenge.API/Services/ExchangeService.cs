using System.Text.Json;

namespace CodingChallenge.API.Services;

public class ExchangeService(IConfiguration configuration, HttpClient httpClient) : IExchangeService
{
    public async Task<decimal> GetExchangeRate(string inputCurrency, string outputCurrency)
    {
        var apiHost = configuration["ExchangeRateApiHost"];
        var apiKey = configuration["ExchangeRateApiKey"];

        if (string.IsNullOrWhiteSpace(apiHost) || string.IsNullOrWhiteSpace(apiKey))
        {
            throw new Exception("API host or key is missing from the configuration.");
        }

        var requestUrl = $"{apiHost}{apiKey}/latest/{inputCurrency}";
        var response = await httpClient.GetAsync(requestUrl);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"ExchangeRate API request failed: {response.StatusCode}");
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        var exchangeData = JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent);
        
        if (exchangeData == null || !exchangeData.TryGetValue("conversion_rates", out var conversionRates) || 
            !(conversionRates is JsonElement ratesElement) || !ratesElement.TryGetProperty(outputCurrency, out var rate))
        {
            throw new Exception("Exchange rate data is invalid or missing.");
        }

        return rate.GetDecimal();
    }
}