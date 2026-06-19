using CitasApp.Interfaces;
using CitasApp.Infrastructure.Repositories;
using CitasApp.Infrastructure.Services;
var builder = WebApplication.CreateBuilder(args);

// Kestrel: escuchar en puerto 5000 para desarrollo (HTTP)
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5000);
});

// CORS: permitir orígenes para desarrollo (si se sirve el HTML desde file:// o desde otro host)
// En producción ajustar esta política a orígenes permitidos.
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontendLocal", policy =>
    {
        policy.AllowAnyOrigin()  // Permite cualquier origen (ideal para desarrollo)
              .AllowAnyMethod()  // Permite cualquier método (GET, POST, etc.)
              .AllowAnyHeader(); // Permite cualquier cabecera
    });
});

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

// Usar CORS antes de mapear controllers
app.UseCors("PermitirFrontendLocal");
// NOTA: No forzar redirección a HTTPS aquí para mantener el puerto HTTP 5000 accesible en desarrollo.
app.UseAuthorization();
app.MapControllers();
app.Run();