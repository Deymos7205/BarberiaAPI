namespace BarberiaAPI.Model
{
    public class Turno{
        public int IdTurno { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string? TipoCorte { get; set; }
        public decimal? Precio { get; set; }
        public string? Notas { get; set; }
    }
}
