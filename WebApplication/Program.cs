using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using WebApp.WebApp.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        //options.JsonSerializerOptions.TypeInfoResolver = null; // Habilita a reflexão
//        //options.JsonSerializerOptions.ReadOnly = false;
//        options.JsonSerializerOptions.TypeInfoResolverChain.Add(SerializationContext.Default);
//    });

var app = builder.Build();




// Configura o pipeline do http
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => // chamar o swagger
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseStaticFiles(); // Usado para que possa ser carregado o arquivo html
app.MapGet("/", () => Results.Redirect("/buscacep"));
app.MapGet("/buscacep", () =>
{
    var htmlpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "htmlpage.html");
    // Retorna uma pagina HTML
    return Results.File(htmlpath, "text/html");
});

app.MapGet("/cadastro", () =>
{
    var htmlpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cadastro.html");
    return Results.File($"{htmlpath}", "text/html");
});


//app.MapPost("/cadastro", static async (CadastroDataService data, HttpContext httpContext) =>
//{
//    if (CadastroService.ValidaCadastrar(data.Nome, data.Idade, data.DataNascimento, long.Parse(data.Cpf), int.Parse(data.Cep)))
//    {
//        // Aqui você deve construir a consulta SQL para inserir os dados no banco.
//        string query = "INSERT INTO cadastrouser (nomeUser, idadeUser, nascimentoUser, cpfUser, cepUser) VALUES (@Nome, @Idade, @DataNascimento, @Cpf, @Cep)";

//        // Construa a string de conexão (substitua os valores adequados)
//        string connectionString = "Server=localhost; Port=3307;Database=cadastrodb;User Id=root;Password=;";

//        // Execute o comando para inserir os dados no banco

//        CadastroService.CreateCommandV3(query, connectionString, data);

//        return Results.Ok("Cadastro realizado com sucesso!");
//    }

//    return Results.BadRequest("Dados inválidos.");
//});

app.MapPost("/cadastro2", static async (HttpContext httpContext) =>
{
    using var reader = new StreamReader(httpContext.Request.Body);
    var body = await reader.ReadToEndAsync();

    if (string.IsNullOrWhiteSpace(body))
    {
        return Results.BadRequest("Corpo da requisição está vazio.");
    }

    var data = JsonSerializer.Deserialize<CadastroDataService>(body);
    try
    {
        if (data == null || !CadastroService.ValidaCadastrar(data.nome, data.idade, data.dataNascimento, data.cpf, data.cep))
        {
            return Results.BadRequest("Dados inválidos.");
        }
    }
    catch (JsonException jsonEx)
    {
        // Este catch captura erros de deserialização JSON
        return Results.BadRequest($"Erro ao processar os dados JSON: {jsonEx.Message}");
    }
    catch (ArgumentNullException argEx)
    {
        // Este catch captura erros para parâmetros nulos
        return Results.BadRequest($"Parâmetro ausente ou nulo: {argEx.Message}");
    }
    catch (Exception ex)
    {
        // Este catch captura quaisquer outros erros inesperados
        return Results.Problem("Ocorreu um erro ao processar a solicitação.");
    }

    // Aqui você deve construir a consulta SQL para inserir os dados no banco.
    string query = "INSERT INTO cadastrouser (nomeUser, idadeUser, nascimentoUser, cpfUser, cepUser) VALUES (@Nome, @Idade, @DataNascimento, @Cpf, @Cep)";

    // Construa a string de conexão (substitua os valores adequados)
    string connectionString = "Server=localhost; Port=3306;Database=cadastrodb;User Id=root;";

    // Execute o comando para inserir os dados no banco

    CadastroService.CreateCommandV3(query, connectionString, data);

    return Results.Ok("Cadastro realizado com sucesso!");

});

app.MapPost("/c", async (HttpContext httpContext) =>
{
    var cepService = new CepService();
    //return await cepService.GetCepInfoAsync(cep);

    var form = await httpContext.Request.ReadFormAsync();
    var cep = form["cep"].ToString(); // Lê o CEP do formulário

    return await cepService.GetCepInfoAsync(cep);
});
app.Run();
