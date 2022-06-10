using Cadastro_de_contatos.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cadastro_de_contatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Login obrigatorio")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo E-mail Obrigatorio")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Perfil obrigatorio")]
        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "Campo Senha obrigatorio")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }  

        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }


    }
}
