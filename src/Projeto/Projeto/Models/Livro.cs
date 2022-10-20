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

        [Required(ErrorMessage = "Nome obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Autor obrigatório!")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Título obrigatório!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Ano obrigatório!")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Gênero obrigatório!")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Editora obrigatório!")]
        public string Editora { get; set; }

        [Required(ErrorMessage = "Quantidade de páginas obrigatório!")]
        public int Paginas { get; set; }

        [Required(ErrorMessage = "ISBN obrigatório!")]
        public string ISBN { get; set; }

        public string Local { get; set; }

        public bool Emprestar { get; set; }

    }
}
