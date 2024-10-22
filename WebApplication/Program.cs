
using Microsoft.OpenApi.Models;
using WebApp.Services.CadastrarInterface;
using WebApp.Services.CadastrarService;

namespace WebApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona o serviço de Cadastro com a conexão
            builder.Services.AddScoped<ICadastroService>(sp =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                return new CadastroService(connectionString);
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // Altera a politica para que o angular possa acessar as apis no swagger, indepentemente da porta, metodo ou header.
            builder.Services.AddCors(option => option.AddPolicy("AllowAllOrigins", policy =>
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
            app.UseCors("AllowAllOrigins"); // Usa as politicas criadas anteriomente

            app.UseStaticFiles(); // Usado para que possa ser carregado o arquivo html

            // Mapeia os controllers
            app.MapControllers();

            app.Run();
        }
    }
}
