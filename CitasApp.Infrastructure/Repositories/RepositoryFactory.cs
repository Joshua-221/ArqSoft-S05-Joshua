using CitasApp.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace CitasApp.Infrastructure.Repositories
{
    public static class RepositoryFactory
    {
        public static IPacienteRepository CrearPacienteRepository(
            string entorno,
            IWebHostEnvironment env,
            bool conLogging = false)
        {
            IPacienteRepository repository = new JsonPacienteRepository(env);

            return conLogging
                ? new LoggingPacienteRepository(repository)
                : repository;
        }

        public static IMedicoRepository CrearMedicoRepository(
            string entorno,
            IWebHostEnvironment env)
        {
            return new JsonMedicoRepository(env);
        }

        public static ICitaRepository CrearCitaRepository(
            string entorno,
            IWebHostEnvironment env)
        {
            return new JsonCitaRepository(env);
        }
    }
}
