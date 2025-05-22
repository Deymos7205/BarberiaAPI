namespace BarberiaFront.Models
{
    public class Gasto{
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Comprobante { get; set; }
        public int UsuarioID { get; set; }
    }
}

