using System.ComponentModel.DataAnnotations;

namespace Cadastro_de_contatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Campo nome obrigatorio")]
        public string Nome { get; set; }

        [Required (ErrorMessage ="Campo E-mail Obrigatorio")]
        [EmailAddress (ErrorMessage ="Email invalido")]
        public string Email { get; set; }

        [Required (ErrorMessage ="Campo Telefone Obrigatorio")]
        [Phone (ErrorMessage ="Telefone invalido")]
        public string Celular { get; set; } 

    }
}
