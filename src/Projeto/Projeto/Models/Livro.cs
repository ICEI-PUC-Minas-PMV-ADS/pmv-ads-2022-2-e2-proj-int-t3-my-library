using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models
{
    [Table("Livros")]
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public int BibliotecaId { get; set; }
        [ForeignKey("BibliotecaId")]
        public Biblioteca Biblioteca { get; set; }

        [Required(ErrorMessage = "Email obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email obrigatório!")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Email obrigatório!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Email obrigatório!")]
        public int Ano { get; set; }
        public string Genero { get; set; }

        [Required(ErrorMessage = "Email obrigatório!")]
        public string Editora { get; set; }

        [Required(ErrorMessage = "Email obrigatório!")]
        public int Paginas { get; set; }
        public string ISBN { get; set; }
        public string Local { get; set; }
        public bool Emprestar { get; set; }

    }
}
