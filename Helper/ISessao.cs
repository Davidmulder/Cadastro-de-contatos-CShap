using Cadastro_de_contatos.Models;

namespace Cadastro_de_contatos.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuarioModel usuario);

        void RemoverSessaoUsuario();

        UsuarioModel BuscaSessaoUsuario();
    }
}
