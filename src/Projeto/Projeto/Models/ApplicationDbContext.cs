using Microsoft.EntityFrameworkCore;

namespace Projeto.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //coleção de veiculos
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
