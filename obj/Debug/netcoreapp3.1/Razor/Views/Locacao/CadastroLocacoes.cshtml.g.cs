#pragma checksum "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c467b9189a956a44a2d98e6cb004230b8645403d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Locacao_CadastroLocacoes), @"mvc.1.0.view", @"/Views/Locacao/CadastroLocacoes.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c467b9189a956a44a2d98e6cb004230b8645403d", @"/Views/Locacao/CadastroLocacoes.cshtml")]
    public class Views_Locacao_CadastroLocacoes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
  
    ViewData["Title"] = "Cadastro";
    Layout = "~/Views/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n\r\n");
#nullable restore
#line 9 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
 if (TempData["MensagemSucesso"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissible\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>\r\n        <strong>");
#nullable restore
#line 13 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
           Write(TempData["MensagemSucesso"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </div>\r\n");
#nullable restore
#line 15 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
 if (TempData["MensagemErro"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger alert-dismissible\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>\r\n        <strong>");
#nullable restore
#line 21 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
           Write(TempData["MensagemErro"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </div>\r\n");
#nullable restore
#line 23 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-8\">\r\n        <h4>Cadastrar Locação</h4>\r\n\r\n\r\n\r\n        <form method=\"post\" action=\"/netfilmes/filmes/salvar\">\r\n            <input type=\"hidden\" name=\"Id\"");
            BeginWriteAttribute("value", " value=\"", 850, "\"", 906, 1);
#nullable restore
#line 34 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
WriteAttributeValue("", 858, ViewBag.Filme != null ? ViewBag.Filme.Id : "", 858, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n            <div class=\"form-group\">\r\n                <label>Nome</label>\r\n                <input type=\"text\" class=\"form-control\" name=\"Nome\"");
            BeginWriteAttribute("value", " value=\"", 1056, "\"", 1114, 1);
#nullable restore
#line 38 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
WriteAttributeValue("", 1064, ViewBag.Filme != null ? ViewBag.Filme.Nome : "", 1064, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n\r\n            <div class=\"checkbox\">\r\n                <label>\r\n                    <input type=\"checkbox\" name=\"Ativo\" value=\"true\" ");
#nullable restore
#line 43 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
                                                                 Write(ViewBag.Filme != null && ViewBag.Filme.Ativo ? "checked" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"> Ativo
                </label>
            </div>

            <div class=""form-group"">
                <label>Gênero</label>
                <select class=""form-control"" name=""GeneroId"">
                    <option value=""-1"">Selecione</option>

");
#nullable restore
#line 52 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
                     if (ViewBag.Generos != null && ViewBag.Generos.Count > 0)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
                         foreach (var genero in ViewBag.Generos)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
                             if (ViewBag.Filme != null && ViewBag.Filme.GeneroId == genero.Id)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <option");
            BeginWriteAttribute("value", " value=\"", 1954, "\"", 1972, 1);
#nullable restore
#line 58 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
WriteAttributeValue("", 1962, genero.Id, 1962, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" selected>");
#nullable restore
#line 58 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
                                                               Write(genero.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 59 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <option");
            BeginWriteAttribute("value", " value=\"", 2141, "\"", 2159, 1);
#nullable restore
#line 62 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
WriteAttributeValue("", 2149, genero.Id, 2149, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 62 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
                                                      Write(genero.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 63 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\FELIPE\source\repos\Netfilmes\Views\Locacao\CadastroLocacoes.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </select>\r\n            </div>\r\n\r\n            <button type=\"submit\" class=\"btn btn-primary\">Salvar</button>\r\n        </form>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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