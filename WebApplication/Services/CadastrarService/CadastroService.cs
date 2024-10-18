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

        public static void DeletarCadastro(string queryString, string connectionString, CadastroDeleteRequest data)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", data.Id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static IEnumerable<CadastroGetRequest> MostrarTodosCadastros(string queryString, string connectionString)
        {
            var users = new List<CadastroGetRequest>();
            using (var connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@Id", data.Id);
                //command.Parameters.AddWithValue("@Nome", data.Nome);
                //command.Parameters.AddWithValue("@Idade", data.Idade);
                //command.Parameters.AddWithValue("@DataNascimento", data.DataNascimento);
                //command.Parameters.AddWithValue("@Cpf", data.Cpf);
                //command.Parameters.AddWithValue("@Cep", data.Cep);
                
                connection.Open();

                using (var responseReader  = command.ExecuteReader())
                {
                    while (responseReader.Read())
                    {
                        var user = new CadastroGetRequest

                        {
                            Id = responseReader.GetInt32("idUser"),
                            Nome = responseReader.GetString("nomeUser"),
                            Idade = responseReader.GetInt32("idadeUser").ToString(),
                            DataNascimento = responseReader.GetString("nascimentoUser"),
                            Cpf = responseReader.GetInt64("cpfUser").ToString(),
                            Cep = responseReader.GetInt32("cepUser").ToString()
                        };
                        users.Add(user);
                    }
                }
                command.ExecuteNonQuery();
                connection.Close();
                return users;
            }
        }
    }
}
