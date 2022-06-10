using Cadastro_de_contatos.Models;
using Cadastro_de_contatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace Cadastro_de_contatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
            

        }      


        public IActionResult Index()
        {

            List<ContatoModel> contato = _contatoRepositorio.BuscaTodos();
           // List<UsuarioModel> list2 = _contatoRepositorio.Buscausuario();


            //  var contatos = list1.Select(x => x.Nome).Except(list2.Select(y => y.Nome)).ToList();

            //  var contatos = (from x in list1  select x.Nome).Except(list2.Select(y => y.Nome)).ToList();

          /*  var contatos = (from x in list1
                            from y in list2
                            .Where(y=> y.Nome == x.Nome)
                            select new { x.Id, x.Nome })
                            .ToList();

            ViewData.Model = contatos; */

            return View(contato);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListaId(id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListaId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {

            try
            {
               bool apagado=  _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Deletado com sucesso";
                    
                }
                else
                {
                    TempData["MensagemErro"] = "Deletado não deu certo";
                }
                return RedirectToAction("Index");

            }

            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro de deletar{ erro.Message }";
                return RedirectToAction("Index");
            }




            
        }


        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid) // se for valido
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Mensagem Realizado com sucesso";
                    return RedirectToAction("Index");  // redireciono apos grava para pagina index
                }
                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro de cadastro{ erro.Message }";
                return RedirectToAction("Index");  // redireciono apos grava para pagina index
            }
        }

        public IActionResult Alterar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "contato alterado com sucesso";
                    return RedirectToAction("Index");  // redireciono apos grava para pagina index
                }
                return View("Editar", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro de Edição{ erro.Message }";
                return RedirectToAction("Index");  // redireciono apos grava para pagina index
            }
            
            
            
            
            
        }

    }
}
