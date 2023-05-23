using MediatR;
using Questao5.Infrastructure.Sqlite;
using System.Reflection;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Questao5.Infrastructure.Database.CommandStore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddTransient<IDbConnection>(provider =>
{
    // Aqui você deve fornecer a lógica para criar e retornar uma instância de IDbConnection,
    // como por exemplo, SqlConnection para bancos de dados SQL Server.
    IDbConnection dbConnection = new SqlConnection("Server=LAPTOP-6F9ISQ9R\\SQLEXPRESS;Database=Teste;User Id=rafael;Password=1234;TrustServerCertificate=True");
    dbConnection.Open();
    return dbConnection;
});
//builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMovimentarContaCorrenteComandStore, MovimentarContaCorrenteComandStore>();
builder.Services.AddScoped<IConsultarSaldoContaCorrenteQueryStore, ConsultarSaldoContaCorrenteQueryStore>();

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

// sqlite
#pragma warning disable CS8602 // Dereference of a possibly null reference.
//app.Services.GetService<IDatabaseBootstrap>().Setup();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

app.Run();

// Informações úteis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html


