#pragma checksum "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Carcaca\InserirCarcaca.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83021127cc39f01fdec64e5ed1b4ec50d23c9a2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Carcaca_InserirCarcaca), @"mvc.1.0.view", @"/Views/Carcaca/InserirCarcaca.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Carcaca/InserirCarcaca.cshtml", typeof(AspNetCore.Views_Carcaca_InserirCarcaca))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83021127cc39f01fdec64e5ed1b4ec50d23c9a2c", @"/Views/Carcaca/InserirCarcaca.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54ceda69199656c87eab8db6137fa0dcd57d0a29", @"/Views/_ViewImports.cshtml")]
    public class Views_Carcaca_InserirCarcaca : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjetoPeritagem.ViewHelper.ViewHelperPeritagem>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_SubMenu", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "true", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "false", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ValidadorCampos.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Carcaca\InserirCarcaca.cshtml"
  
    ViewData["Title"] = "Carcaca";

#line default
#line hidden
            BeginContext(99, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(101, 27, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5849256c0b404d0497debb13f8038e14", async() => {
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
            BeginContext(128, 156, true);
            WriteLiteral("\r\n\r\n<h2 id=\"titulo-form\">Inserir Carca??a</h2>\r\n<div id=\"main\">\r\n    <div id=\"formulario\">\r\n        <button onclick=\"adcionarMedida()\">+</button>\r\n\r\n        ");
            EndContext();
            BeginContext(284, 5365, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94950b70ea534254bead170efd0a7d35", async() => {
                BeginContext(355, 3948, true);
                WriteLiteral(@"

            <div id=""medidas"">
                <div class=""form-row"" id=""medidas_carcaca"">
                    <div class=""form-group col-md-1"">
                        <label for=""posicao"">Posi????o</label>
                        <input type=""text"" class=""form-control"" id=""posicao"" name=""Posicao"" value="""" onkeypress=""ValidarNumerosInteiro()"" required />
                    </div>

                    <div class=""form-group col-md-3"">
                        <label for=""medicao"">Medi????o</label>
                        <input type=""text"" class=""form-control"" id=""medicao"" name=""Medicao"" value="""" required />
                    </div>

                    <div class=""form-group col-md-3"">
                        <label for=""tolerancia"">Toler??ncia</label>
                        <input type=""text"" class=""form-control"" id=""tolerancia"" name=""Tolerancia"" value="""" required />
                    </div>

                    <div class=""form-group col-md-5"">
                        <label for=""desc");
                WriteLiteral(@"ricaoMedida"">Descri????o da Medida</label>
                        <input type=""text"" class=""form-control"" id=""descricaoMedida"" name=""DescricaoMedida"" value="""" required />
                    </div>
                </div>
            </div>
            <div class=""form-row"">
                <div class=""form-group col-md-12"">
                    <label for=""nome"">Nome</label>
                    <input type=""text"" class=""form-control"" id=""nome"" name=""Nome"" value="""">
                </div>
            </div>

            <div class=""form-row"">
                <div class=""form-group col-md-4"">
                    <label for=""altura"">Altura</label>
                    <div class=""input-group flex-nowrap"">
                        <span class=""input-group-text"" id=""addon-wrapping"" style=""width:40px"">h</span>
                        <input type=""text"" class=""form-control"" id=""altura"" name=""Altura"" value="""" />
                        <span class=""input-group-text"" id=""addon-wrapping"" style=""width:50px");
                WriteLiteral(@""">mm</span>
                    </div>
                </div>

                <div class=""form-group col-md-4"">
                    <label for=""largura"">Largura</label>
                    <div class=""input-group flex-nowrap"">
                        <span class=""input-group-text"" id=""addon-wrapping"" style=""width:40px"">b</span>
                        <input type=""text"" class=""form-control"" id=""largura"" name=""Largura"" value="""" />
                        <span class=""input-group-text"" id=""addon-wrapping"" style=""width:50px"">mm</span>
                    </div>
                </div>
                <div class=""form-group col-md-4"">
                    <label for=""comprimento"">Comprimento</label>
                    <div class=""input-group flex-nowrap"">
                        <span class=""input-group-text"" id=""addon-wrapping"" style=""width:40px"">b</span>
                        <input type=""text"" class=""form-control"" id=""comprimento"" name=""Comprimento"" value="""" />
                        <span ");
                WriteLiteral(@"class=""input-group-text"" id=""addon-wrapping"" style=""width:50px"">mm</span>
                    </div>
                </div>
            </div>

            <div class=""form-row"">
                <div class=""form-group col-md-4"">
                    <label for=""peso"">Peso</label>
                    <div class=""input-group flex-nowrap"">
                        <input type=""text"" class=""form-control"" id=""peso"" name=""Peso"" value="""">
                        <span class=""input-group-text"" id=""addon-wrapping"" style=""width:40px"">Kg</span>
                    </div>
                </div>

                <div class=""form-group col-md-4"">
                    <div class=""form-group col-md-12"">
                        <label for=""condicao"">Condi????o</label>
                        <select type=""text"" class=""form-control"" id=""Condicao"" name=""ID_Disposicao"">
");
                EndContext();
#line 86 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Carcaca\InserirCarcaca.cshtml"
                              
                                foreach (var it in Model.listDisposicao)
                                {


#line default
#line hidden
                BeginContext(4446, 36, true);
                WriteLiteral("                                    ");
                EndContext();
                BeginContext(4482, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa3003c178c64163aa55b2a9f5617d8e", async() => {
                    BeginContext(4516, 1, true);
                    WriteLiteral(" ");
                    EndContext();
                    BeginContext(4518, 7, false);
#line 90 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Carcaca\InserirCarcaca.cshtml"
                                                                  Write(it.Nome);

#line default
#line hidden
                    EndContext();
                    BeginContext(4525, 1, true);
                    WriteLiteral(" ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 90 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Carcaca\InserirCarcaca.cshtml"
                                       WriteLiteral(it.ID_Disposicao);

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
                BeginContext(4535, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 91 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Carcaca\InserirCarcaca.cshtml"
                                }
                            

#line default
#line hidden
                BeginContext(4603, 395, true);
                WriteLiteral(@"
                        </select>
                    </div>
                </div>

                <div class=""form-group col-md-4"">
                    <div class=""form-group col-md-12"">
                        <label for=""jateamento"">Jateamento</label>
                        <select type=""text"" class=""form-control"" id=""jateamento"" name=""Jateamento"">
                            ");
                EndContext();
                BeginContext(4998, 33, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35dd2ed4621e4abeb195cd7292cd1303", async() => {
                    BeginContext(5019, 3, true);
                    WriteLiteral("Sim");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5031, 30, true);
                WriteLiteral("\r\n                            ");
                EndContext();
                BeginContext(5061, 34, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d5ac15bf53984a048f9523308e0c30e0", async() => {
                    BeginContext(5083, 3, true);
                    WriteLiteral("N??o");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5095, 423, true);
                WriteLiteral(@"
                        </select>
                    </div>
                </div>
            </div>

            <div class=""form-group"">
                <label for=""descricao"">descricao</label>
                <textarea class=""form-control"" id=""descricao"" name=""Descricao"" rows=""6""></textarea>
            </div>


            <input type=""hidden"" class=""form-control"" id=""id_peritagem"" name=""ID_Peritagem""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5518, "\"", 5545, 1);
#line 115 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Carcaca\InserirCarcaca.cshtml"
WriteAttributeValue("", 5526, Model.peritagem.Id, 5526, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5546, 96, true);
                WriteLiteral(">\r\n\r\n\r\n            <input type=\"submit\" class=\"btn btn-primary mb-2\" value=\"Enviar\" />\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 13 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Carcaca\InserirCarcaca.cshtml"
AddHtmlAttributeValue("", 298, Url.Action("CadastrarCarcaca","Carcaca"), 298, 41, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5649, 24, true);
            WriteLiteral("\r\n\r\n    </div>\r\n</div>\r\n");
            EndContext();
            BeginContext(5673, 48, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f891e9c842d4f10832e67284d1235bf", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5721, 290, true);
            WriteLiteral(@"
<script>
    function adcionarMedida() {

        var medida = document.getElementById(""medidas"");
        var medica_carcaca = document.getElementById(""medidas_carcaca"");
        var copia = medica_carcaca.cloneNode(true);

        medida.appendChild(copia);
    }
</script>

");
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
