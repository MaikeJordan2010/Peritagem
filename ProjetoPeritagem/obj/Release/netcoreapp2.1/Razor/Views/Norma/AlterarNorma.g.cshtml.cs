#pragma checksum "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\AlterarNorma.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d03b1366ebbb7bf338d7cfda333a2fb2616ad8c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Norma_AlterarNorma), @"mvc.1.0.view", @"/Views/Norma/AlterarNorma.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Norma/AlterarNorma.cshtml", typeof(AspNetCore.Views_Norma_AlterarNorma))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d03b1366ebbb7bf338d7cfda333a2fb2616ad8c1", @"/Views/Norma/AlterarNorma.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54ceda69199656c87eab8db6137fa0dcd57d0a29", @"/Views/_ViewImports.cshtml")]
    public class Views_Norma_AlterarNorma : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjetoPeritagem.ViewHelper.ViewHelperPeritagem>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\AlterarNorma.cshtml"
  
    ViewData["Title"] = "AlterarNorma";

#line default
#line hidden
            BeginContext(104, 97, true);
            WriteLiteral("\r\n\r\n<h2 id=\"titulo-form\">Alterar Norma</h2>\r\n<div id=\"main\">\r\n    <div id=\"formulario\">\r\n        ");
            EndContext();
            BeginContext(201, 863, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6191c381bbe74ef581634f99dfa0610e", async() => {
                BeginContext(269, 223, true);
                WriteLiteral("\r\n            <div class=\"form-row\">\r\n                <div class=\"form-group col-md-12\">\r\n                    <label for=\"none\">Nome</label>\r\n                    <input type=\"text\" class=\"form-control\" id=\"nome\" name=\"Nome\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 492, "\"", 517, 1);
#line 14 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\AlterarNorma.cshtml"
WriteAttributeValue("", 500, Model.norma.Nome, 500, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(518, 227, true);
                WriteLiteral(">\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label for=\"descricao\">Descri????o</label>\r\n                <textarea class=\"form-control-file\" id=\"descricao\" name=\"Descricao\">");
                EndContext();
                BeginContext(746, 21, false);
#line 19 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\AlterarNorma.cshtml"
                                                                               Write(Model.norma.Descricao);

#line default
#line hidden
                EndContext();
                BeginContext(767, 112, true);
                WriteLiteral("</textarea>\r\n            </div>\r\n            <input type=\"hidden\" class=\"form-control\" id=\"nome\" name=\"ID_Norma\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 879, "\"", 902, 1);
#line 21 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\AlterarNorma.cshtml"
WriteAttributeValue("", 887, Model.norma.Id, 887, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(903, 154, true);
                WriteLiteral(">\r\n            <div class=\"form-group\">\r\n                <input type=\"submit\" class=\"btn btn-primary mb-2\" value=\"Gravar\" />\r\n            </div>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 10 "C:\Users\mjordan\source\repos\ProjetoPeritagem\ProjetoPeritagem\Views\Norma\AlterarNorma.cshtml"
AddHtmlAttributeValue("", 215, Url.Action("GravarAlteracao","Norma"), 215, 38, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1064, 22, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
