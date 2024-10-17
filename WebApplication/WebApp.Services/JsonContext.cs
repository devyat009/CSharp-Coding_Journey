using System.Text.Json;
using System.Text.Json.Serialization;
using WebApp.WebApp.Services.CadastrarService;

namespace WebApp.WebApp.Services
{
    [JsonSerializable(typeof(CadastroDataService))]
    [JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default)]
    public partial class MyJsonContext : JsonSerializerContext
    {
    }
}