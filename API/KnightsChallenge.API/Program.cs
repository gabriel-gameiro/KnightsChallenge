using KnightsChallenge.Core.Contexts;
using KnightsChallenge.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Documentacao swagger automatico
builder.Services.AddSwaggerGen();

// Obtendo e disponibilizando como dependencia a configuracao de conexao com o mongoDB
builder.Services.Configure<ConnectionConfig>(
    builder.Configuration.GetSection("MongoDatabaseConfig"));

// Inicializando as services para serem consumidas via injecao de dependencia
builder.Services.AddSingleton<KnightService>();
builder.Services.AddSingleton<HallOfHeroesService>();


// Configurando regras de CORS para permitir acesso do front-end
// (Ao definir o IP fixo do Front, permitir acesso apenas dessa origem)
var OrigemFront = "RegrasCORS";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: OrigemFront,
                      policy =>
                      {
                          policy.WithOrigins(builder.Configuration.GetSection("AllowedHosts").Value ?? "")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(OrigemFront);

app.UseAuthorization();

app.MapControllers();

app.Run();
