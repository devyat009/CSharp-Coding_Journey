﻿using SistemaBiblioteca.Entities;
using SistemaBiblioteca.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.Repositories;

namespace SistemaBiblioteca.Domain.Services
{
    public class AlunoDomainService
    {
        private readonly UsuarioDomainService _usuarioDomainService;
        private readonly ApplicationDbContext _context;

        public AlunoDomainService(UsuarioDomainService usuarioDomainService, ApplicationDbContext context)
        {
            _usuarioDomainService = usuarioDomainService;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string CadastrarAluno(Aluno aluno)
        {
            if (aluno == null)
            {
                throw new Exception("Aluno não encontrado");
            }
            if (_usuarioDomainService.VerificarUsuarioExiste(aluno))
            {
                throw new Exception("Aluno já cadastrado");
            }
            var alunoMatriculado = _context.Alunos.FirstOrDefault(a => a.Matricula == aluno.Matricula);
            //OfType<Aluno>().FirstOrDefault(p => p.Matricula == aluno.Matricula);
            if (alunoMatriculado != null)
            {
                throw new Exception("Matricula já cadastrada");
            }
            _context.Add(aluno);
            _context.SaveChanges();
            return "Aluno cadastrado com sucesso";
        }

        public IEnumerable<Aluno> ListarAlunos()
        {
            return _context.Alunos.OrderByDescending(aluno => aluno.Nome).ToList();
        }

        public bool DeletarAluno(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return false;
            }

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            return true;
        }
    }
}
