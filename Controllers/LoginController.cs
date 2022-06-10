using Cadastro_de_contatos.Models;
using Cadastro_de_contatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cadastro_de_contatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        public IActionResult Index()
        {
            return View();
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
