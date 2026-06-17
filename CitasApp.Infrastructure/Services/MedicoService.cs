using CitasApp.Interfaces;
using CitasApp.Models;
using System.Collections.Generic;

namespace CitasApp.Infrastructure.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _repo;
        public MedicoService(IMedicoRepository repo) => _repo = repo;

        public List<Medico> ObtenerTodos() => _repo.ObtenerTodos();

        public Medico? ObtenerPorId(int id) => _repo.ObtenerPorId(id);
    }
}
