using ApiEuroCorp.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiEuroCorp.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get;set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>()
                .HasKey(a => a.Rut);

            modelBuilder.Entity<Libro>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Autor)
                .WithMany(a => a.Libros)
                .HasForeignKey(l => l.AutorRut)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
