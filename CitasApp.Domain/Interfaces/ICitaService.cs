using CitasApp.Models;
using System.Collections.Generic;

namespace CitasApp.Interfaces
{
    public interface ICitaService
    {
        List<Cita> ObtenerTodos();
        List<Cita> ObtenerPorPaciente(int pacienteId);
    }
}
