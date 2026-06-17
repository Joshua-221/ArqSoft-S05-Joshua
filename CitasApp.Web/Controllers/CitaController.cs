using CitasApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    public class CitaController : Controller
    {
        private readonly ICitaService _citaService;
        private readonly IPacienteService _pacienteService;
        private readonly IMedicoService _medicoService;

        public CitaController(ICitaService citaService,
            IPacienteService pacienteService,
            IMedicoService medicoService)
        {
            _citaService = citaService;
            _pacienteService = pacienteService;
            _medicoService = medicoService;
        }

        public IActionResult Index()
        {
            ViewBag.Pacientes = _pacienteService.ObtenerTodos();
            ViewBag.Medicos = _medicoService.ObtenerTodos();
            return View(_citaService.ObtenerTodos());
        }

        public IActionResult PorPaciente(int pacienteId)
        {
            ViewBag.Pacientes = _pacienteService.ObtenerTodos();
            ViewBag.Medicos = _medicoService.ObtenerTodos();
            return View(_citaService.ObtenerPorPaciente(pacienteId));
        }
    }
}