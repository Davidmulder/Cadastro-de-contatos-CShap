using Cadastro_de_contatos.Models;
using System.Collections.Generic;

namespace Cadastro_de_contatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
       // UsuarioModel BuscaPorLogin(string login, string senha);

        UsuarioModel BuscaPorLogin(string login);

        UsuarioModel ListaId(int id);

        List<UsuarioModel> BuscarTodos();

        UsuarioModel AdicionarUsuario(UsuarioModel usuario);

        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);

    }
}
