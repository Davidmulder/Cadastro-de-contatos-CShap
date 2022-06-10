using System.ComponentModel.DataAnnotations;

namespace Cadastro_de_contatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo nome obrigatorio")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo nome obrigatorio")]
        public string Senha { get; set; }
    }
}
