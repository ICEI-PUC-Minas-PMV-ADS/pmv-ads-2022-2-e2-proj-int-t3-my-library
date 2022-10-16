using Microsoft.EntityFrameworkCore;

namespace Projeto.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Biblioteca> Bibliotecas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}
