using Cadastro_de_contatos.Filters;
using Cadastro_de_contatos.Models;
using Cadastro_de_contatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cadastro_de_contatos.Controllers
{
    [PaginaParaAdmin] // somente para admin
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        public IActionResult Index()
        {
            List<UsuarioModel> usuario = _usuarioRepositorio.BuscarTodos();
            return View(usuario);
        }






        public IActionResult Criar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid) // se for valido
                {
                    _usuarioRepositorio.AdicionarUsuario(usuario);
                    TempData["MensagemSucesso"] = "Mensagem Realizado com sucesso";
                    return RedirectToAction("Index");  // redireciono apos grava para pagina index
                }
                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro de cadastro{ erro.Message }";
                return RedirectToAction("Index");  // redireciono apos grava para pagina index
            }
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListaId(id);
            return View(usuario);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListaId(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {

            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

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


        public IActionResult Alterar(UsuarioModel usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "contato alterado com sucesso";
                    return RedirectToAction("Index");  // redireciono apos grava para pagina index
                }
                return View("Editar", usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro de Edição{ erro.Message }";
                return RedirectToAction("Index");  // redireciono apos grava para pagina index
            }





        }




    }
}
