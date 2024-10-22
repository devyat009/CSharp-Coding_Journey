using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApp.Requests;
using WebApp.Services.CadastrarService;
using WebApp.Services.CadastrarInterface;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroService _cadastroService;

        public CadastroController(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }
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

                

                _cadastroService.CriarCadastro(query, cadastroRequest);

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

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public IActionResult Delete([FromForm] CadastroDeleteRequest cadastroDeleteRequest)
        {
            if (cadastroDeleteRequest == null)
            {
                return BadRequest("Corpo de requerimento está vazio, verifique o conteúdo");
            }

            try
            {
                string query = "DELETE FROM cadastrouser WHERE idUser = @Id";

                //string conenctionString = "Server=localhost;Database=cadastrodb;User Id=root;";

                _cadastroService.DeletarCadastro(query, cadastroDeleteRequest);
                return Ok("Excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao processar os dados: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public IActionResult Get()
        {
            try
            {
                string query = "SELECT * FROM cadastrouser";

                //string connectionString = "Server=localhost;Database=cadastrodb;User Id=root;";

                var users = _cadastroService.MostrarTodosCadastros(query);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao processar os dados: {ex.Message}");
            }
        }
    }
}