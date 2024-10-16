using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApp.WebApp.Services
{
    [JsonSerializable(typeof(CadastroDataService))]
    [JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default)]
    public partial class MyJsonContext : JsonSerializerContext
    {
    }
}