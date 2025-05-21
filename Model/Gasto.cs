namespace BarberiaAPI.Model
{
    public class Gasto{
        public int IdGasto{ get; set; }
        public decimal? Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string? Descripcion { get; set; }
        public string? Comprobante { get; set; }
    }
}

