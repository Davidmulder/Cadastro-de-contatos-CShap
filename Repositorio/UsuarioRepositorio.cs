using Cadastro_de_contatos.Data;
using Cadastro_de_contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro_de_contatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel BuscaPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper()); 

        }




        public UsuarioModel ListaId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id); // pega aquele que tive o id igual aque recebe
        }


        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList(); // busca todos da tabela
        }




        public UsuarioModel AdicionarUsuario(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuario);  // cadastra de usuario
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListaId(usuario.Id); // pega o id 

            if (usuarioDB == null) throw new System.Exception("erro");
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Senha = usuario.Senha;
            usuarioDB.Perfil= usuario.Perfil;
            usuario.DataAtualizacao = DateTime.Now;
            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges(); // salva atualizações
            return usuarioDB;
        }




        public bool Apagar(int id)
        {

            UsuarioModel usuarioDB = ListaId(id); // pega o id 

            if (usuarioDB == null) throw new System.Exception("erro");

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();
            return true;
        }

       
    }
}
