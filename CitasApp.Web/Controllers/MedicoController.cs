using CitasApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMedicoService _service;
        public MedicoController(IMedicoService service) { _service = service; }

        public IActionResult Index() => View(_service.ObtenerTodos());

        public IActionResult Detalle(int id)
        {
            var medico = _service.ObtenerPorId(id);
            return medico == null ? NotFound() : View(medico);
        }
    }
}