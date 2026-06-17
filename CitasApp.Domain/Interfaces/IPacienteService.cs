using CitasApp.Models;
using System.Collections.Generic;

namespace CitasApp.Interfaces
{
    public interface IPacienteService
    {
        List<Paciente> ObtenerTodos();
        Paciente? ObtenerPorId(int id);
    }
}
