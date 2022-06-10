using Cadastro_de_contatos.Data;
using Cadastro_de_contatos.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro_de_contatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {

        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel ListaId(int id)
        {
           return _bancoContext.Contatos.FirstOrDefault(x=> x.Id == id); // pega aquele que tive o id igual aque recebe
        }


        public List<ContatoModel> BuscaTodos()
        {
            return _bancoContext.Contatos.ToList(); // busca todos da tabela
        }


      


        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);  // cadastra do conteudo
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
           ContatoModel contatoDB= ListaId(contato.Id); // pega o id 
            if (contatoDB == null) throw new System.Exception("erro"); 
            contatoDB.Nome=contato.Nome;
            contatoDB.Email=contato.Email;
            contatoDB.Celular=contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges(); // salva atualizações
            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListaId(id); // pega o id 
            if (contatoDB == null) throw new System.Exception("erro");
            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;

        }

        
    }
}
