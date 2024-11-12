using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.Entities;
using SistemaBiblioteca.Repositories;
using SistemaBiblioteca.Repositories.Implementation;

namespace SistemaBiblioteca.Domain.Services
{
    public class LivroDomainService
    {
        private readonly ApplicationDbContext _context;

        public LivroDomainService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public string CadastrarLivro(Livro livro)
        {
            // regras de negócio
            var livroExistente = _context.Livros.FirstOrDefault(a => a.ISBN == livro.ISBN);
            if (livroExistente != null)
            {
                livroExistente.QuantidadeDisponivel += livro.QuantidadeDisponivel;
                _context.SaveChanges();
                return "Livro cadastrado, adicionando uma nova unidade ao inventário";
            }
            else
            {
                _context.Livros.Add(livro);
                _context.SaveChanges();
                return "Livro salvo com sucesso";
            }
        }

        public IEnumerable<Livro> ListarLivros()
        {
            return _context.Livros.ToList();
        }

        public bool DeletarLivro(int id)
        {
            var livro = _context.Livros.FirstOrDefault(a => a.Id == id);
            if (livro == null)
            {
                return false;
            }

            _context.Livros.Remove(livro);
            _context.SaveChanges();
            return true;
        }
    }
}
