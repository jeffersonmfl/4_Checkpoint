using ExchangeRateAPI.Interfaces;
using ExchangeRateAPI.Services;
using ExchangeRateAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Carregar configurações do appsettings.json
builder.Services.Configure<ExchangeRateApiSettings>(
    builder.Configuration.GetSection("ExchangeRateAPI"));  // Certifique-se de que a seção corresponde ao seu appsettings.json

// Configurar o HttpClient com injeção de dependência
builder.Services.AddHttpClient<IConversionRate, ConversionRateService>();

// Adicionar serviços de controle
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exchange Rate API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
