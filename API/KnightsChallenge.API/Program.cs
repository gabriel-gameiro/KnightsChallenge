using KnightsChallenge.Core.Contexts;
using KnightsChallenge.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurando a conex�o com o mongoDB
builder.Services.Configure<ConnectionConfig>(
    builder.Configuration.GetSection("MongoDatabaseConfig"));
builder.Services.AddSingleton<KnightService>();
builder.Services.AddSingleton<HallOfHeroesService>();

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
