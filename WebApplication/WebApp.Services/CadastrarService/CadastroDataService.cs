using System.Text.Json.Serialization;
using System.Text.Json;
namespace WebApp.WebApp.Services.CadastrarService
{
    [JsonSerializable(typeof(CadastroDataService))]
    public partial class CadastroDataService
    {
        public string nome { get; set; }
        public string idade { get; set; }
        public string dataNascimento { get; set; }
        public string cpf { get; set; }
        public string cep { get; set; }
    }
}
