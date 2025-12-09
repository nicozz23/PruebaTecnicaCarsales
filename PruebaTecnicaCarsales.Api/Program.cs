using PruebaTecnicaCarsales.Core.Interfaces;
using PruebaTecnicaCarsales.Logic.Clients;
using PruebaTecnicaCarsales.Logic.Services; 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1. Obtener la URL base desde la configuración
var baseApiUrl = builder.Configuration.GetSection("RickAndMortyApi")["BaseUrl"];

// 2. Registrar el HttpClient configurado para el IRickAndMortyClient
builder.Services.AddHttpClient<IRickAndMortyClient, RickAndMortyClient>(client =>
{
    // Usar la URL de appsettings.json
    client.BaseAddress = new Uri(baseApiUrl ?? throw new InvalidOperationException("BaseUrl para RickAndMortyApi no configurada."));
});

builder.Services.AddScoped<ILocationsService, LocationService>();
builder.Services.AddScoped<IEpisodeService, EpisodeService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
// 2. Agregar los servicios de CORS
//Me daba error sin este codigo, entonces agrego las politicas.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          
                         
                          policy.WithOrigins("http://localhost:4200",
                                             "https://localhost:4200")
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

//uso el cors creado
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
