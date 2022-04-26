using Cadastro_de_contatos.Models;
using System.Collections.Generic;

namespace Cadastro_de_contatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListaId(int id);
        List<ContatoModel> BuscaTodos(); // pega todos o dados cadastrados da tabela contatos


        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);
    }
}
