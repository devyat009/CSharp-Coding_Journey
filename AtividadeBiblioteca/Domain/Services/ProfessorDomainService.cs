using SistemaBiblioteca.Entities;
using SistemaBiblioteca.Repositories;
using SistemaBiblioteca.Repositories.Implementation;
using System.Data.SqlTypes;
namespace SistemaBiblioteca.Domain.Services
{
    public class ProfessorDomainService
    {
        private readonly UsuarioDomainService _usuarioDomainService;
        private readonly ApplicationDbContext _context;

        public ProfessorDomainService(ApplicationDbContext context, UsuarioDomainService usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string CadastrarProfessor(Professor professor)
        {
            // regras de negócio;
            if (professor == null)
            {
                throw new Exception("Prencha os dados corretamente");
            }
            var professorExistente = _context.Professores.OfType<Professor>().FirstOrDefault(p => p.Nome == professor.Nome && p.Departamento != professor.Departamento);
            if (professorExistente != null)
            {
                throw new Exception($"Não foi possível cadastrar o professor {professorExistente.Nome}, nome duplicado");
            }
            //if (_usuarioDomainService.VerificarUsuarioExiste(professor))
            //{
            //    throw new Exception("Professor já cadastrado");
            //}
            var professorDepartamento = _context.Professores.OfType<Professor>().FirstOrDefault(p => p.Nome == professor.Nome && p.Departamento == professor.Departamento);
            if (professorDepartamento != null)
            {
                throw new Exception($"Professor já cadastrado no departamento {professorDepartamento.Departamento}");
            }

            //var professorExistente = _repository.Obter(professor.Nome);
            //if (professorExistente != null)
            //{
            //    return "Professor já cadastrado";
            //}
            _context.Professores.Add(professor);
            _context.SaveChanges();
            return "Professor cadastrado com sucesso";
        }

        public IEnumerable<Professor> ListarProfessores()
        {
            return _context.Professores.ToList();
        }

        public bool DeletarProfessor(int id)
        {
            var professor = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (professor == null)
            {
                return false;
            }

            _context.Alunos.Remove(professor);
            _context.SaveChanges();
            return true;
        }
    }
}
