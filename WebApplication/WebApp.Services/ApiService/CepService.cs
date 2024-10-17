using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

namespace WebApp.WebApp.Services.ApiService
{
    public class CepService
    {
        public async Task<IResult> GetCepInfoAsync(string cep)
        {
            // Formata o CEP
            cep = cep.Trim().Replace(".", "").Replace("-", "");
            // Checa se tem apenas números
            if (!cep.All(char.IsDigit))
            {
                return Results.BadRequest("CEP inválido. Deve conter 8 dígitos númericos.");
            }
            // Checa quantidade de números
            if (cep.Length != 8)
            {
                return Results.BadRequest("CEP inválido. Deve conter 8 dígitos.");
            }

            using var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                // Qualquer coisa que não seja um status 200
                if (!response.IsSuccessStatusCode)
                {
                    return Results.Problem("Erro ao buscar CEP na API externa.");
                }

                var data = await response.Content.ReadAsStringAsync();
                var cepResponse = JsonSerializer.Deserialize<CepResponse>(data);
                // Caso o CEP não seja encontrado, retorna 400
                if (cepResponse?.erro == "true")
                {
                    return Results.BadRequest("CEP não encontrado.");
                }
                else
                {
                    // Se tudo occoreu ok vai retornar o resultado como um dicionário
                    var resultado = new Dictionary<string, string>
                {
                    { "cep", cepResponse.cep },
                    { "logradouro", cepResponse.logradouro },
                    { "complemento", cepResponse.complemento },
                    { "bairro", cepResponse.bairro },
                    { "localidade", cepResponse.localidade },
                    { "uf", cepResponse.uf },
                    { "ibge", cepResponse.ibge },
                    { "gia", cepResponse.gia },
                    { "ddd", cepResponse.ddd },
                    { "siafi", cepResponse.siafi }
                };

                    return Results.Ok(new List<Dictionary<string, string>> { resultado });
                }

            }
            catch (Exception ex)
            {
                return Results.Problem($"Erro ao buscar dados de CEP na API: {ex.Message}");
            }
        }
    }

    public class CepResponse
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }
        public string? erro { get; set; }
    }
}
