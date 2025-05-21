namespace BarberiaAPI.Model
{
    public class Horario{
        public int IdHorario { get; set; }
        public int IdUsuario { get; set; }
        public string? DiaSemana { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
    }
}
