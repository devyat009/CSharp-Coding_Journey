using MySql.Data.MySqlClient;
using WebApp.Requests;

namespace WebApp.Services.CadastrarService
{
    public static class CadastroService
    {
        public static void CriarCadastro(string queryString, string connectionString, CadastroRequest data)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Nome", data.Nome);
                command.Parameters.AddWithValue("@Idade", data.Idade);
                command.Parameters.AddWithValue("@DataNascimento", data.DataNascimento);
                command.Parameters.AddWithValue("@Cpf", data.Cpf);
                command.Parameters.AddWithValue("@Cep", data.Cep);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
