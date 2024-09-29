
using Atividade._01;
using Atividade._02;
using Atividade._03;
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
                    Console.WriteLine("1 - Hello World, input, opera��es matem�ticas b�sicas e tabuada");
                    Console.WriteLine("2 - API de Convers�o de dolar e real");
                    Console.WriteLine("3 - Manipula��o de Lista");
                    Console.WriteLine("0 - SAIR");
                    Console.Write("Escolha - ");
                    string? opcao = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(opcao))
                    {
                        Console.WriteLine("Error MenuSelection");
                        Console.WriteLine("Entrada inv�lida, tente novamente...");
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
                        case "0":
                            Console.WriteLine("Saindo...");
                            continuar = false;
                            leitura_input = false;
                            break;
                        default:
                            Console.WriteLine("Op��o inv�lida, tente novamente Menu Principamente...");
                            break;
                    }
                }
            }

        }
    }
}