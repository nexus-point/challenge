using CodingChallenge.API.DTOs;
using CodingChallenge.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.API.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
public class ExchangeServiceController(IExchangeService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ConvertCurrency([FromBody] RequestDto request)
    {
        var exchangeRate = await service.GetExchangeRate(request.InputCurrency, request.OutputCurrency);
        var convertedValue = request.Amount * exchangeRate;
        
        var response = new ResponseDto
        {
            Amount = request.Amount,
            InputCurrency = request.InputCurrency,
            OutputCurrency = request.OutputCurrency,
            Value = convertedValue
        };
        
        return Ok(response);
    }
}