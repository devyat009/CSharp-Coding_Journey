using CSharpJourney.Helpers;

namespace CSharpJourney.Services
{
    public static class MathMenuService
    {
        public static void MenuMath()
        {
            bool inputUser = false;
            int userInput = 0;
            while (!inputUser)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Clear();
                Console.WriteLine($"\u250F{new string('\u2501', 3)}\u257e Menu de Matemática \u257c{new string('\u2501', 3)}\u2513");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"1 - Soma".PadRight(26)}\u2503");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"2 - Subtração".PadRight(26)}\u2503");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"3 - Divisão".PadRight(26)}\u2503");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"4 - Multiplicação".PadRight(26)}\u2503");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"5 - Potencia".PadRight(26)}\u2503");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"6 - Tabuada".PadRight(26)}\u2503");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"0 - Voltar".PadRight(26)}\u2503");
                Console.WriteLine($"\u2517{new string('\u2501', 28)}\u251b");
                Console.Write("\u25b8 Escolha: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            Console.Clear();
                            MenuMathSoma();
                            Console.WriteLine("Pressione qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            MenuMathSubtracao();
                            Console.WriteLine("Pressione qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            MenuMathDivisao();
                            Console.WriteLine("Pressione qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            MenuMathMultiplicacao();
                            Console.WriteLine("Pressione qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            MenuMathPotencia();
                            Console.WriteLine("Pressione qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 6:
                            Console.Clear();
                            MenuMathTabuada();
                            Console.WriteLine("Pressione qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 0:
                            inputUser = true;
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
        // Menu Soma
        public static void MenuMathSoma()
        {
            double x = 0, y = 0;
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("\u25b8 Digite o primeiro número para somar: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && double.TryParse(input, out x))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente Novamente.");
                }
            }
            validInput = false;
            while (!validInput)
            {
                Console.WriteLine("\u25b8 Digite o segundo número para somar: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && double.TryParse(input, out y))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente Novamente.");
                }
            }
            Console.WriteLine($"\u25b8 A soma de {x} mais {y} é: {MathHelper.Soma(x, y)}");
        }
        // Menu Subtracao
        public static void MenuMathSubtracao()
        {
            double x = 0, y = 0;
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("\u25b8 Digite o primeiro número para subtrair: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && double.TryParse(input, out x))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente Novamente.");
                }
            }
            validInput = false;
            while (!validInput)
            {
                Console.WriteLine("\u25b8 Digite o segundo número para subtrair: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && double.TryParse(input, out y))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente Novamente.");
                }
            }
            Console.WriteLine($"\u25b8 A subtração de {x} mais {y} é: {MathHelper.Subtracao(x, y)}");
        }
        // Menu Divisao
        public static void MenuMathDivisao()
        {
            double x = 0, y = 0;
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("\u25b8 Digite o primeiro número para dividr: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && double.TryParse(input, out x))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente Novamente.");
                }
            }
            validInput = false;
            while (!validInput)
            {
                Console.WriteLine("\u25b8 Digite o segundo número para dividir: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && double.TryParse(input, out y))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("\u25b8 Entrada inválida. Tente Novamente.");
                }
            }
            Console.WriteLine($"\u25b8 A divisão de {x} mais {y} é: {MathHelper.Divisao(x, y)}");
        }
        // Menu Multiplicação
        public static void MenuMathMultiplicacao()
        {
            double x = 0, y = 0;
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("\u25b8 Digite o primeiro número para multiplicar: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && double.TryParse(input, out x))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente Novamente.");
                }
            }
            validInput = false;
            while (!validInput)
            {
                Console.WriteLine("\u25b8 Digite o segundo número para multiplicar: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && double.TryParse(input, out y))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente Novamente.");
                }
            }
            Console.WriteLine($"\u25b8 A multiplicação de {x} mais {y} é: {MathHelper.Multiplicacao(x, y)}");
        }
        // Menu Potência
        public static void MenuMathPotencia()
        {
            double x = 0, y = 0;
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("\u25b8 Digite o primeiro número: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && double.TryParse(input, out x))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente Novamente.");
                }
            }
            validInput = false;
            while (!validInput)
            {
                Console.WriteLine("\u25b8 Digite o segundo número para a potência: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && double.TryParse(input, out y))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente Novamente.");
                }
            }
            Console.WriteLine($"\u25b8 A potência de {x} sobre {y} é: {MathHelper.Potencia(x, y)}");
        }
        // Menu tabuada
        public static void MenuMathTabuada()
        {
            double x = 0;
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("\u25b8 Digite o número que queira saber a tabuada: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && double.TryParse(input, out x))
                {
                    validInput = true;
                    List<string> result = MathHelper.Tabuada(x);
                    foreach (var i in result)
                    {
                        Console.WriteLine(i);
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente Novamente.");
                }
            }
        }
    }
}
