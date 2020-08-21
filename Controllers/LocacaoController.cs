using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netfilmes.Business.Entidades;
using Netfilmes.Business.Servicos.Interfaces;

namespace Netfilmes.Controllers
{
    [Route("/netfilmes/locacao")]
    public class LocacaoController : Controller
    {
        private readonly IFilmeService _filmeService;
        private readonly ILocacaoService _locacaoService;

        public LocacaoController(IFilmeService filmeService, ILocacaoService locacaoService)
        {
            _filmeService = filmeService;
            _locacaoService = locacaoService;
        }

        // Retorna a página de locação de filmes
        public IActionResult Index()
        {
            try
            {
                // Verifica se o usuário está autenticado, caso não esteja, ele é redirecionado para a tela de login.
                if (HttpContext.Session.GetString("UsuarioAutenticado") != null)
                {
                    // Retorna uma lista com todas as locações cadastradas
                    var locacoes = _locacaoService.ListarTodos();

                    // Passa a lista para a ViewBag, para exibição na página
                    ViewBag.Locacoes = locacoes;

                    // Se a lista não existir ou estiver vazia, o usuário é informado
                    if (locacoes == null || locacoes.Count == 0)
                    {
                        TempData["MensagemErro"] = "Não existem locações cadastradas.";
                    }

                    // Retorna uma lista com todos os filmes ativos e não locados, para que o usuário possa seleciona-los para locação
                    var filmesNaoLocados = _filmeService.ListarNaoLocados();

                    // Passa a lista com os filmes para a ViewBag, para ser exibida em tela
                    ViewBag.FilmesNaoLocados = filmesNaoLocados;
                }
                else
                {
                    // Mensagem exibida caso o usuario tente acessar a pagina mas não esteja autenticado
                    TempData["MensagemErro"] = "Faça login para acessar o sistema.";

                    // Redireciona o usuario para a tela de login, para que faca a autenticacao
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Não foi possível realizar a operação. Algum erro ocorreu.";
            }

            // Retorna a página inicial de locação
            return View("~/Views/Locacao/IndexLocacao.cshtml");
        }

        // Cadastra uma nova locação no banco de dados
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Locacao locacao, List<int> filmesId)
        {
            try
            {
                // Verifica se o usuário está autenticado, caso não esteja, ele é redirecionado para a tela de login.
                if (HttpContext.Session.GetString("UsuarioAutenticado") != null)
                {
                    // Realiza o cadastro de um locação e faz a ligação com os filmes locados
                    var sucesso = _locacaoService.Cadastrar(locacao, filmesId);

                    // Apos realizar a operação, se houver sucesso exibe a mensagem de sucesso
                    if (sucesso) TempData["MensagemSucesso"] = "Operação realizada com sucesso.";
                }
                else
                {
                    // Mensagem exibida caso o usuario tente acessar a pagina mas não esteja autenticado
                    TempData["MensagemErro"] = "Faça login para acessar o sistema.";

                    // Redireciona o usuario para a tela de login, para que faca a autenticacao
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception e)
            {
                // Caso alguma exceção ocorra, uma mensagem de erro é exibida ao usuário
                TempData["MensagemErro"] = "Não foi possível realizar a operação. Algum erro ocorreu.";
            }

            return RedirectToAction("Index");
        }

        // Termina o relacionamento entre os filmes selecionados e a locacao
        [HttpPost("desalocar")]
        public IActionResult Desalocar(List<int> filmesId)
        {
            try
            {
                // Verifica se o usuário está autenticado, caso não esteja, ele é redirecionado para a tela de login.
                if (HttpContext.Session.GetString("UsuarioAutenticado") != null)
                {
                    // Passa a lista de Ids dos filmes selecionados para que sejam removidos os relacionamentos
                    var sucesso = _locacaoService.Desalocar(filmesId);


                    // Apos realizar a operação, se os generos e filmes selecionados foram removidos exibe mensagem de sucesso
                    if (sucesso) TempData["MensagemSucesso"] = "Operação realizada com sucesso.";
                }
                else
                {
                    // Mensagem exibida caso o usuario tente acessar a pagina mas não esteja autenticado
                    TempData["MensagemErro"] = "Faça login para acessar o sistema.";

                    // Redireciona o usuario para a tela de login, para que faca a autenticacao
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception e)
            {
                // Caso alguma exceção ocorra, uma mensagem de erro é exibida ao usuário
                TempData["MensagemErro"] = "Não foi possível realizar a operação. Algum erro ocorreu.";
            }

            return RedirectToAction("Index");
        }
    }
}