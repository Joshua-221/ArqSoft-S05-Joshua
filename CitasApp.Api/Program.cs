using CitasApp.Interfaces;
using CitasApp.Infrastructure.Repositories;
using CitasApp.Infrastructure.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Repositorios
builder.Services.AddScoped<IPacienteRepository, JsonPacienteRepository>();
builder.Services.AddScoped<IMedicoRepository, JsonMedicoRepository>();
builder.Services.AddScoped<ICitaRepository, JsonCitaRepository>();
// Servicios
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<ICitaService, CitaService>();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();