namespace BarberiaAPI.Model
{
    public class Turno{
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string TipoCorte { get; set; }
        public decimal Precio { get; set; }
        public string Notas { get; set; }
    }
}
