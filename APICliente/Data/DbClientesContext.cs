using APICliente.Models;
using Microsoft.EntityFrameworkCore;

namespace APICliente.Data
{
    public class DbClientesContext : DbContext
    {
        public DbClientesContext(DbContextOptions<DbClientesContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Logradouro> Logradouros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(cliente => cliente.Id);
            modelBuilder.Entity<Logradouro>().HasKey(logradouro => logradouro.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
