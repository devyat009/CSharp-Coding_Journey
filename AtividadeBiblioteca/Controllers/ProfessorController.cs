using SistemaBiblioteca.Entities;
using Microsoft.AspNetCore.Mvc;
using SistemaBiblioteca.Domain.Services;

namespace SistemaBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorDomainService _service;

        public ProfessorController(ProfessorDomainService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Post(
            [FromBody] Professor professor)
        {
            _service.CadastrarProfessor(professor);
            return Ok();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return Ok(_service.ListarProfessores());
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            return Ok(_service.DeletarProfessor(id));
        }
    }
}
