
using Files.core.Services;
namespace CSharpJourney
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //string password = "12345678Gh@";
            //try
            //{
            //    PasswordValidatorService.ValidarComprimento(password);
            //    PasswordValidatorService.ValidarMaiusculoMinusculo(password);
            //    PasswordValidatorService.ValidarCaractereEspecial(password);
            //    PasswordValidatorService.ValidarCaractereNumerico(password);
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine($"Erro: {ex.Message}");
            //}
            // Chamada da interface MathMenuService
            // MathMenuService.MenuMath(); 

            // Chamada da interface DollarAPiMenuService
            //DollarApiMenuService.MenuApiDollar();
            MenuPrincipal();
        }

        public static void MenuPrincipal()
        {
            bool inputUser = false;
            int userInput = 0;
            while (!inputUser)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Clear();
                Console.WriteLine($"\u250F{new string('\u2501', 7)}\u257e Menu \u257c{new string('\u2501', 7)}\u2513");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"1 - Calculadora".PadRight(20)}\u2503");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"2 - Api Dolar".PadRight(20)}\u2503");
                Console.WriteLine($"\u2503{new string(' ', 2)}{"3 - NULL".PadRight(20)}\u2503");
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
    }
}