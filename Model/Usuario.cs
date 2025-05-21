namespace BarberiaAPI.Model
{
    public class Usuario{
        public int Id_Usuario { get; set; }
        public string Nombre { get; set; } = default!;
        public string Cedula { get; set; } = default!;
        public string? Telefono { get; set; }
        public string Contrasena { get; set; } = default!;
        public int Id_Rol { get; set; }
    }
}


