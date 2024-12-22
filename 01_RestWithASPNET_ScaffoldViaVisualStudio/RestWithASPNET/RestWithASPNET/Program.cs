using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Model.Context;
using System.Collections.Generic;
using RestWithASPNET.Business;
using RestWithASPNET.Business.Implementations;
using RestWithASPNET.Repository.Implementations;
using RestWithASPNETErudio.Model.Context;
using RestWithASPNET.Repository;
using MySqlConnector;
using EvolveDb;
using Serilog;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//String de conexão MySql
var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(5, 7, 20)))
);

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

//Versioning API
builder.Services.AddApiVersioning();

//Dependency Injection
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();
builder.Services.AddScoped<IBookRepository, BookRepositoryImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void MigrateDatabase(string connection)
{
    try
    {
        var evolveConnection = new MySqlConnection(connection);
        var evolve = new Evolve(evolveConnection, Log.Information)
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true,
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed", ex);
        throw;
    }
}
        
