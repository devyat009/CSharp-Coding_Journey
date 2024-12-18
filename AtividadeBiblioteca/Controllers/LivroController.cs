﻿using SistemaBiblioteca.Entities;
using SistemaBiblioteca.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;
using SistemaBiblioteca.Domain.Services;

namespace SistemaBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivroDomainService _service;

        public LivroController(LivroDomainService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Livro livro)
        {
            _service.CadastrarLivro(livro);
            return Ok();
        }

        [HttpGet]
        public ActionResult Listar()
            {
                return Ok(_service.ListarLivros());
            }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            return Ok(_service.DeletarLivro(id));
        }
    }
}
