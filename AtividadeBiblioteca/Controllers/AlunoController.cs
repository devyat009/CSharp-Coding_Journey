using SistemaBiblioteca.Entities;
using SistemaBiblioteca.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;
using SistemaBiblioteca.Domain.Services;

namespace SistemaBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoDomainService _service;

        public AlunoController(AlunoDomainService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Post(
            [FromBody] Aluno aluno)
        {
            _service.CadastrarAluno(aluno);
            return Ok();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return Ok(_service.ListarAlunos());
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            return Ok(_service.DeletarAluno(id));
        }
    }
}
