using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netfilmes.Business.Entidades;
using Netfilmes.Business.Servicos.Interfaces;
using Newtonsoft.Json;

namespace Netfilmes.Controllers
{
    [Route("/netfilmes/filmes")]
    public class FilmeController : Controller
    {
        private readonly IGeneroService _generoService;
        private readonly IFilmeService _filmeService;
        private readonly ILocacaoService _locacaoService;

        public FilmeController(IGeneroService generoService, 
                               IFilmeService filmeService,
                               ILocacaoService locacaoService)
        {
            _generoService = generoService;
            _filmeService = filmeService;
            _locacaoService = locacaoService;
        }

        // Retorna a página principal do CRUD Filme
        public IActionResult Index()
        {
            try
            {
                // Verifica se o usuário está autenticado, caso não esteja, ele é redirecionado para a tela de login.
                if (HttpContext.Session.GetString("UsuarioAutenticado") != null)
                {
                    // Na tela inicial, apos o login, exibe as entidades (Filme, Genero, Locacao) registradas no banco de dados 
                    var filmes = _filmeService.ListarTodos();
                    ViewBag.Filmes = filmes;

                    var generos = _generoService.ListarTodos();
                    ViewBag.Generos = generos;

                    var locacoes = _locacaoService.ListarTodos();
                    ViewBag.Locacoes = locacoes;
                }
                else
                {
                    TempData["MensagemErro"] = "Faça login para acessar o sistema.";
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Não foi possível realizar a operação. Algum erro ocorreu.";
            }

            // Retorna a página inicial do CRUD de Filme
            return View("~/Views/Filme/IndexFilmes.cshtml");
        }

        // Retorna o formulário de cadastro/alteração da entidade Filme
        [HttpGet("cadastro")]
        [HttpGet("cadastro/{id}")]
        public IActionResult Cadastro(int id)
        {
            try
            {
                // Verifica se o usuário está autenticado, caso não esteja, ele é redirecionado para a tela de login.
                if (HttpContext.Session.GetString("UsuarioAutenticado") != null)
                {
                    // Se for passado o id do filme, então se trata de edição
                    if (id > 0)
                    {
                        // Obtem o filme pelo seu id
                        var filme = _filmeService.ConsultarPorId(id);

                        // Armazena o filme na ViewBag para preencher os campos do formulario
                        ViewBag.Filme = filme;
                    }

                    // Retorna uma lista com todos os generos cadastrados ativos no banco de dados
                    var generosAtivos = _generoService.ListarAtivos();

                    // Armazena a lista de generos para exibir no campo de generos
                    ViewBag.GenerosAtivos = generosAtivos;

                    // Verifica se foi retornada uma lista com algum item, se não, exibe a seguinte mensagem para o usuário
                    if (generosAtivos == null || generosAtivos.Count == 0)
                    {
                        TempData["MensagemErro"] = "Não existem gêneros ativos cadastrados.";
                    }
                }
                else
                {
                    TempData["MensagemErro"] = "Faça login para acessar o sistema.";
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Não foi possível realizar a operação. Algum erro ocorreu.";
            }

            return View("~/Views/Filme/CadastroFilmes.cshtml");
        }

        // Inseri ou altera no banco de dados um registro da entidade Filme
        [HttpPost("salvar")]
        public IActionResult Salvar(Filme filme)
        {
            bool sucesso = false;

            try
            {
                // Verifica se o usuário está autenticado, caso não esteja, ele é redirecionado para a tela de login.
                if (HttpContext.Session.GetString("UsuarioAutenticado") != null)
                {
                    // Recebe um objeto do tipo Filme, com os dados vindos do formulário, 
                    // e o inseri no banco ou atualiza um registro dele ja existente
                    sucesso = _filmeService.Cadastrar(filme);

                    // Apos realizar a operação (inserção ou alteração), se houve sucesso 
                    // exibe a mensagem de sucesso, caso contrário a de erro
                    if (sucesso)
                        TempData["MensagemSucesso"] = "Operação realizada com sucesso.";
                    else
                        TempData["MensagemErro"] = "Não foi possível realizar a operação.";
                }
                else
                {
                    TempData["MensagemErro"] = "Faça login para acessar o sistema.";
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception e)
            {
                // Caso alguma exceção ocorra, uma mensagem de erro é exibida ao usuário
                TempData["MensagemErro"] = "Não foi possível realizar a operação. Algum erro ocorreu.";
            }

            // Apos inserir ou atualizar um registro de Filme, redireciona a requisição 
            // para a action "Index", para que a pagina inicial do CRUD seja retornada
            return RedirectToAction("Index");
        }

        // Deleta todos os filmes selecionados na listagem
        [HttpPost("remover/selecionados")]
        public IActionResult RemoverSelecionados(List<int> filmesId)
        {
            bool sucesso = false;

            try
            {
                // Verifica se o usuário está autenticado, caso não esteja, ele é redirecionado para a tela de login.
                if (HttpContext.Session.GetString("UsuarioAutenticado") != null)
                {
                    // Recebe uma lista de ids dos filmes selecionados para a remoção, 
                    // para que os registros sejam removidos do banco de dados
                    sucesso = _filmeService.RemoverSelecionados(filmesId);

                    // Apos realizar a operação, se houver sucesso, exibe a mensagem de sucesso
                    if (sucesso) TempData["MensagemSucesso"] = "Operação realizada com sucesso.";
                }
                else
                {
                    // Mensagem exibida caso o usuario não esteja autenticado
                    TempData["MensagemErro"] = "Faça login para acessar o sistema.";

                    // Redireciona o usuario para a pagina de login
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception e)
            {
                // Caso alguma exceção ocorra, uma mensagem de erro é exibida ao usuário
                TempData["MensagemErro"] = "Não foi possível realizar a operação. Algum erro ocorreu.";
            }

            // Apos a remoção redireciona o usuario para a pagina inicial do CRUD de filmes
            return RedirectToAction("Index");
        }

        // Deleta o filme de acordo com o seu Id
        [HttpGet("remover/{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                // Verifica se o usuário está autenticado, caso não esteja, ele é redirecionado para a tela de login.
                if (HttpContext.Session.GetString("UsuarioAutenticado") != null)
                {
                    // Remove do banco um registro de filme pelo seu Id
                    var sucesso = _filmeService.RemoverPorId(id);

                    // Apos realizar a operação, se houve sucesso, exibe a mensagem de sucesso, caso contrário a de erro
                    if (sucesso)
                        TempData["MensagemSucesso"] = "Operação realizada com sucesso.";
                    else
                        TempData["MensagemErro"] = "Não foi possível realizar a operação.";
                }
                else
                {
                    TempData["MensagemErro"] = "Faça login para acessar o sistema.";
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