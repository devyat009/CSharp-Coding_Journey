
using Atividade._01;
using Atividade._02;
using Atividade._03;
using Atividade._04;
namespace Atividade
{
    public static class MenuSelection
    {
       public static async Task Main()
        {
            bool continuar = true;
            bool leitura_input = true;
            while (continuar)
            {
                while (leitura_input)
                {
                    // Menu
                    Console.Clear();
                    Console.WriteLine("Menu Atividades");
                    Console.WriteLine("1 - Hello World, input, operações matemáticas básicas e tabuada");
                    Console.WriteLine("2 - API de Conversão de dolar e real");
                    Console.WriteLine("3 - Manipulação de Lista");
                    Console.WriteLine("4 - Unit Testing (NUnit)");
                    Console.WriteLine("0 - SAIR");
                    Console.Write("Escolha - ");
                    string? opcao = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(opcao))
                    {
                        Console.WriteLine("Error MenuSelection");
                        Console.WriteLine("Entrada inválida, tente novamente...");
                        Console.ReadKey();
                        continue;
                    }
                    switch (opcao)
                    {
                        case "1":
                            leitura_input = false;
                            ProgramMenu.atividade_01_menu();
                            break;
                        case "2":
                            leitura_input = false;
                            await Dolarapi.apitask();
                            break;
                        case "3":
                            Atividade03.atividade_03_menu();
                            Console.ReadKey();
                            continue;
                        case "4":
                            //For True
                            //var Testinstance = new TestuN();
                            //Console.WriteLine("Testing True...");
                            //Testinstance.test_true();
                            //Console.WriteLine("Testing False...");
                            //Testinstance.test_false();
                            var Testinstance = new UNTest01();  // Instancia da classe UNTest01
                            Console.WriteLine("Testing True...");
                            var resultTrue = Testinstance.TrueTest(1);  // Testando TrueTest
                            Console.WriteLine($"Resultado TrueTest(1): {resultTrue}");
                            Console.WriteLine("Testing False...");
                            var resultFalse = Testinstance.TrueTest(-1);  // Testando TrueTest
                            Console.WriteLine($"Resultado TrueTest(-1): {resultFalse}");
                            Console.ReadKey(); // Pausa para ver os resultados
                            break;
                        case "0":
                            Console.WriteLine("Saindo...");
                            continuar = false;
                            leitura_input = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida, tente novamente Menu Principamente...");
                            break;
                    }
                }
            }
            //var Testinstance0 = new TestuN();
            //Testinstance0.test_true();
            //Testinstance0.test_false();
            //Console.WriteLine("O processo fechou");
            //Console.ReadKey();
        }
    }
}