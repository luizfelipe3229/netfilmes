using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netfilmes.Business.Entidades;
using Netfilmes.Business.Servicos.Interfaces;
using System;

namespace Netfilmes.Controllers
{
    [Route("")]
    [Route("/netfilmes")]
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // Retorna a pagina de login
        public IActionResult Index()
        {
            return View();
        }

        // Realiza a autenticação do usuário
        [HttpPost("autenticar")]
        public IActionResult Autenticar(Usuario usuario)
        {
            try
            {
                // Busca um usuário com as credenciais informadas
                var usuarioAutenticado = _usuarioService.Buscar(usuario);

                // Se o usuário estiver cadastrado, redireciona a requisição para a tela principal do CRUD de filmes,
                if (usuarioAutenticado != null)
                {
                    // Guarda na sessão a informação que o usuário foi autenticado, para poder autorizar o acesso em outras actions
                    HttpContext.Session.SetString("UsuarioAutenticado", "Autenticado");

                    return RedirectToAction("Index", "Filme");
                }
                else
                {
                    TempData["MensagemErro"] = "Falha na autenticação. Usuário ou senha incorretos.";
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Não foi possível realizar a operação. Algum erro ocorreu.";
            }

            return RedirectToAction("Index");
        }

        // Realiza o logout
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            // Retira da sessão a informação de que o usuário está autenticado,
            // impedindo assim o acesso as páginas da aplicação
            HttpContext.Session.Remove("UsuarioAutenticado");

            // Retorna para a página de login
            return View("~/Views/Login/Index.cshtml");
        }
    }
}