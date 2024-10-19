namespace CSharpJourney.Services
{
    public static class DollarApiMenuService
    {
        public static async Task DollarApiMenu()
        {
            await DollarApiService.DollarApiRun();
            DollarApiService.DollarValue();
            float dolar = DollarApiService.dollarValue;
            int userInput = 0;
            while (true)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Clear();
                Console.WriteLine($"\u250F{new string('\u2501', 9)}\u257e Menu de API \u257c{new string('\u2501', 9)}\u2513");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"1 - Cotação Dolar".PadRight(31)}\u2503");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"2 - Converção Dolar para Real".PadRight(31)}\u2503");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"3 - Converção Real para Dolar".PadRight(31)}\u2503");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"0 - Voltar".PadRight(31)}\u2503");
                Console.WriteLine($"\u2517{new string('\u2501', 33)}\u251b");
                Console.Write("\u25b8 Escolha: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine($"O dolar esta sendo cotado a: R${dolar:F2}");
                            Console.WriteLine("Pressione qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            ConversionDollarToRealMenu();
                            Console.WriteLine("Pressione qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            ConversionRealToDollarMenu();
                            Console.WriteLine("Pressione qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 0:
                            return;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Tente Novamente.");
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                }
            }
        }
        public static void ConversionDollarToRealMenu()
        {
            bool inputUser = false;
            float userInput = 0;
            while (!inputUser)
            {
                Console.Write("Digite a quantidade de Dolares para converter: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && float.TryParse(input, out userInput))
                {
                    float value = DollarApiService.ConversionDollarToReal(userInput);
                    Console.WriteLine($"A quantidade de ${userInput} em Reais equivale a: R${value:F2}");
                    inputUser = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente Novamente.");
                }
            }
        }
        public static void ConversionRealToDollarMenu()
        {
            bool inputUser = false;
            float userInput = 0;
            while (!inputUser)
            {
                Console.Write("Digite a quantidade de Reais para converter: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && float.TryParse(input, out userInput))
                {
                    float value = DollarApiService.ConversionRealToDollar(userInput);
                    Console.WriteLine($"A quantidade de R${userInput} em Dolares equivale a: ${value:F2}");
                    inputUser = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente Novamente.");
                }
            }
        }

    }
}
