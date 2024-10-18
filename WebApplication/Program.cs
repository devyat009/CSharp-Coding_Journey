
using Microsoft.OpenApi.Models;

namespace WebApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // Altera a politica para que o angular possa acessar as apis no swagger, indepentemente da porta, metodo ou header.
            builder.Services.AddCors(option => option.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            }));

            builder.Services.AddControllers();
            builder.Services.AddHttpClient();


            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Painel Conexões", Version = "v1.0" });

                // Para adicionar exemplos do response body
            });

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


            app.UseHttpsRedirection(); // Pode gerar problemas de redirecionamento para https (as vezes)
            app.UseCors(); // Usa as politicas criadas anteriomente

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

            app.MapControllers();

            app.Run();
        }
    }
}
