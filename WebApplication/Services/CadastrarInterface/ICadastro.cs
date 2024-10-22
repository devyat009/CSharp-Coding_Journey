using WebApp.Requests;

namespace WebApp.Services.CadastrarInterface
{
    public interface ICadastroService
    {
        void CriarCadastro(string query, CadastroRequest cadastroRequest);
        void DeletarCadastro(string query, CadastroDeleteRequest cadastroDeleteRequest);
        IEnumerable<CadastroGetRequest> MostrarTodosCadastros(string query);
    }
}
