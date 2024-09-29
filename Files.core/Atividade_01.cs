namespace Atividade._01
{
    public static class ProgramMenu
    {
        // Funções:
        // Menu
        public static void atividade_01_menu()
        {
            bool continuar = true;
            while (continuar)
            {
                // Mostrar o menu
                
                Console.WriteLine("Menu de Atividade\n 1 - Hello World\n 2 - Input\n 3 - Múltiplos input\n 4 - Operações Matemáticas\n 5 - Tabuada\n 0 - SAIR");
                string? opcao = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(opcao))
                {
                    Console.WriteLine("Entrada inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }
                if (opcao == "1")
                {
                    Console.WriteLine("Opção 1 Selecionada\n");
                    helloworld();
                    Console.WriteLine($"\nPrecisone qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                else if (opcao == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Opção 2 Selecionada");
                    Console.WriteLine("Digite algo:");
                    string? input_usuario = Console.ReadLine();
                    if (input_usuario == null)
                    {
                        Console.WriteLine("Você não digitou nada, tente novamente...");
                    }
                    else
                    {
                        inputF(input_usuario);
                    }
                    Console.WriteLine($"\nPrecisone qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                else if (opcao == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Opção 3 Selecionada");
                    string? nome;
                    do
                    {
                        Console.WriteLine("Digite seu nome:");
                        nome = Console.ReadLine();
                        if (string.IsNullOrEmpty(nome))
                        {
                            Console.WriteLine("Entrada inválida! Tente novamente.");
                            nome = null;
                        }
                    } while (string.IsNullOrEmpty(nome));
                    string? idade;
                    do
                    {
                        Console.WriteLine("Digite sua idade:");
                        idade = Console.ReadLine();
                    } while (string.IsNullOrEmpty(idade));
                    multiplosInput(nome, idade);
                    Console.WriteLine($"\nPrecisone qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                else if (opcao == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Opção 4 Selecionada");
                    string? a;
                    do
                    {
                        Console.WriteLine("Insira o primeiro número:");
                        a = Console.ReadLine();
                        if (string.IsNullOrEmpty(a))
                        {
                            Console.WriteLine("Entrada inválida! Tente novamente.");
                            a = null;
                        }
                    } while (string.IsNullOrEmpty(a));

                    string? b;
                    do
                    {
                        Console.WriteLine("Insira o segundo número:");
                        b = Console.ReadLine();
                        if (string.IsNullOrEmpty(b))
                        {
                            Console.WriteLine("Entrada inválida! Tente novamente.");
                        }
                    } while (string.IsNullOrEmpty(b));

                    double numeroA = double.Parse(a);
                    double numeroB = double.Parse(b);

                    matematicaBasica(numeroA, numeroB);
                    Console.WriteLine($"\nPrecisone qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                else if (opcao == "5")
                {
                    Console.Clear();
                    Console.WriteLine("Opção 5 Selecionada");
                    string? input;
                    do
                    {
                        Console.WriteLine("Digite um número na qual queira sabe a tabuada:");
                        input = Console.ReadLine();
                        if (string.IsNullOrEmpty(input))
                        {
                            Console.WriteLine("Entrada inválida! Tente Novamente.");
                        }
                    } while (string.IsNullOrEmpty(input));
                    double numero = double.Parse(input);
                    Console.WriteLine(); // Linha vazia
                    tabuada(numero);
                    Console.WriteLine($"\nPrecisone qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                else if (opcao == "0")
                {
                    Console.WriteLine("Saindo...");
                    continuar = false; // Para o while
                    MenuSelection.Main();
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                // Linha vazia
                Console.WriteLine();
            }
        }
        // HelloWorld
        private static void helloworld()
        {
            Console.WriteLine("Hello World!");
        }
        // Único Input
        private static void inputF(string qualquercoisa)
        {
            Console.WriteLine($"\nVocê digitou: {qualquercoisa}");
        }
        // Múltiplos Input
        private static void multiplosInput(string nome, string idade)
        {
            Console.WriteLine($"\nSeu nome é {nome} e sua idade é {idade}");
        }
        // Matematica Básica
        private static void matematicaBasica(double a, double b)
        {
            double soma = a + b;
            double subtracao = a - b;
            double multiplicacao = a * b;
            double quadradoA = a * a;
            double quadradoB = b * b;
            double divisao = a/b;
            Console.Write($"\nResultados:\n\nSoma: {soma}\nSubtração: {subtracao}\nMultiplicação: {multiplicacao}\nO quadrado de {a}: {quadradoA}\nO quadrado de {b}: {quadradoB}\nA divisão de {a} por {b}: {divisao}\n");
        }
        // Tabuada
        private static void tabuada(double numero) {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{numero} X {i} = {numero*i}\n");
            }
        }
    }
}
