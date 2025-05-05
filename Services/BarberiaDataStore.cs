using BarberiaAPI.Model;

namespace BarberiaAPI.Services
{
    public class BarberiaDataStore{
        public static List<Cliente> Clientes { get; } = new() {
            new Cliente { Id=1, Nombre="Lionel Messi", Cedula="10000001", Telefono="555-0001", Direccion="Calle GOAT 10", Preferencias="Corte moderno", FechaRegistro=DateTime.Now },
            new Cliente { Id=2, Nombre="Cristiano Ronaldo", Cedula="10000002", Telefono="555-0002", Direccion="Avenida Champions 7", Preferencias="Fade alto", FechaRegistro=DateTime.Now },
            new Cliente { Id=3, Nombre="Neymar Jr", Cedula="10000003", Telefono="555-0003", Direccion="Boulevard Samba 10", Preferencias="Desvanecido", FechaRegistro=DateTime.Now },
            new Cliente { Id=4, Nombre="Kylian Mbappé", Cedula="10000004", Telefono="555-0004", Direccion="Ruta del Gol 7", Preferencias="Corte clásico", FechaRegistro=DateTime.Now },
            new Cliente { Id=5, Nombre="Zlatan Ibrahimović", Cedula="10000005", Telefono="555-0005", Direccion="Plaza Zlatan 9", Preferencias="Corte con estilo", FechaRegistro=DateTime.Now }
        };
        public static List<Turno> Turnos { get; } = new() {
            new Turno { Id=1, ClienteId=1, UsuarioId=1, Fecha=DateTime.Today, Hora=new TimeSpan(10,0,0), TipoCorte="Corte clásico", Precio=20m, Notas="Sin especificaciones" },
            new Turno { Id=2, ClienteId=1, UsuarioId=1, Fecha=DateTime.Today, Hora=new TimeSpan(10,0,0), TipoCorte="Fade Alto", Precio=20m, Notas="Sin especificaciones" },
            new Turno { Id=3, ClienteId=1, UsuarioId=1, Fecha=DateTime.Today, Hora=new TimeSpan(10,0,0), TipoCorte="Desvanecido", Precio=20m, Notas="Sin especificaciones" }
        };
        public static List<Pago> Pagos { get; } = new() {
            new Pago { Id=1, TurnoId=1, Monto=20000m, MetodoPago="Efectivo", FechaPago=DateTime.Now },
            new Pago { Id=2, TurnoId=2, Monto=30000m, MetodoPago="Trajeta", FechaPago=DateTime.Now },
            new Pago { Id=3, TurnoId=3, Monto=25000m, MetodoPago="Transferencia", FechaPago=DateTime.Now }
        };
        public static List<Gasto> Gastos { get; } = new() {
            new Gasto { Id=1, Monto=50m, Fecha=DateTime.Today, Descripcion="Compra de insumos", Comprobante="Factura 001" }
        };
        public static List<Rol> Roles { get; } = new() {
            new Rol { Id=1, NombreRol="Administrador", Descripcion="Acceso total" },
            new Rol { Id=2, NombreRol="Barbero", Descripcion="Puede gestionar turnos" }
        };
        public static List<Usuario> Usuarios { get; } = new() {
            new Usuario { Id=1, NombreUsuario="admin", Contrasena="0000", RolId=1, Nombre="Admin Principal" },
            new Usuario { Id=2, NombreUsuario="barbero_1", Contrasena="0001", RolId=1, Nombre="Juan" },
            new Usuario { Id=3, NombreUsuario="barbero_2", Contrasena="0002", RolId=1, Nombre="Andres" },

        };
        public static List<Horario> Horarios { get; } = new() {
            new Horario { Id=1, UsuarioId=1, DiaSemana="Lunes", HoraInicio=new TimeSpan(8,0,0), HoraFin=new TimeSpan(17,0,0) },
            new Horario { Id=2, UsuarioId=1, DiaSemana="Martes", HoraInicio=new TimeSpan(8,0,0), HoraFin=new TimeSpan(17,0,0) },
            new Horario { Id=3, UsuarioId=1, DiaSemana="Miercoles", HoraInicio=new TimeSpan(8,0,0), HoraFin=new TimeSpan(17,0,0) },
            new Horario { Id=4, UsuarioId=1, DiaSemana="Jueves", HoraInicio=new TimeSpan(8,0,0), HoraFin=new TimeSpan(17,0,0) },
            new Horario { Id=5, UsuarioId=1, DiaSemana="Viernes", HoraInicio=new TimeSpan(8,0,0), HoraFin=new TimeSpan(17,0,0) },
            new Horario { Id=6, UsuarioId=1, DiaSemana="Sabado", HoraInicio=new TimeSpan(8,0,0), HoraFin=new TimeSpan(17,0,0) }
        };
    }
}

