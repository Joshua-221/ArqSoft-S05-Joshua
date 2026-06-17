using CitasApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteService _service;
        public PacienteController(IPacienteService service) { _service = service; }

        public IActionResult Index() => View(_service.ObtenerTodos());

        public IActionResult Detalle(int id)
        {
            var paciente = _service.ObtenerPorId(id);
            return paciente == null ? NotFound() : View(paciente);
        }
    }
}