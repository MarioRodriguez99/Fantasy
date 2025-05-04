using Fantasy.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fantasy.Bakend.Data
{
    public class FantasyContext : DbContext

    {
        public FantasyContext(DbContextOptions<FantasyContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        //Creando indice unico para paises (Para que no se repitan) en el campo name usando el siguiente metodo:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Aqui se indica el modelBuilder para en la clase Country con HasIndex en name para evitar repetir nombres en los paises:
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
        }
    }
}