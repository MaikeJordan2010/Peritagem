#pragma checksum "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peritagem\InserirPeritagem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09dee0e8408a8cc30aeb4b54f793da066d8a5753"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Peritagem_InserirPeritagem), @"mvc.1.0.view", @"/Views/Peritagem/InserirPeritagem.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Peritagem/InserirPeritagem.cshtml", typeof(AspNetCore.Views_Peritagem_InserirPeritagem))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09dee0e8408a8cc30aeb4b54f793da066d8a5753", @"/Views/Peritagem/InserirPeritagem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54ceda69199656c87eab8db6137fa0dcd57d0a29", @"/Views/_ViewImports.cshtml")]
    public class Views_Peritagem_InserirPeritagem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjetoPeritagem.ViewHelper.ViewHelperPeritagem>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ValidadorCampos.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peritagem\InserirPeritagem.cshtml"
  
   
    ViewData["Title"] = "CadastrarPeritagem";

#line default
#line hidden
            BeginContext(115, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peritagem\InserirPeritagem.cshtml"
   

    DateTime dt = DateTime.Now;
    DateTime d = dt.AddDays(12);


    var dt_chegada = DateTime.Now.Year + "-" + (DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString()) + "-" + DateTime.Now.Day;
    var dt_inicio = d.ToString().Split("/")[2].Split(" ")[0] + "-" + d.ToString().Split("/")[1] + "-" + d.ToString().Split("/")[0];


#line default
#line hidden
            BeginContext(521, 98, true);
            WriteLiteral("<h2 id=\"titulo-form\">CadastrarPeritagem</h2>\r\n<div id=\"main\">\r\n    <div id=\"formulario\">\r\n        ");
            EndContext();
            BeginContext(619, 5056, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9eda1f94590248bd82133e23e1eeae31", async() => {
                BeginContext(724, 555, true);
                WriteLiteral(@"
            <div class=""form-row"">
                <div class=""form-group col-md-12"">
                    <label for=""descricao"">Descrição do Equipamento</label>
                    <input type=""text"" class=""form-control"" id=""descricao"" name=""Descricao"" required />
                </div>
            </div>
            <div class=""form-row"">
                <div class=""form-group col-md-4"">
                    <label for=""cliente"">Cliente</label>
                    <select type=""text"" class=""form-control"" id=""cliente"" name=""ID_Cliente"">
");
                EndContext();
#line 31 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peritagem\InserirPeritagem.cshtml"
                          
                            foreach (var it in Model.listCliente)
                            {

#line default
#line hidden
                BeginContext(1405, 32, true);
                WriteLiteral("                                ");
                EndContext();
                BeginContext(1437, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d325da680227423ab868d6c71a6b4d71", async() => {
                    BeginContext(1461, 7, false);
#line 34 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peritagem\InserirPeritagem.cshtml"
                                                  Write(it.Nome);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 34 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peritagem\InserirPeritagem.cshtml"
                                   WriteLiteral(it.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1477, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 35 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peritagem\InserirPeritagem.cshtml"
                            }
                        

#line default
#line hidden
                BeginContext(1537, 1437, true);
                WriteLiteral(@"                    </select>
                </div>
                <div class=""form-group col-md-4"">
                    <label for=""numNota"">Nº Nota</label>
                    <input type=""text"" class=""form-control"" id=""numNota"" name=""NumeroNota"" onkeypress=""ValidarNumerosInteiro()"" required />
                </div>
                <div class=""form-group col-md-4"">
                    <label for=""numContrato"">Nº Contrato</label>
                    <input type=""text"" class=""form-control"" id=""numContrato"" name=""NumeroContrato"" onkeypress=""ValidarNumerosInteiro()"" />
                </div>
            </div>
            <div class=""form-row"">
                <div class=""form-group col-md-6"">
                    <label for=""numOrcamento"">Orçamento</label>
                    <input type=""text"" class=""form-control"" id=""numOrcamento"" name=""NumeroOrcamento"" onkeypress=""ValidarNumerosInteiro()"" />
                </div>
                <div class=""form-group col-md-6"">
                    <labe");
                WriteLiteral(@"l for=""procuto"">Produto</label>
                    <input type=""text"" class=""form-control"" id=""produto"" name=""Produto"">
                </div>
            </div>
            <div class=""form-row"">
                <div class=""form-group col-md-4"">
                    <label for=""dt_chegada"">Data Chegada</label>
                    <input type=""date"" class=""form-control"" id=""dt_chegada"" name=""DT_Chegada""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2974, "\"", 2993, 1);
#line 61 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peritagem\InserirPeritagem.cshtml"
WriteAttributeValue("", 2982, dt_chegada, 2982, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2994, 245, true);
                WriteLiteral(" required />\r\n                </div>\r\n                <div class=\"form-group col-md-4\">\r\n                    <label for=\"dt_entrada\">Data Inicio</label>\r\n                    <input type=\"date\" class=\"form-control\" id=\"dt_inicio\" name=\"DT_Inicio\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3239, "\"", 3257, 1);
#line 65 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peritagem\InserirPeritagem.cshtml"
WriteAttributeValue("", 3247, dt_inicio, 3247, 10, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3258, 778, true);
                WriteLiteral(@" required />
                </div>
                <div class=""form-group col-md-4"">
                    <label for=""dt_previsao"">Previsão</label>
                    <input type=""date"" class=""form-control"" id=""dt_previsao"" name=""DT_Previsao"" required />
                </div>
            </div>
            <div class=""form-row"">
                <div class=""form-group col-md-4"">
                    <label for=""cliente"">Protocolo</label>
                    <input type=""text"" class=""form-control"" id=""protocolo"" name=""Protocolo"">
                </div>
                <div class=""form-group col-md-4"">
                    <label for=""numNota"">Responsável</label>
                    <input type=""text"" class=""form-control"" id=""responsavel"" name=""Responsavel""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4036, "\"", 4063, 1);
#line 79 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peritagem\InserirPeritagem.cshtml"
WriteAttributeValue("", 4044, Model.usuario.Nome, 4044, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4064, 217, true);
                WriteLiteral(" disabled>\r\n                </div>\r\n                <div class=\"form-group col-md-4\">\r\n                    <label for=\"numContrato\">Setor</label>\r\n                    <input type=\"text\" class=\"form-control\" id=\"setor\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4281, "\"", 4316, 1);
#line 83 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peritagem\InserirPeritagem.cshtml"
WriteAttributeValue("", 4289, Model.usuario.Departamento, 4289, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4317, 1351, true);
                WriteLiteral(@" name=""Setor"">
                </div>
            </div>
            <div class=""form-group"">
                <label for=""referencia"">Referência</label>
                <textarea class=""form-control"" id=""referencia"" name=""Referencia"" rows=""3""></textarea>
            </div>
            <div class=""form-group"">
                <label for=""motivo"">Motivo da Manutenção</label>
                <textarea class=""form-control"" id=""motivo"" name=""Motivo_Manutencao"" rows=""3""></textarea>
            </div>
            <div class=""form-group"">
                <label for=""referencia"">Aplicação</label>
                <textarea class=""form-control"" id=""aplicacao"" name=""Aplicacao"" rows=""3""></textarea>
            </div>
            <div class=""form-group"">
                <label for=""observacao"">Observações</label>
                <textarea class=""form-control"" id=""observacao"" name=""Observacao"" rows=""3""></textarea>
            </div>
            <p class=""msgErro"">Por favor, anexo a NFE junto ao cadastro</");
                WriteLiteral(@"p>
            <div class=""form-group"">
                <label for=""exampleFormControlFile1"">Arquivo</label>
                <input multiple type=""file"" class=""form-control-file"" id=""documento"" name=""Documento"">
            </div>
            <input type=""submit"" class=""btn btn-primary mb-2"" value=""Gravar"" />

        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 20 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Peritagem\InserirPeritagem.cshtml"
AddHtmlAttributeValue("", 633, Url.Action("CadastrarPeritagem","Peritagem"), 633, 45, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5675, 24, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(5699, 47, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "415c48d32b9a4452ba1e0279eb7cdabd", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5746, 180, true);
            WriteLiteral("\r\n<script>\r\n    function pegarData() {\r\n        var data = new Date();\r\n\r\n        alert(data.getDate() + \"/\" + (data.getMonth() + 1) + \"/\"  + data.getFullYear());\r\n    }\r\n</script>");
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
