﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CPF obrigatório!")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Telefone obrigatório!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Endereço obrigatório!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Senha obrigatória!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAtualizacao { get; set; }

    }

    static class UsuarioLogado
    {
        public static Usuario usuario { get; set; }

        public static bool usuarioLogado()
        {
            return usuario != null;
        }
    }
}
