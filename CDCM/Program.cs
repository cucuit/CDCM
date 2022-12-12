using CDCM.APIs;
using CDCM.DataAccess;
using CDCM.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISQLDataAccess, SQLDataAccess>();
builder.Services.AddSingleton<ICollectorClientData, CollectorClientData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureCollectorConfigurationAPI();
app.ConfigureCollectorClientAPI();

app.Run();
