using Cadastro_de_contatos.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Cadastro_de_contatos.Helper
{
    public class Sessao : ISessao

    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext )
        {
            _httpContext = httpContext;
        }
        
        public UsuarioModel BuscaSessaoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado"); // busca a sessao
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(UsuarioModel usuario)
        {
            string valor=JsonConvert.SerializeObject(usuario); // transforma em strig serializada
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado",valor);
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
