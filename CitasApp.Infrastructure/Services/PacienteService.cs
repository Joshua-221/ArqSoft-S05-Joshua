using CitasApp.Interfaces;
using CitasApp.Models;
using System.Collections.Generic;

namespace CitasApp.Infrastructure.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repo;
        public PacienteService(IPacienteRepository repo) => _repo = repo;

        public List<Paciente> ObtenerTodos() => _repo.ObtenerTodos();

        public Paciente? ObtenerPorId(int id) => _repo.ObtenerPorId(id);
    }
}
