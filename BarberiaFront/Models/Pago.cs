namespace BarberiaFront.Models
{
    public class Pago{
        public int Id { get; set; }
        public int TurnoId { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
