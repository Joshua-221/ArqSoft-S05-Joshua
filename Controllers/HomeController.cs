using CitasApp.Interfaces;
using CitasApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CitasApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMedicoRepository _medicoRepository;

        public HomeController(ICitaRepository citaRepository,
                              IPacienteRepository pacienteRepository,
                              IMedicoRepository medicoRepository)
        {
            _citaRepository = citaRepository;
            _pacienteRepository = pacienteRepository;
            _medicoRepository = medicoRepository;
        }

        public IActionResult Index()
        {
            var citas = _citaRepository.ObtenerTodos().OrderBy(c => c.Fecha).ThenBy(c => c.Hora).ToList();
            var pacientes = _pacienteRepository.ObtenerTodos().ToList();
            var medicos = _medicoRepository.ObtenerTodos().ToList();
            var proximaCita = citas.FirstOrDefault();

            ViewBag.TotalCitas = citas.Count;
            ViewBag.Pendientes = citas.Count(c => c.Estado == "Pendiente");
            ViewBag.Confirmadas = citas.Count(c => c.Estado == "Confirmada");
            ViewBag.TotalPacientes = pacientes.Count;
            ViewBag.TotalMedicos = medicos.Count;
            ViewBag.ProximaCita = proximaCita;
            ViewBag.ProximaPaciente = proximaCita != null ? pacientes.FirstOrDefault(p => p.Id == proximaCita.PacienteId) : null;
            ViewBag.ProximoMedico = proximaCita != null ? medicos.FirstOrDefault(m => m.Id == proximaCita.MedicoId) : null;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
