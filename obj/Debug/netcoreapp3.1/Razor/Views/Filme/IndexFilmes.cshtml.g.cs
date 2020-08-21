#pragma checksum "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76e880985804543daa0a23ea8756007ff648f64b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Filme_IndexFilmes), @"mvc.1.0.view", @"/Views/Filme/IndexFilmes.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76e880985804543daa0a23ea8756007ff648f64b", @"/Views/Filme/IndexFilmes.cshtml")]
    public class Views_Filme_IndexFilmes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
  
    ViewData["Title"] = "FilmesDisponiveis";
    Layout = "~/Views/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n\r\n");
#nullable restore
#line 9 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
 if (TempData["MensagemSucesso"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissible\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>\r\n        <strong>");
#nullable restore
#line 13 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
           Write(TempData["MensagemSucesso"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </div>\r\n");
#nullable restore
#line 15 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
 if (TempData["MensagemErro"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger alert-dismissible\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>\r\n        <strong>");
#nullable restore
#line 21 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
           Write(TempData["MensagemErro"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </div>\r\n");
#nullable restore
#line 23 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />

<div class=""row"">
    <div class=""col-md-12"">
        <h3>Filmes</h3>
    </div>
</div>

<br />

<form method=""post"" action=""/netfilmes/filmes/remover/selecionados"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""row"">
                <div class=""col-md-2"">
                    <a href=""/netfilmes/filmes/cadastro"" class=""btn btn-primary"">Cadastrar</a>
                </div>

                <div class=""col-md-3"">
                    <button class=""btn btn-danger"">Deletar Selecionados</button>
                </div>

                <div class=""col-md-3"">
                    <a href=""/netfilmes/locacao"" class=""btn btn-primary"">Locação</a>
                </div>
            </div>

            <br /><br />

            <div class=""row"">
                <div class=""col-md-12"">
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th></th>
               ");
            WriteLiteral(@"                 <th>ID</th>
                                <th>NOME</th>
                                <th>ATIVO</th>
                                <th>GENERO</th>
                                <th>LOCADO</th>
                                <th>OPERAÇÃO</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 69 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                             if (ViewBag.Filmes != null && ViewBag.Filmes.Count > 0)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                 foreach (var filme in ViewBag.Filmes)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td><input type=\"checkbox\"");
            BeginWriteAttribute("value", " value=\"", 2384, "\"", 2401, 1);
#nullable restore
#line 74 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
WriteAttributeValue("", 2392, filme.Id, 2392, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"filmesId\"></td>\r\n                                        <td>");
#nullable restore
#line 75 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                       Write(filme.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 76 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                       Write(filme.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 77 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                        Write(filme.Ativo ? "ATIVO" : "INATIVO");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 78 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                        Write(filme.Genero != null ? filme.Genero.Nome : "SEM GÊNERO");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 79 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                        Write(filme.Locacao != null ? "SIM" : "NÃO");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 2927, "\"", 2970, 2);
            WriteAttributeValue("", 2934, "/netfilmes/filmes/cadastro/", 2934, 27, true);
#nullable restore
#line 81 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
WriteAttributeValue("", 2961, filme.Id, 2961, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Alterar</a>\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 3055, "\"", 3097, 2);
            WriteAttributeValue("", 3062, "/netfilmes/filmes/remover/", 3062, 26, true);
#nullable restore
#line 82 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
WriteAttributeValue("", 3088, filme.Id, 3088, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Deletar</a>\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 85 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 85 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                 
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <tr>
                                    <td colspan=""7"" class=""text-center"">
                                        <strong>Não existem filmes cadastrados.</strong>
                                    </td>
                                </tr>
");
#nullable restore
#line 94 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</form>

<br />
<hr />
<br />

<div class=""row"">
    <div class=""col-md-12"">
        <h3>Gêneros</h3>
    </div>
</div>

<br />

<div class=""row"">
    <table class=""table"">
        <thead>
            <tr>
                <th>ID</th>
                <th>NOME</th>
                <th>ATIVO</th>
                <th>FILMES</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 126 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
             if (ViewBag.Generos != null && ViewBag.Generos.Count > 0)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 128 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                 foreach (var genero in ViewBag.Generos)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 131 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                       Write(genero.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 132 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                       Write(genero.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 133 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                        Write(genero.Ativo ? "ATIVO" : "INATIVO");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n");
#nullable restore
#line 135 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                             if (genero.Filmes != null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <ul style=\"list-style-type: none; padding-left:0;\">\r\n");
#nullable restore
#line 138 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                     foreach (var filme in genero.Filmes)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li>");
#nullable restore
#line 140 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                       Write(filme.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 141 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </ul>\r\n");
#nullable restore
#line 143 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <strong style=\"color: red;\">N/A</strong>\r\n");
#nullable restore
#line 147 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 150 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 150 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                 
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"3\" class=\"text-center\">\r\n                        <strong>Não existem gêneros cadastrados.</strong>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 159 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>

<br />
<hr />
<br />

<div class=""row"">
    <div class=""col-md-12"">
        <h3>Locações</h3>
    </div>
</div>

<br />

<div class=""row"">
    <div class=""col-md-12"">
        <div class=""row"">
            <div class=""col-md-12"">
                <table class=""table"">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>CPF DO CLIENTE</th>
                            <th>FILMES</th>
                            <th>DATA DE LOCAÇÃO</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 190 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                         if (ViewBag.Locacoes != null && ViewBag.Locacoes.Count > 0)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 192 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                             foreach (var locacao in ViewBag.Locacoes)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 195 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                   Write(locacao.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 196 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                   Write(locacao.Cpf);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n");
#nullable restore
#line 198 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                         if (locacao.Filmes != null)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <ul style=\"list-style-type: none; padding-left:0;\">\r\n");
#nullable restore
#line 201 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                                 foreach (var filme in locacao.Filmes)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li>");
#nullable restore
#line 203 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                                   Write(filme.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 204 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </ul>\r\n");
#nullable restore
#line 206 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <strong style=\"color: red;\">N/A</strong>\r\n");
#nullable restore
#line 210 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>");
#nullable restore
#line 212 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                                   Write(locacao.DataDaLocacao.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 214 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 214 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                             
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <tr>
                                <td colspan=""4"" class=""text-center"">
                                    <strong>Não existem locações cadastradas.</strong>
                                </td>
                            </tr>
");
#nullable restore
#line 223 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Filme\IndexFilmes.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591