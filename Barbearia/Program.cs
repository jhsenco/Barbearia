using Barbearia.Data;
using Barbearia.Repositorios;
using Barbearia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Barbearia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<BarbeariaDBContex>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                 );

            builder.Services.AddScoped<IBarbeiroRepositorio, BarbeiroRepositorio>();
            builder.Services.AddScoped<IServicoRepositorio, ServicoRepositorio>();
            builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            builder.Services.AddScoped<IBarbeariaRepositorio, BarbeariaRepositorio>();
            builder.Services.AddScoped<IAgendamentoRepositorio, AgendamentoRepositorio>();

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
        }
    }
}