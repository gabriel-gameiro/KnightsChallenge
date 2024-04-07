using KnightsChallenge.Core.Contexts;
using KnightsChallenge.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurando a conexão com o mongoDB
builder.Services.Configure<ConnectionConfig>(
    builder.Configuration.GetSection("MongoDatabaseConfig"));
builder.Services.AddSingleton<KnightService>();
builder.Services.AddSingleton<HallOfHeroesService>();

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

// Configure the HTTP request pipeline.
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
