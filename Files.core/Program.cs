using CSharpJourney.Services;
namespace CSharpJourney
{
    public static class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        public static void MenuPrincipal()
        {
            int userInput = 0;
            while (true)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Clear();
                Console.WriteLine($"\u250F{new string('\u2501', 7)}\u257e Menu \u257c{new string('\u2501', 7)}\u2513");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"1 - Calculadora".PadRight(20)}\u2503");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"2 - Api Dolar".PadRight(20)}\u2503");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"3 - Validar Senha".PadRight(20)}\u2503");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"0 - Voltar".PadRight(20)}\u2503");
                Console.WriteLine($"\u2517{new string('\u2501', 22)}\u251b");
                Console.Write("\u25b8 Escolha: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            Console.Clear();
                            MathMenuService.MenuMath();
                            Console.WriteLine("Pressione qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            Task.Run(async () => await DollarApiMenuService.DollarApiMenu()).GetAwaiter().GetResult();
                            Console.WriteLine("Pressione qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Digite uma senha forte que contenha:");
                            Console.WriteLine("1 - Mínimo 8 Caracteres");
                            Console.WriteLine("2 - Deve conter pelo menos 1 maiúsculo e 1 minúsculo");
                            Console.WriteLine("3 - Deve conter pelo menos 1 caractere especial");
                            Console.WriteLine("4 - Deve conter pelo menos 1 caractere numérico");
                            Console.Write("Digite uma senha forte:");
                            string? password = Console.ReadLine();
                            if (!string.IsNullOrEmpty(password))
                            {
                                try
                                {
                                    PasswordValidatorService.ValidarComprimento(password);
                                    PasswordValidatorService.ValidarMaiusculoMinusculo(password);
                                    PasswordValidatorService.ValidarCaractereEspecial(password);
                                    PasswordValidatorService.ValidarCaractereNumerico(password);
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine($"Erro: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida. Tente Novamente.");
                            }
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
    }
}