using System.ComponentModel.DataAnnotations;

namespace BarberiaFront.Models
{
    public class Turno
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El cliente es obligatorio.")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "El usuario (barbero) es obligatorio.")]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public TimeSpan Hora { get; set; }
        [Required(ErrorMessage = "La hora es obligatoria.")]
        public string TipoCorte { get; set; }
        [Required(ErrorMessage = "El tipo de corte es obligatorio.")]
        [StringLength(100, ErrorMessage = "El tipo de corte no puede exceder los 100 caracteres.")]
        public decimal Precio { get; set; }
        [StringLength(500, ErrorMessage = "Las notas no pueden exceder los 500 caracteres.")]
        public string Notas { get; set; }

    }
}
