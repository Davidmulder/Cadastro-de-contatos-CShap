using Cadastro_de_contatos.Helper;
using Cadastro_de_contatos.Models;
using Cadastro_de_contatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cadastro_de_contatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio,ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }


        public IActionResult Index()
        {
            // se usuario estive logado fica na tela principal

            if (_sessao.BuscaSessaoUsuario() != null) return RedirectToAction("Index", "Home"); // se ele tive logado 

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]

        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid) // ele e valido

                   
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscaPorLogin(loginModel.Login);


                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                            {

                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");

                        }

                        TempData["MensagemErro"] = $"sua senha invalida";



                    }
                    TempData["MensagemErro"] = $"usuario  invalido";

                }
                return View("Index");
            }

            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Erro de Login{ erro.Message }";
                return RedirectToAction("Index");
            }
        }
    }
}
