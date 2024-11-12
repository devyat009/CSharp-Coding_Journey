using SistemaBiblioteca.Repositories.Implementation;
using SistemaBiblioteca.Entities;
using SistemaBiblioteca.Domain.Exceptions;
using SQLitePCL;
using SistemaBiblioteca.Repositories;
using Microsoft.EntityFrameworkCore;
namespace SistemaBiblioteca.Domain.Services
{
    public class EmprestimoDomainService
    {
        private readonly ApplicationDbContext _context;
        private readonly UsuarioDomainService _usuarioDomainService;
        public EmprestimoDomainService(ApplicationDbContext context, UsuarioDomainService usuarioDomainService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _usuarioDomainService = usuarioDomainService;
        }

        public string CadastrarEmprestimo(Emprestimo emprestimo)
        {
            //if (_repository.ExisteEmprestimoAberto(emprestimo.Usuario.Nome, emprestimo.Livro.ISBN))
            //{

            //}
            var maiorDezData = emprestimo.DataDevolucao > DateTime.Now.AddDays(10);
            var maiorTrintaeData = emprestimo.DataDevolucao > DateTime.Now.AddDays(30);
            if (!emprestimo.DataDevolucao.HasValue)
            {
                return "Data de devolução não informada.";
            }
            if (emprestimo.Usuario.Discriminator == "PROFESSOR" && emprestimo.DataDevolucao > DateTime.Now.AddDays(30))
            {
                return "Tempo limite excede os 30 dias estipulados para professor";
            }
            if (emprestimo.Usuario.Discriminator == "ALUNO" && emprestimo.DataDevolucao > DateTime.Now.AddDays(10))
            {
                return "Tempo limite exece os 10 dias estipulados para aluno";
            }
            if (emprestimo.Livro.QuantidadeDisponivel <= 1)
            {
                return "Livro indisponível para empréstimo.";
            }
            
            _context.Attach(emprestimo.Usuario);
            _context.Attach(emprestimo.Livro);
            emprestimo.Livro.QuantidadeDisponivel -= 1;
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();
            return $"Emprestimo feito com sucesso";

            

        }
        public IEnumerable<Emprestimo> ListarEmprestimos()
        {
            var emprestimos = _context.Emprestimos;
            return emprestimos.Include(e => e.Usuario).Include(e => e.Livro).ToList();
            //return _context.Emprestimos.ToList();
        }

        public bool DevolverLivro(Emprestimo emprestimo)
        {
            return false;
        }

        public bool DeletarRegistroEmprestimo(int id)
        {
            var emprestimo = _context.Emprestimos.FirstOrDefault(a => a.Id == id);
            if (emprestimo == null)
            {
                return false;
            }

            _context.Emprestimos.Remove(emprestimo);
            _context.SaveChanges();
            return true;
        }
    }
}
