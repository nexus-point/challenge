using CodingChallenge.API.Services;
using NSubstitute;

namespace CodingChallenge.API.Tests
{
    public class ExchangeServiceTests
    {
        [Fact]
        public async Task Mock_GetExchangeRate_ShouldReturnMockedRate()
        {
            // Arrange
            var exchangeServiceMock = Substitute.For<IExchangeService>();
            exchangeServiceMock.GetExchangeRate( "AUD", "USD").Returns(3.175m);

            // Act
            var result = await exchangeServiceMock.GetExchangeRate( "AUD","USD");

            // Assert
            Assert.Equal(3.175m, result);
            await exchangeServiceMock.Received(1).GetExchangeRate( "AUD","USD");
        }
    }
}
