using VendaLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace VendaLivros.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }

        public DbSet<LivrosModel> Livros { get; set; }
        public DbSet<UsuariosModel> Usuarios { get; set; }
       


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LivrosModel>(entity => {
                entity.Property(e => e.Preco)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired(); 
            });

            
            modelBuilder.Entity<UsuariosModel>(entity => {
                
            });
        }
    }
}





