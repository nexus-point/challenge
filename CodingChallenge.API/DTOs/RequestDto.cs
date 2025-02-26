namespace CodingChallenge.API.DTOs;

public class RequestDto
{
    public required decimal Amount { get; set; }
    public required string InputCurrency { get; set; }
    public required string OutputCurrency { get; set; }
}