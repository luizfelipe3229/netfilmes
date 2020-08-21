#pragma checksum "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7c3c3c425d6a3ebd2c208d4d6c70456f5f63ad9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Locacao_IndexLocacao), @"mvc.1.0.view", @"/Views/Locacao/IndexLocacao.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7c3c3c425d6a3ebd2c208d4d6c70456f5f63ad9", @"/Views/Locacao/IndexLocacao.cshtml")]
    public class Views_Locacao_IndexLocacao : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
  
    ViewData["Title"] = "Locação";
    Layout = "~/Views/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n\r\n");
#nullable restore
#line 9 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
 if (TempData["MensagemSucesso"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissible\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>\r\n        <strong>");
#nullable restore
#line 13 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
           Write(TempData["MensagemSucesso"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </div>\r\n");
#nullable restore
#line 15 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
 if (TempData["MensagemErro"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger alert-dismissible\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>\r\n        <strong>");
#nullable restore
#line 21 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
           Write(TempData["MensagemErro"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </div>\r\n");
#nullable restore
#line 23 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <h3>Locações</h3>\r\n    </div>\r\n</div>\r\n\r\n<br />\r\n\r\n");
#nullable restore
#line 35 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
 if (ViewBag.Locacoes != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<form method=""post"" action=""/netfilmes/locacao/desalocar"">
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
                                <th>OPERAÇÕES</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 53 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                             foreach (var locacao in ViewBag.Locacoes)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 56 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                                   Write(locacao.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 57 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                                   Write(locacao.Cpf);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n");
#nullable restore
#line 59 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                                         if (locacao.Filmes != null && locacao.Filmes.Count > 0)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <ul style=\"list-style-type: none; padding-left:0;\">\r\n\r\n");
#nullable restore
#line 63 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                                                 foreach (var filme in locacao.Filmes)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li>\r\n                                                        <input type=\"checkbox\"");
            BeginWriteAttribute("value", " value=\"", 2272, "\"", 2289, 1);
#nullable restore
#line 66 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
WriteAttributeValue("", 2280, filme.Id, 2280, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"filmesId\" /> ");
#nullable restore
#line 66 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                                                                                                               Write(filme.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </li>\r\n");
#nullable restore
#line 68 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </ul>\r\n");
#nullable restore
#line 71 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <strong style=\"color: red;\">N/A</strong>\r\n");
#nullable restore
#line 75 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>");
#nullable restore
#line 77 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                                   Write(locacao.DataDaLocacao.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        <button class=\"btn btn-primary\">DESALOCAR</button>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 82 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</form>\r\n");
#nullable restore
#line 90 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
    
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<hr />\r\n<br />\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <h3>Filmes Não Locados</h3>\r\n    </div>\r\n</div>\r\n\r\n<br />\r\n\r\n");
#nullable restore
#line 105 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
 if (ViewBag.FilmesNaoLocados != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <form method=""post"" action=""/netfilmes/locacao/cadastrar"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""row"">
                    <div class=""col-md-3"">
                        <input type=""text"" name=""Cpf"" class=""form-control"" maxlength=""11"" placeholder=""CPF DO CLIENTE"" />
                    </div>

                    <div class=""col-md-2"">
                        <button class=""btn btn-primary"">Realizar Locação</button>
                    </div>
                </div>

                <br /><br />

                <div class=""row"">
                    <div class=""col-md-12"">
                        <table class=""table"">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>ID</th>
                                    <th>NOME</th>
                                    <th>GENERO</th>
                                </tr>
          ");
            WriteLiteral("                  </thead>\r\n                            <tbody>\r\n");
#nullable restore
#line 134 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                                 foreach (var filme in ViewBag.FilmesNaoLocados)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td><input type=\"checkbox\"");
            BeginWriteAttribute("value", " value=\"", 4785, "\"", 4802, 1);
#nullable restore
#line 137 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
WriteAttributeValue("", 4793, filme.Id, 4793, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"filmesId\"></td>\r\n                                        <td>");
#nullable restore
#line 138 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                                       Write(filme.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 139 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                                       Write(filme.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 140 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                                       Write(filme.Genero.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 142 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n\r\n\r\n            </div>\r\n        </div>\r\n    </form>\r\n");
#nullable restore
#line 152 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p style=\"color:red;\"><strong>Todos os filmes estão locados.</strong></p>\r\n");
#nullable restore
#line 156 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\IndexLocacao.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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