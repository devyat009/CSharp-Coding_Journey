namespace MenuAtividade_01
{
    class ProgramMenu
    {
        static void Main(string[] args)
        {   
            bool continuar = true;
            while (continuar)
            {
                // Mostrar o menu
                Console.WriteLine("Menu de Atividade\n 1 - Hello World\n 2 - Input\n 3 - Múltiplos input\n 4 - Operações Matemáticas\n 5 - Tabuada");
                string? opcao = Console.ReadLine();
                if (opcao == null)
                {
                    Console.WriteLine("Entrada Invalida");
                    break;
                }
                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Opção 1 Selecionada");
                        helloworld();
                        break;
                    case "2":
                        Console.WriteLine("Opção 2 Selecionada");
                        Console.WriteLine("Digite algo:");
                        string? input_usuario = Console.ReadLine();
                        if (input_usuario == null)
                        {
                            Console.WriteLine("Você não digitou nada, tente novamente...");
                        }
                        else{
                            inputF(input_usuario);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Opção 3 Selecionada");
                        Console.WriteLine("Digite seu nome:");
                        string? nome = Console.ReadLine();
                        Console.WriteLine("Digite sua idade:");
                        string? idade = Console.ReadLine();
                        multiplosInput(nome, idade);
                        break;
                    case "4":
                        Console.WriteLine("Opção 4 Selecionada");
                        string? a;
                        do {
                            Console.WriteLine("Insira o primeiro número:");
                            a = Console.ReadLine();
                            if (string.IsNullOrEmpty(a))
                            {
                                Console.WriteLine("Entrada inválida! Tente novamente.");
                                a = null;
                            }
                        } while (string.IsNullOrEmpty(a));

                        string? b;
                        do {
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
                        break;
                    case "5":
                        Console.WriteLine("Opção 5 Selecionada");
                        string? input;
                        do {
                            Console.WriteLine("Digite um número na qual queira sabe a tabuada:");
                            input = Console.ReadLine();
                            if (string.IsNullOrEmpty(input)) {
                                Console.WriteLine("Entrada inválida! Tente Novamente.");
                            }
                        } while (string.IsNullOrEmpty(input));
                        double numero = double.Parse(input);
                        tabuada(numero);
                        break;
                    case "0":
                        Console.WriteLine("Saindo...");
                        continuar = false; // Para o while
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente...");
                        break;
                }
                // Linha vazia
                Console.WriteLine();
            }
        }
        // Funções:
        // HelloWorld
        static void helloworld()
        {
            Console.WriteLine("Hello World!");
        }
        // Único Input
        static void inputF(string qualquercoisa)
        {
            Console.WriteLine($"Você digitou: {qualquercoisa}");
        }
        // Múltiplos Input
        static void multiplosInput(string nome, string idade)
        {
            Console.WriteLine($"Seu nome é {nome} e sua idade é {idade}");
        }
        // Matematica Básica
        static void matematicaBasica(double a, double b)
        {
            double soma = a + b;
            double subtracao = a - b;
            double multiplicacao = a * b;
            double quadradoA = a * a;
            double quadradoB = b * b;
            double divisao = a/b;
            Console.Write($"\nResultados:\nSoma: {soma}\nSubtração: {subtracao}\nMultiplicação: {multiplicacao}\nO quadrado de {a}: {quadradoA}\nO quadrado de {b}: {quadradoB}\nA divisão de {a} e {b}: {divisao}\n");
        }
        // Tabuada
        static void tabuada(double numero) {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{numero} X {i} = {numero*i}\n");
            }
        }
    }
}
