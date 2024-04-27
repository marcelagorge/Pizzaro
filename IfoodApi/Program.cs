using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração Swagger no builder
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração banco MySQL
builder.Services.AddDbContext<BancoDeDados>();

var app = builder.Build();

// Configuração Swagger no app
app.UseSwagger();
app.UseSwaggerUI();

// http://localhost:xxxx/swagger/index.html

app.MapGet("/", () => "API da Pizzaria");

app.MapPizzaAPI();
app.MapClienteAPI();
app.MapPedidoAPI();

app.Run();

