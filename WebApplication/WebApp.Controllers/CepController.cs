using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using WebApp.WebApp.Requests;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CepRequest cepRequest)
        {
            string cep = cepRequest.cep.Trim().Replace(".", "").Replace("-", "");
            int ceplenght = cep.Length;
            if (ceplenght != 8)
            {
                return BadRequest("CEP inválido, o CEP deve conter 8 dígitos númericos");
            }

            using (var httpClient = new HttpClient())
            {
                try
                {
                    //Conecta a api externa
                    var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                    if (!response.IsSuccessStatusCode) // se der ruim ele envia um erro
                    {
                        return BadRequest($"Erro ao buscar CEP na API externa. {response}");
                    }

                    var data = await response.Content.ReadAsStringAsync();
                    

                    var CepResponse = JsonSerializer.Deserialize<CepResponse>(data);
                    // Se deparar com cep inesistente ele retorna não encontrado
                    if (CepResponse?.erro == "true")
                    {
                        return BadRequest("CEP não encontrado"); // Retorna null se houver erro no CEP
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

        private class CepResponse
        {
            public string? cep { get; set; }
            public string? logradouro { get; set; }
            public string? complemento { get; set; }
            public string? unidade { get; set; }
            public string? bairro { get; set; }
            public string? localidade { get; set; }
            public string? uf { get; set; }
            public string? estado { get; set; }
            public string? regiao { get; set; }
            public string? ibge { get; set; }
            public string? gia { get; set; }
            public string? ddd { get; set; }
            public string? siafi { get; set; }
            public string? erro { get; set; }
        }
    }
}
