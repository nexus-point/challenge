namespace CodingChallenge.API.DTOs;

public class ResponseDto
{
    public required decimal Amount { get; set; }
    public required string InputCurrency { get; set; }
    public required string OutputCurrency { get; set; }
    public required decimal Value { get; set; }
}