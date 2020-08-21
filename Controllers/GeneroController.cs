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
    [Route("/netfilmes/generos")]
    public class GeneroController : Controller
    {
        private readonly IGeneroService _generoService;
        private readonly IFilmeService _filmeService;

        public GeneroController(IGeneroService generoService, 
                                IFilmeService filmeService)
        {
            _generoService = generoService;
            _filmeService = filmeService;
        }

        // Retorna a página principal do CRUD de Genero
        public IActionResult Index()
        {
            try
            {
                // Verifica se o usuário está autenticado, caso não esteja, ele é redirecionado para a tela de login.
                if (HttpContext.Session.GetString("UsuarioAutenticado") != null)
                {
                    // Retorna uma lista com todos os generos cadastrados no banco de dados
                    var generos = _generoService.ListarTodos();

                    // Guarda a lista na ViewBag, para exibi-la na página para o usuario
                    ViewBag.Generos = generos;

                    // Verifica se a lista de generos esta vazia, caso esteja, exibe a mensagem informando o usuario
                    if (generos == null || generos.Count == 0)
                    {
                        TempData["MensagemErro"] = "Não existem gêneros cadastrados.";
                    }
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
            
            // Retorna a página inicial do CRUD de Genero
            return View("~/Views/Genero/IndexGenero.cshtml");
        }

        // Retorna o formulário de cadastro da entidade Genero
        // Uma rota é para retornar apenas o formulario, a outra para retornar 
        // o formulario e os dados para preenche-lo (edição)
        [HttpGet("cadastro")]
        [HttpGet("cadastro/{id}")]
        public IActionResult Cadastro(int id)
        {
            try
            {
                // Verifica se o usuário está autenticado, caso não esteja, ele é redirecionado para a tela de login.
                if (HttpContext.Session.GetString("UsuarioAutenticado") != null)
                {
                    // Se for passado o id do genero, então se trata de edição
                    if (id > 0)
                    {
                        // Obtem o genero pelo seu id
                        var genero = _generoService.ConsultarPorId(id);

                        // Armazena o geneor na ViewBag para preencher os campos do formulario
                        ViewBag.Genero = genero;
                    }
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

            return View("~/Views/Genero/CadastroGeneros.cshtml");
        }

        // Inseri ou altera no banco de dados um registro da entidade Genero
        [HttpPost("salvar")]
        public IActionResult Salvar(Genero genero)
        {
            try
            {
                // Verifica se o usuário está autenticado, caso não esteja, ele é redirecionado para a tela de login.
                if (HttpContext.Session.GetString("UsuarioAutenticado") != null)
                {
                    // Recebe um objeto do tipo Genero, com os dados vindos do formulário, 
                    // e o inseri no banco ou atualiza um registro dele ja existente
                    var sucesso = _generoService.Cadastrar(genero);

                    // Apos realizar a operação (inserção ou alteração), se houve sucesso 
                    // exibe a mensagem de sucesso, caso contrário a de erro
                    if (sucesso)
                        TempData["MensagemSucesso"] = "Operação realizada com sucesso.";
                    else
                        TempData["MensagemErro"] = "Não foi possível realizar a operação.";
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

            // Apos inserir ou atualizar um registro de Genero, redireciona a requisição 
            // para a action "Index", para que a pagina inicial do CRUD seja retornada
            return RedirectToAction("Index");
        }

        // Deleta todos os generos e/ou filmes selecionados na listagem
        [HttpPost("remover/selecionados")]
        public IActionResult RemoverSelecionados(List<int> generosId, List<int> filmesId)
        {
            try
            {
                // Verifica se o usuário está autenticado, caso não esteja, ele é redirecionado para a tela de login.
                if (HttpContext.Session.GetString("UsuarioAutenticado") != null)
                {
                    // Passa a lista de Ids dos generos selecionados para que sejam removidos
                    var sucesso = _generoService.RemoverSelecionados(generosId);

                    // Passa a lista de Ids dos filmes selecionados para a remoção
                    sucesso = _filmeService.RemoverSelecionados(filmesId);

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

        // Deleta o filme de acordo com o seu Id
        [HttpGet("remover/{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                // Verifica se o usuário está autenticado, caso não esteja, ele é redirecionado para a tela de login.
                if (HttpContext.Session.GetString("UsuarioAutenticado") != null)
                {
                    // Remove do banco um registro de genero pelo seu Id
                    var sucesso = _generoService.RemoverPorId(id);

                    // Apos realizar a operação, se houve sucesso, exibe a mensagem de sucesso, caso contrário a de erro
                    if (sucesso)
                        TempData["MensagemSucesso"] = "Operação realizada com sucesso.";
                    else
                        TempData["MensagemErro"] = "Não foi possível realizar a operação.";
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