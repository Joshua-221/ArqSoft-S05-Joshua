using CitasApp.Interfaces;
using CitasApp.Models;
using System.Collections.Generic;

namespace CitasApp.Infrastructure.Services
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _repo;
        public CitaService(ICitaRepository repo) => _repo = repo;

        public List<Cita> ObtenerTodos() => _repo.ObtenerTodos();

        public List<Cita> ObtenerPorPaciente(int pacienteId) => _repo.ObtenerPorPaciente(pacienteId);
    }
}
