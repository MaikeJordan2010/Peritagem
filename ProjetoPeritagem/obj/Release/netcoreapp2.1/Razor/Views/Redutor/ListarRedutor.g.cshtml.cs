#pragma checksum "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2bf580c2aab1df59c2eed737c31c88dc946f8d75"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Redutor_ListarRedutor), @"mvc.1.0.view", @"/Views/Redutor/ListarRedutor.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Redutor/ListarRedutor.cshtml", typeof(AspNetCore.Views_Redutor_ListarRedutor))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2bf580c2aab1df59c2eed737c31c88dc946f8d75", @"/Views/Redutor/ListarRedutor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54ceda69199656c87eab8db6137fa0dcd57d0a29", @"/Views/_ViewImports.cshtml")]
    public class Views_Redutor_ListarRedutor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjetoPeritagem.ViewHelper.ViewHelperPeritagem>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_SubMenu", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
  
    ViewData["Title"] = "ListarObjetos";

#line default
#line hidden
            BeginContext(105, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(107, 27, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "37ca58e00491404bb83d3a2910152fc3", async() => {
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
            BeginContext(134, 554, true);
            WriteLiteral(@"
<h2 id=""titulo-form"">Informações do Equipamento</h2>
<div id=""main"">
    <div id=""tabela"">
        <table class=""table table-striped"">
            <thead class=""thead-dark"">
                <tr>
                    <th scope=""col"">ID</th>
                    <th>Nome</th>
                    <th>Tipo de Dados</th>
                    <th>Fabricante</th>
                    <th>Modelo</th>
                    <th>Sentido</th>
                    <th scope=""col"" class=""btn_padrao"">
                        <a class=""badge badge-primary""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 688, "\"", 779, 1);
#line 20 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
WriteAttributeValue("", 695, Url.Action( "InserirRedutor", "Redutor", new { ID_Peritagem = Model.ID_Peritagem }), 695, 84, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(780, 150, true);
            WriteLiteral(">Incluir</a>\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody style=\"max-height:500pc;overflow-y:scroll\">\r\n");
            EndContext();
#line 25 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                  
                    foreach (var it in Model.listRedutor)
                    {

#line default
#line hidden
            BeginContext(1032, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(1079, 5, false);
#line 29 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                   Write(it.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1084, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1116, 7, false);
#line 30 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                   Write(it.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1123, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1155, 12, false);
#line 31 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                   Write(it.TipoDados);

#line default
#line hidden
            EndContext();
            BeginContext(1167, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1199, 13, false);
#line 32 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                   Write(it.Fabricante);

#line default
#line hidden
            EndContext();
            BeginContext(1212, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1244, 9, false);
#line 33 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                   Write(it.Modelo);

#line default
#line hidden
            EndContext();
            BeginContext(1253, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1285, 10, false);
#line 34 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                   Write(it.Sentido);

#line default
#line hidden
            EndContext();
            BeginContext(1295, 147, true);
            WriteLiteral("</td>\r\n\r\n                    <td class=\"btn_padrao\" rowspan=\"3\">\r\n                        <li class=\"btn_padrao_100\"><a class=\"badge badge-warning\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1442, "\"", 1550, 1);
#line 37 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
WriteAttributeValue("", 1449, Url.Action( "AlterarRedutor", "Redutor", new { ID_Peritagem = it.ID_Peritagem, ID_Redutor = it.Id }), 1449, 101, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1551, 99, true);
            WriteLiteral(">Alterar</a></li>\r\n                        <li class=\"btn_padrao_100\"><a class=\"badge badge-danger\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1650, "\"", 1758, 1);
#line 38 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
WriteAttributeValue("", 1657, Url.Action( "ExcluirRedutor", "Redutor", new { ID_Peritagem = it.ID_Peritagem, ID_Redutor = it.Id }), 1657, 101, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1759, 97, true);
            WriteLiteral(">Excluir</a></li>\r\n                        <li class=\"btn_padrao_100\"><a class=\"badge badge-info\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1856, "\"", 1961, 1);
#line 39 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
WriteAttributeValue("", 1863, Url.Action( "ListarImagem", "Imagem", new { ID_Peritagem = it.ID_Peritagem, ID_Redutor = it.Id }), 1863, 98, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1962, 196, true);
            WriteLiteral(">Album</a></li>\r\n                    </td>\r\n                </tr>\r\n                        <tr>\r\n                            <td ><strong>Fabricação</strong></td>\r\n                            <td>");
            EndContext();
            BeginContext(2159, 16, false);
#line 44 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                           Write(it.AnoFabricacao);

#line default
#line hidden
            EndContext();
            BeginContext(2175, 99, true);
            WriteLiteral("</td>\r\n                            <td ><strong>Cor</strong></td>\r\n                            <td>");
            EndContext();
            BeginContext(2275, 6, false);
#line 46 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                           Write(it.Cor);

#line default
#line hidden
            EndContext();
            BeginContext(2281, 100, true);
            WriteLiteral("</td>\r\n                            <td ><strong>Peso</strong></td>\r\n                            <td>");
            EndContext();
            BeginContext(2382, 7, false);
#line 48 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                           Write(it.Peso);

#line default
#line hidden
            EndContext();
            BeginContext(2389, 167, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td ><strong>Rotação IN</strong></td>\r\n                            <td>");
            EndContext();
            BeginContext(2557, 12, false);
#line 52 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                           Write(it.RotacaoIN);

#line default
#line hidden
            EndContext();
            BeginContext(2569, 107, true);
            WriteLiteral("</td>\r\n                            <td ><strong>Rotação OUT</strong></td>\r\n                            <td>");
            EndContext();
            BeginContext(2677, 13, false);
#line 54 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                           Write(it.RotacaoOUT);

#line default
#line hidden
            EndContext();
            BeginContext(2690, 104, true);
            WriteLiteral("</td>\r\n                            <td ><strong>Potência</strong></td>\r\n                            <td>");
            EndContext();
            BeginContext(2795, 11, false);
#line 56 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                           Write(it.Potencia);

#line default
#line hidden
            EndContext();
            BeginContext(2806, 208, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr class=\"lista_final_peritagem\">\r\n                            <td ><strong>Aplicação</strong></td>\r\n                            <td colspan=\"2\">");
            EndContext();
            BeginContext(3015, 12, false);
#line 60 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                                       Write(it.Aplicacao);

#line default
#line hidden
            EndContext();
            BeginContext(3027, 117, true);
            WriteLiteral("</td>\r\n                            <td ><strong>Descrição</strong></td>\r\n                            <td colspan=\"4\">");
            EndContext();
            BeginContext(3145, 12, false);
#line 62 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                                       Write(it.Descricao);

#line default
#line hidden
            EndContext();
            BeginContext(3157, 38, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n");
            EndContext();
#line 64 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Redutor\ListarRedutor.cshtml"
                    }
                

#line default
#line hidden
            BeginContext(3237, 189, true);
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n        <div>\r\n            <nav aria-label=\"Page navigation example\">\r\n                \r\n            </nav>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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