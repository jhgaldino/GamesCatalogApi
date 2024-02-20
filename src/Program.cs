using FluentValidation;
using GamesCatalogApi.Data;
using GamesCatalogApi.Models;
using GamesCatalogApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner.
builder.Services.AddDbContext<GamesContext>(opt =>
       opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddScoped<IGameService, GameService>(); // Adicione esta linha
builder.Services.AddScoped<GameService>(); // Mova esta linha para aqui
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Adiciona todos os validadores do assemblu
builder.Services.AddValidatorsFromAssemblies(new[] { typeof(Game).Assembly });

var app = builder.Build();

// Configura o pipeline de solicita��es HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


