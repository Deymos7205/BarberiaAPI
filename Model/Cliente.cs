namespace BarberiaAPI.Model
{
    public class Cliente{
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = default!;
        public string Cedula { get; set; } = default!;
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Preferencias { get; set; }
        public DateTime Fecha_Registro { get; set; }
    }
}

