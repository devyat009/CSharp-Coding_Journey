using SistemaBiblioteca.Entities;
using SistemaBiblioteca.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;
using SistemaBiblioteca.Domain.Services;

namespace SistemaBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        private readonly EmprestimoDomainService _service;

        public EmprestimoController(EmprestimoDomainService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Post(
            [FromBody] Emprestimo emprestimo)
        {
            
            return Ok(_service.CadastrarEmprestimo(emprestimo));
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return Ok(_service.ListarEmprestimos());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(_service.DeletarRegistroEmprestimo(id));
        }
    }
}
