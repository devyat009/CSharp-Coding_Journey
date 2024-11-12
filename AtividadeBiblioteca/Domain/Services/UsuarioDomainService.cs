using SistemaBiblioteca.Repositories.Implementation;
using SistemaBiblioteca.Entities;
using SistemaBiblioteca.Repositories;
namespace SistemaBiblioteca.Domain.Services
{
    public class UsuarioDomainService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioDomainService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool VerificarUsuarioExiste(Usuario usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(p => p.Nome == usuario.Nome);
            return user != null;
        }
    }
}
