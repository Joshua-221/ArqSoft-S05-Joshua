using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CitasApp.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un paciente.")]
        public int PacienteId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un médico.")]
        public int MedicoId { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Fecha { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly Hora { get; set; }

        public string Motivo { get; set; } = string.Empty;

        [JsonIgnore]
        [Required(ErrorMessage = "El asunto del paciente es obligatorio.")]
        public string Asunto
        {
            get => Motivo;
            set => Motivo = value;
        }

        public string Estado { get; set; } = "Pendiente";
    }
}
