﻿namespace BarberiaFront.Models
{
    public class Cliente{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Preferencias { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}

