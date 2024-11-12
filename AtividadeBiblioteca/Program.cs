using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.Domain.Services;
using SistemaBiblioteca.Entities;
using SistemaBiblioteca.Repositories;
using SistemaBiblioteca.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<Repository>();

builder.Services.AddScoped<AlunoDomainService>();

builder.Services.AddScoped<LivroDomainService>();
builder.Services.AddScoped<UsuarioDomainService>();

builder.Services.AddScoped<ProfessorDomainService>();
builder.Services.AddScoped<EmprestimoDomainService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=BancoDeDados.db")
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
