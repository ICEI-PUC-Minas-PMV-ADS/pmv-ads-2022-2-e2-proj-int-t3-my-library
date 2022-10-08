using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatório!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nome obrigatório!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Nome obrigatório!")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Nome obrigatório!")]
        public string Telefone { get; set; }

    }
}
