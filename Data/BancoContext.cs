using Cadastro_de_contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_de_contatos.Data
{
    public class BancoContext: DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)  // setamos os banco no DBcontent option        
        {

        }

        public DbSet<ContatoModel> Contatos { get; set; } // criar a tabela contato
    }
}
