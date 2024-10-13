using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using System.Text.Json;
using Xunit.Sdk;

namespace CSharpJourney.core.Services
{
    public static class ApiConstants
    {
        #pragma warning disable S1075 // URIs should not be hardcoded
        public const string dollarApiUrl = "https://economia.awesomeapi.com.br/last/USD-BRL";
        #pragma warning restore S1075 // URIs should not be hardcoded
    }
    public static class DollarApiService
    {
        // Response from the url after using DollarApiRun
        private static List<string> urlResponseItem = new List<string>();
        // Declare the dollar
        public static float dollarValue = 0;
        public static async Task DollarApiRun()
        {
            using HttpClient request = new HttpClient();
            try
            {
                string url = ApiConstants.dollarApiUrl;

                HttpResponseMessage response = await request.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseItem = await response.Content.ReadAsStringAsync();
                urlResponseItem.Add(responseItem);
            } catch (HttpRequestException e)
            {
                Console.WriteLine($"A error happened: {e.Message}");
            }
        }
        public static void DollarValue()
        {
            foreach (string json in urlResponseItem)
            {
                using JsonDocument doc = JsonDocument.Parse(json);
                JsonElement root = doc.RootElement;
                if (root.TryGetProperty("USDBRL", out JsonElement usdBrl))
                {
                    string? usdBid = usdBrl.GetProperty("bid").GetString();
                    if (usdBid != null)
                    {
                        dollarValue = float.Parse(usdBid);
                    }
                    else
                    {
                        throw new ArgumentException("Dollar Value is NULL");
                    }
                }
            }
        }
        public static float ConversionRealToDollar(float realValue)
        {
            return realValue / DollarApiService.dollarValue;
        }
        public static float ConversionDollarToReal(float usdValue)
        {
            return usdValue * DollarApiService.dollarValue;
        }
    }
}
