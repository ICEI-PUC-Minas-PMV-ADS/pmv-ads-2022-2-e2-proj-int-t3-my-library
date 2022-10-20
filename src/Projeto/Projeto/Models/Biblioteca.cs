using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models
{
    [Table("Biblitoecas")]
    public class Biblioteca
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public string Nome { get; set; }

        public bool Compartilhar { get; set; }
    
    }
}
