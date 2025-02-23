using Microsoft.EntityFrameworkCore;
using DemoCharla.Models;

namespace DemoCharla.Data
{
    public class ProductoContext:DbContext
    {
        public ProductoContext(DbContextOptions<ProductoContext> options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación entre Producto y Empresa
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Empresa)
                .WithMany() // Asumiendo que una empresa puede tener muchos productos
                .HasForeignKey(p => p.EmpresaId);
        }

    }
}
