using CSharpJourney.core.Services;
using Xunit.Abstractions;

namespace programT.tests
{
    public class UnitTestApiDollar
    {
        private readonly ITestOutputHelper _output;
        // Usado para ter um output no Test Summary.
        public UnitTestApiDollar(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact(DisplayName = "Obter Cotação Dolar")]
        public async Task TestApiCotacaoDolar()
        {
            await DollarApiService.DollarApiRun();
            DollarApiService.DollarValue();
            float dollar = DollarApiService.dollarValue;
            Assert.NotEqual(0, dollar);

            _output.WriteLine($"O valor do dólar retornado é: {dollar:F2}");
        }

        [Fact(DisplayName = "Converção dolar para real")]
        public async Task TestApiConversionDolarToReal()
        {
            await DollarApiService.DollarApiRun();
            DollarApiService.DollarValue();
            float result = DollarApiService.ConversionDollarToReal(10);
            Assert.NotEqual(0, result);

            _output.WriteLine($"O valor de $10 dolares para reais retornado é: {result:F2}");
        }

        [Fact(DisplayName = "Converção real para dolar")]
        public async Task TestApiConversionRealToDolar()
        {
            await DollarApiService.DollarApiRun();
            DollarApiService.DollarValue();
            float result = DollarApiService.ConversionRealToDollar(50);
            Assert.NotEqual(0, result);

            _output.WriteLine($"O valor de R$50 reais para dolares retornado é: ${result:F2}");
        }
    }
}
