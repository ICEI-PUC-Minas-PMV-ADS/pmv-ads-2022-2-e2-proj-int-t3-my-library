using Projeto.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models
{
    [Table("Reservas")]
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public int LivroId { get; set; }
        [ForeignKey("LivroId")]
        public Livro Livro { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        public DateTime DataFim { get; set; }

        public Status Status{
            get;
            set;
        }

        public int AvaliacaoProprietario { get; set; }

        public int AvaliacaoConsulente { get; set; }

        public DateTime DataDevolucaoAntecipada { get; set; }

    }
}
