namespace BarberiaAPI.Data
{
    using BarberiaAPI.Model;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class BarberiaContext : DbContext
    {
        public BarberiaContext(DbContextOptions<BarberiaContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }

}
