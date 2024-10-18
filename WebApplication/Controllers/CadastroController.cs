using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApp.Requests;
using WebApp.Services.CadastrarService;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] // Specify the return type for successful responses
        public IActionResult Post([FromBody] CadastroRequest cadastroRequest)
        {
            if (cadastroRequest == null)
            {
                return BadRequest("Corpo de requerimento está vazio, verifique o conteúdo");
            }

            string cep = cadastroRequest.Cep.Trim().Replace(".", "").Replace("-", "");
            if (cep.Length != 8 || !cep.All(char.IsDigit))
            {
                return BadRequest("CEP inválido, o CEP deve conter 8 dígitos númericos");
            }

            string cpf = cadastroRequest.Cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11 || !cpf.All(Char.IsDigit))
            {
                return BadRequest("CPF inválido.");
            }
            try
            {
                string query = "INSERT INTO cadastrouser (nomeUser, idadeUser, nascimentoUser, cpfUser, cepUser) VALUES (@Nome, @Idade, @DataNascimento, @Cpf, @Cep)";

                string connectionString = "Server=localhost; Port=3306;Database=cadastrodb;User Id=root;";

                CadastroService.CriarCadastro(query, connectionString, cadastroRequest);

                return Ok("Cadastro realizado com sucesso");
            }
            catch (JsonException jsonEx)
            {
                // Este catch captura erros de deserialização JSON
                return BadRequest($"Erro ao processar os dados JSON: {jsonEx.Message}");
            }
            catch (ArgumentNullException argEx)
            {
                // Este catch captura erros para parâmetros nulos
                return BadRequest($"Parâmetro ausente ou nulo: {argEx.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }


        }
    }
}
