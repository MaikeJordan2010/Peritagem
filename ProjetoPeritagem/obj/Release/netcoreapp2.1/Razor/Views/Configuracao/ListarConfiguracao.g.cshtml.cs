#pragma checksum "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62fb25b1e0dad222351426810b9ddec1c52aad28"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Configuracao_ListarConfiguracao), @"mvc.1.0.view", @"/Views/Configuracao/ListarConfiguracao.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Configuracao/ListarConfiguracao.cshtml", typeof(AspNetCore.Views_Configuracao_ListarConfiguracao))]
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
#line 1 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\_ViewImports.cshtml"
using ProjetoPeritagem;

#line default
#line hidden
#line 2 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\_ViewImports.cshtml"
using Modelo;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62fb25b1e0dad222351426810b9ddec1c52aad28", @"/Views/Configuracao/ListarConfiguracao.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54ceda69199656c87eab8db6137fa0dcd57d0a29", @"/Views/_ViewImports.cshtml")]
    public class Views_Configuracao_ListarConfiguracao : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjetoPeritagem.ViewHelper.ViewHelperPeritagem>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
  
    ViewData["Title"] = "ListarConfiguracao";

#line default
#line hidden
            BeginContext(110, 635, true);
            WriteLiteral(@"
<h2 id=""titulo-form"">Listar Classe</h2>

<div id=""main"">
    <div id=""tabela-cliente"">
        <table class=""table table-striped"">
            <thead class=""thead-dark"">
                <tr>
                    <th scope=""col"">ID</th>
                    <th scope=""col"">Nome</th>
                    <th scope=""col"">Protocolo</th>
                    <th scope=""col"">Dom??nio</th>
                    <th scope=""col"">Porta</th>
                    <th scope=""col"">Padr??o</th>
                    <th scope=""col"">Descri????o</th>
                    <th scope=""col"">
                        <a class=""badge badge-primary""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 745, "\"", 789, 1);
#line 21 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
WriteAttributeValue("", 752, Url.Action( "Index", "Configuracao"), 752, 37, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(790, 109, true);
            WriteLiteral(">Incluir</a>\r\n                    </th>\r\n\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            EndContext();
#line 27 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
                  
                    foreach (var conf in Model.listConfiguracao)
                    {

#line default
#line hidden
            BeginContext(1008, 74, true);
            WriteLiteral("                        <tr>\r\n                            <th scope=\"row\">");
            EndContext();
            BeginContext(1083, 7, false);
#line 31 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
                                       Write(conf.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1090, 39, true);
            WriteLiteral("</th>\r\n                            <td>");
            EndContext();
            BeginContext(1130, 9, false);
#line 32 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
                           Write(conf.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1139, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1179, 14, false);
#line 33 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
                           Write(conf.Protocolo);

#line default
#line hidden
            EndContext();
            BeginContext(1193, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1233, 12, false);
#line 34 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
                           Write(conf.Dominio);

#line default
#line hidden
            EndContext();
            BeginContext(1245, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1285, 10, false);
#line 35 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
                           Write(conf.Porta);

#line default
#line hidden
            EndContext();
            BeginContext(1295, 41, true);
            WriteLiteral("</td>\r\n                            <td>\r\n");
            EndContext();
#line 37 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
                                   
                                    if (conf.Padrao)
                                    {

#line default
#line hidden
            BeginContext(1466, 52, true);
            WriteLiteral("                                        <p>Sim</p>\r\n");
            EndContext();
#line 41 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(1638, 52, true);
            WriteLiteral("                                        <p>N??o</p>\r\n");
            EndContext();
#line 45 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
                                    }
                                

#line default
#line hidden
            BeginContext(1764, 67, true);
            WriteLiteral("                            </td>\r\n                            <td>");
            EndContext();
            BeginContext(1832, 14, false);
#line 48 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
                           Write(conf.Descricao);

#line default
#line hidden
            EndContext();
            BeginContext(1846, 103, true);
            WriteLiteral("</td>\r\n                            <td>\r\n                                <a class=\"badge badge-warning\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1949, "\"", 2041, 1);
#line 50 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
WriteAttributeValue("", 1956, Url.Action( "AlterarConfiguracao", "Configuracao", new { ID_Configuracao = conf.Id}), 1956, 85, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2042, 81, true);
            WriteLiteral(">Alterar</a><br />\r\n                                <a class=\"badge badge-danger\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2123, "\"", 2210, 1);
#line 51 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
WriteAttributeValue("", 2130, Url.Action( "ExcluirClasse", "Configuracao", new { ID_Configuracao = conf.Id }), 2130, 80, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2211, 79, true);
            WriteLiteral(">Excluir</a><br />\r\n                                <a class=\"badge badge-info\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2290, "\"", 2376, 1);
#line 52 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
WriteAttributeValue("", 2297, Url.Action( "GravarPadrao", "Configuracao", new { ID_Configuracao = conf.Id }), 2297, 79, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2377, 87, true);
            WriteLiteral(">Padr??o</a><br />\r\n\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 56 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Configuracao\ListarConfiguracao.cshtml"
                    }
                

#line default
#line hidden
            BeginContext(2506, 62, true);
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProjetoPeritagem.ViewHelper.ViewHelperPeritagem> Html { get; private set; }
    }
}
#pragma warning restore 1591
