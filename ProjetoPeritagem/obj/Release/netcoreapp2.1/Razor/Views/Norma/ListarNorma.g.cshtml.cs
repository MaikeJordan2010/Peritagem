#pragma checksum "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\ListarNorma.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e4ab5c15a8e63d05d7a82776de262d277ed0bec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Norma_ListarNorma), @"mvc.1.0.view", @"/Views/Norma/ListarNorma.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Norma/ListarNorma.cshtml", typeof(AspNetCore.Views_Norma_ListarNorma))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e4ab5c15a8e63d05d7a82776de262d277ed0bec", @"/Views/Norma/ListarNorma.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54ceda69199656c87eab8db6137fa0dcd57d0a29", @"/Views/_ViewImports.cshtml")]
    public class Views_Norma_ListarNorma : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjetoPeritagem.ViewHelper.ViewHelperPeritagem>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\ListarNorma.cshtml"
  
    ViewData["Title"] = "ListarMaterial";

#line default
#line hidden
            BeginContext(106, 435, true);
            WriteLiteral(@"
<h2 id=""titulo-form"">Listar Norma</h2>

<div id=""main"">
    <div id=""tabela-cliente"">
        <table class=""table table-striped"">
            <thead class=""thead-dark"">
                <tr>
                    <th scope=""col"">ID</th>
                    <th scope=""col"">Nome</th>
                    <th scope=""col"">Descrição</th>
                    <th scope=""col"">
                        <a class=""badge badge-primary""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 541, "\"", 585, 1);
#line 17 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\ListarNorma.cshtml"
WriteAttributeValue("", 548, Url.Action( "InserirNorma", "Norma"), 548, 37, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(586, 107, true);
            WriteLiteral(">Incluir</a>\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            EndContext();
#line 22 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\ListarNorma.cshtml"
                  
                    foreach (var nor in Model.listNorma)
                    {

#line default
#line hidden
            BeginContext(794, 58, true);
            WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
            EndContext();
            BeginContext(853, 6, false);
#line 26 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\ListarNorma.cshtml"
                               Write(nor.Id);

#line default
#line hidden
            EndContext();
            BeginContext(859, 31, true);
            WriteLiteral("</th>\r\n                    <td>");
            EndContext();
            BeginContext(891, 8, false);
#line 27 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\ListarNorma.cshtml"
                   Write(nor.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(899, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(931, 13, false);
#line 28 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\ListarNorma.cshtml"
                   Write(nor.Descricao);

#line default
#line hidden
            EndContext();
            BeginContext(944, 87, true);
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a class=\"badge badge-warning\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1031, "\"", 1101, 1);
#line 30 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\ListarNorma.cshtml"
WriteAttributeValue("", 1038, Url.Action( "AlterarNorma", "Norma", new { ID_Norma = nor.Id}), 1038, 63, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1102, 73, true);
            WriteLiteral(">Alterar</a><br />\r\n                        <a class=\"badge badge-danger\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1175, "\"", 1246, 1);
#line 31 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\ListarNorma.cshtml"
WriteAttributeValue("", 1182, Url.Action( "ExcluirNorma", "Norma", new { ID_Norma = nor.Id }), 1182, 64, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1247, 70, true);
            WriteLiteral(">Excluir</a><br />\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 34 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\ListarNorma.cshtml"
                    }
                

#line default
#line hidden
            BeginContext(1359, 60, true);
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
