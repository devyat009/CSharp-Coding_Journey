using Newtonsoft.Json;

namespace WebApp.Requests
{
    public class CadastroRequest
    {
        [JsonProperty("nome")]
        public string Nome { get; set; } = "";

        [JsonProperty("idade")]
        public string Idade { get; set; } = "";

        [JsonProperty("dataNascimento")]
        public string DataNascimento { get; set; } = "";

        [JsonProperty("cpf")]
        public string Cpf { get; set; } = "";

        [JsonProperty("cep")]
        public string Cep { get; set; } = "";
    }

    public class CadastroDeleteRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class CadastroGetRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; } = "";

        [JsonProperty("idade")]
        public string Idade { get; set; } = "";

        [JsonProperty("dataNascimento")]
        public string DataNascimento { get; set; } = "";

        [JsonProperty("cpf")]
        public string Cpf { get; set; } = "";

        [JsonProperty("cep")]
        public string Cep { get; set; } = "";
    }
}
