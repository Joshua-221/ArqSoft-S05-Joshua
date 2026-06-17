using CitasApp.Models;
using System.Collections.Generic;

namespace CitasApp.Interfaces
{
    public interface IMedicoService
    {
        List<Medico> ObtenerTodos();
        Medico? ObtenerPorId(int id);
    }
}
