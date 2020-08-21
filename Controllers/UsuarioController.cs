using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Netfilmes.Business.Entidades;
using Netfilmes.Business.Servicos.Interfaces;

namespace Netfilmes.Controllers
{
    [Route("/netfilmes/usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // Retorna o formulário de cadastro de usuario
        [HttpGet("cadastro")]
        public IActionResult Cadastro(int id)
        {
            return View("~/Views/Usuario/CadastroUsuarios.cshtml");
        }

        // Insere no banco um registro da entidade Usuario
        [HttpPost("salvar")]
        public IActionResult Salvar(Usuario usuario)
        {
            bool sucesso = false;

            try
            {
                // Recebe um objeto do tipo Usuario, com os dados vindos do formulário, e o insere no banco ou o atualiza
                sucesso = _usuarioService.Cadastrar(usuario);

                // Apos realizar a operação (inserção ou alteração), se houve sucesso 
                // exibe a mensagem de sucesso, caso contrário a de erro
                if (sucesso)
                    TempData["MensagemSucesso"] = "Operação realizada com sucesso.";
                else
                    TempData["MensagemErro"] = "Não foi possível realizar a operação.";
            }
            catch (Exception e)
            {
                // Caso alguma exceção ocorra, uma mensagem de erro é exibida ao usuário
                TempData["MensagemErro"] = "Não foi possível realizar a operação. Algum erro ocorreu.";
            }

            return RedirectToAction("Index", "Login");
        }
    }
}