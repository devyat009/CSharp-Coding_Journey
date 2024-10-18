using Microsoft.AspNetCore.Mvc;
using WebApp.WebApp.Requests;
using WebApp.WebApp.Services.CadastrarService;

namespace WebApp.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CadastroRequest cadastroRequest)
        {
            if (cadastroRequest == null)
            {
                return BadRequest("Corpo de requerimento está vazio, verifique o conteúdo");
            }

            string cep = cadastroRequest.cep.Trim().Replace(".", "").Replace("-", "");
            if (cep.Length != 8 || !cep.All(char.IsDigit))
            {
                return BadRequest("CEP inválido, o CEP deve conter 8 dígitos númericos");
            }

            string cpf = cadastroRequest.cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11 || !cpf.All(Char.IsDigit))
            {
                return BadRequest("CPF inválido.");
            }
            try
            {
                string query = "INSERT INTO cadastrouser (nomeUser, idadeUser, nascimentoUser, cpfUser, cepUser) VALUES (@Nome, @Idade, @DataNascimento, @Cpf, @Cep)";

                string connectionString = "Server=localhost; Port=3306;Database=cadastrodb;User Id=root;";

                CadastroService.CreateCommandV3(query, connectionString, cadastroRequest);

                return Ok("Cadastro realizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }


            //string nome = cadastroRequest.nome;
            //string email = cadastroRequest.idade;
            //string dataNascimento = cadastroRequest.dataNascimento;
            //string cpf = cadastroRequest.cpf.Trim().Replace(".", "").Replace("-", "");

        }
    }
}
