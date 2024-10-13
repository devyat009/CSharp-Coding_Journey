using CSharpJourney.core.Helpers;
using Xunit.Abstractions;

namespace programT.tests
{
    public class UnitTestMath
    {
        private readonly ITestOutputHelper _output;
        public UnitTestMath(ITestOutputHelper output)
        {
            _output = output;
        }
        // Test Soma
        [Fact(DisplayName = "Soma: 10+20 = 30")]
        public void TestMath01Soma()
        {
            double result = MathHelper.Soma(10, 20);
            Assert.Equal(30, result);
            _output.WriteLine($"O valor da soma retornado é: {result}");
        }

        // Test Subtração
        [Fact(DisplayName = "Subtração: 10-20 = -10")]
        public void TestMath02Subtracao()
        {
            double result = MathHelper.Subtracao(10, 20);
            Assert.Equal(-10, result);
            _output.WriteLine($"O valor da subtração retornado é: {result}");
        }

        // Test Divisão
        [Fact(DisplayName = "Divisão: 30/2 = 15")]
        public void TestMath03Divisao()
        {
            double result = MathHelper.Divisao(30, 2);
            Assert.Equal(15, result);
            _output.WriteLine($"O valor da divisão retornado é: {result}");
        }

        // Test Multiplicação
        [Fact(DisplayName = "Multiplicação: 45*2 = 90")]
        public void TestMath04Multiplicacao()
        {
            double result = MathHelper.Multiplicacao(45, 2);
            Assert.Equal(90, result);
            _output.WriteLine($"O valor da multiplicação retornado é: {result}");
        }

        // Test Potência

        [Fact(DisplayName = "Potência: 3^3 = 27")]
        public void TestMath05Potencia()
        {
            double result = MathHelper.Potencia(3, 3);
            Assert.Equal(27, result);
            _output.WriteLine($"O valor da potência retornado é: {result}");
        }

        // Test Tabuada
        [Fact(DisplayName = "Tabuada: 4")]
        
        public void TestMath06PTabuada()
        {
            List<string> expectedList = new List<string>
            {
                "4 X 0 = 0",
                "4 X 1 = 4",
                "4 X 2 = 8",
                "4 X 3 = 12",
                "4 X 4 = 16",
                "4 X 5 = 20",
                "4 X 6 = 24",
                "4 X 7 = 28",
                "4 X 8 = 32",
                "4 X 9 = 36",
                "4 X 10 = 40"
            };
            List<string> actualList = MathHelper.Tabuada(4);
            Assert.Equal(expectedList, actualList);
            _output.WriteLine($"O valor da potência retornado é: \n{string.Join("\n", actualList)}");
        }
    }
}