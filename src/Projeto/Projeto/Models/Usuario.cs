using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email obrigatório!")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Digite um e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CPF obrigatório!")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$", ErrorMessage = "Digite o CPF corretamente")]
        public string CPF { get; set; }

        [RegularExpression(@"(^[0-9]{2})?(\s|-)?(9?[0-9]{1})(9?[0-9]{4})-?([0-9]{4}$)", ErrorMessage = "Digite um telefone válido.")]
        [Required(ErrorMessage = "Telefone obrigatório!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Endereço obrigatório!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Senha obrigatória!")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=^.{6,}$)((?=.*\w)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[|!""$%&\/\(\)\?\^\'\\\+\-\*]))^.*", ErrorMessage = "Senha de no mínimo 6 caracteres, pelo menos uma letra maiúscula, pelo menos uma letra minúscula, pelo menos um número, pelo menos um caractere especial")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAtualizacao { get; set; }

    }

    static class UsuarioLogado
    {
        public static Usuario usuario { get; set; }
        public static int bibliotecaId { get; set; }

        public static bool usuarioLogado()
        {
            return usuario != null;
        }
    }
}
