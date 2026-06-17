using CitasApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly ICitaService _citaService;
        private readonly IPacienteService _pacienteService;
        private readonly IMedicoService _medicoService;

        public CitasController(ICitaService citaService,
            IPacienteService pacienteService,
            IMedicoService medicoService)
        {
            _citaService = citaService;
            _pacienteService = pacienteService;
            _medicoService = medicoService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_citaService.ObtenerTodos());

        [HttpGet("porpaciente/{pacienteId}")]
        public IActionResult PorPaciente(int pacienteId)
        {
            var citas = _citaService.ObtenerPorPaciente(pacienteId);
            return citas == null || citas.Count == 0 ? NotFound() : Ok(citas);
        }
    }
}