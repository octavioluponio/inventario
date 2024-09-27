using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace luponio_madereras.Models
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        // Definir DbSet para las tablas de la base de datos
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

   
        public DbSet<Proveedor> Proveedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuraciones adicionales de modelos
        }

    }
}
