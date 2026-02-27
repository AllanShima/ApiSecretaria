using ApiSecretaria.Application.Services;
using ApiSecretaria.Data;
using ApiSecretaria.Domain.Interfaces.IRepositories;
using ApiSecretaria.Domain.Interfaces.IServices;
using ApiSecretaria.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace ApiSecretaria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Corrigido: primeiro a interface (serviço), depois a implementação concreta
            builder.Services.AddScoped<IAlunoService, AlunoService>();
            builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();

            // Configuração do Context
            string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<Context>(options =>
                options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection))
            );

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddOpenApi();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(); // Isso cria uma interface linda no navegador
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();


            // (Opcional) Uma rota padrão para você testar se o servidor responde
            app.MapGet("/", () => "A API está online!");

            app.Run();
        }
    }
}
