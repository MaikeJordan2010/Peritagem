#pragma checksum "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "886aca35cd868b1b690907ead7df55e919db1edd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Peca_ListarPeca), @"mvc.1.0.view", @"/Views/Peca/ListarPeca.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Peca/ListarPeca.cshtml", typeof(AspNetCore.Views_Peca_ListarPeca))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"886aca35cd868b1b690907ead7df55e919db1edd", @"/Views/Peca/ListarPeca.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54ceda69199656c87eab8db6137fa0dcd57d0a29", @"/Views/_ViewImports.cshtml")]
    public class Views_Peca_ListarPeca : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjetoPeritagem.ViewHelper.ViewHelperPeritagem>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_SubMenu", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/clips.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:15px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
  
    ViewData["Title"] = "Listar Pe??as";

#line default
#line hidden
            BeginContext(104, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(106, 27, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a4a84e3bed3844e09a2ecafb5b1ebe82", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(133, 717, true);
            WriteLiteral(@"

<h2 id=""titulo-form"">Listar Pe??as</h2>
<div id=""main"">
    <div id=""tabela"">
        <table class=""table table-striped"">
            <thead class=""thead-dark"">
                <tr>
                    <th scope=""col"">Per/Peca</th>
                    <th scope=""col"">Tipo</th>
                    <th scope=""col"">Nome</th>
                    <th scope=""col"">Condi????o</th>
                    <th scope=""col"">N?? Dentes</th>
                    <th scope=""col"">Medidas</th>
                    <th scope=""col"">Dureza</th>
                    <th scope=""col"" style=""width:170px"">Anexo</th>
                    <th scope=""col"" class=""btn_padrao"">
                        <a class=""badge badge-primary""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 850, "\"", 935, 1);
#line 23 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
WriteAttributeValue("", 857, Url.Action( "InserirPeca", "Peca", new { ID_Peritagem = Model.ID_Peritagem }), 857, 78, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(936, 107, true);
            WriteLiteral(">Incluir</a>\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            EndContext();
#line 28 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
                  
                    foreach (var it in Model.listPeca)
                    {

#line default
#line hidden
            BeginContext(1142, 58, true);
            WriteLiteral("                <tr>\r\n                    <td scope=\"row\">");
            EndContext();
            BeginContext(1201, 15, false);
#line 32 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
                               Write(it.ID_Peritagem);

#line default
#line hidden
            EndContext();
            BeginContext(1216, 1, true);
            WriteLiteral("/");
            EndContext();
            BeginContext(1218, 5, false);
#line 32 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
                                                Write(it.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1223, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1255, 16, false);
#line 33 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
                   Write(it.TipoPeca.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1271, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1303, 7, false);
#line 34 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
                   Write(it.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1310, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1342, 18, false);
#line 35 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
                   Write(it.Disposicao.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1360, 62, true);
            WriteLiteral("</td>\r\n                    <td></td>\r\n                    <td>");
            EndContext();
            BeginContext(1423, 9, false);
#line 37 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
                   Write(it.Altura);

#line default
#line hidden
            EndContext();
            BeginContext(1432, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1464, 9, false);
#line 38 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
                   Write(it.Dureza);

#line default
#line hidden
            EndContext();
            BeginContext(1473, 47, true);
            WriteLiteral("</td>\r\n\r\n                    <td rowspan=\"3\">\r\n");
            EndContext();
#line 41 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
                         foreach (var doc in it.ListDocumentos)
                        {

#line default
#line hidden
            BeginContext(1612, 46, true);
            WriteLiteral("                            <a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1658, "\"", 1680, 2);
            WriteAttributeValue("", 1665, "../", 1665, 3, true);
#line 43 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
WriteAttributeValue("", 1668, doc.Caminho, 1668, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1681, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1682, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c164396794394e79bb3bf2efdb8d47a5", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1733, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1735, 8, false);
#line 43 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
                                                                                                                     Write(doc.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1743, 14, true);
            WriteLiteral("  <br /></a>\r\n");
            EndContext();
#line 44 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
                        }

#line default
#line hidden
            BeginContext(1784, 165, true);
            WriteLiteral("                    </td>\r\n                    <td class=\"btn_padrao\" rowspan=\"2\">\r\n                        <li class=\"btn_padrao_100\"><a class=\"badge badge-success\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1949, "\"", 2050, 1);
#line 47 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
WriteAttributeValue("", 1956, Url.Action("ListarCroqui", "Croqui", new { ID_Peca = it.Id, ID_Peritagem = it.ID_Peritagem }), 1956, 94, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2051, 104, true);
            WriteLiteral(">Croqui</a><br /></li>\r\n                        <li class=\"btn_padrao_50\"><a class=\"badge badge-warning\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2155, "\"", 2253, 1);
#line 48 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
WriteAttributeValue("", 2162, Url.Action("AlterarPeca", "Peca", new { ID_Peca = it.Id, ID_Peritagem = it.ID_Peritagem }), 2162, 91, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2254, 104, true);
            WriteLiteral(">Alterar</a><br /></li>\r\n                        <li class=\"btn_padrao_50\"><a class=\"badge badge-danger\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2358, "\"", 2456, 1);
#line 49 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
WriteAttributeValue("", 2365, Url.Action("ExcluirPeca", "Peca", new { ID_Peca = it.Id, ID_Peritagem = it.ID_Peritagem }), 2365, 91, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2457, 97, true);
            WriteLiteral(">Excluir</a></li>\r\n                        <li class=\"btn_padrao_100\"><a class=\"badge badge-info\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2554, "\"", 2655, 1);
#line 50 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
WriteAttributeValue("", 2561, Url.Action("ListarImagem", "Imagem", new { ID_Peca = it.Id, ID_Peritagem = it.ID_Peritagem }), 2561, 94, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2656, 73, true);
            WriteLiteral(">Album</a><br /></li>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
            BeginContext(2754, 139, true);
            WriteLiteral("                        <tr>\r\n                            <td><strong>Descri????o</strong></td>\r\n                            <td colspan=\"8\">");
            EndContext();
            BeginContext(2894, 12, false);
#line 56 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
                                       Write(it.Descricao);

#line default
#line hidden
            EndContext();
            BeginContext(2906, 208, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr class=\"lista_final_peritagem\">\r\n                            <td><strong>Retrabalho</strong></td>\r\n                            <td colspan=\"8\">");
            EndContext();
            BeginContext(3115, 22, false);
#line 60 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
                                       Write(it.DescricaoRetrabalho);

#line default
#line hidden
            EndContext();
            BeginContext(3137, 38, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n");
            EndContext();
#line 62 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peca\ListarPeca.cshtml"
                    }
                

#line default
#line hidden
            BeginContext(3217, 64, true);
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n");
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
