#pragma checksum "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Cliente\ListarCliente.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f014d746246ff25c1e5cac4fe4e251738c12f9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cliente_ListarCliente), @"mvc.1.0.view", @"/Views/Cliente/ListarCliente.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cliente/ListarCliente.cshtml", typeof(AspNetCore.Views_Cliente_ListarCliente))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f014d746246ff25c1e5cac4fe4e251738c12f9f", @"/Views/Cliente/ListarCliente.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54ceda69199656c87eab8db6137fa0dcd57d0a29", @"/Views/_ViewImports.cshtml")]
    public class Views_Cliente_ListarCliente : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjetoPeritagem.ViewHelper.ViewHelperPeritagem>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Cliente\ListarCliente.cshtml"
  
    ViewData["Title"] = "ListarPeritagem";

#line default
#line hidden
            BeginContext(107, 411, true);
            WriteLiteral(@"

<h2 id=""titulo-form"">Lista de Clientes</h2>
<div id=""main"">
    <div id=""tabela-cliente"">
        <table class=""table table-striped"">
            <thead class=""thead-dark"">
                <tr>
                    <th scope=""col"">ID</th>
                    <th scope=""col"">Nome</th>
                    <th scope=""col"">Logo</th>

                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 20 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Cliente\ListarCliente.cshtml"
                  
                    foreach (var it in Model.listCliente)
                    {

#line default
#line hidden
            BeginContext(620, 74, true);
            WriteLiteral("                        <tr>\r\n                            <th scope=\"row\">");
            EndContext();
            BeginContext(695, 5, false);
#line 24 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Cliente\ListarCliente.cshtml"
                                       Write(it.Id);

#line default
#line hidden
            EndContext();
            BeginContext(700, 39, true);
            WriteLiteral("</th>\r\n                            <td>");
            EndContext();
            BeginContext(740, 7, false);
#line 25 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Cliente\ListarCliente.cshtml"
                           Write(it.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(747, 43, true);
            WriteLiteral("</td>\r\n                            <td><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 790, "\"", 808, 2);
            WriteAttributeValue("", 796, "../", 796, 3, true);
#line 26 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Cliente\ListarCliente.cshtml"
WriteAttributeValue("", 799, it.Icone, 799, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(809, 83, true);
            WriteLiteral(" alt=\"logo\" style=\"width:50px; height:50px\"/></td>\r\n                        </tr>\r\n");
            EndContext();
#line 28 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Cliente\ListarCliente.cshtml"
                    }
                

#line default
#line hidden
            BeginContext(934, 60, true);
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
