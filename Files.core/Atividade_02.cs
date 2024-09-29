using System.Text.Json;
using Atividade;
namespace Atividade._02
{
    public static class ApiConstants
    {
#pragma warning disable S1075 // URIs should not be hardcoded
        public const string DollarApiUrl = "https://economia.awesomeapi.com.br/last/USD-BRL";
#pragma warning restore S1075 // URIs should not be hardcoded
    }
    public static class Dolarapi
    {

        // Lista de forma statica para ser acessada em outros lugares
        // Lista para armazernar as informações disponiveis do JSON da API
        private static List<string> responses = new List<string>();
        private static float dolar = 0;
        public static async Task apitask()
        {   
            using HttpClient request = new HttpClient();
            try
            {
                string url = ApiConstants.DollarApiUrl;

                // Usa get na requisição
                HttpResponseMessage response = await request.GetAsync(url);

                // Obtem o status code de conexão
                response.EnsureSuccessStatusCode();

                // Faz o request na url da api
                string responseItem = await response.Content.ReadAsStringAsync();
                responses.Add(responseItem);
                valorDolar();
                MenuAPI();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro de requisição na API: {e}");
            }
        }
        // Menu opções
        static void MenuAPI()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("API Dolar X Real");
                Console.WriteLine("1 - Visualizar valor do Dolar");
                Console.WriteLine("2 - Converter REAL para DOLAR");
                Console.WriteLine("3 - Converter DOLAR para REAL");
                Console.WriteLine("0 - SAIR");

                string? inputUser = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputUser))
                {
                    Console.WriteLine("Entrada inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine(inputUser);
                switch (inputUser)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"Dólar: {dolar}");
                        Console.WriteLine($"\nPrecisone qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Quantos reais deseja converter para dolar?");
                        Console.Write("-- ");
                        string? valor = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(valor))
                        {
                            Console.WriteLine("Entrada inválida. Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            continue;
                        }
                        float valorFloat = float.Parse(valor);
                        float realxdolar = ConversaoReaisXDolar(valorFloat, dolar);
                        Console.WriteLine($"Valor de R${valorFloat} equivale em DOLARES ${realxdolar}");
                        Console.WriteLine($"\nPrecisone qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Quantos DOLARES deseja coverter para REAL?");
                        Console.WriteLine("-- ");
                        string? valorDolar = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(valorDolar))
                        {
                            Console.WriteLine("Entrada inválida. Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            continue;
                        }
                        float valorFloatDollar = float.Parse(valorDolar);
                        float dolarxreal = ConversaoDolarXReais(dolar, valorFloatDollar);
                        Console.WriteLine($"Valor de ${valorDolar} equivale em REAIS R${dolarxreal}");
                        Console.WriteLine($"\nPrecisone qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "0":
                        continuar = false;
                        MenuSelection.Main();
                        break;
                    default:
                        Console.WriteLine($"\nPrecisone qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Conversão de Reais para Dolar
        static float ConversaoReaisXDolar(float reaisValor, float usdValor)
        {
            float valor = reaisValor / usdValor;
            return valor;
        }
        // Conversão de Dolares para Reais
        static float ConversaoDolarXReais(float usdValor, float reaisValor)
        {
            float valor = usdValor * reaisValor;
            return valor;
        }

        static void valorDolar()
        {
            Console.WriteLine("Valor Dolar foi chamado");
           foreach (string json in responses)
            {
                // Deserializa o JSON em um JsonDocument
                using JsonDocument doc = JsonDocument.Parse(json);
                JsonElement root = doc.RootElement;
                if (root.TryGetProperty("USDBRL", out JsonElement usdBrl))
                {
                    string usdBid = usdBrl.GetProperty("bid").GetString();
                    dolar = float.Parse(usdBid);
                }
                else
                {
                    Console.WriteLine("Dados de USD-BRL não encontrados.");
                }
            }
        }
    }
}
