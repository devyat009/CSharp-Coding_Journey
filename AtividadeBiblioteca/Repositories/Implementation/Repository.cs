using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.Entities;

namespace SistemaBiblioteca.Repositories.Implementation
{
    public class Repository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CadastrarLivro(
            Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Livro> ListarLivros()
        {
            return _context.Livros.ToList();
        }

        public Livro? Obter(string ISBN)
        {
            return _context.Livros
                .Where(x => x.ISBN == ISBN)
                .FirstOrDefault();
        }

        public void CadastrarAluno(
            Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        public IEnumerable<Aluno> ListarAlunos()
        {
            return _context.Alunos.ToList();
        }



        public void CadastrarProfessor(
            Professor professor)
        {
            _context.Professores.Add(professor);
            _context.SaveChanges();
        }

        public IEnumerable<Professor> ListarProfessores()
        {
            return _context.Professores.ToList();
        }

        public void CadastrarEmprestimo(
            Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> ListarUsuarios() {
            return _context.Usuarios.ToList();
        }

        public IEnumerable<Emprestimo> ListarEmprestimos()
        {
            return _context.Emprestimos.AsNoTracking().ToList();
        }

        //public bool ExisteEmprestimoAberto(string nomeUsuario, string isbn)
        //{
        //    return _context.()
        //        .Any(x => x.Usuario.Nome == nomeUsuario &&
        //                  x.Livro.ISBN == isbn &&
        //                  x.DataDevolucao == null);
        //}
    }
}
