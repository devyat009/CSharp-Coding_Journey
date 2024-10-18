using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using WebApp.WebApp.Requests;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApp.WebApp.Services.CadastrarService
{
    public class CadastroService
    {
        //public static void CreateCommand(string queryString, string connectionString)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(queryString, connection);
        //        connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}
        //// Made by ChadGpt
        //public static void CreateCommandV2(string queryString, string connectionString, CadastroDataService data)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(queryString, connection);
        //        command.Parameters.AddWithValue("@Nome", data.nome);
        //        command.Parameters.AddWithValue("@Idade", data.Idade);
        //        command.Parameters.AddWithValue("@DataNascimento", data.dataNascimento);
        //        command.Parameters.AddWithValue("@Cpf", data.cpf);
        //        command.Parameters.AddWithValue("@Cep", data.cep);

        //        connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}

        public static void CreateCommandV3(string queryString, string connectionString, CadastroRequest data)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Nome", data.nome);
                command.Parameters.AddWithValue("@Idade", data.idade);
                command.Parameters.AddWithValue("@DataNascimento", data.dataNascimento);
                command.Parameters.AddWithValue("@Cpf", data.cpf);
                command.Parameters.AddWithValue("@Cep", data.cep);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static bool ValidaCadastrar(string? nome, string? idade, string? dataNasciment, string? cpf, string? cep)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(dataNasciment) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(cep))
            {
                return false;
            }
            if (int.Parse(idade) is < 0 or > 130)
            {
                return false;
            }
            if (cpf.ToString().Length != 11 || cep.ToString().Length != 8)
            {
                return false;
            }
            if (nome.Length > 60)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
