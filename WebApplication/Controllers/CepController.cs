using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApp.Requests;
using WebApp.Responses;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CepController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CepRequest cepRequest)
        {
            string cep = cepRequest.cep.Trim().Replace(".", "").Replace("-", "");
            int ceplenght = cep.Length;
            if (ceplenght != 8)
            {
                return BadRequest("CEP inválido, o CEP deve conter 8 dígitos númericos");
            }
            try
            {
                // tenta conectar a api externa
                var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                if (!response.IsSuccessStatusCode) // se der ruim ele envia um erro
                {
                    return BadRequest($"Erro ao buscar CEP na API externa. {response}");
                }

                var data = await response.Content.ReadAsStringAsync();
                    

                var cepResponse = JsonSerializer.Deserialize<CepResponse>(data);
                // Se deparar com cep inesistente ele retorna não encontrado
                if (cepResponse?.Erro == "true")
                {
                    return BadRequest("CEP não encontrado");
                }
                // Deu bom, retorna as informações
                else
                {
                    return Ok(data);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar dados de CEP na API: {ex.Message}");
            }
            
        }

    }
}
