namespace BarberiaAPI.Model
{
    public class Pago{
        public int IdPago { get; set; }
        public int IdTurno { get; set; }
        public decimal? Monto { get; set; }
        public string? MetodoPago { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
